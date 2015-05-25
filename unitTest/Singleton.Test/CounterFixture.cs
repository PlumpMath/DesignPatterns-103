using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Singleton.SimplestCounter;
using MedikzWorks.PracticalPattern.Common;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Singleton.Test
{
    [TestClass]
    public class CounterFixture
    {
        const int TestTimes = 10;

        [TestMethod]
        public void SequentialExecuteCounter()
        {
            var c1 = Counter.Instance;
            var c2 = Counter.Instance;
            Assert.IsTrue(c1 == c2);
            Assert.AreEqual<int>(c1.GetHashCode(), c2.GetHashCode());

            var counter = Counter.Instance;
            for (var i = 0; i < TestTimes; i++)
                Assert.AreEqual<int>(i + 1, counter.Next);
            counter.Reset();
            for (var i = 0; i < TestTimes; i++)
                Assert.AreEqual<int>(i + 1, counter.Next);
        }

        static IList<Counter> counters;

        [TestMethod]
        public void ParallelExecuteCounter()
        {
            counters = new List<Counter>();
            TestHarness.Parallel(
                ThreadBody,
                ThreadBody,
                ThreadBody);
            Assert.AreEqual<int>(30, counters.Count());
            // 只有唯一实例
            Assert.AreEqual<int>(1, counters.Distinct().Count());
            // 唯一实例执行正常
            Assert.AreEqual<int>(1, Counter.Instance.Next);
        }

        private void ThreadBody()
        {
            for(int i =0;i < TestTimes;i++)
            {
                Thread.Sleep(new Random().Next() % 53);
                AddCounter();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void AddCounter()
        {
            counters.Add(Counter.Instance);
        }
    }
}
