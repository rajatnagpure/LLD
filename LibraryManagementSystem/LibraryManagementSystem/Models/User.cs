namespace LibraryManagementSystem.Models
{
    public class User:BaseModel
    {
        public string name { private set; get; }
        public string phone { private set; get; }
        public string email { private set; get; }
        public float fineAmt { private set; get; }
        public List<BorrowedBook> borrowedBooks { private set; get; }
        public User(long id, string name, string email = "", string phone = ""): base(id)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            fineAmt = 0.0f;
            borrowedBooks = new List<BorrowedBook>();
        }
        public void UpdateName(string name)
        {
            this.name = name;
            base.Update();
        }
        public void UpdaPhone(string phone)
        {
            this.phone = phone;
            base.Update();
        }
        public void UpdateEmail(string email)
        {
            this.email = email;
            base.Update();
        }
        public void AddFineAmt(float fineAmt)
        {
            this.fineAmt += fineAmt;
            base.Update();
        }
        public void ReduceFineAmt(float fineAmt)
        {
            this.fineAmt -= fineAmt;
            base.Update();
        }
        public void AddBorrowedBook(BorrowedBook borrowedBook)
        {
            borrowedBooks.Add(borrowedBook);
            base.Update();
        }
        public void RemoveBorrowedBook(BorrowedBook borrowedBook)
        {
            borrowedBooks.Remove(borrowedBook);
            base.Update();
        }
    }
}

