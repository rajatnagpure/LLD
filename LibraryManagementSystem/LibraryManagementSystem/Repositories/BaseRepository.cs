namespace LibraryManagementSystem.Repositories
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
        public long Add(T entry)
        {
            table.Add(IdCount, entry);
            return IdCount++;
        }
        public void Update(long id, T entry)
        {
            table[id] = entry;
        }
        public void Save()
        {
            System.Console.WriteLine("Saved!");
        }
        public T GetEntityById(long id)
        {
            if (!table.ContainsKey(id)) throw new Exception("Invalid Id");
            return table[id];
        }
    }
}