using System;
using System.Windows;
using System.Windows.Controls;

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
    
    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (this.DataContext != null)
        { ((LoginCredentialsList)this.DataContext).Password = ((PasswordBox)sender).Password; }

    }
}