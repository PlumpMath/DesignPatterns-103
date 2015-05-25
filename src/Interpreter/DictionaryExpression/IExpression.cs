using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Interpreter.DictionaryExpression
{
    /// <summary>
    /// 所有表达式的抽象接口
    /// </summary>
    public interface IExpression
    {
        Action<Context> Evaluate { get; }
    }
}
