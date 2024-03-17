namespace Splitwise.Models
{
    public class BalanceSheet: BaseModel 
    {
        public string Name { get; private set; }
        public List<Expense> SettledUpExpenses { get; private set; }
        public List<Expense> UnSettledExpenses { get; private set; }
        public DateTime LastSettleUp { get; private set; }
        public List<User> Users { get; private set; }
        public BalanceSheet(long id, string name, List<User> users): base(id)
        {
            Name = name;
            SettledUpExpenses = new List<Expense>();
            UnSettledExpenses = new List<Expense>();
            Users = users;
        }
        public void UpdateBalanceSheetName(string name)
        {
            Name = name;
        }
        public void AddExpense(Expense expense)
        {
            if(expense!=null)
                UnSettledExpenses.Add(expense);
        }
        public void AddUser(User user)
        {
            if (Users.Find(usr => usr.Id == user.Id) != null) throw new Exception("User already added");
            Users.Add(user);
        }
        public void RemoveUser(User user)
        {
            if (!Users.Remove(user)) throw new Exception("User Not Found!");
        }
        public void SettleUp(List<Expense> expenses)
        {
            LastSettleUp = DateTime.Now;
            expenses.ForEach(exp => UnSettledExpenses?.Remove(exp));
            SettledUpExpenses?.AddRange(expenses);
            base.Update();
        }
    }
}

