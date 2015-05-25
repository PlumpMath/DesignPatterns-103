using System;
using MedikzWorks.PracticalPattern.Concept.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Concept.Test.DependencyInjection.Interfacer
{
    /// <summary>
    /// 定义需要注入ITimeProvider的类型
    /// </summary>
    interface IObjectWithTimeProvider
    {
        ITimeProvider TimeProvider { get; set; }
    }

    [TestClass]
    public class InterfacerInjectionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    /// <summary>
    /// 通过接口方式注入
    /// </summary>
    class Client:IObjectWithTimeProvider
    {
        public ITimeProvider TimeProvider
        {
            get;
            set;
        }
    }

    [TestClass]
    public class TestClient
    {
        [TestMethod]
        public void Test()
        {
            ITimeProvider timeProvider = (new Assembler()).Create<ITimeProvider>();
            Assert.IsNotNull(timeProvider);
            IObjectWithTimeProvider objectWithTimeProvider = new Client();
            objectWithTimeProvider.TimeProvider = timeProvider; // 通过接口方式注入
        }
    }
}
