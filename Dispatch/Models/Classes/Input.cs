using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Input
    {
        private string username;
        private string password;

        public Input(string user, string pass)
        {
            this.username = user;
            this.password = pass;
        }

        public string getUser()
        {
            return this.username;
        }
        public string getPass()
        {
            return this.password;
        }
        public void setUser(string user)
        {
            this.username = user;
        }
    }
}
