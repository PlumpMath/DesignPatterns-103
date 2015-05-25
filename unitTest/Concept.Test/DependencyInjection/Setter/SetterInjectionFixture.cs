using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Concept.DependencyInjection;

namespace Concept.Test.DependencyInjection.Setter
{
    [TestClass]
    public class SetterInjectionFixture
    {
        [TestMethod]
        public void Test()
        {
            var client = new Client() { TimeProvider = (new Assembler()).Create<ITimeProvider>() };
        }
    }
}
