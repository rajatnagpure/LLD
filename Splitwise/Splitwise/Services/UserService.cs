using Splitwise.Models;
using Splitwise.Repositories;

namespace Splitwise.Services
{
    public class UserService
    {
        private UserRepository UserRepository;
        public UserService(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public User CreateUser(string name, string email)
        {
            User user = new User(UserRepository.IdCount, name, email);
            UserRepository.Save(user);
            return user;
        }
        public void UpdateUserDetails(long id, string? name, string? email, string? mobile)
        {
            User user = UserRepository.GetEntityById(id);
            if (name != null) user.SetName(name);
            if (email != null) user.SetEmail(email);
            if (mobile != null) user.SetMobileNum(mobile);
            UserRepository.Update(user.Id, user);
        }

    }
}

