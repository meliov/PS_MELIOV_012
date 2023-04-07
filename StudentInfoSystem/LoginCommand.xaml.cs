using System.Windows;

namespace WpfApp1;

public partial class LoginCommand : Window
{
    private LoginCommandCode _loginCommand = new LoginCommandCode();
    public LoginCommandCode LoginCommandCode
    {
        get { return _loginCommand; }
    }
    
    public LoginCommand()
    {
        InitializeComponent();
        DataContext = new LoginCredentialsList();
    }
}