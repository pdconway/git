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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace facebook_project.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LocationPage : Page
    {
        FacebookClient fb = new FacebookClient(App.AccessToken);
        public LocationPage()
        {
            this.InitializeComponent();
            this.LoadUserInfo();
        }

        private void goToMap(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MapPage));
        }

        private void goToHome(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(LandingPage));
        }

        private void GoBackPage(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }
        private async void LoadUserInfo()
        {
            dynamic parameters = new ExpandoObject();
            parameters.access_token = App.AccessToken;
            parameters.fields = "name";
            dynamic result = await fb.GetTaskAsync("me", parameters);
            string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", App.FacebookId, "large", fb.AccessToken);
            this.MyImage.Source = new BitmapImage(new Uri(profilePictureUrl));
            this.MyName.Text = result.name;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (this.thingsListBox.SelectedIndex >= 0)
            {
                StaticLocationData.SelectedLocation = (Location)this.thingsListBox.SelectedItem;
                StaticLocationData.IsLocationSelected = true;
            }

            base.OnNavigatedFrom(e);
        }

    }
}
