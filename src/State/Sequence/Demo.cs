using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.State.Sequence
{
    /// <summary>
    /// 抽象的状态接口
    /// </summary>
    public interface IState
    {
        void Open(IContext context);
        void Close(IContext context);
        void Query(IContext context);
    }

    public interface IContext
    {
        IState State { get; set; }
        IContext Open();
        IContext Close();
        IContext Query();
    }

    public abstract class ContextBase:IContext
    {
        /// <summary>
        /// 实际控制处理的状态对象
        /// </summary>
        public virtual IState State { get; set; }
        public virtual IContext Open()
        {
            State.Open(this);
            return this;
        }

        public IContext Close()
        {
            State.Close(this);
            return this;
        }

        public IContext Query()
        {
            State.Query(this);
            return this;
        }
    }
}
