using Facebook;
using facebook_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace facebook_project.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class LandingPage : Page
    {

        FacebookClient fb = new FacebookClient(App.AccessToken);
        //constructor
        public LandingPage()
        {
            this.InitializeComponent();
            this.LoadUserInfo();
        }

        //very simple...
        private void GoBackPage(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }

        private async void LoadUserInfo()
        {
            //this App.AccessToken is changed on the HomePage when you Authenticate()... it comes from the current FacebookSession
            FacebookClient fb = new FacebookClient(App.AccessToken);
            //this ExpandoObject is kinda cool... it follows like 6 interfaces or inherits from classes idk (??? how know difference between interface, abstract, subclass ???)
            dynamic parameters = new ExpandoObject();
            parameters.access_token = App.AccessToken;
            parameters.fields = "name";
            //so can GetTaskAsync because we entered accessToken... we give parameters and we ask for "me" as the field 
            dynamic result = await fb.GetTaskAsync("me", parameters);
            //the App.FacebookId came from the Authenticate() method in on the HomePage... 
            //looks like the App.AccessToken turns into the fb.AccessToken 
            //so its http://graph.facebook.com/App.FacebookId/picture?type=large&acess_token=fb.AccessToken... sounds good 
            string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", App.FacebookId, "large", fb.AccessToken);
            //so the bitmapImage will take care of the formatting for me and bam we have the image! its stored in MyImage.Source
            //MyImage is the name of the image from the xaml file
            this.MyImage.Source = new BitmapImage(new Uri(profilePictureUrl));
            this.MyName.Text = result.name;
        }

        async private void selectFriendsTextBox_Tapped(object sender, TappedRoutedEventArgs evtArgs)
        {
            

            dynamic friendsTaskResult = await fb.GetTaskAsync("/me/friends");
            //sort of like a hashmap with built in functionalities 
            //foreach (KeyValuePair<int, string> kvp in myDictionary)
            //{
            //    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            //}
            //so for this case the friends are brought in with a name and id number 
            var result = (IDictionary<string, object>)friendsTaskResult;
            //we take objects from results and store them as enumberable objects 
            var data = (IEnumerable<object>)result["data"];
            foreach (var item in data)
            {
                var friend = (IDictionary<string, object>)item;
                //we simply add a new "friend" which has the properties that we specified in the class we created
                //the friend["name"] retrieves the name of the current item
                //the friend["id"] retrieves the id of the current item
                //we get the picture by inserting the picture ID and AccessToken into the URL and specify square 
                //REMEMBER: the ObservableCollection contains your friends but your friends are not currently displayed!
                FriendData.Friends.Add(new Friend { Name = (string)friend["name"], id = (string)friend["id"], PictureUri = new Uri(string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", (string)friend["id"], "square", App.AccessToken)) });
            }
            //then we simply go to the FriendSelector page as soon as the textbox is tapped. 
            Frame.Navigate(typeof(FriendSelector));
        }

        //again this whole nagivationeventargs thing is throwing me off... do these events have methods that they automatically reference? like an interupt handler would?
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //>>>so is this kinda like a super() call? or something? and then we run our own underneath... i know its necessary but why?
            base.OnNavigatedTo(e);
            if (FriendData.SelectedFriends.Count > 0)
            {
                if (FriendData.SelectedFriends.Count > 1)
                    //I really hate the whole {0} {1} thing... you have no idea what "type" is going there 
                    this.selectFriendsTextBox.Text = String.Format("With {0} & {1} Others", FriendData.SelectedFriends[0].Name, FriendData.SelectedFriends.Count - 1);
                else
                    this.selectFriendsTextBox.Text = "With " + FriendData.SelectedFriends[0].Name;
            }
            else 
                this.selectFriendsTextBox.Text = "Select Friends";
        }

        async private void post(object sender, RoutedEventArgs e)
        {
            var postParams = new
            {
                name = "Paul Conway Windows 8.1 Application",
                caption = status.Text,
                description = ".",
                link = "https://www.facebook.com",
                picture = "http://www.wallstreet.org/wp-content/uploads/2013/10/facebook.png"
            };

            try
            {
                dynamic fbPostTaskResult = await fb.PostTaskAsync("/me/feed", postParams);
                var result = (IDictionary<string, object>)fbPostTaskResult;

                var successMessageDialog = new Windows.UI.Popups.MessageDialog("Posted Open Graph Action, id: " + (string)result["id"]);
                await successMessageDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                var exceptionMessageDialog = new Windows.UI.Popups.MessageDialog("Exception during post: " + ex.Message);
                exceptionMessageDialog.ShowAsync();
            }
        }

    }
}
