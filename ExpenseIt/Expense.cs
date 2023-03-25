using System;

namespace ExpenseIt;

public class Expense
{
    private string expenseType; 
    private double expenseAmount;

    public string ExpenseType
    {
        get => expenseType;
        set => expenseType = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double ExpenseAmount
    {
        get => expenseAmount;
        set => expenseAmount = value;
    }
}