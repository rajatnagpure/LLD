namespace Splitwise.Models
{
    public class User: BaseModel
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
        public User(long userId, string name, string email): base(userId)
        {
            Name = name;
            Email = email;
        }
        public void SetMobileNum(string mobile)
        {
            Mobile = mobile;
            base.Update();
        }
        public void SetEmail(string email)
        {
            Email = email;
            base.Update();
        }
        public void SetName(string name)
        {
            Name = name;
            base.Update();
        }
    }
}

