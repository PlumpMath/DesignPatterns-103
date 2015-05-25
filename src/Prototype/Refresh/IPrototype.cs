using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MedikzWorks.PracticalPattern.Common;

namespace MedikzWorks.PracticalPattern.Prototype.Refresh
{
    public interface IPrototype
    {
        string Name { get; set; }
        IPrototype Clone();
    }

    [Serializable]
    public abstract class PrototypeBase:IPrototype
    {
        public virtual IPrototype Clone()
        {
            return SerializationHelper.DeserializeStringToObject<IPrototype>(SerializationHelper.SerializeObjectToString(this));
        }

        public string Name { get; set; }
    }

    [Serializable]
    public class ConcretePrototype : PrototypeBase { }
}
