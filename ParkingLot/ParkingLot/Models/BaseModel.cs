namespace ParkingLot.Models
{
    public class BaseModel
    {
        public long Id { set; get; }
        public DateTime CreatedAt { private set; get; }
        public DateTime UpdatedAt { private set; get; }
        public BaseModel(long id)
        {
            Id = id;
            CreatedAt = DateTime.Now;
        }
        void SetUpdatedAt(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }
    }
}

