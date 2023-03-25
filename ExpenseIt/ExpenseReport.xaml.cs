using System.Windows;

namespace ExpenseIt;

public partial class ExpenseReport : Window
{
    public ExpenseReport()
    {
        InitializeComponent();
    }
    
    public ExpenseReport(object data) 
        : this() 
    { 
        // Bind to expense report data. 
        this.DataContext = data; 
    }
}