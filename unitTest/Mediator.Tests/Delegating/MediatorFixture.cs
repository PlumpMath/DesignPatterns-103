using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MedikzWorks.PracticalPattern.Mediator.Delegating;

namespace Mediator.Tests.Delegating
{
    [TestClass]
    public class MediatorFixture
    {
        public class A:ColleagueBase<int>
        {
            public event EventHandler<DataEventArgs<int>> Changed;

            public override int Data
            {
                get
                {
                    return base.Data;
                }
                set
                {
                    base.Data = value;
                    Changed(this, new DataEventArgs<int>(value));
                }
            }
        }

        public class B : ColleagueBase<int> { }
        public class C : ColleagueBase<int> { }

        [TestMethod]
        public void Test()
        {
            var a = new A();
            var b = new B();
            var c = new C();
            a.Changed += b.OnChanged;
            a.Changed += c.OnChanged;
            a.Data = 20;
            Assert.AreEqual<int>(20, b.Data);
            Assert.AreEqual<int>(20, c.Data);

            a.Changed -= c.OnChanged;
            a.Data = 30;
            Assert.AreEqual<int>(30, b.Data);
            Assert.AreEqual<int>(20, c.Data);
        }
    }
}
