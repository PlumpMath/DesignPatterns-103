﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.CoR.NoChain
{
    /// <summary>
    /// 调用者的Request类型
    /// </summary>
    public enum RequestOptions
    {
        /// <summary>
        /// 购买
        /// </summary>
        Purchase = 0x1,

        /// <summary>
        /// 退货
        /// </summary>
        Return = 0x2,

        /// <summary>
        /// 破损
        /// </summary>
        Damaged = 0x4
    }

    /// <summary>
    /// 调用者
    /// </summary>
    public class Request
    {
        public double Price { get; set; }
        public PurchaseType Type { get; set; }
        public RequestOptions Option { get; set; }
    }
}
