using MedikzWorks.PracticalPattern.Concept.Delegating;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Concept.Tests
{
    [TestClass]
    public class DelegatingFixture
    {
        [TestMethod]
        public void SimpleAsyncInvoke()
        {
            new AsyncInvoker();
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void AysncInvokeList()
        {
            var list = new InvokeList();
            list.Invoke();
            Assert.AreEqual<string>("hello,world", list[0] + list[1] + list[2]);
        } 

        [TestMethod]
        public void MulticastDelegateInvoke()
        {
            var invoker = new MulticastDelegateInvoker();
            Assert.AreEqual<string>("hello,world", invoker[0] + invoker[1] + invoker[2]);
        }

        [TestMethod]
        public void EventMonitorSimulate()
        {
            var order1 = new Order();
            order1.Create();
            order1.ChangeDate();
            order1.ChangeDate();
            order1.ChangeOwner();

            var order2 = new Order();
            order2.Create();
            order2.ChangeOwner();
            order2.ChangeId();
            Assert.AreEqual<int>(2, EventMonitor.AddedTimes);
            Assert.AreEqual<int>(4, EventMonitor.ModifiedTimes);

        }
    }

    [TestClass]
    public class LamadaTimerFixture
    {
        class AsyncInvoker
        {
            /// <summary>
            /// Lamada方式定义Timer所需的回调委托过程
            /// </summary>
            /// <remarks>
            /// 这里(x) => Trace.WriteLine(x as string)就是用Lamada语法定义的委托回调内容
            /// </remarks>
            public AsyncInvoker()
            {
                Trace.WriteLine("method");
                new Timer((x) => Trace.WriteLine(x), "slow", 2500, 2500);
                new Timer((x) => Trace.WriteLine(x), "fast", 2000, 2000);
            }
        }

        [TestMethod]
        public void SimpleAysncInvoke()
        {
            new AsyncInvoker();
            Thread.Sleep(3000);
        }
    }
}
