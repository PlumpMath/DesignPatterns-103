using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Memento.Persistence
{
    public interface IState { }

    public interface IPersistenceStore<T>
        where T:IState
    {
        void Store(string originatorID, int version, T target);
        T Find(string originator, int version);
    }

    public abstract class OriginatorBase<T>
        where T:IState
    {
        protected T state;
        protected string key;
        public OriginatorBase()
        {
            key = (new Guid()).ToString();
        }

        protected IPersistenceStore<T> store;

        public virtual void SaveCheckpoint(int version)
        {
            store.Store(key, version, state);
        }

        public virtual void Undo(int version)
        {
            state = store.Find(key, version);
        }
    }

    /// <summary>
    /// 具体状态类型
    /// </summary>
    [Serializable]
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
        public Originator()
        {
            store = new MementoPersistenceStore<Position>();
        }

        /// <summary>
        /// 供客户程序使用的非备忘录相关操作
        /// </summary>
        /// <param name="x"></param>
        public void UpdateX(int x) { base.state.X = x; }
        public void DecreaseX() { base.state.X--; }
        public void IncreaseY() { base.state.Y++; }
        public Position Current { get { return base.state; } }
    }
}
