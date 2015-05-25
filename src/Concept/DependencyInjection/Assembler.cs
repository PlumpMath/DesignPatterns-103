using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.DependencyInjection
{
    public class Assembler
    {
        /// <summary>
        /// 保存“抽象类型/实体类型”对应关系的字典
        /// </summary>
        static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            dictionary.Add(typeof(ITimeProvider),typeof(SystemTimeProvider));
        }

        /// <summary>
        /// 根据客户端需要的抽象类型选择相应的实体类型，并返回类型实体
        /// </summary>
        /// <param name="type">抽象类型(抽象类/接口/或者某周基类)</param>
        /// <returns>实体类型实例</returns>
        public object Create(Type type) // 非泛型方式调用
        {
            if ((type == null) || !dictionary.ContainsKey(type))
                throw new NullReferenceException();

            Type targetType = dictionary[type];
            return Activator.CreateInstance(targetType);
        }

        /// <summary>
        /// 抽象类型(抽象类/接口/或者某周基类)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Create<T>() // 泛型方式调用
        {
            return (T)Create(typeof(T));
        }
    }
}
