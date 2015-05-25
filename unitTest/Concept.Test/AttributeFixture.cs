using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Concept.Attributing;

namespace Concept.Tests
{
    [TestClass]
    public class AttributeFixture
    {
        [Director(3,"BuildPartA")]
        [Director(2, "BuildPartB")]
        [Director(1, "BuildPartC")]
        class AttributeBuilder:IAttributedBuilder
        {
            IList<string> log = new List<string>();
            public IList<string> Log { get { return log; } }
            
            public void BuildPartA()
            {
                log.Add("a");
            }

            public void BuildPartB()
            {
                log.Add("b");
            }

            public void BuildPartC()
            {
                log.Add("c");
            }
        }

        [TestMethod]
        public void BuildAccordingToAttribute()
        {
            IAttributedBuilder builder = new AttributeBuilder();
            new Director().BuildUp(builder);
            Assert.AreEqual<string>("a", builder.Log[0]);
            Assert.AreEqual<string>("b", builder.Log[1]);
            Assert.AreEqual<string>("c", builder.Log[2]);
        }
    }
}
