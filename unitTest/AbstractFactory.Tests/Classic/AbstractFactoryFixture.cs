using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.AbstractFactory.Classic;
using MedikzWorks.PracticalPattern.AbstractFactory;

namespace AbstractFactory.Tests.Classic
{
    [TestClass]
    public class AbstractFactoryFixture
    {
        [TestMethod]
        public void Test()
        {
            var factory = new ConcreteFactory2();
            var productA = factory.CreateProductA();
            var productB = factory.CreateProductB();
            Assert.IsTrue(productA is ProductA2Y);
            Assert.IsTrue(productB is ProductB2);
        }
    }
}
