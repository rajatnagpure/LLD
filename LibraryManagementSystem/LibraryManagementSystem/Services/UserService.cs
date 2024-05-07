using LibraryManagementSystem.Repositories;
using LibraryManagementSystem.Models;
namespace LibraryManagementSystem.Services
{
    public class UserService
    {
        private UserRepository userRepository;
        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User CreateUser(string name, string email)
        {
            User user = new User(userRepository.IdCount, name, email);
            if (userRepository.FindByEmailId(email)) new InvalidOperationException("Email Already Exists");
            userRepository.Add(user);
            userRepository.Save();
            return user;
        }
        public User UpdateUserDetails(long id, string? name, string? email, string? mobile)
        {
            User user = userRepository.GetEntityById(id);
            if (name != null) user.UpdateName(name);
            if (email != null) user.UpdateEmail(email);
            if (mobile != null) user.UpdaPhone(mobile);
            userRepository.Update(id, user);
            userRepository.Save();
            return user;
        }
    }
}