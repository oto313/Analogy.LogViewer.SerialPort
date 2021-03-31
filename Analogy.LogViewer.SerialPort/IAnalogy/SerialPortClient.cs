using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.LogViewer.SerialPort.Managers;
using Analogy.LogViewer.Template;

namespace Analogy.LogViewer.SerialPort.IAnalogy
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

                        var matches = Regex.Matches(line, UserSettingsManager.UserSettings.Settings.Regex,
                                                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture);
                        if (matches.Count != 1) {
                            continue;
                        }
                        
                        
                        var match = matches[0];
                        if (!match.Groups["level"].Success || !match.Groups["text"].Success) {
                            continue;
                        }
                        var levelString = match.Groups["level"].Value;
                        var level = levelString switch {
                            "ANA" => AnalogyLogLevel.Analogy,
                            "CRT" => AnalogyLogLevel.Critical,
                            "ERR" => AnalogyLogLevel.Error,
                            "WRN" => AnalogyLogLevel.Warning,
                            "INF" => AnalogyLogLevel.Information,
                            "DBG" => AnalogyLogLevel.Debug,
                            "TRC" => AnalogyLogLevel.Trace,
                            "A" => AnalogyLogLevel.Analogy,
                            "C" => AnalogyLogLevel.Critical,
                            "E" => AnalogyLogLevel.Error,
                            "W" => AnalogyLogLevel.Warning,
                            "I" => AnalogyLogLevel.Information,
                            "D" => AnalogyLogLevel.Debug,
                            "T" => AnalogyLogLevel.Trace,
                            _ => AnalogyLogLevel.Unknown
                        };

                        var date = DateTime.Now.ToLocalTime();
                        if (match.Groups["date"].Success && DateTime.TryParse(match.Groups["date"].Value, out var d)) {
                            date = d;
                        }
                        MessageReady(
                            this,
                            new AnalogyLogMessageArgs(
                                new AnalogyLogMessage() {
                                    Level = level,
                                    Class = AnalogyLogClass.General,
                                    Date = date,
                                    FileName = match.Groups["file"].Success ? match.Groups["file"].Value : "",
                                    LineNumber = match.Groups["line"].Success ? Convert.ToInt32(match.Groups["line"].Value) : 0,
                                    MethodName = match.Groups["method"].Success ? match.Groups["method"].Value : "",
                                    Source = match.Groups["file"].Success ? match.Groups["file"].Value : "",
                                    Category = match.Groups["category"].Success ? match.Groups["category"].Value : "",
                                    MachineName = match.Groups["machine_name"].Success ? match.Groups["machine_name"].Value : "",
                                    Module = match.Groups["module"].Success ? match.Groups["module"].Value : "",
                                    Text = match.Groups["text"].Value,
                                    ThreadId = match.Groups["thread_id"].Success ? Convert.ToInt32(match.Groups["thread_id"].Value) : 0,
                                    AdditionalInformation = new Dictionary<string,string> {["port"] = _sp.PortName },
                                    RawText = line,
                                    RawTextType = AnalogyRowTextType.PlainText,
                                    ProcessId = match.Groups["process_id"].Success ? Convert.ToInt32(match.Groups["process_id"].Value) : 0,
                                    User = match.Groups["user"].Success ? match.Groups["user"].Value : "",
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
            _sp?.Dispose();
            return Task.CompletedTask;
        }
    }
}
