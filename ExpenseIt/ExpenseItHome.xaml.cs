using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace ExpenseIt;

public partial class ExpenseItHome : Window, INotifyPropertyChanged
{
     private string mainCaptionText;
     public event PropertyChangedEventHandler? PropertyChanged;
    public List<Person> ExpenseDataSource { get; set; }
    
    private DateTime lastChecked; 
    public DateTime LastChecked 
    { 
        get => lastChecked;  
        set 
        { 
            lastChecked = value;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
            }
        } 
    }
    
    public ObservableCollection<string> PersonsChecked 
    { get; set;}

    
    
    public string MainCaptionText
    {
        get => mainCaptionText;
        set => mainCaptionText = value ?? throw new ArgumentNullException(nameof(value));
    }

    public ExpenseItHome()
    {
        this.DataContext = this;
        InitializeComponent();
        mockDataSoruce();
        MainCaptionText = "View Expense Report :"; 
        this.LastChecked = DateTime.Now;
        PersonsChecked = new ObservableCollection<string>();

        // ListBoxItem james = new ListBoxItem();
        // james.Content = "James";
        // peopleListBox.Items.Add(james);
        // ListBoxItem david = new ListBoxItem();
        // james.Content = "David";
        // peopleListBox.Items.Add(david);
        // peopleListBox.SelectedItem = james;
    }

    private void viewClick(object sender, RoutedEventArgs e)
    {
        ExpenseReport expenseReport = new ExpenseReport(peopleListBox.SelectedItem);
        expenseReport.Height = this.Height;
        expenseReport.Width = this.Width;
        expenseReport.Show();
    }

    private void peopleListBox_SelectionChanged_1(object sender, 
        SelectionChangedEventArgs e) 
    { 
        LastChecked = DateTime.Now; 
        PersonsChecked.Add((peopleListBox.SelectedItem as 
            Person).Name);
    }

    
    private void mockDataSoruce()
    {
        ExpenseDataSource = new List<Person>() 
        { 
            new Person() 
            { 
                Name="Mike", 
                Department ="Legal", 
                Expenses = new List<Expense>() 
                { 
                    new Expense() { ExpenseType="Lunch", ExpenseAmount =50 }, 
                    new Expense() { ExpenseType="Transportation", ExpenseAmount=50 } 
                } 
            }, 
            new Person() 
            { 
                Name ="Lisa", 
                Department ="Marketing", 
                Expenses = new List<Expense>() 
                { 
                    new Expense() { ExpenseType="Document printing", ExpenseAmount=50 }, 
                    new Expense() { ExpenseType="Gift", ExpenseAmount=125 } 
                } 
            }, 
            new Person() 
            { 
                Name="John", 
                Department ="Engineering", 
                Expenses = new List<Expense>() 
                { 
                    new Expense() { ExpenseType="Magazine subscription", ExpenseAmount=50 }, 
                    new Expense() { ExpenseType="New machine", ExpenseAmount=600 }, 
                    new Expense() { ExpenseType="Software", ExpenseAmount=500 } 
                } 
            }, 
            new Person() 
            { 
                Name="Mary", 
                Department ="Finance", 
                Expenses = new List<Expense>() 
                { 
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=100 } 
                } 
            }, 
            new Person() 
            { 
                Name="Theo", 
                Department ="Marketing", 
                Expenses = new List<Expense>() 
                { 
                    new Expense() { ExpenseType="Dinner", ExpenseAmount=100 } 
                } 
            } 
        };

    }
    

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}