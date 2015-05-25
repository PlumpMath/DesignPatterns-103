using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Adapter.Grouping;

namespace Adapter.Tests
{
    [TestClass]
    public class TestAdapter
    {
        [TestMethod]
        public void Test()
        {
            var factory = new MedikzWorks.PracticalPattern.FactoryMethod.Factory()
                .RegisterType<IDatabaseAdapter, OracleAdapter>("ora")
                .RegisterType<IDatabaseAdapter, SqlServerAdapter>("sql");

            var oracleAdapter = factory.Create<IDatabaseAdapter>("ora");
            var sqlAdapter = factory.Create<IDatabaseAdapter>("sql");

            Assert.AreEqual<string>("oracle", oracleAdapter.ProviderName);
            Assert.AreEqual<string>("SQL Server", sqlAdapter.ProviderName);
        }
    }
}
