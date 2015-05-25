using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using C = MedikzWorks.PracticalPattern.Composite.Iterating;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Composite.Tests.Iterating
{
    /// <summary>
    /// CompositeFixture 的摘要说明
    /// </summary>
    [TestClass]
    public class CompositeFixture
    {
        #region non-linq version
        class LeafMatchRule:C.IMatchRule
        {
            public bool IsMatch(C.Component target)
            {
                if (target == null) return false;
                return target.GetType().IsAssignableFrom(typeof(C.Leaf));
            }
        }

        C.Component corporate;
        
        #endregion

        [TestInitialize]
        public void Initialize()
        {
            var factory = new C.ComponentFactory();
            corporate = factory.Create<C.Composite>("corporate");           // 1
            factory.Create<C.Leaf>(corporate, "president");                 // 2
            factory.Create<C.Leaf>(corporate, "vice president");            // 3
            var sales = factory.Create<C.Composite>(corporate, "sales");    // 4
            var market = factory.Create<C.Composite>(corporate, "market");  // 5
            factory.Create<C.Leaf>(sales, "joe");                           // 6
            factory.Create<C.Leaf>(sales, "bob");                           // 7
            factory.Create<C.Leaf>(market, "judi");                         // 8
            var branch = factory.Create<C.Composite>(corporate, "branch");  // 9
            factory.Create<C.Leaf>(branch, "manager");                      // 10
            factory.Create<C.Leaf>(branch, "peter");                        // 11
        }

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual<int>(7, corporate.Enumerate(new LeafMatchRule()).Count());
            Assert.AreEqual<int>(11, corporate.Enumerate().Count());

            Trace.WriteLine("List all leaves:\n------------------\n");
            foreach (var item in corporate.Enumerate(new LeafMatchRule()))
                Trace.WriteLine(item.Name);
        }
    }
}
