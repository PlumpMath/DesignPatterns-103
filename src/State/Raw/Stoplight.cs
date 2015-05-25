using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.State.Raw
{
    public enum Color { Red, Green, Yellow }
    
    public class Stoplight
    {
        Color current = Color.Yellow;

        public Color Next
        {
            get
            {
                if (current == Color.Green)
                    current = Color.Yellow;
                else if (current == Color.Yellow)
                    current = Color.Red;
                else if (current == Color.Red)
                    current = Color.Green;
                return current;
            }
            
        }
    }
}
