using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Decorator.WithBuilder
{
    /// <summary>
    /// 装饰类型的装配器
    /// </summary>
    public class DecoratorAssembler
    {
        /// <summary>
        /// 等级装饰不同类型需要使用的一组ConcreteDecorator类型
        /// </summary>
        static IDictionary<Type, IEnumerable<Type>> dictionary =
            new Dictionary<Type, IEnumerable<Type>>();

        /// <summary>
        /// 试剂项目中这个加载过程可由配置完成
        /// </summary>
        static DecoratorAssembler()
        {
            var types = new List<Type>()
                            {
                                typeof(BoldDecorator),
                                typeof(ColorDecorator)
                            };
            dictionary.Add(typeof(TextObject), types);
        }

        /// <summary>
        /// 按照需要构造的客户类型选择相应的Decorator列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<Type> this[Type type]
        {
            get
            {
                if (type == null)
                    throw new ArgumentException("type");
                IEnumerable<Type> result;
                return dictionary.TryGetValue(type, out result) ? result : null;
            }
        }
    }
}
