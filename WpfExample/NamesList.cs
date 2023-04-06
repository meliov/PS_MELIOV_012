using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfExample;

public class NamesList : INotifyPropertyChanged 
{ 
    string _firstName = ""; 
    string _lastName = ""; 
    string _selectedName; 
    
    AddCommand _addNameCommand = new AddCommand();
    private RemoveCommand _removeCommand = new RemoveCommand();
    public AddCommand AddNameCommand
    {
        get { return _addNameCommand; }
    }

    public RemoveCommand RemoveCommand
    {
        get { return _removeCommand;  }
    }
    public NamesList() 
    { 
        Names = new ObservableCollection<string>(); 
    } 
    public string FirstName 
    { 
        get { return _firstName; } 
        set
        { 
            if (_firstName != value) 
            { 
                _firstName = value; 
                OnPropertyChanged("FirstName"); 
            } 
        } 
    } 
    public string LastName 
    { 
        get { return _lastName; } 
        set
        { 
            if (_lastName != value) 
            { 
                _lastName = value; 
                OnPropertyChanged("LastName"); 
            } 
        } 
    } 
    public string SelectedName 
    { 
        get { return _selectedName; } 
        set
        { 
            if (_selectedName != value) 
            { 
                _selectedName = value; 
                OnPropertyChanged("SelectedName"); 
            } 
        } 
    } 
    public ObservableCollection<string> Names { get; private set; } 
    private void OnPropertyChanged(string property) 
    { 
        if (PropertyChanged != null) 
        { 
            PropertyChanged(this, new PropertyChangedEventArgs(property)); 
        } 
    } 
    public event PropertyChangedEventHandler PropertyChanged; 
}