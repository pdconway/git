using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;

namespace Models.UserStuff
{
    //perhaps store this data on a database
    public class UserData
    {
        //to check to see if the user exists
        public static List<string> usernames = new List<string>();
        public static List<Mapper<string,string>> map = new List<Mapper<string,string>>();
        public static Dictionary<string, Mapper<string,User>> userDictionary = new Dictionary<string, Mapper<string,User>>();
        public static User currentUser;


        public UserData() { }

        //this creates a sample user
        public static void includeSampleData()
        {
            foreach (string user in UserData.usernames)
                if ("pdconway" == user) return;

            string username = "pdconway";
            string password = "twitty11";
            string firstName = "Paul";
            string lastName = "Conway";
            
            User newUser = new User(firstName, lastName);
            Mapper<string, User> newInput = new Mapper<string, User>(password, newUser);
            usernames.Add(username);
            UserData.userDictionary.Add(username, newInput);
        }

        public void addMap(Mapper<string,string> i)
        {
            map.Add(i);
        }
        public void removeMap(Mapper<string,string> i)
        {
            map.Remove(i);
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
