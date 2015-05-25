using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;

namespace Builder.Tests
{
    class Entry
    {
        public string A { get; set; }
        public int B { get; private set; }
        public double C { get; set; }
        public float D { get; private set; }
        public DateTime E { get; private set; }
        public IList<string> F { get; set; }

        /// <summary>
        /// 对封闭Entry的构造过程
        /// </summary>
        /// <param name="builder"></param>
        public Entry(Builder builder)
        {
            A = builder.AValue;
            B = builder.BValue;
            C = builder.CValue;
            D = builder.DValue;
            E = builder.EValue;
            F = builder.FValue;
        }

        public class Builder
        {
            public string AValue { get; private set; }
            public int BValue { get; private set; }
            public double CValue { get; private set; }
            public float DValue { get; private set; }
            public DateTime EValue { get; private set; }
            public IList<string> FValue { get; private set; }

            public Builder(string a,int b)
            {
                AValue = a;
                BValue = b;

                // C、D默认为0，F默认为null
                EValue = DateTime.Now;
            }

            #region 连贯接口方法
            public Builder C(double c)
            {
                this.CValue = c;
                return this;
            }

            public Builder D(float d)
            {
                this.DValue = d;
                return this;
            }

            public Builder E(DateTime e)
            {
                this.EValue = e;
                return this;
            }

            public Builder F(IList<string> f)
            {
                this.FValue = f;
                return this;
            }
            #endregion

            public Entry BuildUp()
            {
                return new Entry(this);
            }
        }
    }

    [TestClass]
    public class FluentInterfaceBuilderFixture
    {
        [TestMethod]
        public void TestInnerFluentBuildUp()
        {
            var e1 = new Entry.Builder("a", 20)
                .C(30)
                .D(40)
                .F(new List<string> { "A", "B", "C" }).BuildUp();
            Output(e1);
            var e2 = new Entry.Builder("b", 18).BuildUp();
            Output(e2);
        }

        void Output(Entry entry)
        {
            Trace.WriteLine("\nEntry["+entry.A+"]");
            Trace.WriteLine(entry.B.ToString());
            Trace.WriteLine(entry.C.ToString());
            Trace.WriteLine(entry.D.ToString());
            Trace.WriteLine(entry.E.ToString());
            Trace.WriteLine(entry.F == null?"NULL":string.Join(",",entry.F));
        }
    }
}
