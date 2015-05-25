using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.DependencyInjection.Example2
{
    interface ITimeProvider
    {
        DateTime CurrentDate { get; }
    }

    class SystemTimeProvider:ITimeProvider
    {
        public DateTime CurrentDate { get { return DateTime.Now; } }
    }

    public class Client
    {
        public int GetYear()
        {
            ITimeProvider tiimeprovier = new SystemTimeProvider();
            return new SystemTimeProvider().CurrentDate.Year;
        }
    }
}
