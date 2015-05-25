using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.AbstractFactory.ASync;

namespace AbstractFactory.Tests.Async
{
    [TestClass]
    public class FactoryFixture
    {
        class ConcreteProduct : IProduct { }

        class ConcreteFactory:IFactoryWithNotifier
        {
            /// <summary>
            /// 同步构造过程
            /// </summary>
            /// <returns></returns>
            public IProduct Create()
            {
                return new ConcreteProduct();
            }

            /// <summary>
            /// 异步构造过程
            /// </summary>
            /// <param name="callback"></param>
            public void Create(Action<IProduct> callback)
            {
                callback(Create());
            }
        }

        class Subscribe
        {
            public IProduct Product { get; set; }
        }

        [TestMethod]
        public void Test()
        {
            IFactoryWithNotifier factory = new ConcreteFactory();
            Subscribe subscriber = new Subscribe();
            Assert.IsNull(subscriber.Product);
            factory.Create(x => { subscriber.Product = x; });
            Assert.IsNotNull(subscriber.Product);
            Assert.IsTrue(subscriber.Product is ConcreteProduct);
        }
    }
}
