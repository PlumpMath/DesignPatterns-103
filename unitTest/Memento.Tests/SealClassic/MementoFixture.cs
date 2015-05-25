using System;
using MedikzWorks.PracticalPattern.Memento.SealClassic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Memento.Tests.SealClassic
{
    [TestClass]
    public class MementoFixture
    {
        [TestMethod]
        public void Test()
        {
            var originator = new Originator();
            originator.SaveCheckpoint();

            originator.IncreaseY();
            originator.DecreaseX();
            Assert.AreEqual<int>(-1, originator.Current.X);
            Assert.AreEqual<int>(1, originator.Current.Y);

            originator.Undo();
            Assert.AreEqual<int>(0, originator.Current.Y);
            Assert.AreEqual<int>(0, originator.Current.X);
        }
    }
}
