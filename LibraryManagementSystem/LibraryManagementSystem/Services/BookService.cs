using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
namespace LibraryManagementSystem.Services
{
    public class BookService
    {
        private BookRepository bookRepository;
        public BookService(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public Book AddBook(string title, List<string> authors, List<string> publishers)
        {
            Book book = new Book(bookRepository.IdCount, title, authors, publishers);
            bookRepository.Add(book);
            bookRepository.Save();
            return book;
        }
        public Book UpdateTitle(long bookId, string title)
        {
            Book book = bookRepository.GetEntityById(bookId);
            book.UpdateTitle(title);
            bookRepository.Update(bookId, book);
            bookRepository.Save();
            return book;
        }
        public Book AddAuthor(long bookId, string author)
        {
            Book book = bookRepository.GetEntityById(bookId);
            book.AddAuthor(author);
            bookRepository.Update(bookId, book);
            bookRepository.Save();
            return book;
        }
        public Book AddPublisher(long bookId, string publisher)
        {
            Book book = bookRepository.GetEntityById(bookId);
            book.AddPublisher(publisher);
            bookRepository.Update(bookId, book);
            bookRepository.Save();
            return book;
        }
    }
}

