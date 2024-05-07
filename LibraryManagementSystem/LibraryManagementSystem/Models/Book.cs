namespace LibraryManagementSystem.Models
{
    public class Book: BaseModel
    {
        public string title { private set; get; }
        public List<string> authors { private set; get; }
        public List<string> pulishers { private set; get; }
        public Book(long id, string title, List<string>? authors = null, List<string>? publishers = null): base(id)
        {
            this.title = title;
            this.authors = authors ?? new List<string>();
            this.pulishers = publishers ?? new List<string>();
        }
        public void UpdateTitle(string title)
        {
            this.title = title;
            base.Update();
        }
        public void AddAuthor(string author)
        {
            this.authors.Add(author);
            base.Update();
        }
        public void AddPublisher(string publisher)
        {
            this.pulishers.Add(publisher);
            base.Update();
        }
    }
}

