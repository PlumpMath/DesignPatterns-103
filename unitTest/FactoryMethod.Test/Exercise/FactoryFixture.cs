using System;
using F = MedikzWorks.PracticalPattern.FactoryMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryMethod.Test.Exercise
{
    [TestClass]
    public class FactoryFixture
    {
        interface IFactory:F.IFactory
        {
            TTarget Create<TTarget>(object[] parameters);
            TTarget Create<TTarget>(string name, object[] parameters);
        }

        class Factory:F.Factory,IFactory
        {
            public TTarget Create<TTarget>(object[] parameters)
            {
                return (TTarget)Activator.CreateInstance(register[typeof(TTarget)], parameters);
            }

            public TTarget Create<TTarget>(string name, object[] parameters)
            {
                return (TTarget)Activator.CreateInstance(register[typeof(TTarget), name], parameters);
            }
        }

        [TestMethod]
        public void CreateInstance()
        {
            var factory = new Factory()
                .RegisterType<IFruit, Apple>()
                .RegisterType<IFruit, Orange>("o")
                .RegisterType<IVehicle, Bicycle>()
                .RegisterType<IVehicle, Bicycle>("a")
                .RegisterType<IVehicle, Train>("b")
                .RegisterType<IVehicle, Car>("c")
                .RegisterType<IEntry, EntryWithName>()
                .RegisterType<IEntry, EntryWithNameAndTitle>("nat");
            
            #region 构造函数无参数的类型

            Assert.IsInstanceOfType(factory.Create<IFruit>(), typeof(Apple));
            Assert.IsInstanceOfType(factory.Create<IFruit>("o"), typeof(Orange));

            Assert.IsInstanceOfType(factory.Create<IVehicle>(), typeof(Bicycle));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("a"),typeof(Bicycle));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("b"), typeof(Train));
            Assert.IsInstanceOfType(factory.Create<IVehicle>("c"), typeof(Car));

            #endregion

            #region 构造函数带参数的类型

            var f = (IFactory)factory;
            var e1 = f.Create<IEntry>(new object[] { "joe" });
            Assert.IsInstanceOfType(e1, typeof(EntryWithName));
            Assert.AreEqual<string>("joe", ((EntryWithName)e1).Name);

            var e2 = f.Create<IEntry>("nat", new object[] { "joe",20 });
            Assert.IsInstanceOfType(e2, typeof(EntryWithNameAndTitle));
            Assert.AreEqual<int>(20,((EntryWithNameAndTitle)e2).Age);
            Assert.AreEqual<string>(EntryWithNameAndTitle.DefaultTitle, ((EntryWithNameAndTitle)e2).Title);
            #endregion
        }
    }
}
