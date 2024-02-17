namespace ExpenseTracker.Models;

public class Expense
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public string? Category { get; set; }
    public DateTime Date { get; set; }
}