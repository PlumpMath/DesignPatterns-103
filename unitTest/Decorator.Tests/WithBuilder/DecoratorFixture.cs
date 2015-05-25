﻿using System;
using MedikzWorks.PracticalPattern.Decorator.WithBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Decorator.Tests.WithBuilder
{
    [TestClass]
    public class DecoratorFixture
    {
        [TestMethod]
        public void Test()
        {
            // 修改后的IText仅仅依赖于一个Builder类型
            IText text = new TextObject();
            text = (new DecoratorBuilder()).BuildUp(text);
            Assert.AreEqual<string>("<color><b>hello</b></color>", text.Content);
        }
    }
}
