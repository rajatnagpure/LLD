namespace LibraryManagementSystem.Models
{
    public class BorrowedBook: BaseModel
    {
        public Bookcopy bookcopy { private set; get; }
        public DateTime dueDate { private set; get; }
        public BorrowedBook(long id, Bookcopy bookcopy): base(id)
        {
            this.bookcopy = bookcopy;
        }
        public void SetDueDate(DateTime dueDate)
        {
            this.dueDate = dueDate;
        }
    }
}

