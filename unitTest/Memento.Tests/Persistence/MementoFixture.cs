using System;
using MedikzWorks.PracticalPattern.Memento.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Memento.Tests.Persistence
{
    [TestClass]
    public class MementoFixture
    {
        [TestMethod]
        public void Main()
        {
            var o1 = new Originator();
            o1.IncreaseY();
            o1.SaveCheckpoint(1);
            o1.IncreaseY();
            o1.SaveCheckpoint(2);
            var o2 = new Originator();
            o2.UpdateX(3);
            o2.SaveCheckpoint(2);

            o1.Undo(1);
            Assert.AreEqual<int>(0, o1.Current.X);
            Assert.AreEqual<int>(1, o1.Current.Y);
            o2.Undo(2);
            Assert.AreEqual<int>(3, o2.Current.X);
            Assert.AreEqual<int>(0, o2.Current.Y);
        }
    }
}
