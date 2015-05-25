using System;
using System.Collections.Generic;
using MedikzWorks.PracticalPattern.Interpreter.DictionaryExpression;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interpreter.Tests.DictionaryExpression
{
    [TestClass]
    public class ExpressionFixture
    {
        enum Color { Red,Green,Blue}

        IDictionary<string, string> data;
        SimpleDictionaryExpression expression;

        [TestInitialize]
        public void Initialize()
        {
            data = new Dictionary<string, string>()
                {
                    {"R","Red"},
                    {"G","Green"},
                    {"B","Blue"}
                };
            expression = new SimpleDictionaryExpression();
        }

        [TestMethod]
        public void Test()
        {
            expression.Store = new EnumDictionaryStore<Color>();
            var context = new Context() { Key = Color.Red, Operator = 'F' };
            expression.Evaluate(context);
            Assert.AreEqual<string>("Red", context.Value as string);

            context = new Context() { Value = "Blue", Operator = 'T' };
            expression.Evaluate(context);
            Assert.AreEqual<Color>(Color.Blue, (Color)(context.Key));

            expression.Store = new StringDictionaryStore() { Data = data };
            expression.Evaluate(context);
            Assert.AreEqual<string>("B", context.Key as string);
        }
    }
}
