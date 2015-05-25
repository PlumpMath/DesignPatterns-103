using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Interpreter.Classic
{
    /// <summary>
    /// 表达所有表达式的抽象接口
    /// </summary>
    public interface IExpression
    {
        /// <summary>
        /// 用Context负责保存中间结果
        /// </summary>
        /// <param name="context"></param>
        void Evaluate(Context context);
    }
}
