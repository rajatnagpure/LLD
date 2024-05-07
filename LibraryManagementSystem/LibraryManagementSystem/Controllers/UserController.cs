using LibraryManagementSystem.Services;
namespace LibraryManagementSystem.Controllers
{
    public class UserController
    {
        private const string SUCCESS = "SUCCESS!";
        private UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        public string CreateUser(string name, string email)
        {
            long userId;
            try
            {
                userId = userService.CreateUser(name, email).id;
            }catch(Exception ex)
            {
                return ex.Message;
            }
            return userId.ToString();
        }
        public string UpdateUserDetails(long userId, string name = "", string email = "", string phone = "")
        {
            try
            {
                userService.UpdateUserDetails(userId, name, email, phone);
            }catch( Exception ex)
            {
                return ex.Message;
            }
            return SUCCESS;
        }
    }
}

