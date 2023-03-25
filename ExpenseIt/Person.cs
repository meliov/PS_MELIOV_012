using System;
using System.Collections.Generic;

namespace ExpenseIt;

public class Person
{
    private string name; 
    private string department; 
    private List<Expense> expenses;

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Department
    {
        get => department;
        set => department = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Expense> Expenses
    {
        get => expenses;
        set => expenses = value ?? throw new ArgumentNullException(nameof(value));
    }
}