using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebook_project.ViewModel
{
    //Note to self: only reason this class is necessary is because it is a static data holder that scopes to the entire project
    class StaticLocationData
    {
        private static ObservableCollection<Location> locations = new ObservableCollection<Location>();
        public static ObservableCollection<Location> Locations
        {
            get
            {
                return locations;
            }
        }

        private static bool isLocationSelected = false;
        public static bool IsLocationSelected
        {
            get
            {
                return isLocationSelected;
            }
            set
            {
                isLocationSelected = value;
            }
        }


        //Does not need to be ObservableCollection because users will only select one location
        public static Location SelectedLocation { get; set; }


    }
}
