using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Services
{
    public class BorrowService
    {
        private LibraryRepository libraryRepository;
        private RackRepository rackRepository;
        private BorrowedBookRepository borrowedBookRepository;
        private UserRepository userRepository;
        public BorrowService(LibraryRepository libraryRepository,
            RackRepository rackRepository,
            BorrowedBookRepository borrowedBookRepository,
            UserRepository userRepository)
        {
            this.libraryRepository = libraryRepository;
            this.rackRepository = rackRepository;
            this.borrowedBookRepository = borrowedBookRepository;
            this.userRepository = userRepository;
        }
        public BorrowedBook BorrowBook(long userId, long libraryId, long bookId)
        {
            Library library = libraryRepository.GetEntityById(libraryId);
            int rackidx = library.racks.FindIndex(rack => rack.bookcopies.Find(bookcopy => bookcopy.book.id == bookId) != null);
            if (rackidx == -1) new InvalidOperationException("Book Unavailable");
            Bookcopy? bookcopy = library.racks[rackidx].bookcopies.Find(bookcopy => bookcopy.book.id == bookId);
            library.racks[rackidx].bookcopies.Remove(bookcopy);
            rackRepository.Save();
            BorrowedBook borrowedBook = new BorrowedBook(borrowedBookRepository.IdCount, bookcopy);
            borrowedBook.SetDueDate(DateTime.Now.AddDays(30));
            borrowedBookRepository.Add(borrowedBook);
            borrowedBookRepository.Save();
            User user = userRepository.GetEntityById(userId);
            user.AddBorrowedBook(borrowedBook);
            return borrowedBook;
        }
        public float ReturBook(long userId, long libraryId, long borrowedBookId)
        {
            Library library = libraryRepository.GetEntityById(libraryId);
            BorrowedBook borrowedBook = borrowedBookRepository.GetEntityById(borrowedBookId);
            int rackidx = library.racks.FindLastIndex(rack => rack.bookcopies.Find(bookcopy => bookcopy.book.id == borrowedBook.bookcopy.book.id) != null);
            library.racks[rackidx + 1].AddBookCopy(borrowedBook.bookcopy);
            borrowedBook.delete();
            borrowedBookRepository.Update(borrowedBook.id, borrowedBook);
            borrowedBookRepository.Save();

            //total fine calculation
            if(DateTime.Now < borrowedBook.dueDate)
            {
                TimeSpan diff = borrowedBook.dueDate - DateTime.Now;
                long fine = diff.Days * 1;
                User user = userRepository.GetEntityById(userId);
                user.AddFineAmt(fine);
                userRepository.Update(userId, user);
                userRepository.Save();
                return fine;
            }
            return 0.0f;
        }
    }
}

