namespace Splitwise.Models
{
    public class BaseModel
    {
        public long Id { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public BaseModel(long id)
        {
            Id = id;
            CreatedOn = DateTime.Now;
            UpdatedOn = null;
        }
        public void Update()
        {
            UpdatedOn = DateTime.Now;
        }
    }
}

