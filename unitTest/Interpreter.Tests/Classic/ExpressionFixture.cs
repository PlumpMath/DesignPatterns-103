using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Interpreter.Classic;

namespace Interpreter.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual<int>(1 + 3 - 2, new Calculator().Calculate("1+3-2"));
            Assert.AreEqual<int>(1 - 1 - 2 + 7, new Calculator().Calculate("1-1-2+7"));
        }
    }
}
