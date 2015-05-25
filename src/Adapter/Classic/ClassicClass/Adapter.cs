using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Adapter.Classic.ClassicClass
{
    public class Adapter:Adaptee,ITarget
    {
        public void Request()
        {
            base.SpecifiedRequest();
        }
    }
}
