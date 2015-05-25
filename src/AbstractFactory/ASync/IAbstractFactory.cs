using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.AbstractFactory.ASync
{
    public interface IFactory
    {
        IProduct Create();
    }

    public interface IFactoryWithNotifier:IFactory
    {
        void Create(Action<IProduct> callback);
    }
}
