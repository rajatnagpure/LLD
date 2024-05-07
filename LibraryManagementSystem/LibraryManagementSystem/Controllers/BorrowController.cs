using LibraryManagementSystem.Services;
namespace LibraryManagementSystem.Controllers
{
    public class BorrowController
    {
        private const string SUCCESS = "SUCCESS!";
        private BorrowService borrowService;
        public BorrowController(BorrowService borrowService)
        {
            this.borrowService = borrowService;
        }
        public string BorrowBook(long userId, long libraryId, long bookId)
        {
            try
            {
                return borrowService.BorrowBook(userId, libraryId, bookId).id.ToString();
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string ReturBook(long userId, long libraryId, long borrowedBookId)
        {
            try
            {
                return borrowService.ReturBook(userId, libraryId, borrowedBookId).ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

