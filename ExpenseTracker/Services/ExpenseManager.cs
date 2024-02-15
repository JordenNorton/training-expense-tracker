using System.Text.Json;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public class ExpenseManager
{
    
    private List<Expense> _expenses = [];
    
    private static readonly string? ProjectDirectory = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName;
    private static readonly string FilePath = $"{ProjectDirectory}/expenses.json";

    public void LoadExpenses()
    {
        if (File.Exists(FilePath))
        {
            string json = File.ReadAllText(FilePath);
            
            _expenses = JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();        
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    private void SaveExpenses()
    {
        string json = JsonSerializer.Serialize(_expenses);
        
        File.WriteAllText(@$"{FilePath}", json);
    }

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
        SaveExpenses();
    }

    public void RemoveExpense(int expenseId)
    {
        _expenses.RemoveAll(expense => expense.Id == expenseId);
    }

    public void ListExpenses()
    {
        // var expenses = _expenses;
        
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