using System;
using MedikzWorks.PracticalPattern.Flyweight;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Flyweight.Classic;

namespace Flyweight.Tests
{
    [TestClass]
    public class FlyweightFixture
    {
        [TestMethod]
        public void TestGetPoker()
        {
            var factory = new PokerFactory();
            var p1 = factory.Create(10,SuitOptions.Heart);
            var p2 = factory.Create(10, SuitOptions.Heart);
            var p3 = factory.Create(10, SuitOptions.Spade);
            var p4 = factory.Create(11, SuitOptions.Heart);

            Assert.AreEqual<Poker>(p1, p2); // 都是红桃10
            Assert.AreNotEqual<Poker>(p1, p3);
            Assert.AreNotEqual<Poker>(p1, p4);

            Assert.AreEqual<Rank>(p1.Rank, p3.Rank); // 都是10点
            Assert.AreEqual<Suit>(p1.Suit, p4.Suit); // 都是红桃
        }
    }
}
