using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Interpreter.DictionaryExpression
{
    /// <summary>
    /// 适用于字典信息的Context对象
    /// </summary>
    public class Context
    {
        public object Key { get; set; }
        public object Value { get; set; }
        public char Operator { get; set; }
    }
}
