using LibraryManagementSystem.Services;
namespace LibraryManagementSystem.Controllers
{
    public class LibraryController
    {
        private const string SUCCESS = "SUCCESS!";
        private LibraryService libraryService;
        public LibraryController(LibraryService libraryService)
        {
            this.libraryService = libraryService;
        }
        public long CreateLibrary()
        {
            return libraryService.CreateLibrary().id;
        }
        public string AddRack(long libraryId)
        {
            try
            {
                return libraryService.AddRack(libraryId).id.ToString();
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string AddBookCopy(long libraryId, long rackId)
        {
            try
            {
                return libraryService.AddBookCopy(libraryId, rackId).id.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

