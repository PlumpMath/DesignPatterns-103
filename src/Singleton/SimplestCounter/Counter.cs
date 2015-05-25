using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Singleton.SimplestCounter
{
    public class Counter
    {
        public Counter()
        {

        }

        public static readonly Counter Instance = new Counter();

        int value;
        public int Next { get { return ++value; } }
        public void Reset() { value = 0; }
    }
}
