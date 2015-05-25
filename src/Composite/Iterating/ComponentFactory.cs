using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Composite.Iterating
{
    public class ComponentFactory
    {
        public Component Create<T>(string name) where T : Component, new()
        {
            return new T() { Name = name };
        }

        /// <summary>
        /// 连贯方法：直接向某个节点下增加新的节点
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Component Create<T>(Component parent, string name)
            where T : Component, new()
        {
            if (parent == null)
                throw new ArgumentNullException("parent");
            if (!(parent is Composite))
                throw new Exception("non-composite type");
            Component instance = Create<T>(name);
            parent.Add(instance);
            return instance;
        }
    }
}
