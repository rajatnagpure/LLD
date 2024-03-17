using Splitwise.Models;
namespace Splitwise.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository() { }
        public new long Save(User user)
        {
            User? usr = table.Values.FirstOrDefault(x => x.Email == user.Email);
            if (usr != null) throw new Exception("User with Email address already Exists!");
            table.Add(IdCount, user);
            return IdCount++;
        }
    }
}

