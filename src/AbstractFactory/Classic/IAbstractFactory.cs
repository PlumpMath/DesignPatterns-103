﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.AbstractFactory.Classic
{
    /// <summary>
    /// 具体工厂类型
    /// </summary>
    public class ConcreteFactory1:IAbstractFactory
    {
        public virtual IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public virtual IProductB CreateProductB()
        {
            return new ProductB1();
        }

        public virtual IProductC CreateProductC()
        {
            return new ProductC1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public virtual IProductA CreateProductA()
        {
            return new ProductA2Y();
        }

        public virtual IProductB CreateProductB()
        {
            return new ProductB2();
        }

        public virtual IProductC CreateProductC()
        {
            return new ProductC2();
        }
    }
}
