using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.FactoryMethod;

namespace FactoryMethod.Test
{
    [TestClass]
    public class GenericsFactoryFixture
    {
        [TestMethod]
        public void CreateProductByName()
        {
            var factory = new MedikzWorks.PracticalPattern.FactoryMethod.Generics.Factory();

            Assert.IsInstanceOfType(factory.Create(), typeof(ProductA));
            Assert.IsInstanceOfType(factory.Create("a"),typeof(ProductA));
            Assert.IsInstanceOfType(factory.Create("b"),typeof(ProductB));
        }

        [TestMethod]
        public void BatchCreateProductByName()
        {
            var batchSize = 5;
            var factory = new MedikzWorks.PracticalPattern.FactoryMethod.Generics.BatchFactory();

            var products = factory.Create(batchSize);
            Assert.AreEqual<int>(batchSize, products.Count());
            Assert.AreEqual<int>(batchSize, products.Count(x => x is ProductA));

            products = factory.Create("a",batchSize);
            Assert.AreEqual<int>(batchSize, products.Count());
            Assert.AreEqual<int>(batchSize, products.Count(x => x is ProductA));

            products = factory.Create("b", batchSize);
            Assert.AreEqual<int>(batchSize, products.Count());
            Assert.AreEqual<int>(batchSize, products.Count(x => x is ProductB));
        }
    }
}
