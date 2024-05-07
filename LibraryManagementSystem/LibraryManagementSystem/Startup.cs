using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Controllers;

namespace LibraryManagementSystem
{
    public class Startup
    {
        private static Startup? instance = null;
        private BookController bookController;
        private BorrowController borrowController;
        private LibraryController libraryController;
        private UserController userController;
        private Startup()
        {
            BookRepository bookRepository = new BookRepository();
            BookcopyRepository bookcopyRepository = new BookcopyRepository();
            BorrowedBookRepository borrowedBookRepository = new BorrowedBookRepository();
            LibraryRepository libraryRepository = new LibraryRepository();
            RackRepository rackRepository = new RackRepository();
            UserRepository userRepository = new UserRepository();

            BookService bookService = new BookService(bookRepository);
            BorrowService borrowService = new BorrowService(libraryRepository, rackRepository, borrowedBookRepository, userRepository);
            LibraryService libraryService = new LibraryService(libraryRepository, rackRepository, bookRepository, bookcopyRepository);
            UserService userService = new UserService(userRepository);

            bookController = new BookController(bookService);
            borrowController = new BorrowController(borrowService);
            libraryController = new LibraryController(libraryService);
            userController = new UserController(userService);
        }
        public static Startup getInstance()
        {
            if(instance == null)
            {
                instance = new Startup();
            }
            return instance;
        }

        public BookController GetBookController()
        {
            return bookController;
        }

        public BorrowController GetBorrowController()
        {
            return borrowController;
        }

        public LibraryController GetLibraryController()
        {
            return libraryController;
        }

        public UserController GetUserController()
        {
            return userController;
        }
    }
}

