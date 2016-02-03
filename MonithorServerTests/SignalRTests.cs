using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonithorServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Host.HttpListener;


namespace MonithorServer.Tests
{
    [TestClass()]
    public class SignalRTests
    {
        [TestMethod()]
        public void SignalRTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void startTest()
        {
            SignalR s = new SignalR("127.0.0.1", 8080);
            Trace.WriteLine(s.url);
            
            Assert.AreEqual(true, s.start());
        }
    }
}