using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.DependencyInjection
{
    public class SystemTimeProvider:ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.Now; } }
    }
}
