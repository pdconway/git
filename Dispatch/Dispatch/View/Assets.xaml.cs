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
using Models.UserStuff;
using Dispatch.Transfer;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Dispatch.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Assets : Page
    {

        public Assets()
        {
            this.InitializeComponent();
            this.LoadInformation();
            //this prevents the data from being instantiated every single time you load the page
            if (DataTransfer.isFirstTimeEntered == 0)
                DataTransfer.useSampleData();
            

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataTransfer.isFirstTimeEntered++;
        }




        #region standardPageMethods
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
        #endregion


    }
}
