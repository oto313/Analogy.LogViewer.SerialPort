namespace Analogy.LogViewer.SerialPort
{
    public class SerialPortSettings
    {
        public string SerialPort { get; set; }
        public int Baudrate { get; set; } = 115200;

        public string Regex { get; set; } = @"^(?<time>\d*)\|(?<level>\w*)\|(?<file>[^:]*):(?<line>\d*)\|(?<text>.*)$";

        public SerialPortSettings()
        {
        }
    }
}
