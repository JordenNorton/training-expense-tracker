using ExpenseTracker.Models;
using ExpenseTracker.Services;

var expenseManager = new ExpenseManager();

expenseManager.LoadExpenses(); //load the expense file at application startup

Console.WriteLine("Welcome to Personal Expense Tracker");

// expenseManager.AddExpense(new Expense {Id = 1, Amount = 200, Category = "Travel", Date = "21/02/2024"});
// expenseManager.AddExpense(new Expense {Id = 2, Amount = 100, Category = "Food", Date = "12/02/2024"});


expenseManager.ListExpenses();

Console.ReadLine();