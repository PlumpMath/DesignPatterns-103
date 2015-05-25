using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Composite.Classic
{
    /// <summary>
    /// 由于组合形式对象的特殊性，这个工厂同时具有工厂方法模式和抽象工厂模式的特点：
    /// T:Component,new()体现工厂方法的特点
    /// 但Create<T>其实当相遇CreateComposte()、CreateLeaf()的作用，特显抽象工厂的特点
    /// </summary>
    public class ComponentFactory
    {
        public Component Create<T>(string name) where T:Component,new()
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
        public Component Create<T>(Component parent,string name)
            where T:Component,new()
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
