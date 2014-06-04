using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    //perhaps store this data on a database
    public class UserData
    {
        //to check to see if the user exists
        public static List<string> usernames = new List<string>();
        public static List<Input> input = new List<Input>();
        public static Dictionary<Input, User> userDictionary = new Dictionary<Input, User>();

        public UserData() { }

        public void addInput(Input i)
        {
            input.Add(i);
        }
        public void removeInput(Input i)
        {
            input.Remove(i);
        }
        public void addUser(string newUser)
        {
            usernames.Add(newUser);
        }
        public void removeUser(string oldUser)
        {
            usernames.Remove(oldUser);
        }
        public void addToDictionary(Input i, User u)
        {
            userDictionary.Add(i, u);
        }
        public void removeFromDictionary(Input i)
        {
            userDictionary.Remove(i);
        }
    }
}
