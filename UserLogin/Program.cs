using System;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Insert Username: ");
            String username = Console.ReadLine();
            Console.WriteLine("Insert Password: ");
            String password = Console.ReadLine();
            LoginValidation loginValidation = new LoginValidation(username, password, errorMessage);
            UserData.ResetTestUserData();
            User user = new User();
            if (loginValidation.validateUserInput(user)) 
            {
                Console.WriteLine("successfully logged in user -> " + user);
                roleToString();
                Console.WriteLine("user role is -> " + LoginValidation.CurrentUserRole);
                if (LoginValidation.CurrentUserRole == UserRoles.ADMIN)
                {
                    adminMenu();
                }
            }
        }

        static void errorMessage(String errorMsg)
        {
            Console.WriteLine("!!!" + errorMsg + "!!!");
        }

        static void adminMenu()
        {
            while (true)
            {
                Console.WriteLine("Chose Option: ");
                Console.WriteLine("0: Exit ");
                Console.WriteLine("1: Change user role ");
                Console.WriteLine("2: Change user active date ");
                Console.WriteLine("3: Users list");
                Console.WriteLine("4: View activity log file");
                Console.WriteLine("5: View current activity");
                String input = Console.ReadLine();
                if (input.Equals("1"))
                {
                    Console.WriteLine("Insert role(number from 1 to 5)");
                    String role = Console.ReadLine();
                    Console.WriteLine("Insert Username");
                    String username = Console.ReadLine();
                    if (role != null && role[0] >= '1' && role[0] <= '5' && role.Length == 1)
                    {
                        UserData.assignUserRole(username, Convert.ToInt32(role));
                    }
                    else
                    {
                        Console.WriteLine("Wrong input! Exiting..");
                    }
                }
                else if (input.Equals("2"))
                {
                    Console.WriteLine("Insert Date: ");
                    String date = Console.ReadLine();
                    Console.WriteLine("Insert Username");
                    String username = Console.ReadLine();
                    try
                    {
                        UserData.setUserActveTo(username, Convert.ToDateTime(date));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Wrong date input..");
                    }
                }
                else if (input.Equals("3"))
                {
                    UserData.printAllUsers();
                }
                else if (input.Equals("4"))
                {
                    Logger.getAllSessionActivities();
                }
                else if (input.Equals("5"))
                {
                    Logger.getCurrentSessionActivities();
                }
                else
                {
                    Console.WriteLine("Exiting..");
                    break;
                }
            }
        }

        private static void roleToString()
        {
            switch (LoginValidation.CurrentUserRole) //??
            {
                case   UserRoles.ADMIN:
                    Console.WriteLine("Admin just logged in");
                    break;
                case   UserRoles.STUDENT:
                    Console.WriteLine("Student just logged in");
                    break;
                case   UserRoles.INSPECTOR:
                    Console.WriteLine("Inspector just logged in");
                    break;
                case   UserRoles.PROFESSOR:
                    Console.WriteLine("Professor just logged in");
                    break;
                case   UserRoles.ANONYMOUS:
                    Console.WriteLine("ANONYMOUS just logged in");
                    break;
                default:
                    Console.WriteLine("This Role aint defined yet bruh");
                    break;
            }
        }
    }
    

}
