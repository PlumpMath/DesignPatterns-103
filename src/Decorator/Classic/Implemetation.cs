﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Decorator.Classic
{
    /// <summary>
    /// 具体装饰类
    /// 属于“马甲”
    /// </summary>
    public class BoldDecorator : DecoratorBase
    {
        public BoldDecorator(IText target)
            :base(target)
        {

        }

        public override string Content
        {
            get { return ChangeToBoldFont(target.Content); }
        }

        public string ChangeToBoldFont(string content)
        {
            return "<b>" + content + "</b>";
        }
    }

    /// <summary>
    /// 具体装饰类
    /// 属于“马甲”
    /// </summary>
    public class ColorDecorator:DecoratorBase
    {
        public ColorDecorator(IText target)
            :base(target)
        {

        }

        public override string Content
        {
            get { return AddColorTag(target.Content); }
        }

        public string AddColorTag(string content)
        {
            return "<color>" + target.Content + "</color>";
        }
    }

    public class BlockAllDecorator:DecoratorBase
    {
        public BlockAllDecorator(IText target)
            :base(target)
        {

        }

        public override string Content
        {
            get { return string.Empty; }
        }
    }

    /// <summary>
    /// 实体对象类型
    /// </summary>
    public class TextObject:IText
    {
        public string Content { get { return "hello"; } }
    }
}
