namespace LibraryManagementSystem.Models
{
    public class BaseModel
    {
        public long id { get; private set; }
        public DateTime createdOn { get; private set; }
        public DateTime updatedOn { get; private set; }
        public DateTime deletedOn { get; private set; }
        public bool deleted { get; private set; }
        public BaseModel(long id)
        {
            this.id = id;
            createdOn = DateTime.Now;
            deleted = false;
        }
        public void Update()
        {
            updatedOn = DateTime.Now;
        }
        public void delete()
        {
            deletedOn = DateTime.Now;
            deleted = true;
        }
    }
}

