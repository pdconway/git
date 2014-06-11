using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Models.Classes;
using Windows.UI.Popups;
using Models.UserStuff;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dispatch.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private Mapper<string,User> map;

        public Login()
        {
            this.InitializeComponent();
            //this is sample data for users
            UserData.includeSampleData();
        }

        private void goToNewUserPage(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewUser));
        }

        private bool varifyUser(string str)
        {
            if (UserData.usernames.Contains(str))
            {
                this.map = UserData.userDictionary[str];
                if (this.pass.Password == this.map.key)
                {
                    //this is how the current user is stored in data so that we can 
                    //access the user information on the main page
                    UserData.currentUser = this.map.value;
                    return true;
                }
                    
                else
                    return false;
            }
            else
                return false;
        }

        async private void tryLogin(object sender, RoutedEventArgs e)
        {
            if ((this.user.Text != "") && (this.pass.Password != ""))
            {
                if (this.varifyUser(this.user.Text))
                {
                    Frame.Navigate(typeof(MainPage));
                }
                else
                {
                    MessageDialog warning = new MessageDialog("Incorrect Username and Password!");
                    await warning.ShowAsync();
                }
            }
            else
            {
                MessageDialog notFilled = new MessageDialog("Please Enter Username and Password");
                await notFilled.ShowAsync();
            }
        }






    }
}
