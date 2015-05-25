using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Command.NetClassic
{
    public class Database
    {
        #region Command
        public Action OpenConnection { get; set; }
        public Func<bool> ExecuteCommand { get; set; }
        public Action CloseConnection { get; set; }

        #endregion

        public void Process()
        {
            OpenConnection();
            Trace.WriteLine(string.Format("Command result:{0}",ExecuteCommand()));
            CloseConnection();
        }
    }
}
