using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1;

public class  LoginCredentialsList: INotifyPropertyChanged 
{ 
    string _username = ""; 
    string _password = "";
    private string _errorMessage = "";

    LoginCommandCode _loginCommandCode = new LoginCommandCode();
 

    public LoginCommandCode LoginCommandCode
    {
        get { return _loginCommandCode;  }
    }
    public LoginCredentialsList() 
    { 
        Credentials = new ObservableCollection<string>(); 
    } 
    public string Username 
    { 
        get { return _username; } 
        set
        { 
            if (_username != value) 
            { 
                _username = value; 
                OnPropertyChanged("Username"); 
            } 
        } 
    } 
    public string Password 
    { 
        get { return _password; } 
        set
        { 
            if (_password != value) 
            { 
                _password = value; 
                OnPropertyChanged("Password"); 
            } 
        } 
    }
    
    public string ErrorMessage 
    { 
        get { return _errorMessage; } 
        set
        { 
            if (_errorMessage != value) 
            { 
                _errorMessage = value; 
                OnPropertyChanged("ErrorMessage"); 
            } 
        } 
    }
    public ObservableCollection<string> Credentials { get; private set; } 
    private void OnPropertyChanged(string property) 
    { 
        if (PropertyChanged != null) 
        { 
            PropertyChanged(this, new PropertyChangedEventArgs(property)); 
        } 
    } 
    public event PropertyChangedEventHandler PropertyChanged; 
}