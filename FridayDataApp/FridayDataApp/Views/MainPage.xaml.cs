using FridayDataApp.ViewTables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FridayDataApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page //FridayDataApp.Common.LayoutAwarePage
    {

        ImagesViewer imageViewer = null;
        ObservableCollection<ViewImage> img = null;
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            imageViewer = new ImagesViewer();
            //imges = imageViwer.GetImages();
            //dont know what this is...
            //CustomersViewSource.Source = customers;
            //CustomerGridView.SelectedItem = null;
            base.OnNavigatedTo(e);
        }

        private void ImageGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(Views.ProjectsPage), e.ClickedItem);
        }
        private void ImageGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ImagesViewer.SelectedItems.Count() > 0)
            {

            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
