using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Decorator.WithBuilder
{
    /// <summary>
    /// 为目标类型做“装饰”的创建者
    /// </summary>
    public class DecoratorBuilder
    {
        static readonly DecoratorAssembler assembly = new DecoratorAssembler();

        public IText BuildUp(IText target)
        {
            if (target == null)
                throw new ArgumentException("target");
            var types = assembly[target.GetType()];
            if ((types != null) && (types.Count() > 0))
                types.ToList().ForEach(x => target = (IText)Activator.CreateInstance(x, target));
            return target;
        }
    }
}
