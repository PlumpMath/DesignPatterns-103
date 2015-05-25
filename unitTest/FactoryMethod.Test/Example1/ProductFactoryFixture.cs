using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.FactoryMethod.Example1;

namespace FactoryMethod.Test.Example1
{
    [TestClass]
    public class ProductFactoryFixture
    {
        /// <summary>
        /// 说明静态工厂可以根据提供参数选择需要实例化的类型
        /// </summary>
        [TestMethod]
        public void Test()
        {
            var product = ProductFactory.Create(Category.B);
            Assert.IsNotNull(product);
            Assert.IsInstanceOfType(product,typeof(ConcreteProductB));
        }
    }
}
