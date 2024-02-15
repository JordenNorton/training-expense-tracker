using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public class ExpenseManager
{
    private readonly List<Expense> _expenses = [];

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
    }

    public void ListExpenses()
    {
        foreach (var expense in _expenses)
        {
            Console.WriteLine($"ID: {expense.Id}, Amount: {expense.Amount}, Category: {expense.Category}, Date: {expense.Date}");
        }
    }
}