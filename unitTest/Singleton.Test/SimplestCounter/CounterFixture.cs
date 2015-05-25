using System;
using MedikzWorks.PracticalPattern.Singleton.SimplestCounter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton.Test.SimplestCounter
{
    [TestClass]
    public class CounterFixture
    {
        [TestMethod]
        public void Test()
        {
            Counter.Instance.Reset();
            Assert.AreEqual<int>(1, Counter.Instance.Next);
            Assert.AreEqual<int>(2, Counter.Instance.Next);
            Assert.AreEqual<int>(3, Counter.Instance.Next);
        }
    }
}
