using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Adapter.Classic.ClassicObject
{
    public class Adapter:ITarget
    {
        public Adapter(Adaptee adaptee)
        {

        }

        public Adaptee Adpatee { get; private set; }

        public void Request()
        {
            Adpatee.SpecifiedRequest();
        }
    }
}
