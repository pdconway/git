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
using FridayDataApp.ViewTables;
using FridayDataApp.Tables;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FridayDataApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProjectsPage : Page
    {

        ProjectsViewModel projectsViewModel = null;
        ObservableCollection<ProjectsViewModel> projects = null;
        private FridayDataApp.App app = (Application.Current as App);


        public ProjectsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var customer = (ViewImage)e.Parameter;
            app.CurrentPhotoID = TableImages.ID; //UHHH LOOK HERE WHAT THE HECK!!!
        }
    }
}
