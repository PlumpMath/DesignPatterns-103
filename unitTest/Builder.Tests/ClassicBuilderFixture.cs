using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Builder.Classic;

namespace Builder.Tests
{
    [TestClass]
    public class ClassicBuilderFixture
    {
        [TestMethod]
        public void BuildUp()
        {
            var maker = new VehicleMaker();
            maker.Builder = new CarBuilder();
            maker.Construct();
            Assert.AreEqual<int>(4, maker.Vehicle.Wheels.Count());
            Assert.AreEqual<int>(4, maker.Vehicle.Lights.Count());

            maker.Builder = new BicycleBuilder();
            maker.Construct();
            Assert.AreEqual<int>(2, maker.Vehicle.Wheels.Count());
            Assert.IsNull(maker.Vehicle.Lights);
        }
    }
}
