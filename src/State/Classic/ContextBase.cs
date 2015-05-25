using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.State.Classic
{
    /// <summary>
    /// 抽象的状态接口
    /// </summary>
    public interface IState
    {
        void Open();
        void Close();
        void Query();
    }

    /// <summary>
    /// 抽象的Context对象
    /// </summary>
    public abstract class ContextBase:IState
    {
        /// <summary>
        /// 实际控制处理的状态对象
        /// </summary>
        public virtual IState State { get; set; }
        public void Open()
        {
            State.Open();
        }

        public void Close()
        {
            State.Close();
        }

        public void Query()
        {
            State.Query();
        }
    }
}
