using System;
using System.Windows.Forms;
using Analogy.LogViewer.SerialPort.Managers;

namespace Analogy.LogViewer.SerialPort
{
    public partial class SerialPortUserSettingsUC : UserControl
    {
        public SerialPortUserSettingsUC()
        {
            InitializeComponent();
        }

        private void SerialPortUserSettingsUC_Load(object sender, EventArgs e)
        {
            txtbSerialPort.Text = UserSettingsManager.UserSettings.Settings.SerialPort;
            txtbSerialPortBaudrate.Text = UserSettingsManager.UserSettings.Settings.Baudrate.ToString();
            txbRegex.Text = UserSettingsManager.UserSettings.Settings.Regex;
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

        private void txtbRegex(object sender, EventArgs e)
        {
            UserSettingsManager.UserSettings.Settings.Regex = txbRegex.Text;

        }
    }
}
