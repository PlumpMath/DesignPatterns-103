using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Generics
{
    public class RawGenericFactory<T>
    {
        public T Create(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                throw new ArgumentNullException("typename");

            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }
    }
}
