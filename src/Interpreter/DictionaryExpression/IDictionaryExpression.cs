﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Interpreter.DictionaryExpression
{
    /// <summary>
    /// 抽象字典信息存储访问对象
    /// </summary>
    public interface IDictionaryStore
    {
        /// <summary>
        /// 对于基于配置、数据库等信息的Store对象可以通过该方法重新加载相应的缓冲信息
        /// </summary>
        void Refresh();

        /// <summary>
        /// 根据Context定义的Key/Value以及访问方法提取信息
        /// </summary>
        /// <param name="context"></param>
        void Find(Context context);
    }

    /// <summary>
    /// 具有字典信息的表达式对象接口
    /// </summary>
    public interface IDictionaryExpression:IExpression
    {
        IDictionaryStore Store { get; set; }
    }

    public class SimpleDictionaryExpression:IDictionaryExpression
    {
        public virtual IDictionaryStore Store { get; set; }
        public Action<Context> Evaluate { get{return Store.Find;} }
    }
}
