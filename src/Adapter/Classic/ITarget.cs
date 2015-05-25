using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Adapter.Classic
{
    public interface ITarget
    {
        void Request();
    }

    public class Adaptee
    {
        public void SpecifiedRequest() { }
    }
}
