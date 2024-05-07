using LibraryManagementSystem.Models;
namespace LibraryManagementSystem.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository() { }
        public bool FindByEmailId(string email)
        {
            return table.Values.FirstOrDefault(x => x.email == email) != null;
        }
    }
}

