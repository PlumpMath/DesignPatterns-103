using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Composite.Classic
{
    public class Composite:Component
    {
        public Composite()
        {
            base.children = new List<Component>();
        }
    }
}
