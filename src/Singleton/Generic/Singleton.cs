
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MedikzWorks.PracticalPattern.Singleton.Generic
{
    /// <summary>
    /// 提供对封闭构造方法类型的Singleton包装
    /// </summary>
    public class Singleton<T>
        where T:class
    {
        private Singleton()
        {

        }

        public static readonly T Instance =
            (T)typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null).
            Invoke(null);
    }
}
