using System;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.LogServer.Clients;
using Analogy.LogViewer.gRPC.IAnalogy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analogy.LogViewer.gRPC.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SerialPortFactory gf = new SerialPortFactory();
            Assert.IsTrue(gf.FactoryId != Guid.Empty);
        }
    }
}