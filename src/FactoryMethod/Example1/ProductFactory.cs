﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.FactoryMethod.Example1
{
    public enum Category
    {
        A,
        B
    }

    public static class ProductFactory
    {
        public static IProduct Create(Category category)
        {
            switch(category)
            {
                case Category.A:
                    return new ConcreteProductA();
                case Category.B:
                    return new ConcreteProductB();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
