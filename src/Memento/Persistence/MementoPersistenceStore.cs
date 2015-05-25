using MedikzWorks.PracticalPattern.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Memento.Persistence
{
    public class MementoPersistenceStore<T>
        :IPersistenceStore<T>
        where T:IState
    {
        static IDictionary<KeyValuePair<string, int>, string>
            store = new Dictionary<KeyValuePair<string, int>, string>();

        public void Store(string originatorId,int version,T target)
        {
            if (target == null)
                throw new ArgumentNullException("target");

            var key = new KeyValuePair<string, int>(originatorId, version);
            string value = SerializationHelper.SerializeObjectToString(target);
            if (store.ContainsKey(key))
                store[key] = value;
            else
                store.Add(key, value);
        }

        public T Find(string originatorId,int version)
        {
            string value;
            if (!store.TryGetValue(new KeyValuePair<string, int>(originatorId, version), out value))
                throw new NullReferenceException();
            return SerializationHelper.DeserializeStringToObject<T>(value);
        }
    }
}
