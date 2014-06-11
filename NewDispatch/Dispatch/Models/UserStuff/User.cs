using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UserStuff
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
        //this is called in order to get the name of the user at the top of the page
        public string getName()
        {
            return String.Format(this.firstName + " " + this.lastName);
        }

    }
}
