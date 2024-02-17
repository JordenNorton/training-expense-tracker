using System.Diagnostics;
using System.Globalization;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

var expenseManager = new ExpenseManager();
var menuHandler = new MenuHandler(expenseManager);
expenseManager.LoadExpenses(); //load the expense file at application startup

Console.WriteLine("Welcome to Personal Expense Tracker");

menuHandler.DisplayMenu();