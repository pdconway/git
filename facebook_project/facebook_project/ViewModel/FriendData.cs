using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebook_project.ViewModel
{
    class FriendData
    {
        //Declaring ObservableCollection has added advantage - can use ?Expression Blend? to easily bind
        //collection data to the UI without having to write complicated DataModel<->UI synchronization logic. 
        //remember when you used observables for the game and you had to notify the board of the players move
        //emphasis on the notify************
        private static ObservableCollection<Friend> friends = new ObservableCollection<Friend>();
        public static ObservableCollection<Friend> Friends
        {
            get
            {
                return friends;
            }
        }
        private static ObservableCollection<Friend> selectedFriends = new ObservableCollection<Friend>();
        public static ObservableCollection<Friend> SelectedFriends
        {
            get
            {
                return selectedFriends;
            }
        }

    }
}
