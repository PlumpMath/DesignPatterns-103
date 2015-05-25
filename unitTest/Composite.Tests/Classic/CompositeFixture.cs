using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using C = MedikzWorks.PracticalPattern.Composite.Classic;

namespace Composite.Tests.Classic
{
    [TestClass]
    public class CompositeFixture
    {
        C.Component corporate;

        /// <summary>
        /// 建立测试公司的组织结构
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            var factory = new C.ComponentFactory();
            corporate = factory.Create<C.Composite>("corporate");
            factory.Create<C.Leaf>(corporate, "president");
            factory.Create<C.Leaf>(corporate, "vice president");
            var sales = factory.Create<C.Composite>(corporate, "sales");
            var market = factory.Create<C.Composite>(corporate, "market");
            factory.Create<C.Leaf>(sales, "joe");
            factory.Create<C.Leaf>(sales, "bob");
            factory.Create<C.Leaf>(market, "judi");
            var branch = factory.Create<C.Composite>(corporate, "branch");
            factory.Create<C.Leaf>(branch, "manager");
            factory.Create<C.Leaf>(branch, "peter");
        }

        [TestMethod]
        public void Test()
        {
            Assert.AreEqual<int>(11, corporate.GetNameList().Count());

            Trace.WriteLine("List all components:\n---------------------\n");
            corporate.GetNameList().ToList().ForEach(x => Trace.WriteLine(x));
        }
    }
}
