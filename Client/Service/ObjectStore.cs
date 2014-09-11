using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Client.Service
{
    public class ObjectStore<ObjectType>
    {
        protected Dictionary<Guid, ObjectType> store = new Dictionary<Guid, ObjectType>();

        public ObjectType Get(Guid id)
        {
            return store[id];
        }

        public Guid Add(ObjectType item)
        {
            if (store.ContainsValue(item))
                return store.First(s => s.Value.Equals(item)).Key;

            Guid id = Guid.NewGuid();

            store.Add(id, item);

            return id;
        }
    }
}
