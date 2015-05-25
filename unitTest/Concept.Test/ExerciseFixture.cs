using System;
using MedikzWorks.PracticalPattern.Concept.Exercise;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Collections;

namespace Concept.Test
{
    [TestClass]
    public class ExerciseFixture
    {
        [TestMethod]
        public void SingleLineTest()
        {
            var singleLine = ExerciseManager.SingleLineSetting;
            Assert.AreEqual<string>("first", singleLine.Name);
            Assert.AreEqual<string>("second",singleLine.Age);
            Assert.AreEqual<string>("third",singleLine.Level);
        }

        [TestMethod]
        public void DictionaryTest()
        {
            var dictSetting = ExerciseManager.DictSetting;
            Assert.AreEqual<string>("name", dictSetting.Dictionary["name"].Key);
            Assert.AreEqual<string>("first", dictSetting.Dictionary["name"].Value);

            Assert.AreEqual<string>("age", dictSetting.Dictionary["age"].Key);
            Assert.AreEqual<string>("second", dictSetting.Dictionary["age"].Value);

            Assert.AreEqual<string>("level", dictSetting.Dictionary["level"].Key);
            Assert.AreEqual<string>("third", dictSetting.Dictionary["level"].Value);
        }

        [TestMethod]
        public void TestReadSingleTagCongiurationSection()
        {
            var section = ConfigurationManager.GetSection("singleLine") as Hashtable;
            Assert.AreEqual("first", section["name"]);
            Assert.AreEqual("second", section["age"]);
            Assert.AreEqual("third",section["level"]);

        }

        [TestMethod]
        public void TestReadDictionaryConfigurationSection()
        {
            var section = ConfigurationManager.GetSection("dictionary") as Hashtable;
            Assert.AreEqual("first", section["name"]);
            Assert.AreEqual("second",section["age"]);
            Assert.AreEqual("third",section["level"]);

        }
    }
}
