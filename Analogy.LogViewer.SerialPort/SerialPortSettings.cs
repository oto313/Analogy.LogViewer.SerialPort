namespace Analogy.LogViewer.gRPC
{
    public class SerialPortSettings
    {
        public string SerialPort { get; set; }
        public int Baudrate { get; set; }

        public SerialPortSettings()
        {
            Baudrate = 115200;
        }
    }
}
