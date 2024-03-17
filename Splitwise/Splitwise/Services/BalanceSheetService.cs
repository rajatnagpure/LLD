using Splitwise.Models;
using Splitwise.Repositories;

namespace Splitwise.Services
{
    public class BalanceSheetService
    {
        private UserRepository UserRepository;
        private ExpenseRepository ExpenseRepository;
        private BalanceSheetRepository BalanceSheetRepository;
        public BalanceSheetService(UserRepository userRepository,
            ExpenseRepository expenseRepository,
            BalanceSheetRepository balanceSheetRepository)
        {
            ExpenseRepository = expenseRepository;
            UserRepository = userRepository;
            BalanceSheetRepository = balanceSheetRepository;
        }
        public BalanceSheet CreateBalanceSheet(string name, List<User> users)
        {
            BalanceSheet balanceSheet = new BalanceSheet(BalanceSheetRepository.IdCount, name, users);
            BalanceSheetRepository.Save(balanceSheet);
            return balanceSheet;
        }
        public void UpdateBalanceSheetTitle(BalanceSheet balanceSheet, string title)
        {
            balanceSheet.UpdateBalanceSheetName(title);
            BalanceSheetRepository.Update(balanceSheet.Id, balanceSheet);
        }
        public void AddUser(BalanceSheet balanceSheet, User user)
        {
            balanceSheet.AddUser(user);
            BalanceSheetRepository.Update(balanceSheet.Id ,balanceSheet);
        }
        public void RemoveUser(BalanceSheet balanceSheet, User user)
        {
            balanceSheet.RemoveUser(user);
            BalanceSheetRepository.Update(balanceSheet.Id, balanceSheet);
        }
        public ExpenseBuilder GetExpenseBuilder()
        {
            return new ExpenseBuilder(ExpenseRepository.IdCount);
        }
        public void AddExpense(BalanceSheet balanceSheet, Expense expense)
        {
            ExpenseRepository.Save(expense);
            balanceSheet.AddExpense(expense);
        }
        public Dictionary<User, float>? GetTotalBalanceForOtherUsers(BalanceSheet balanceSheet, User user)
        {
            if (!balanceSheet.Users.Contains(user)) return null;
            Dictionary<User, float> total = new Dictionary<User, float>();
            balanceSheet.UnSettledExpenses.ForEach(exp =>
            {
                if (exp.Payee == user)
                {
                    foreach (var key in exp.UserShare.Keys)
                    {
                        if (!total.ContainsKey(key))
                            total.Add(key, 0);
                        total[key] += -1 * exp.UserShare[key];
                    }
                }
                else
                {
                    total[exp.Payee] += exp.UserShare[user];
                }
            });
            total.Remove(user);
            return total;
        }
        public float GetMyTotalBalance(BalanceSheet balanceSheet, User user)
        {
            if (!balanceSheet.Users.Contains(user)) return 0;
            float total = 0.0f;
            balanceSheet.UnSettledExpenses.ForEach(exp =>
            {
                total += exp.UserShare[user];
            });
            return total;
        }
        public void SettleUpTillDate(BalanceSheet balanceSheet)
        {
            balanceSheet.SettleUp(balanceSheet.UnSettledExpenses);
        }
    }
}

