using Newtonsoft.Json;
using System;
using System.IO;

namespace Analogy.LogViewer.gRPC.Managers
{
    public class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        public string gRPCFileSetting { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Analogy.LogViewer", "AnalogyGRPCSettings.json");
        public SerialPortSettings Settings { get; set; }


        public UserSettingsManager()
        {
            if (File.Exists(gRPCFileSetting))
            {
                try
                {
                    var settings = new JsonSerializerSettings
                    {
                        ObjectCreationHandling = ObjectCreationHandling.Replace
                    };
                    string data = File.ReadAllText(gRPCFileSetting);
                    Settings = JsonConvert.DeserializeObject<SerialPortSettings>(data, settings);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogException("Error loading user setting file", ex, "Analogy gRPC Parser");
                    Settings = new SerialPortSettings();

                }
            }
            else
            {
                Settings = new SerialPortSettings();
            }

        }
        public void Save()
        {
            try
            {
                File.WriteAllText(gRPCFileSetting, JsonConvert.SerializeObject(Settings));
            }
            catch (Exception ex)
            {
                LogManager.Instance.LogCritical("", $"Unable to save file {gRPCFileSetting}: {ex}");

            }
        }
    }

}
