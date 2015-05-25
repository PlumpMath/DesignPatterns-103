using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.CoR.Classic
{
    /// <summary>
    /// 调用者
    /// </summary>
    public class Request
    {
        public double Price { get; set; }
        public PurchaseType Type { get; set; }
    }
}
