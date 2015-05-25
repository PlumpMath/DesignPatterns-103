using System;
using E = MedikzWorks.PracticalPattern.FactoryMethod.Example1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethod.Test.Example1
{
    [TestClass]
    public class FactoryFixture
    {
        /// <summary>
        /// 说明可以按照要求生成抽象类型，但具体实例化哪个类型由工厂决定
        /// </summary>
        [TestMethod]
        public void Test()
        {
            Assert.IsInstanceOfType(new E.Factory().Create(),typeof(E.ConcreteProductA));
        }
    }
}
