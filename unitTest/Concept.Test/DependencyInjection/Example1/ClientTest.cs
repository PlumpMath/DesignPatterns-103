using MedikzWorks.PracticalPattern.Concept.DependencyInjection.Example1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Concept.Test.DependencyInjection.Example1
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void Test()
        {
            Client client = new Client();
            Trace.WriteLine(client.GetYear());
        }
    }
}
