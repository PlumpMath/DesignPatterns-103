﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.FactoryMethod
{
    /// <summary>
    /// 抽象产品类型
    /// </summary>
    public interface IProduct
    {
        string Name { get; }    // 约定的抽象产品所必须具有的特征
    }

    public class ProductA:IProduct
    {
        public string Name { get { return "A"; } }
    }

    public class ProductB:IProduct
    {
        public string Name { get { return "B"; } }
    }
}
