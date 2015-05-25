using System;
using MedikzWorks.PracticalPattern.Memento.StackMode;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Memento.Tests.StackMode
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
            originator.SaveCheckpoint();

            originator.UpdateX(2);
            originator.SaveCheckpoint();

            originator.UpdateX(3);
            originator.IncreaseY();

            Assert.AreEqual<int>(3, originator.Current.X);
            Assert.AreEqual<int>(2, originator.Current.Y);

            originator.Undo();
            Assert.AreEqual<int>(2, originator.Current.X);
            Assert.AreEqual<int>(1, originator.Current.Y);

            originator.Undo();
            Assert.AreEqual<int>(-1, originator.Current.X);
            Assert.AreEqual<int>(1, originator.Current.Y);
        }
    }
}
