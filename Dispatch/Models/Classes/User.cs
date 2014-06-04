using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class User
    {
        private string firstName;
        private string lastName;

        public User(string first, string last)
        {
            this.firstName = first;
            this.lastName = last;
        }
        public string getFirstName()
        {
            return this.firstName;
        }
        public string getLastName()
        {
            return this.lastName;
        }
        public void setFirstName(string name)
        {
            this.firstName = name;
        }
        public void setLastName(string name)
        {
            this.lastName = name;
        }

    }
}
