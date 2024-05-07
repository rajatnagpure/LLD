using LibraryManagementSystem;
using LibraryManagementSystem.Controllers;

Console.WriteLine("Wel-Come to Library Management System");

BookController bookController = Startup.getInstance().GetBookController();
BorrowController borrowController = Startup.getInstance().GetBorrowController();
LibraryController libraryController = Startup.getInstance().GetLibraryController();
UserController userController = Startup.getInstance().GetUserController();

long libraryId = libraryController.CreateLibrary();
long userId = Convert.ToInt32(userController.CreateUser("Rajat", "rajat@abc.com"));
long bookId = bookController.AddBook("Fifth Agreement", new List<string>{"toltec"}, new List<string>{ "Anuj"});
libraryController.AddRack(libraryId);
libraryController.AddBookCopy(libraryId, bookId);

long borrowBookId = Convert.ToInt32(borrowController.BorrowBook(userId, libraryId, bookId));
borrowController.ReturBook(userId, libraryId, borrowBookId);

Console.ReadKey();