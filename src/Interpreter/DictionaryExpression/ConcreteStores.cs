using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Interpreter.DictionaryExpression
{
    /// <summary>
    /// 基于枚举项的DictionaryStore
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class EnumDictionaryStore<T>:IDictionaryStore
   {
       public void Refresh() { } // 对于枚举类型暂时用不到
       public void Find(Context context)
       {
           switch(context.Operator)
           {
               case 'F':
                   context.Value = ((T)(context.Key)).ToString();
                   break;
               case 'T':
                   context.Key = Enum.Parse(typeof(T), (string)context.Value);
                   break;
               default:
                   throw new ArgumentException();
           }
       }
   }

    /// <summary>
    /// 基于Dictionary<string,string>的DictionaryStore
    /// </summary>
    public class StringDictionaryStore:IDictionaryStore
    {
        public void Refresh() { }

        protected IDictionary<string, string> data;
        public virtual IDictionary<string,string> Data
        {
            get { return data; }
            set { data = value; }
        }

        public void Find(Context context)
        {
            if (Data == null)
                throw new NullReferenceException("Data");
            string value;
            switch(context.Operator)
            {
                case 'F':
                    if (!Data.TryGetValue((string)context.Key, out value))
                        context.Value = string.Empty;
                    else
                        context.Value = value;
                    break;
                case 'T':
                    value = (string)context.Value;
                    foreach(string key in Data.Keys)
                        if(string.Equals(Data[key],value))
                        {
                            context.Key = key;
                            return;
                        }
                    context.Key = string.Empty;
                    break;
                default:
                    throw new ArgumentException();
            }
        }
    }
}