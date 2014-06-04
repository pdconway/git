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
        public static List<Mapper<string,string>> input = new List<Mapper<string,string>>();
        public static Dictionary<string, Mapper<string,User>> userDictionary = new Dictionary<string, Mapper<string,User>>();

        public UserData() { }

        public void addInput(Mapper<string,string> i)
        {
            input.Add(i);
        }
        public void removeInput(Mapper<string,string> i)
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
        public void addToDictionary(string i, Mapper<string,User> u)
        {
            userDictionary.Add(i, u);
        }
        public void removeFromDictionary(string i, Mapper<string,User> u)
        {
            userDictionary.Remove(i);
        }
    }
}
