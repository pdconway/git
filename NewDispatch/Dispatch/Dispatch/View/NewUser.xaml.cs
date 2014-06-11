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
    public sealed partial class NewUser : Page
    {
        //KEY THAT IS NEEDED IN ORDER TO CREATE A NEW USER!
        private User newUser;
        private Mapper<string, User> newInput;
        //private Input newInput;
        private string keyBinary;

        public NewUser()
        {
            this.InitializeComponent();
            this.keyBinary = Convert.ToString(Key.K, 2);
            this.addkey();
            
        }

        //temporary method to add the key value to the key textbox
        private void addkey()
        {
            this.key.Text = this.keyBinary;
        }

        //this method is called when the button is pushed 
        async private void addNewUser(object sender, TappedRoutedEventArgs e)
        {
            if (this.key.Text == this.keyBinary)
            {
                if ((this.first.Text != "") && (this.last.Text != "") && (this.user.Text != "") && (this.pass.Password != "") && (this.varifypass.Password != ""))
                {
                    if (this.pass.Password != this.varifypass.Password)
                    {
                        MessageDialog notEqual = new MessageDialog("Passwords are not equal");
                        await notEqual.ShowAsync();
                        return;
                    }
                    foreach (string user in UserData.usernames)
                    {
                        if (this.user.Text == user)
                        {
                            MessageDialog dail = new MessageDialog("Username is already taken");
                            await dail.ShowAsync();
                            return;
                        }
                    }
                    if (this.pass.Password.Length >= 8)
                    {
                        newUser = new User(this.first.Text, this.last.Text);                
                        newInput = new Mapper<string, User>(this.pass.Password, newUser);
                       // UserData.input.Add(newInput);
                        UserData.usernames.Add(this.user.Text);
                        UserData.userDictionary.Add(this.user.Text, newInput);
                        Frame.Navigate(typeof(Login));
                    }
                    else
                    {
                        MessageDialog dg = new MessageDialog("Password must be 8 characters");
                        await dg.ShowAsync();
                    }
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Please Complete Form");
                    await dialog.ShowAsync();
                }
            }
        }

        private void GoBackPage(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }


        private void refresh(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewUser));
        }


    }
}
