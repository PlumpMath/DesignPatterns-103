using System;
using MedikzWorks.PracticalPattern.Prototype.Classic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prototype.Tests
{
    [TestClass]
    public class PrototypeFixture
    {
        IPrototype sample;

        [TestInitialize]
        public void Initialize()
        {
            sample = new ConcretePrototype();
        }

        [TestMethod]
        public void Test()
        {
            var image = sample.Clone();
            Assert.IsNull(sample.Name);
            Assert.IsNull(image.Name);

            sample.Name = "A";
            image = sample.Clone();
            Assert.AreEqual<string>("A", image.Name);
            Assert.IsInstanceOfType(image, typeof(ConcretePrototype));
            image.Name = "B";
            Assert.IsTrue(sample.Name != image.Name);
        }

        [TestMethod]
        public void TestReferenceType()
        {
            var image = sample.Clone();
            Assert.AreEqual<int>(image.Signal.GetHashCode(), sample.Signal.GetHashCode());
        }
    }
}
