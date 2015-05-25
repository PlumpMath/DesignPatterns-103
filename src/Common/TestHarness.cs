using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MedikzWorks.PracticalPattern.Common
{
    /// <summary>
    /// Some utility extensions on unit test
    /// </summary>
    public static class TestHarness
    {
        public static void Parallel(params ThreadStart[] actions)
        {
            Thread[] threads = actions.Select(a => new Thread(a)).ToArray();
            threads.ForEach(t => t.Start());
            threads.ForEach(t => t.Join());
        }
    }
}
