namespace LibraryManagementSystem.Models
{
    public class Bookcopy : BaseModel
    {
        public Book book { private set; get; }
        public Bookcopy(long id, Book book): base(id)
        {
            this.book = book;
        }
    }
}

