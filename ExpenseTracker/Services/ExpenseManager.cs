using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public class ExpenseManager
{
    private readonly List<Expense> _expenses = [];

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
    }

    public void RemoveExpense(int expenseId)
    {
        _expenses.RemoveAll(expense => expense.Id == expenseId);
    }

    public void ListExpenses()
    {
        foreach (var expense in _expenses)
        {
            Console.WriteLine($"ID: {expense.Id}, Amount: {expense.Amount}, Category: {expense.Category}, Date: {expense.Date}");
        }
    }

    public void SearchExpensesId(int searchTerm)
    {
        var searchResults = _expenses.Where(expense => expense.Id.Equals(searchTerm)).ToList();

        if (searchResults.Any())
            foreach (var expense in searchResults)
            {
                Console.WriteLine($"Id: {expense.Id}, Amount: {expense.Amount}, Category: {expense.Category}, Date: {expense.Date}");
            }
    }

    public void SearchExpensesDate(string searchTerm)
    {
        var searchResults = _expenses.Where(expense => expense.Date != null && expense.Date.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        foreach (var expense in searchResults)
        {
            Console.WriteLine($"Id: {expense.Id}, Amount: {expense.Amount}, Category: {expense.Category}, Date: {expense.Date}");
        }
    }

    public void SearchExpenseCategory(string searchTerm)
    {
        var searchResults = _expenses.Where(expense => expense.Category != null && expense.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();

        foreach (var expense in searchResults)
        {
            Console.WriteLine($"Id: {expense.Id}, Amount: {expense.Amount}, Category: {expense.Category}, Date: {expense.Date}");
        }
    }

}