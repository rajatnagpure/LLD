using System;
using Splitwise.Models;

namespace Splitwise.Repositories
{
    public class BaseRepository<T>
    {
        protected Dictionary<long, T> table;
        public long IdCount { get; protected set; }
        public BaseRepository()
        {
            IdCount = 0;
            table = new Dictionary<long, T>();
        }
        public long Save(T entry)
        {
            table.Add(IdCount, entry);
            return IdCount++;
        }
        public void Update(long id, T entry)
        {
            table[id] = entry;
        }
        public T GetEntityById(long id)
        {
            if (!table.ContainsKey(id)) throw new Exception("Invalid Id");
            return table[id];
        }
    }
}

