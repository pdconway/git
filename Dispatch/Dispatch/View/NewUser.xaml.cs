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
        private Input newInput;
        private string keyBinary;
        private string password = "";

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
                if ((this.first.Text != null) && (this.last.Text != null) && (this.user.Text != null) && (this.password != null))
                {
                    foreach (string user in UserData.usernames)
                    {
                        if (this.user.Text == user)
                        {
                            MessageDialog dail = new MessageDialog("Username is already taken");
                            await dail.ShowAsync();
                            return;
                        }
                    }
                    if (this.password.Length >= 13)
                    {
                        newUser = new User(this.first.Text, this.last.Text);                    
                        newInput = new Input(this.user.Text, this.password);
                        UserData.input.Add(newInput);
                        UserData.usernames.Add(this.user.Text);
                        UserData.userDictionary.Add(newInput, newUser);
                        Frame.Navigate(typeof(Login));
                    }
                    else
                    {
                        MessageDialog dg = new MessageDialog("Password must be 13 characters");
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



        private void getPassword(object sender, RoutedEventArgs e)
        {
            if (this.pass.Text.Length > 0)
            {
                int num = this.pass.Text.Length;
                //string last = this.pass.Text.Substring(num - 1, num);
                this.password = this.pass.Text;
                this.pass.Text = "";

                while (num != 0)
                {
                    this.pass.Text += "*";
                    num--;
                }
            }
        }


    }
}
