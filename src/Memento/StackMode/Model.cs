﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Memento.StackMode
{
    /// <summary>
    /// 为了便于定义抽象状态类型所定义的接口
    /// </summary>
    public interface IState { }

    /// <summary>
    /// 抽象备忘录对象接口
    /// </summary>
    public interface IMemento<T> where T : IState
    {
        T State { get; set; }
    }

    /// <summary>
    /// 包括内部备忘录类型的发起者抽象定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class OriginatorBase<T>
        where T : IState
    {
        /// <summary>
        /// 发起者对象的状态
        /// </summary>
        protected T state;

        /// <summary>
        /// 把备忘录定义为发起者的内部类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected class InternalMemento : IMemento<T>
        {
            public T State { get; set; }
        }

        protected virtual IMemento<T> CreateMemento()
        {
            return new InternalMemento() { State = this.state };
        }

        /// <summary>
        /// 用于保存历次备忘信息的堆栈
        /// </summary>
        Stack<IMemento<T>> stack = new Stack<IMemento<T>>();

        /// <summary>
        /// 把状态保存到备忘录
        /// </summary>
        public virtual void SaveCheckpoint() { stack.Push(CreateMemento()); }
        /// <summary>
        /// 从备忘录恢复之前的状态
        /// </summary>
        public virtual void Undo()
        {
            if (stack.Count == 0) return;
            this.state = stack.Pop().State;
        }
    }

    /// <summary>
    /// 具体状态类型
    /// </summary>
    public struct Position : IState
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// 具体发起者类型
    /// </summary>
    public class Originator : OriginatorBase<Position>
    {
        /// <summary>
        /// 供客户程序使用的非备忘录相关操作
        /// </summary>
        /// <param name="x"></param>
        public void UpdateX(int x) { state.X = x; }
        public void DecreaseX() { state.X--; }
        public void IncreaseY() { state.Y++; }
        public Position Current { get { return state; } }
    }
}
