using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Command.NetClassic;
using System.Diagnostics;

namespace Command.Tests.NetClassic
{
    [TestClass]
    public class CommandFixture
    {
        [TestMethod]
        public void Test()
        {
            var database = new Database()
                {
                    OpenConnection = () => { Trace.WriteLine("Open db"); },
                    ExecuteCommand = () => { return false; },
                    CloseConnection = () => { Trace.WriteLine("db closed"); }
                };
            database.Process();
        }
    }
}
