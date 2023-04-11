using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserLogin;
using WpfApp1;
using WpfApp1.Properties;

namespace StudentInfoSystem
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student student;
        private User user;
        public List<string> StudStatusChoices { get; set; }

        private Visibility _disable;

        public Visibility Disable
        {
            get => _disable;
            set => _disable = value;
        }

        public MainWindow(User user)
        {
            FillStudStatusChoices();
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
            
            Student student;
            this.user = user;
            if (user != null)
            {
                Disable = Visibility.Hidden;
                student = StudentValidation.getStudentDataByUser(user);
            }
            else
            {
                Disable = Visibility.Visible;
                student = StudentValidation.getStudentDataByUserSortedAlphabetically();
            }
            //var student = StudentValidation.getStudentDataByUserSortedAlphabetically();
            DataContext = new StudentAndButtonContext(student, Disable);
            InitializeComponent();
            
        }

        private void clear()
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

        private void Logout(object sender, RoutedEventArgs e)
        {
            personalInfo.IsEnabled = false;
            StudentInfo.IsEnabled = false;
            clear();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            StudentInfo.IsEnabled = true;
            personalInfo.IsEnabled = true;
            Student student;
           // var user = new User("Dragan", "12345", "12334", 4, DateTime.Now, DateTime.MaxValue);
           if (user != null)
           {
               student = StudentValidation.getStudentDataByUser(user);
           }
           else
           {
               student = StudentValidation.getStudentDataByUserSortedAlphabetically();   
           }
           firstName.Text = student.FirstName;
            secondName.Text = student.MiddleName;
            lastName.Text = student.LastName;   
            fac.Text = student.Faculty;
            spec.Text = student.Specialty;
            oks.Text = student.EducationDegree;
            //facNum.Text = student.FaqNumber;
            status.Text = student.Status;//StudStatusChoices[0];
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
                 clear();
             }

            count.Text = TestStudentsIfEmpty().ToString();
        }

        private void FillStudStatusChoices()
        {
            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr
                    FROM StudStatus";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

        private Boolean TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            return countStudents < 1;
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudents)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }
    }
}