﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Mediator.Classic
{
    /// <summary>
    /// 具体中介者类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Mediator<T>:IMediator<T>
    {
        protected IColleague<T> provider = null;
        protected IEnumerable<IColleague<T>> consumers = null;

        public virtual void Change()
        {
            if ((provider != null) && (consumers != null))
                foreach (var colleague in consumers)
                    colleague.Data = provider.Data;
        }

        public virtual void Introduce(IColleague<T> provider,IEnumerable<IColleague<T>> consumers)
        {
            this.provider = provider;
            this.consumers = consumers;
        }

        public virtual void Introduce(IColleague<T> provider,IColleague<T> consumer)
        {
            IList<IColleague<T>> consumers = new List<IColleague<T>>();
            consumers.Add(consumer);
            this.provider = provider;
            this.consumers = consumers;
        }

        public virtual void Introduce(IColleague<T> provider,params IColleague<T>[] consumers)
        {
            if(consumers.Length > 0)
            {
                IList<IColleague<T>> array = new List<IColleague<T>>(consumers);
                this.consumers = array;
            }
            this.provider = provider;
        }
    }
}
