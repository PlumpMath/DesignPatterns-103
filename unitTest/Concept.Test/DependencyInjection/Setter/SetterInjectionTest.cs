using MedikzWorks.PracticalPattern.Concept.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Concept.Test.DependencyInjection.Setter
{
    /// <summary>
    /// 通过setter实现注入
    /// </summary>
    class Client
    {
        public ITimeProvider TimeProvider
        {
            get;
            set;
        }
    }

    [TestClass]
    class TestClient
    {
        [TestMethod]
        public void Test()
        {
            ITimeProvider timeProvider = (new Assembler()).Create<ITimeProvider>();
            Assert.IsNotNull(timeProvider);     // 确认可以正常获得抽象类型实例
            Client client = new Client();
            client.TimeProvider = timeProvider; // 通过Setter实现注入
        }
    }
}
