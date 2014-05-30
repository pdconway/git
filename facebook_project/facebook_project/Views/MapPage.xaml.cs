using Facebook;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using facebook_project.ViewModel;
using Bing.Maps;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace facebook_project.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        public MapPage()
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

        private void goToHome(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LandingPage));
        }

        //I was thinking that I needed to clear the list of dots but I think I will create the dots every single time I load the map... not the best but okay for this
        /*
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            StaticMessageData.Message.Clear();
            base.OnNavigatedFrom(e);
        }
         * */



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //>>>so is this kinda like a super() call? or something? and then we run our own underneath... i know its necessary but why?
            base.OnNavigatedTo(e);
            int num = 1;
            foreach (var items in StaticMessageData.Message)
            {
                Pushpin pushpin = new Pushpin();
                //pushpin.Text = String.Format(items.Message + "\r\n" + "with " + items.Friends + "\r\n" + "at " + items.Location);
                pushpin.Text = String.Format(num + "");
                MapLayer.SetPosition(pushpin, new Location(Convert.ToDouble(items.Location_information.Latitude), Convert.ToDouble(items.Location_information.Longitude)));
                pushpin.Tapped += pushpinTapped;
                pushpin.Name = Convert.ToString(num);
                myMap.Children.Add(pushpin);
                num++;
                
            }
            

        }


        private async void pushpinTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("HEY! I HAVE NO IDEA HOW TO TRANSFER INFORMATION FROM THIS PIN TO THIS DIALOG :(");
            await dialog.ShowAsync();
        }

    }
}
