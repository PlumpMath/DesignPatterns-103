using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Mediator.Delegating
{
    public class DataEventArgs<T>:EventArgs
    {
        public T Data;
        public DataEventArgs(T data) { this.Data = data; }
    }

   public abstract class ColleagueBase<T>
   {
       public virtual T Data { get; set; }
       public virtual void OnChanged(object sender,DataEventArgs<T> args)
       {
           Data = args.Data;
       }
   }
}
