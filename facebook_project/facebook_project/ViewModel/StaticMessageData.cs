using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebook_project.ViewModel
{
    class StaticMessageData
    {
        private static ObservableCollection<Messages> message = new ObservableCollection<Messages>();
        public static ObservableCollection<Messages> Message
        {
            get
            {
                return message;
            }
        }

        
  
        //Does not need to be ObservableCollection because users will only select one location
        public static Messages SelectedMessage { get; set; }



    }
}
