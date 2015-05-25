using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Singleton.DoubleCheckClassic
{
    public class Singleton
    {
        protected Singleton() { }
        static volatile Singleton instance = null;

        /// <summary>
        /// Lazy方式创建唯一实例的过程
        /// </summary>
        /// <returns></returns>
        public static Singleton Instance()
        {
            if (instance == null)
                lock (typeof(Singleton))
                    if (instance == null)
                        instance = new Singleton();
            return instance;
        }
    }
}
