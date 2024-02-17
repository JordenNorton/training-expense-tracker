using System.Diagnostics;
using System.Globalization;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

var expenseManager = new ExpenseManager();

expenseManager.LoadExpenses(); //load the expense file at application startup

Console.WriteLine("Welcome to Personal Expense Tracker");

// expenseManager.AddExpense(new Expense {Id = 1, Amount = 200, Category = "Travel", Date = "21/02/2024"});
// expenseManager.AddExpense(new Expense {Id = 2, Amount = 100, Category = "Food", Date = "12/02/2024"});
bool continueRunning = true;
while (continueRunning)
{
    Console.WriteLine("What would you like to do? \n 1: Add expense \n 2: Remove expense \n 3: View all expenses \n 4: Search by ID \n" +
                      " 5: Search by Category \n 6: Search by Date \n 7: Save & Quit");

// expenseManager.ListExpenses();

    int choice = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

    switch (choice)
    {
        case 1:
            AddExpense();
            break;
        case 2:
            RemoveExpense();
            break;
        case 3:
            ListExpenses();
            break;
        case 4:
            SearchExpenseId();
            break;
        case 5:
            SearchExpenseCategory();
            break;
        case 6:
            SearchExpenseDate();
            break;
        case 7:
            continueRunning = false;
            break;
            
    }

    continue;


    void AddExpense()
    {
        Console.WriteLine("Enter ID");
        int id = int.TryParse(Console.ReadLine(), out int idResult) ? idResult : 0;
        Console.WriteLine("Enter Amount");
        int amount = int.TryParse(Console.ReadLine(), out int amountResult) ? amountResult : 0;
        Console.WriteLine("Enter Category");
        string? category = Console.ReadLine();
        Console.WriteLine("Enter Date");
        DateTime date = Convert.ToDateTime(Console.ReadLine());

        expenseManager.AddExpense(new Expense { Id = id, Amount = amount, Category = category, Date = date });
        Console.WriteLine("Expense added successfully");
    }

    void RemoveExpense()
    {
        Console.WriteLine("Enter expense ID #");
        int id = int.TryParse(Console.ReadLine(), out int idResult) ? idResult : 0;
        
        expenseManager?.RemoveExpense(id);
        Console.WriteLine($"Expense {id} removed");
    }

    void ListExpenses()
    {
        expenseManager?.ListExpenses();
        Console.WriteLine("\nPress enter to exit");
        Console.ReadLine();
    }

    void SearchExpenseId()
    {
        Console.WriteLine("Enter expense ID #:");
        int id = int.TryParse(Console.ReadLine(), out int idResult) ? idResult : 0;
        expenseManager?.SearchExpenseId(id);
        Console.WriteLine("\nPress enter to exit");
        Console.ReadLine();
    }

    void SearchExpenseCategory()
    {
        Console.WriteLine("Enter expense category:");
        string? category = Console.ReadLine();
        expenseManager?.SearchExpenseCategory(category);
        Console.WriteLine("\nPress enter to exit");
        Console.ReadLine();
    }
    
    void SearchExpenseDate()
    {
        Console.WriteLine("Enter expense date (dd/MM/yyyy):");
        string? dateString = Console.ReadLine();
        
        DateTime date;

        bool success = DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture,
            DateTimeStyles.None, out date);

        if (success)
        {
            // If parsing is successful, search for expenses on that date
            expenseManager?.SearchExpenseDate(date);
        }
        else
        {
            // If parsing fails, inform the user
            Console.WriteLine("Invalid date format. Please use the format dd/MM/yyyy.");
        }

        Console.WriteLine("\nPress enter to exit");
        Console.ReadLine();
    }

}