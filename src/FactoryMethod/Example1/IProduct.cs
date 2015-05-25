using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.FactoryMethod.Example1
{
    public interface IProduct { }
    public class ConcreteProductA : IProduct { }
    public class ConcreteProductB : IProduct { }

    public class Factory
    {
        public IProduct Create()
        {
            return new ConcreteProductA();
        }
    }
}
