namespace Splitwise.Models
{
    public class ExpenseBuilder
    {
        private long Id;
        private string Title;
        private float TotalAmt;
        private User? Payee;
        private Dictionary<User, float> UserShare;
        private ExpenseTypeEnum ExpenseType;
        public ExpenseBuilder(long id)
        {
            Id = id;
            UserShare = new Dictionary<User, float>();
            TotalAmt = 0.0f;
            Payee = null;
            Title = "";
        }

        public ExpenseBuilder WithTitle(string title)
        {
            this.Title = title;
            return this;
        }

        public ExpenseBuilder WithTotalAmt(float totalAmt)
        {
            if (!CheckForUserShareEquality()) throw new Exception("Total Isn't Matching");
            this.TotalAmt = totalAmt;
            return this;
        }

        public ExpenseBuilder WithPayee(User payee)
        {
            this.Payee = payee;
            return this;
        }

        private bool CheckForUserShareEquality()
        {
            if (TotalAmt == 0.0f || UserShare.Count == 0) return true;
            float collected = 0.0f;
            foreach (var key in UserShare.Keys) collected += UserShare[key];
            if (collected != TotalAmt) return false;
            return true;
        }

        public ExpenseBuilder WithUserShare(Dictionary<User, float> userShare)
        {
            if (!CheckForUserShareEquality()) throw new Exception("Total Isn't Matching");
            this.UserShare = userShare;
            return this;
        }

        public ExpenseBuilder WithExpenseType(ExpenseTypeEnum expenseType)
        {
            this.ExpenseType = expenseType;
            return this;
        }

        public Expense Build()
        {
            return new Expense(Id, Title, TotalAmt, Payee, ExpenseType, UserShare);
        }
    }
}

