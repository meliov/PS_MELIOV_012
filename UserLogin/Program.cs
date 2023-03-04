using System;
using System.Collections.Generic;
using System.Linq;

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
                menu();
            }
        }

        static void errorMessage(String errorMsg)
        {
            Console.WriteLine("!!!" + errorMsg + "!!!");
        }

        static void menu()
        {
            List<String> permittedActions = new List<string>(){"0"};
            if (RightsGranted.RoleToRights.ContainsKey(LoginValidation.CurrentUserRole))
            {
                if (RightsGranted.RoleToRights.ContainsKey(LoginValidation.CurrentUserRole))
                {
                   var currentRights =  RightsGranted.RoleToRights[LoginValidation.CurrentUserRole];
                   if (currentRights.Contains(RoleRight.REDACTOR))
                   {
                       permittedActions.Add("1");
                       permittedActions.Add("2");
                   }
                   if (currentRights.Contains(RoleRight.OBSERVER))
                   {
                       permittedActions.Add("3");
                       permittedActions.Add("5");
                   }
                   if (currentRights.Contains(RoleRight.OBSERVER))
                   {
                       permittedActions.Add("4");
                   }
                       
                       
                }
                
               
            }
            permittedActions.Sort();
            Dictionary<String, String> consoloOptions = new Dictionary<String, String>
            {
                { "0", ": Exit" },
                { "1", ": Change user role" },
                { "2", ": Change user active date" },
                { "3", ": Users list" },
                { "4", ": View activity log file" },
                { "5", ": View current activity" },
            };
            while (true)
            {
                Console.WriteLine("Chose Option: ");
                foreach (var permittedAction in permittedActions)
                {
                    Console.WriteLine(permittedAction + consoloOptions[permittedAction]);
                }
                
                String input = Console.ReadLine();
                if (!permittedActions.Contains(input))
                {
                    input = "Wrong";
                }
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
                    foreach (var activity in  Logger.getAllSessionActivities())
                    {
                        Console.WriteLine(activity+ "\n");
                    }
                }
                else if (input.Equals("5"))
                {
                    foreach (var activity in  Logger.getCurrentSessionActivities())
                    {
                        Console.WriteLine(activity+ "\n");
                    }
                }else if (input.Equals("Wrong"))
                {
                    Console.WriteLine("Access Denied..");
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
