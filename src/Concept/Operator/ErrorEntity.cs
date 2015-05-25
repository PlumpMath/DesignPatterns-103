using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Operator
{
    public class ErrorEntity
    {
        IList<string> messages = new List<string>();
        IList<int> codes = new List<int>();

        public static ErrorEntity operator+(ErrorEntity entity,string message)
        {
            entity.messages.Add(message);
            return entity;
        }

        public static ErrorEntity operator+(ErrorEntity entity,int code)
        {
            entity.codes.Add(code);
            return entity;
        }

        public IList<string> Messages { get { return messages; } }
        public IList<int> Codes { get { return codes; } }
    }
}
