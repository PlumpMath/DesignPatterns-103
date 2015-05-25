﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Composite.Iterating
{
   public interface IMatchRule
   {
       bool IsMatch(Component target);
   }

    public abstract class Component
    {
        /// <summary>
        /// 保存子节点
        /// </summary>
        protected IList<Component> children;

        /// <summary>
        /// Leaf和Composite的共同特征. setter方式注入名称
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 其实只有Composite类型才需要真正实现的功能
        /// </summary>
        /// <param name="child"></param>
        public virtual void Add(Component child) { children.Add(child); }
        public virtual void Remove(Component child) { children.Remove(child); }
        public virtual Component this[int index] { get { return children[index]; } }

        public virtual IEnumerable<Component> Enumerate(IMatchRule rule)
        {
            if ((rule == null) || (rule.IsMatch(this)))
                yield return this;
            if ((children != null) && (children.Count > 0))
                foreach (Component child in children)
                    foreach (Component item in child.Enumerate(rule))
                        if ((rule == null) || (rule.IsMatch(item)))
                            yield return item;
        }

        public virtual IEnumerable<Component> Enumerate() { return Enumerate(null); }
    }

    public class Leaf : Component
    {
        /// <summary>
        /// 明确声明不支持此类操作
        /// </summary>
        /// <param name="child"></param>
        public override void Add(Component child) { throw new NotSupportedException(); }
        public override void Remove(Component child) { throw new NotSupportedException(); }
        public override Component this[int index] { get { throw new NotSupportedException(); } }
    }

    public class Composite : Component
    {
        public Composite() { base.children = new List<Component>(); }
    }
}
