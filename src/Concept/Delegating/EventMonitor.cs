using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Concept.Delegating
{
    #region 业务实体和事件监视器

    /// <summary>
    /// 业务实体
    /// </summary>
    public class Order
    {
        public void Create() { EventMonitor.Added(this, null); }
        public void ChangeDate() { EventMonitor.Modified(this, null); }
        public void ChangeOwner() { EventMonitor.Modified(this, null); }
        public void ChangeId() { } // 不计入监控

    }

    /// <summary>
    /// 事件监视器
    /// </summary>
    public static class EventMonitor
    {
        public static EventHandler<EventArgs> Modified;
        public static EventHandler<EventArgs> Added;

        static EventMonitor()
        {
            Modified = OnModified;
            Added = OnAdded;
        }
 
        private static void OnAdded(object sender, EventArgs e)
        {
            AddedTimes++;
        }
 
        private static void OnModified(object sender, EventArgs e)
        {
            ModifiedTimes++;
        }

        public static int ModifiedTimes { get; private set; }
        public static int AddedTimes { get; private set; }

    }
    #endregion
}
