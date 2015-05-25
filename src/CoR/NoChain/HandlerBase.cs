using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.CoR.NoChain
{
    /// <summary>
    /// 操作的抽象类型
    /// </summary>
    public abstract class HandlerBase:IHandler
    {
        public IHandler Successor { get; set; }
        public PurchaseType Type { get; protected set; }
        public RequestOptions Option { get; protected set; }

        /// <summary>
        /// Handler需要处理的内容
        /// </summary>
        /// <param name="request"></param>
        public virtual void Process(Request request) { }

        /// <summary>
        /// 按照链式方式依次把调用继续下去
        /// </summary>
        /// <param name="request"></param>
        public virtual void HandleRequest(Request request)
        {
            if (request == null)
                throw new ArgumentNullException("request");
            Trace.WriteLine("");
            Trace.WriteLine(GetType().Name);
            if(request.Type == Type)
            {
                Process(request);
                Trace.Write(" has been processed");
            }
        }
    }
}
