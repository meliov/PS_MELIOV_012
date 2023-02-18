using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class User
    {
        private String username;
        private String password;
        private String fakNum;
        private Int32 role;
        private DateTime created;
        private DateTime activeTo;

        public DateTime ActiveTo
        {
            get => activeTo;
            set => activeTo = value;
        }

        public DateTime Created
        {
            get => created;
            set => created = value;
        }


        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string FakNum
        {
            get => fakNum;
            set => fakNum = value;
        }

        public int Role
        {
            get => role;
            set => role = value;
        }

        public User()
        {
        }

        public User(string username, string password, string fakNum, int role, DateTime time, DateTime active)
        {
            Username = username;
            Password = password;
            FakNum = fakNum;
            Role = role;
            created = time;
            activeTo = active;
        }

        public override string ToString()
        {
            return " username: " + username + " password: " + password + " fakNum" + fakNum + " role: " + 
                   role.ToString() + "active to: ";
        }
        
    }
}