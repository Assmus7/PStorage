using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PStorage
{
    public class Users
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Users(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
