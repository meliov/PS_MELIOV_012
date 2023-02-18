using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class LoginValidation
    {
        private static String username;
        
        private String password;

        private String errorMessage;

        private ActionOnError errorFunction;

        private static UserRoles currentUserRole = UserRoles.ANONYMOUS;
        
        internal static UserRoles CurrentUserRole
        {
            get => currentUserRole;
            private set => currentUserRole = value;
        }

        
        public static string CurrentUsername
        {
            get => username;
            set => username = value;
        }
        
        public LoginValidation(string username, string password, ActionOnError errorFunction)
        {
            LoginValidation.username = username;
            this.password = password;
            this.errorFunction = errorFunction;
        }


        public bool validateUserInput(User user)
        {
            if (String.IsNullOrEmpty(username)) 
            { 
                errorMessage = "Given bad username";
                errorFunction(errorMessage);
                return false; 
            }else if (username.Length < 5)
            {
                errorMessage = "Username must contain at least 5 symbols";
                errorFunction(errorMessage);
                return false; 
            }
            if (String.IsNullOrEmpty(password)) 
            { 
                errorMessage = "Given bad password"; 
                errorFunction(errorMessage);
                return false; 
            } else if (password.Length < 5)
            {
                errorMessage = "Password must contain at least 5 symbols";
                errorFunction(errorMessage);
                return false; 
            }
            //this will probably be replaced by fetching form db
            User dbUser = UserData.isUserPassCorrect(username, password);
            if (dbUser == null)
            {
                errorMessage = "User with given credentials does not exist";
                errorFunction(errorMessage);
                return false; 
            }
            user.Username = dbUser.Username;
            user.Password = dbUser.Password;
            user.FakNum = dbUser.FakNum;
            user.Role = dbUser.Role;
            CurrentUserRole = (UserRoles)user.Role;
            Logger.LogActivity("Successfully logged in..");
            return true;
        }
        
        public delegate void ActionOnError(string errorMsg);

    
    }
    
}