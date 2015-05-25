using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Prototype.Classic
{
    public class Indicator { }

    public interface IPrototype
    {
        IPrototype Clone();
        string Name { get; set; }
        Indicator Signal { get; }
    }

    public class ConcretePrototype:IPrototype
    {
        public IPrototype Clone()
        {
            return (IPrototype)this.MemberwiseClone();
        }

        public string Name { get; set; }

        private Indicator signal = new Indicator();
        public Indicator Signal { get { return this.signal; } }
    }
}
