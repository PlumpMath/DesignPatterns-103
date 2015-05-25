using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Command.Delegating;

namespace Command.Tests.Delegating
{
    [TestClass]
    public class CommandFixture
    {
        [TestMethod]
        public void TestMethod1()
        {
            Invoker invoker = new Invoker();
            invoker.AddHandler((new Receiver1()).A);
            invoker.AddHandler((new Receiver2()).B);
            invoker.AddHandler(Receiver3.C);
            invoker.Run();
        }
    }
}
