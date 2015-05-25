using System;
using System.Linq;
using MedikzWorks.PracticalPattern.Concept.FluentInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Concept.Test
{
    [TestClass]
    public class FluentInterfaceFixture
    {
        [TestMethod]
        public void TestFluentInterface()
        {
            IDataFacade facade = new CollectionDataFacade();
            var currentRows = facade.ExecuteQuery(null).Count();

            // 连续添加记录
            facade.AddNewCurrency("CNY", "人民币元")
                .AddNewCurrency("USD", "美元")
                .AddNewCurrency("JPY", "日元")
                .AddNewCurrency("HKD", "港元")
                .AddNewCurrency("FRF", "法郎")
                .AddNewCurrency("GBP", "英镑");
            Assert.AreEqual<int>(currentRows + 6, facade.ExecuteQuery(null).Count());

            //  连续添加记录
            facade
                .AddNewCurrency("DW1", "Known1")
                .AddNewCurrency("DW2", "Known2")
                .AddNewCurrency("DW3", "Known3")
                .AddNewCurrency("DW4", "Known4")
                .AddNewCurrency("DW5", "Known5");
            Assert.AreEqual<int>(5, facade.ExecuteQuery((x) => { return x.Code.StartsWith("DW"); }).Count());
        }
    }
}
