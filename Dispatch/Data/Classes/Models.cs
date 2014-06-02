using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attributes.Classes;
using Attributes.Card;

namespace Data.Classes
{
    public class Models
    {
        //created these to be static so that they are the SAME DATA throughout the entire SLN 
        private static List<Asset> assetList = new List<Asset>();
        private static List<Worker> workerList = new List<Worker>();
        //dont know if you want it to be just a list or a list that has the ID of the assests associated to it. 
        //REMEMBER... even if you just do the list you can find the assests as they are this.MyActions.Assets 
        private static List<TripCard> tripCardList = new List<TripCard>();
        private static Dictionary<TripCard, Asset> tripCardListAss = new Dictionary<TripCard, Asset>();

        #region getters_and_setters
        //we will need to be able to set data as well 
        public List<Asset> getAssetList()
        {
            return assetList;
        }
        public void setTripCardList(List<TripCard> tp)
        {
            tripCardList = tp;
        }

        public List<Worker> getWorkerList()
        {
            return workerList;
        }
        public void setWorkerList(List<Worker> wk)
        {
            workerList = wk;
        }


        public List<TripCard> getCardList()
        {
            return tripCardList;
        }
        //haha ass
        public void setAssetList(List<Asset> ass)
        {
            assetList = ass;
        }

        public Dictionary<TripCard, Asset> getTripCardListAss()
        {
            return tripCardListAss;
        }
        public void setTripCardListAss(Dictionary<TripCard, Asset> newTripList)
        {
            tripCardListAss = newTripList;
        }
        #endregion



    }
}
