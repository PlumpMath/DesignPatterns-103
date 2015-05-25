using System;
using System.Linq;
using MedikzWorks.PracticalPattern.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Prototype.Customerized;

namespace Prototype.Tests
{
    [TestClass]
    public class CustomerizedSerializationFixture
    {
        [TestMethod]
        public void Test()
        {
            var user = new UserInfo()
            {
                Name = "joe",
                Age = 20,
                Education = new string[] { "A", "B", "C", "D" }
            };

            var graph = SerializationHelper.SerializeObjectToString(user);
            var clone = SerializationHelper.DeserializeStringToObject<UserInfo>(graph);

            Assert.AreEqual<int>(3, clone.Education.Count());
            CollectionAssert.AreEqual(new string[] { "A", "B", "C" }, clone.Education);

            Assert.AreNotEqual<int>(user.Age, clone.Age);
            Assert.AreEqual<string>(user.Name, clone.Name);
        }
    }
}
