using System;
using System.Linq;
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

        private void SerialPortUserSettingsUC_Load(object sender, EventArgs e) {
            var ports = System.IO.Ports.SerialPort.GetPortNames();
            var selectedPort = string.IsNullOrEmpty(UserSettingsManager.UserSettings.Settings.SerialPort) ? ports.FirstOrDefault() : UserSettingsManager.UserSettings.Settings.SerialPort;
            comboBoxSerialPort.DataSource = ports;
            comboBoxSerialPort.SelectedIndex = comboBoxSerialPort.FindStringExact(selectedPort);
            txtbSerialPortBaudrate.Text = UserSettingsManager.UserSettings.Settings.Baudrate.ToString();
            txbRegex.Text = string.IsNullOrEmpty(UserSettingsManager.UserSettings.Settings.Regex) ? @"^(?<time>\d*)\|(?<level>\w*)\|(?<file>[^:]*):(?<line>\d*)\|(?<text>.*)$" : UserSettingsManager.UserSettings.Settings.Regex;
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

        private void spChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxSerialPort.SelectedItem.ToString())) {
                UserSettingsManager.UserSettings.Settings.SerialPort = comboBoxSerialPort.SelectedItem.ToString();
            }
           
        }
    }
}
