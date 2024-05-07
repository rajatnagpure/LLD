namespace LibraryManagementSystem.Models
{
    public class Rack: BaseModel
    {
        public List<Bookcopy> bookcopies { private set; get; }
        public Rack(long id): base(id)
        {
            bookcopies = new List<Bookcopy>();
        }
        public void AddBookCopy(Bookcopy bookcopy)
        {
            bookcopies.Add(bookcopy);
            base.Update();
        }
        public void RemoveBookCopy(Bookcopy bookcopy)
        {
            bookcopies.Remove(bookcopy);
            base.Update();
        }
    }
}

