using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Singleton.Test.NotSingleton
{
    class Target { }

    class Client
    {
        static IList<Target> list = new List<Target>();
        Target target;

        public void SomeMethod()
        {
            if (list.Count == 0)
            {
                target = new Target();
                list.Add(target);
            }
            else
                target = list[0];
        }

        public Target Instance { get { return target; } }
    }

    [TestClass]
    public class ClientSlideSingleton
    {
        [TestMethod]
        public void Test()
        {
            Client client1 = new Client();
            client1.SomeMethod();
            Client client2 = new Client();
            client2.SomeMethod();
            Assert.AreEqual<int>(client1.Instance.GetHashCode(),client2.Instance.GetHashCode());
        }
    }
}
