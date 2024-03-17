namespace Splitwise.Models
{
    public class Expense: BaseModel
    {
        public string Title { get; private set; }
        public float TotalAmt { get; private set; }
        public User Payee { get; private set; }
        public Dictionary<User, float> UserShare { get; private set; }
        public ExpenseTypeEnum ExpenseType { get; private set; }
        public Expense(long id, string title, float totalAmt, User payee, ExpenseTypeEnum expenseType, Dictionary<User, float> userShare): base(id)
        {
            Title = title;
            TotalAmt = totalAmt;
            Payee = payee;
            UserShare = userShare;
            ExpenseType = expenseType;
        }
        public void UpdateTotalExpense(float totalAmt, Dictionary<User, float> userShare)
        {
            TotalAmt = totalAmt;
            UserShare = userShare;
            base.Update();
        }
        public void ChangeTitle(string title)
        {
            Title = title;
            base.Update();
        }
    }
}

