using Splitwise.Models;
using Splitwise.Services;
using Splitwise.Repositories;

BalanceSheetRepository balanceSheetRepository = new BalanceSheetRepository();
UserRepository userRepository = new UserRepository();
ExpenseRepository expenseRepository = new ExpenseRepository();

UserService userService = new UserService(userRepository);
BalanceSheetService balanceSheetService = new BalanceSheetService(userRepository, expenseRepository, balanceSheetRepository);

User user1 = userService.CreateUser("Rajat", "rajat@gmail.com");
User user2 = userService.CreateUser("Harsh", "harsh@gmail.com");
User user3 = userService.CreateUser("Anuj", "anuj@gmail.com");

BalanceSheet balanceSheet = balanceSheetService.CreateBalanceSheet("Groceries", new List<User> { user1, user2, user3 });

Expense expense = balanceSheetService
    .GetExpenseBuilder()
    .WithTitle("Milk")
    .WithExpenseType(ExpenseTypeEnum.EQUAL)
    .WithTotalAmt(30)
    .WithPayee(user1)
    .WithUserShare(new Dictionary<User, float> { { user1, 30 }, { user2, -10 }, { user3, -10 } })
    .Build();

balanceSheetService.AddExpense(balanceSheet, expense);

expense = balanceSheetService
    .GetExpenseBuilder()
    .WithTitle("Rent")
    .WithExpenseType(ExpenseTypeEnum.EXACT)
    .WithTotalAmt(39500)
    .WithPayee(user2)
    .WithUserShare(new Dictionary<User, float> { { user1, -13500 }, { user2, 39500 }, { user3, -13500 } })
    .Build();

balanceSheetService.AddExpense(balanceSheet, expense);

expense = balanceSheetService
    .GetExpenseBuilder()
    .WithTitle("Electricity")
    .WithExpenseType(ExpenseTypeEnum.PERCENTAGE)
    .WithTotalAmt(1000)
    .WithPayee(user3)
    .WithUserShare(new Dictionary<User, float> { { user1, -500 }, { user2, -250 }, { user3, 1000 } })
    .Build();

balanceSheetService.AddExpense(balanceSheet, expense);

System.Console.WriteLine("My total Balance is: " + balanceSheetService.GetMyTotalBalance(balanceSheet, user1));
Dictionary<User, float>? user1Balance = balanceSheetService.GetTotalBalanceForOtherUsers(balanceSheet, user1);
foreach(var key in user1Balance.Keys)
{
    System.Console.WriteLine("User " + key.Name + " Amount: " + user1Balance[key]);
}
System.Console.ReadKey();