using System;
using System.Collections.Generic;
using Analogy.Interfaces;
using Analogy.LogViewer.Template;

namespace Analogy.LogViewer.SerialPort.IAnalogy
{
    public class SerialPortFactory : PrimaryFactory
    {
        internal static readonly Guid Id = new Guid("1296d9a6-18d3-4554-95b2-7f6fe629aa4c");

        public override Guid FactoryId { get; set; } = Id;

        public override string Title { get; set; } = "Serial port receiver";

        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = new List<AnalogyChangeLog>
        {
        };
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Oto Dusek" };
        public override string About { get; set; } = "";

    }
}
