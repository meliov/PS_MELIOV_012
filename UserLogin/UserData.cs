using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        static private List<User> testUsers;

        internal static List<User> TestUsers
        {
            get => testUsers;
            set => testUsers = value;
        }

        static public void ResetTestUserData()
        {
            if (testUsers == null)
            {
                testUsers = new List<User>()
                {
                    new User("Ivaan", "12345", " 12333", 1, DateTime.Now, DateTime.MaxValue),
                    new User("Dragan", "12345", " 12334", 4, DateTime.Now, DateTime.MaxValue),
                    new User("Petkan", "12345", " 12335", 4, DateTime.Now, DateTime.MaxValue)
                };
            }
        }

        static public User isUserPassCorrect(String username, String password)
        {
            return testUsers
                .FirstOrDefault(it => it.Username.Equals(username) && it.Password.Equals(password));

        }

        public static void setUserActveTo(string username, DateTime date)
        {
            foreach (var t in testUsers.Where(t => t.Username.Equals(username)))
            {
                t.ActiveTo = date;
                Console.WriteLine(t);
                Logger.LogActivity("Setting user activity to: " + username);
            }
        }
        
        public static void assignUserRole(string username, Int32 role)
        {
            Logger.LogActivity("Successfully logged in..");
            foreach (var user in testUsers.Where(user => user.Username.Equals(username)))
            {
                user.Role = role;
                Console.WriteLine(user);
                Logger.LogActivity("Setting user role to: " + username);
            }
        }

        public static void printAllUsers()
        {
            foreach (var testUser in TestUsers)
            {
                Console.WriteLine(testUser + "\n");
            }
        }
        
    }
}