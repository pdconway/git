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
using facebook_project.ViewModel;
using Windows.UI.Xaml.Media.Imaging;
using Facebook;
using System.Dynamic;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace facebook_project.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FriendSelector : Page
    {
        public FriendSelector()
        {
            this.InitializeComponent();
            this.LoadUserInfo();
        }

        private void GoBackPage(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }
        private async void LoadUserInfo()
        {
           
            FacebookClient fb = new FacebookClient(App.AccessToken);
            dynamic parameters = new ExpandoObject();
            parameters.access_token = App.AccessToken;
            parameters.fields = "name";
            dynamic result = await fb.GetTaskAsync("me", parameters);
            string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", App.FacebookId, "large", fb.AccessToken);
            this.MyImage.Source = new BitmapImage(new Uri(profilePictureUrl));
            this.MyName.Text = result.name;
        }



        //so >>>QUESTION<<< does this OnNavigateFrom method get called when leaving this page... where's it called from???
        //im sure the NavigationEventArgs e parameter is doing it... but I dont have my mind completely wrapped around it
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //uh >>>QUESTION<<< when did we create this "UI thread" ... so much is happening here AHHH!
            // this runs in the UI thread, so it is ok to modify the viewmodel directly here 
            FriendData.SelectedFriends.Clear();
            //the friendsListBox is the ListBox that we created in the .xaml file
            //im sure the selectedItems is a built in functionality... we had to switch the selection to multiple 
            var selectedFriends = this.friendsListBox.SelectedItems;
            //we loop through each selected friend to add them to the selectedfriends observable collection
            foreach (Friend oneFriend in selectedFriends)
            {
                FriendData.SelectedFriends.Add(oneFriend);
            }

            base.OnNavigatedFrom(e);
        }

        private void goToHome(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LandingPage));
        }


    }
}
