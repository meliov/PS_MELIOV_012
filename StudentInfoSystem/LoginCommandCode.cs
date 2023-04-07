using System;
using System.Windows;
using System.Windows.Input;
using StudentInfoSystem;
using UserLogin;

namespace WpfApp1;

public class LoginCommandCode : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        var list = parameter as LoginCredentialsList; 
        var username = list.Username;
        var pass = list.Password;
        // MessageBox.Show("Hello, world!" + " " + username + " " + pass);
        User dbUser = UserData.isUserPassCorrect(username, pass);
        if (dbUser == null)
        {
            list.ErrorMessage = "User with given credentials does not exist";
        }
        else
        {
            MainWindow mainWindow = new MainWindow(dbUser);
            (Application.Current.MainWindow as Window)?.Close();
            mainWindow.Show();
        }
    }

    public event EventHandler? CanExecuteChanged;
    
}