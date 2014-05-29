using Facebook.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace facebook_project.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private FacebookSession session;

        public HomePage()
        {
            this.InitializeComponent();
        }

        private async Task Authenticate()
        {
            try
            {
                //remember... you created the string variable with the key and the object FacebookSessionClient...
                //so the LoginAsync
                session = await App.FacebookSessionClient.LoginAsync("user_about_me,read_stream,user_friends,read_friendlists,publish_actions");
                //i HATE that i can change variables in another class like this.... Tisk Tisk
                //so this accessToken is used to access information in the future such as the GetTaskAsync method
                App.AccessToken = session.AccessToken;
                App.FacebookId = session.FacebookId;
                //you go to the LandingPage BECUASE of the awesome following statement! swweeet...
                Frame.Navigate(typeof(LandingPage));
            }
            catch (InvalidOperationException e)
            {
                string message = "Login failed! Exception details: " + e.Message;
                MessageDialog dialog = new MessageDialog(message);
                dialog.ShowAsync();
            }
        }

        async private void btnFacebookLogin_Click(object sender, RoutedEventArgs e)
        {
            if (!App.isAuthenticated)
            {
               // App.isAuthenticated = true;
                await Authenticate();
            }
        }


    }
}
