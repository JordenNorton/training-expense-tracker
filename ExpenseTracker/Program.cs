using ExpenseTracker.Models;
using ExpenseTracker.Services;

var expenseManager = new ExpenseManager();

Console.WriteLine("Welcome to Personal Expense Tracker");

expenseManager.AddExpense(new Expense {Id = 1, Amount = 200, Category = "Travel", Date = "21/02/2024"});

expenseManager.ListExpenses();

Console.ReadLine();