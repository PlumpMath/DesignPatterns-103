using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Collections.Specialized;

namespace FactoryMethod.Test.Classic
{
    [TestClass]
    public class ConfigurationFactoryFixture
    {
        const string SectionName = "factoryMethod.customFactories";
        const string Name = "FactoryMethod.Test.Classic.IFactory, FactoryMethod.Test";
        
        [TestMethod]
        public void Test()
        {
            string typeName = ((NameValueCollection)ConfigurationManager.GetSection(SectionName))[Name];
            Assert.IsTrue(typeof(IFactory).IsAssignableFrom(Type.GetType(typeName)));
        }
    }
}
