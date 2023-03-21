using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudentInfoSystem;
using UserLogin;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void signin(object sender, RoutedEventArgs e)
        {
            User dbUser = UserData.isUserPassCorrect(username.Text, pass.Password);
            if (dbUser == null)
            {
                errorMessage.Content = "User with given credentials does not exist";
            }
            else
            {
                MainWindow mainWindow = new MainWindow(dbUser);
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
