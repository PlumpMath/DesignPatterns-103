using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Common
{
    public static class EnumerableHelper
    {
        public static void ForEach<T>(this IEnumerable<T> sequence,Action<T> action)
        {
            if (sequence == null)
                throw new ArgumentNullException("sequence");
            if (action == null)
                throw new ArgumentNullException("action");
            foreach (var item in sequence)
                action(item);
        }
    }
}
