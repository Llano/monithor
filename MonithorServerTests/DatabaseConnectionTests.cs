using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonithorServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonithorServer.Tests
{
    [TestClass()]
    public class DatabaseConnectionTests
    {
        [TestMethod()]
        public void DatabaseConnectionTest()
        {
            
            
        }

        [TestMethod()]
        public void databaseAvaiableTest()
        {
            DatabaseConnection con = new DatabaseConnection("monithor", "password", "127.0.0.1", "monithor");
            Assert.AreEqual(true, con.databaseAvaiable());
        }

        [TestMethod()]
        public void getArmaServersTest()
        {
            Assert.Fail();
        }
    }
}