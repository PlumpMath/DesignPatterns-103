using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Decorator.Classic
{
    public interface IText
    {
        string Content { get; }
    }

    public interface IDecorator : IText { }

    public abstract class DecoratorBase:IDecorator // is a
    {
        /// <summary>
        /// has a
        /// </summary>
        protected IText target;

        public DecoratorBase(IText target)
        {
            this.target = target;
        }

        public abstract string Content { get; }
    }
}
