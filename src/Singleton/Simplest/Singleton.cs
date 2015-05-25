using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Singleton.Simplest
{
    sealed class Singleton
    {
        public Singleton(){ }

        [ThreadStatic]
        public static readonly Singleton Instance = new Singleton();
    }
}
