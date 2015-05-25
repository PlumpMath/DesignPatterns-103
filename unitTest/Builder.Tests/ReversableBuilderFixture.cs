using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Builder.Reversable;

namespace Builder.Tests
{
    [TestClass]
    public class ReversableBuilderFixture
    {
        [TestMethod]
        public void Test()
        {
            IBuilder<Product> builder = new ProductBuilder();
            var product1 = builder.BuildUp();
            Assert.AreEqual<int>(5, product1.Count);
            Assert.AreEqual<int>(5, product1.Items.Count);
            var product2 = builder.TearDown();
            Assert.AreEqual<int>(0, product2.Count);
            Assert.AreEqual<int>(0, product2.Items.Count);
            Assert.IsTrue(product1 == product2);
        }
    }
}
