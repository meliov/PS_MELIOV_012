using System.Windows;
using System.Windows.Input;
using StudentInfoSystem;
using UserLogin;

namespace WpfApp1;

public class TestModeCommands
{
    private static User dbUser = null;
    
    public TestModeCommands(User user)
    {
       dbUser = user;
    }
    
    public new ICommand DelegateYesCommand => new DelegateCommand(() =>
    {
        MainWindow mainWindow = new MainWindow(null);
        App.Current.Windows[0].Close();
        mainWindow.Show();
        
    });

    public new ICommand DelegateNoCommand => new DelegateCommand(() =>
    {
        MainWindow mainWindow = new MainWindow(dbUser);
        App.Current.Windows[0].Close();
        mainWindow.Show();
    });
}