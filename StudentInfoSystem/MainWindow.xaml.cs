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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student student;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            foreach (UIElement child in StudentInfo.Children)
            {
                if (child is TextBox)
                {
                    ((TextBox)child).Text = "";
                }
            }

            foreach (UIElement child in personalInfo.Children)
            {
                if (child is TextBox)
                {
                    ((TextBox)child).Text = "";
                }
            }
        }

        private void Disable(object sender, RoutedEventArgs e)
        {
            StudentInfo.IsEnabled = !StudentInfo.IsEnabled;
            personalInfo.IsEnabled = !personalInfo.IsEnabled;
        }

        private void Fill(object sender, RoutedEventArgs e)
        {
            var user = new User("Dragan", "12345", "12334", 4, DateTime.Now, DateTime.MaxValue);
            var student = StudentValidation.getStudentDataByUser(user);
            firstName.Text = student.FirstName;
            secondName.Text = student.MiddleName;
            lastName.Text = student.LastName;   
            fac.Text = student.Faculty;
            spec.Text = student.Specialty;
            oks.Text = student.EducationDegree;
            facNum.Text = student.FaqNumber;
            status.Text = student.Status;
            course.Text = student.Course.ToString();
            stream.Text = student.Stream.ToString();
            group.Text = student.Group.ToString();
        }
        
        private void Submit(object sender, RoutedEventArgs e)
        {
            try
            {
                student = new Student(firstName.Text, secondName.Text,
                    lastName.Text, fac.Text, spec.Text,
                    oks.Text, status.Text,
                    facNum.Text, int.Parse(course.Text), int.Parse(stream.Text), int.Parse(group.Text)
                );
            }
            catch (Exception er)
            {
                Console.WriteLine(er);
            }

            if (student == null)
             {
                 Clear(sender, e);
             }
        }
    }
}