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
using Models.CardAttributes;
using Models.UserStuff;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dispatch.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Map : Page
    {
        public Map()
        {
            this.InitializeComponent();
            this.LoadInformation();
        }


        public void LoadInformation()
        {
            this.name.Text = UserData.currentUser.getName();
        }


        private void logout(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }

        private void goHome(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void GoBackPage(object sender, RoutedEventArgs e)
        {
            if (this.Frame != null && this.Frame.CanGoBack) this.Frame.GoBack();
        }
        private void goToActivityCardPage(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(ActivityCardsPage));
        }

    }
}
