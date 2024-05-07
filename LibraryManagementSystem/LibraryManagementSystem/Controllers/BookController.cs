using LibraryManagementSystem.Services;
namespace LibraryManagementSystem.Controllers
{
    public class BookController
    {
        private const string SUCCESS = "SUCCESS!";
        private BookService bookService;
        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }
        public long AddBook(string title, List<string> authors, List<string> publishers)
        {
            return bookService.AddBook(title, authors, publishers).id;
        }
        public string UpdateTitle(long bookId, string title)
        {
            try
            {
                bookService.UpdateTitle(bookId, title);
            }catch(Exception ex)
            {
                return ex.Message;
            }
            return SUCCESS;
        }
        public string AddAuthor(long bookId, string author)
        {
            try
            {
                bookService.AddAuthor(bookId, author);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return SUCCESS;
        }
        public string AddPublisher(long bookId, string publisher)
        {
            try
            {
                bookService.AddPublisher(bookId, publisher);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return SUCCESS;
        }
    }
}

