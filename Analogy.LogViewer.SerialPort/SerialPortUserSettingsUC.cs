using Analogy.LogViewer.gRPC.Managers;
using System;
using System.Windows.Forms;

namespace Analogy.LogViewer.gRPC
{
    public partial class SerialPortUserSettingsUC : UserControl
    {
        public SerialPortUserSettingsUC()
        {
            InitializeComponent();
        }

        private void grpcUserSettingsUC_Load(object sender, EventArgs e)
        {
            txtbSerialPort.Text = UserSettingsManager.UserSettings.Settings.SerialPort;
            txtbSerialPortBaudrate.Text = UserSettingsManager.UserSettings.Settings.Baudrate.ToString();
        }

        private void txtbRealTimeServerURL_TextChanged(object sender, EventArgs e)
        {
            UserSettingsManager.UserSettings.Settings.SerialPort = txtbSerialPort.Text;

        }

        private void txtbSelfHostingServerURL_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtbSerialPortBaudrate.Text, out var baudrate))
            {
                UserSettingsManager.UserSettings.Settings.Baudrate = baudrate;
            }

        }
    }
}
