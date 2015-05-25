using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Composite.Classic
{
    public class Leaf:Component
    {
        public override void Add(Component child)
        {
            throw new NotSupportedException();
        }

        public override void Remove(Component child)
        {
            throw new NotSupportedException();
        }

        public override Component this[int index]
        {
            get { throw new NotSupportedException(); }
        }
    }
}
