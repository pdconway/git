using Models.Card;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.Transfer
{
    //this class might not be necessary... struggling with the instantiation of objects on the other page
    public class HoldingData
    {
        private static ObservableCollection<TripCard> tripCardList;


        public static void removeAndHoldData()
        {
            tripCardList = DataTransfer.TripCardList;
        }


        public static void preventFromChangingData()
        {
            DataTransfer.setTripCardList(tripCardList);
        }


        public ObservableCollection<TripCard> getTripCards()
        {
            return tripCardList;
        }

        
        

    }
}
