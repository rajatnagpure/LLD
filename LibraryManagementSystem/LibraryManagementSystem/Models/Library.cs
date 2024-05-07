namespace LibraryManagementSystem.Models
{
    public class Library: BaseModel
    {
        public List<Rack> racks { private set; get; }
        public Library(long id): base(id)
        {
            racks = new List<Rack>();
        }
        public void AddRack(Rack rack)
        {
            racks.Add(rack);
        }
        public void RemoveRack(Rack rack)
        {
            racks.Remove(rack);
        }
    }
}

