using Facebook;
using facebook_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
            //its important to know that all the work is being taken care of on this tapped function before the page is even loaded!

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

        async private void selectPlaceTextBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //its important to note that this is taking care of the work of loading locations before page is navigated to

            Geolocator _geolocator = new Geolocator();
            //this is from the threading library.....
            CancellationTokenSource _cts = new CancellationTokenSource();
            CancellationToken token = _cts.Token;

            // Carry out the operation
            Geoposition pos = null;

            // default location 
            double latitude = 39.9667;
            double longitude = -86.1000;
            try
            {
                //wait 100 milliseconds and accept locations up to 48 hours old before we give up
                pos = await _geolocator.GetGeopositionAsync(new TimeSpan(48, 0, 0), new TimeSpan(0, 0, 0, 0, 100)).AsTask(token);
            }
            catch (Exception)
            {
                // this API can timeout, so no point breaking the code flow. Use
                // default latitutde and longitude and continue on.
            }

            if (pos != null)
            {
                latitude = pos.Coordinate.Latitude;
                longitude = pos.Coordinate.Longitude;
            }

            //so this thing is really cool... it kinda acts like a hashmaps that is filled with hashmaps... im a fan
            dynamic thingsTaskResult = await fb.GetTaskAsync("/search", new {  type = "place", center = latitude.ToString() + "," + longitude.ToString(), distance = "1000" });
            //can loop through the IDictionary guy
            var result = (IDictionary<string, object>)thingsTaskResult;
            //so make the processor think that they are IEnumberable types yeah so now each key and value is an object
            var data = (IEnumerable<object>)result["data"];
            //and bam! were looping 
            foreach (var item in data)
            {
                //let turn them back into IDictionary guys 
                var things = (IDictionary<string, object>)item;
                //ok so now we want look specifically at the location values 
                var location = (IDictionary<string, object>)things["location"];
                StaticLocationData.Locations.Add(new LocationMine
                {
                    
                    Street = location.ContainsKey("street") ? (string)location["street"] : String.Empty,
                    City = location.ContainsKey("city") ? (string)location["city"] : String.Empty,
                    State = location.ContainsKey("state") ? (string)location["state"] : String.Empty,
                    Country = location.ContainsKey("country") ? (string)location["country"] : String.Empty,
                    Zip = location.ContainsKey("zip") ? (string)location["zip"] : String.Empty,
                    Latitude = location.ContainsKey("latitude") ? ((double)location["latitude"]).ToString() : String.Empty,
                    Longitude = location.ContainsKey("longitude") ? ((double)location["longitude"]).ToString() : String.Empty,

                    // these properties are at the top level in the object...
                    Category = things.ContainsKey("category") ? (string)things["category"] : String.Empty,
                    Name = things.ContainsKey("name") ? (string)things["name"] : String.Empty,
                    Id = things.ContainsKey("id") ? (string)things["id"] : String.Empty,
                    PictureUri = new Uri(string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", (string)things["id"], "square", App.AccessToken))
                });
            }
            //move to the location page
            Frame.Navigate(typeof(LocationPage));
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


            //for the location
            if(StaticLocationData.IsLocationSelected)
            {
                this.selectRestaurantTextBox.Text = StaticLocationData.SelectedLocation.Name;
            }

        }


        //this function will determine how many friends are being added to the status and then will post to facebook
        async private void post(object sender, RoutedEventArgs e)
        {


            var postParams = new
            {
                name = status.Text,
                caption = ".",
                description = ".",
                link = "https://www.facebook.com",
                picture = "http://www.wallstreet.org/wp-content/uploads/2013/10/facebook.png"
            };

            if (StaticLocationData.IsLocationSelected)
            {
                postParams = new
                {
                    name = status.Text,
                    caption = String.Format("Location " + StaticLocationData.SelectedLocation.City + ", " + StaticLocationData.SelectedLocation.State),
                    description = ".",
                    link = "https://www.facebook.com",
                    picture = "http://www.wallstreet.org/wp-content/uploads/2013/10/facebook.png"
                };
            }
            
            if (FriendData.SelectedFriends.Count > 0)
            {
                if (FriendData.SelectedFriends.Count > 1)
                {
                    if (StaticLocationData.IsLocationSelected)
                    {
                        postParams = new
                        {
                            name = status.Text,
                            caption = String.Format("Location " + StaticLocationData.SelectedLocation.City + ", " + StaticLocationData.SelectedLocation.State),
                            description = String.Format("with {0} and {1} others", FriendData.SelectedFriends[0].Name, FriendData.SelectedFriends.Count - 1),
                            link = "https://www.facebook.com",
                            picture = "http://www.wallstreet.org/wp-content/uploads/2013/10/facebook.png"
                        };
                    }
                    else
                    {
                        postParams = new
                        {
                            name = status.Text,
                            caption = ".",
                            description = String.Format("with {0} and {1} others", FriendData.SelectedFriends[0].Name, FriendData.SelectedFriends.Count - 1),
                            link = "https://www.facebook.com",
                            picture = "http://www.wallstreet.org/wp-content/uploads/2013/10/facebook.png"
                        };
                    }      
                }
                else
                {
                    if(StaticLocationData.IsLocationSelected)
                    {
                        postParams = new
                        {
                            name = status.Text,
                            caption = String.Format("Location " + StaticLocationData.SelectedLocation.City + ", " + StaticLocationData.SelectedLocation.State),
                            description = String.Format("with " + FriendData.SelectedFriends[0].Name),
                            link = "https://www.facebook.com",
                            picture = "http://www.wallstreet.org/wp-content/uploads/2013/10/facebook.png"
                        };
                    }
                    else
                    {
                        postParams = new
                        {
                            name = status.Text,
                            caption = ".",
                            description = String.Format("with " + FriendData.SelectedFriends[0].Name),
                            link = "https://www.facebook.com",
                            picture = "http://www.wallstreet.org/wp-content/uploads/2013/10/facebook.png"
                        };
                    }
                    
                }
            }

            //this adds the post to the observablecollection of messages
            StaticMessageData.Message.Add(new Messages
            {
                Message = postParams.name,
                Friends = postParams.description,
                Location = postParams.caption,
                Location_information = StaticLocationData.SelectedLocation

            });

            

            try
            {
                dynamic fbPostTaskResult = await fb.PostTaskAsync("/me/feed", postParams);
               // var result = (IDictionary<string, object>)fbPostTaskResult;
               // var successMessageDialog = new Windows.UI.Popups.MessageDialog("Posted Open Graph Action, id: " + (string)result["id"]);
                var successMessageDialog = new MessageDialog("Status Posted to Facebook Timeline");
                await successMessageDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                var exceptionMessageDialog = new Windows.UI.Popups.MessageDialog("Exception during post: " + ex.Message);
                exceptionMessageDialog.ShowAsync();
            }
        }

        private void goToMap(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapPage));
        }


    }
}
