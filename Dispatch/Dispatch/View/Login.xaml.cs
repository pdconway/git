﻿using System;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dispatch.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        private Input inp;

        public Login()
        {
            this.InitializeComponent();
        }

        private void goToNewUserPage(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(NewUser));
        }

        private bool varifyUser(string str)
        {
            if (UserData.usernames.Contains(str))
            {
                this.inp = new Input(this.user.Text, this.pass.Text);
                if (UserData.input.Contains(inp))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void tryLogin(object sender, RoutedEventArgs e)
        {
            if ((this.user.Text != null) && (this.pass.Text != null))
            {
                if (this.varifyUser(this.user.Text))
                {

                }
            }
            else
                return false;
            
        }


    }
}
