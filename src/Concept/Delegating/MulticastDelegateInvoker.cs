using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Delegating
{
    public class MulticastDelegateInvoker
    {
        string[] message = new string[3];

        #region Lamada
        public MulticastDelegateInvoker()
        {
            List<Action> handler = new List<Action>()
            {
                () => {message[0] = "hello";},
                () => {message[1] = ",";},
                () => {message[2] = "world";}
            };
            handler.ForEach(x => x());
        }
        #endregion

        public string this[int index] { get { return message[index]; } }
    }
}
