using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.DependencyInjection
{
    public interface ITimeProvider
    {
        DateTime CurrentDate { get; }
    }
}
