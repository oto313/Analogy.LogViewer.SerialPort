using System;
using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.LogViewer.Template;

namespace Analogy.LogViewer.SerialPort.IAnalogy
{
    public class SerialPortDataProvider : DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = SerialPortFactory.Id;
        public override string Title { get; set; } = "Serial port Receiver";

        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = new List<IAnalogyDataProvider> { new SerialPortClient() };
    }
}
