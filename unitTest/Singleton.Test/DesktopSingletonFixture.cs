using System;
using System.Linq;
using MedikzWorks.PracticalPattern.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Singleton.Test
{
    [TestClass]
    public class DesktopSingletonFixture
    {
        public class ThreadScopedSingleton
        {
            ThreadScopedSingleton() { }
            [ThreadStatic] // 说明每个Instance仅在当前线程内为静态
            static ThreadScopedSingleton instance;

            public static ThreadScopedSingleton Instance
            {
                get
                {
                    if (instance == null)
                        instance = new ThreadScopedSingleton();
                    return instance;
                }
            }
        }

        static IList<ThreadScopedSingleton> registry;
        const int TestTimes = 10;

        [TestMethod]
        public void Test()
        {
            registry = new List<ThreadScopedSingleton>();
            TestHarness.Parallel(
                ThreadBody,
                ThreadBody,
                ThreadBody);
            Assert.AreEqual<int>(3, registry.Distinct().Count());
        }

        private void ThreadBody()
        {
            ThreadScopedSingleton instance = ThreadScopedSingleton.Instance;
            for (int i = 0; i < TestTimes; i++)
                Assert.IsTrue(instance == ThreadScopedSingleton.Instance);
            registry.Add(instance);
        }
    }
}
