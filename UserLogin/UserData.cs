using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        private static UserContext context = new UserContext();
        static private List<User> testUsers;

        internal static List<User> TestUsers
        {
            get => testUsers;
            set => testUsers = value;
        }

        static public void ResetTestUserData()
        {
            if (TestUserIfEmpty())
            {
                CopyTestUsers();
            }

            if (testUsers == null || TestUserIfEmpty())
            {
                testUsers = new List<User>()
                {
                    new User("Ivaan", "12345", " 12333", 1, DateTime.Now, DateTime.MaxValue),
                    new User("Dragan", "12345", " 12334", 4, DateTime.Now, DateTime.MaxValue),
                    new User("Petkan", "12345", " 12335", 4, DateTime.Now, DateTime.MaxValue)
                };
            }
            else
            {
                testUsers = context.Users.ToList();
            }
        }

        private static Boolean TestUserIfEmpty()
        {
            IEnumerable<User> queryStudents = context.Users;
            int countUsers = queryStudents.Count();

            return countUsers < 1;
        }

        private static void CopyTestUsers()
        {
            UserContext context = new UserContext();
            foreach (User us in testUsers)
            {
                context.Users.Add(us);
            }

            context.SaveChanges();
        }

        static public User isUserPassCorrect(String username, String password)
        {
            return context.Users
                .FirstOrDefault(it => it.Username.Equals(username) && it.Password.Equals(password));
        }

        public static void setUserActveTo(string username, DateTime date)
        {
            User usr =
                (from u in context.Users
                    where u.Username == username
                    select u).First();
            usr.ActiveTo = date;
            context.SaveChanges();
            Console.WriteLine(usr);
            Logger.LogActivity("Setting user activity to: " + username);
        }

        public static void assignUserRole(string username, int role)
        {
            User usr =
                (from u in context.Users
                    where u.Username == username
                    select u).First();
            usr.Role = role;
            context.SaveChanges();
            Console.WriteLine(usr);
            Logger.LogActivity("Setting user role to: " + username);
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