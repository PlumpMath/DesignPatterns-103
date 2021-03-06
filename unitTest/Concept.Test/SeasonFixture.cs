﻿using MedikzWorks.PracticalPattern.Concept.Operator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Concept.Tests
{
    [TestClass]
    public class SeasonFixture
    {
        [TestMethod]
        public void TestSeasonIterator()
        {
            var season = new Season();
            // 春天
            Assert.AreEqual<string>(Season.Seasons[0], season);
            Trace.WriteLine(season);

            season++;
            season++;
            // 秋天
            Assert.AreEqual<string>(Season.Seasons[2], season);
            Trace.WriteLine(season);
        }
    }
}
