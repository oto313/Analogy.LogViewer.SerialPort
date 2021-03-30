using Analogy.Interfaces;
using Analogy.LogViewer.gRPC.Managers;
using Analogy.LogViewer.Template;
using System;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.gRPC.IAnalogy
{
    public class SerialPortClient : OnlineDataProvider
    {
        public override string OptionalTitle { get; set; } = "Connect to Serial port";
        public override Guid Id { get; set; } = new Guid("1f1be880-3b1b-499d-91aa-71509707a8d5");
        private Task hostingTask;
        private static CancellationTokenSource cts;
        private System.IO.Ports.SerialPort? _sp;
        public override Task InitializeDataProviderAsync(IAnalogyLogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            return base.InitializeDataProviderAsync(logger);

        }

        public override Task<bool> CanStartReceiving() {
            var sp = new System.IO.Ports.SerialPort(UserSettingsManager.UserSettings.Settings.SerialPort, UserSettingsManager.UserSettings.Settings.Baudrate) { DtrEnable = true };
            try {
                sp.Open();
                return Task.FromResult(true);
            } 
            catch (Exception) {
                return Task.FromResult(false);
            }

        }


        public override Task StartReceiving() {
            _sp = new System.IO.Ports.SerialPort(UserSettingsManager.UserSettings.Settings.SerialPort, UserSettingsManager.UserSettings.Settings.Baudrate) {DtrEnable = true};
            cts = new CancellationTokenSource();
            hostingTask = Task.Factory.StartNew(() =>
            {
                var token = cts.Token;
                while (!token.IsCancellationRequested) {
                    try {
                        if (!_sp.IsOpen) {
                            _sp.Open();
                        }

                        var line = _sp.ReadLine().Trim();
                        if (token.IsCancellationRequested) {
                            return;
                        }

                        var matches = Regex.Matches(line, @"^(?<time>\d*)\|(?<level>\w*)\|(?<file>[^:]*):(?<line>\d*)\|(?<text>.*)$");
                        if (matches.Count != 1) {
                            continue;
                        }

                        
                        var match = matches[0];
                        var levelString = match.Groups["level"].Value;
                        AnalogyLogLevel level = levelString switch {
                            "INF" => AnalogyLogLevel.Information,
                            "DBG" => AnalogyLogLevel.Debug,
                            "TRC" => AnalogyLogLevel.Trace,
                            "ERR" => AnalogyLogLevel.Error,
                            "WRN" => AnalogyLogLevel.Warning,
                            _ => AnalogyLogLevel.Unknown
                        };

                        MessageReady(
                            this,
                            new AnalogyLogMessageArgs(
                                new AnalogyLogMessage() {
                                    Category = "",
                                    Level = level,
                                    Class = AnalogyLogClass.General,
                                    Date = DateTime.Now.ToLocalTime(),
                                    FileName = match.Groups["file"].Value,
                                    LineNumber = Convert.ToInt32(match.Groups["line"].Value),
                                    MachineName = "",
                                    MethodName = "",
                                    //Module = m.Module,
                                    Source = "Serial port",
                                    Text = match.Groups["text"].Value,
                                    //User = m.User
                                },
                                Environment.MachineName,
                                OptionalTitle,
                                Id));

                    } catch (Exception e) {
                        LogManager.Instance.LogError("Error: " + e.Message, nameof(SerialPortClient));
                    }
                }
            }, TaskCreationOptions.LongRunning);
            return Task.CompletedTask;
        }
        
        public override Task StopReceiving()
        {
            cts?.Cancel();
            Disconnected(this, new AnalogyDataSourceDisconnectedArgs("user disconnected", Environment.MachineName, Id));
            cts = new CancellationTokenSource();
            _sp?.Close();
            return Task.CompletedTask;
        }
    }
}
