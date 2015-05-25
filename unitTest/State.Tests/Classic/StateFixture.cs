using System;
using MedikzWorks.PracticalPattern.State.Classic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace State.Tests
{
    [TestClass]
    public class UnitTest1
    {
        class OpenState:IState
        {
            public void Open() { throw new NotSupportedException(); }
            public void Close() { }
            public void Query() { }
        }

        class ClosedState:IState
        {
            public void Open() { }
            public void Close() { }
            public void Query() { throw new NotSupportedException(); }
        }

        class Connection : ContextBase { }

        Connection connection;
        [TestInitialize]
        public void Initialize()
        {
            connection = new Connection();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TryOnAnOpenConnection()
        {
            connection.State = new OpenState();
            connection.Open();
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void TryOnAnClosedConnection()
        {
            connection.State = new ClosedState();
            connection.Query();
        }

        [TestMethod]
        public void TrySupportOperations()
        {
            connection.State = new OpenState();
            connection.Query();
            connection.Close();
        }
    }
}
