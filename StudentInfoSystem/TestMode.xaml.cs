using System;
using System.Windows;
using UserLogin;

namespace WpfApp1;

public partial class TestMode : Window
{
    private TestModeCommands _testModeCommands;
    

    public TestMode(User dbUser)
    {
        InitializeComponent();
        //_testModeCommands = new TestModeCommands(dbUser);
        DataContext = new TestModeCommands(dbUser);
    }
    
    
}