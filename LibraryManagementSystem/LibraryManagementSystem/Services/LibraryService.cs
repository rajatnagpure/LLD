using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
namespace LibraryManagementSystem.Services
{
    public class LibraryService
    {
        private LibraryRepository libraryRepository;
        private RackRepository rackRepository;
        private BookRepository bookRepository;
        private BookcopyRepository bookcopyRepository;
        public LibraryService(LibraryRepository libraryRepository,
            RackRepository rackRepository,
            BookRepository bookRepository,
            BookcopyRepository bookcopyRepository)
        {
            this.libraryRepository = libraryRepository;
            this.rackRepository = rackRepository;
            this.bookRepository = bookRepository;
            this.bookcopyRepository = bookcopyRepository;
        }
        public Library CreateLibrary()
        {
            Library library = new Library(libraryRepository.IdCount);
            libraryRepository.Add(library);
            return library;
        }
        public Rack AddRack(long libraryId)
        {
            Rack rack = new Rack(rackRepository.IdCount);
            rackRepository.Add(rack);
            rackRepository.Save();
            Library library = libraryRepository.GetEntityById(libraryId);
            library.AddRack(rack);
            libraryRepository.Save();
            return rack;
        }
        public Bookcopy AddBookCopy(long libraryId, long bookId)
        {
            Book book = bookRepository.GetEntityById(bookId);
            Bookcopy bookcopy = new Bookcopy(bookcopyRepository.IdCount, book);

            Library library = libraryRepository.GetEntityById(libraryId);

            int storeAt = library.racks.FindIndex(rack => rack.bookcopies.Find(bookcopy => bookcopy.book.id == bookId) == null);
            library.racks[storeAt].AddBookCopy(bookcopy);
            libraryRepository.Save();
            return bookcopy;
        }
    }
}