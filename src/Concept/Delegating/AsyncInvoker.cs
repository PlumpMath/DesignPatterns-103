using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MedikzWorks.PracticalPattern.Concept.Delegating
{
    public class AsyncInvoker
    {
        public AsyncInvoker()
        {
            new Timer(new TimerCallback(OnTimeInterval), "slow", 2500, 2500);
            new Timer(new TimerCallback(OnTimeInterval), "fast", 2000, 2000);
            Trace.WriteLine("method");
        }

        static void OnTimeInterval(object state)
        {
            Trace.WriteLine(state as string);
        }
    }
}
