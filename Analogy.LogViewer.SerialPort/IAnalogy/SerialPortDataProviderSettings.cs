using Analogy.LogViewer.gRPC.Managers;
using Analogy.LogViewer.Template;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.gRPC.IAnalogy
{
    public class SerialPortDataProviderSettings : UserSettingsFactory
    {
        public override string Title { get; set; } = "Serial port settings";
        public override UserControl DataProviderSettings { get; set; } = new SerialPortUserSettingsUC();

        public override Guid FactoryId { get; set; } = SerialPortFactory.Id;
        public override Guid Id { get; set; } = new Guid("9b549847-861d-427b-9232-979547ce91a3");

        public override Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }
    }
}
