using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;
using Models.Card;
using Models.Sections;
using System.Collections.ObjectModel;

namespace Data_.Classes
{
    public class Model
    {
        ///////THESE ARE LOADED INFORMATION
        //created these to be static so that they are the SAME DATA throughout the entire SLN 
        //THESE ASSETS ARE ALLLLLLLLLL ASSETS
        private static ObservableCollection<Asset> assetList = new ObservableCollection<Asset>();
        //THESE WORKERS ARE ALLLLLLLLL WORKERS
        private static ObservableCollection<Worker> workerList = new ObservableCollection<Worker>();
        //dont know if you want it to be just a list or a list that has the ID of the assests associated to it. 
        //REMEMBER... even if you just do the list you can find the assests as they are this.MyActions.Assets 
        //THESE TRIP CARDS WILL GO TO THE MAP
        private static ObservableCollection<TripCard> tripCardList = new ObservableCollection<TripCard>();

        //OKAY NEW IDEA AS OF 06/09/2014... should make list view that contains grid views 
        //the rows will have titles (string) and contain a list of tripCards that will be associated to that particular string 
        //ex:
        //|ARRIVE
        //|[CARD] [CARD] [CARD] [CARD]
        //|DEPART
        //|[CARD] [CARD] [CARD] [CARD]
        //private static Dictionary<string, ObservableCollection<TripCard>> listViewContainGridView = new Dictionary<string, ObservableCollection<TripCard>>();
        //this is interesting... :) we will try this data structure :)
        private static ObservableCollection<Mapper<string, ObservableCollection<TripCard>>> listViewContainGridView = new ObservableCollection<Mapper<string,ObservableCollection<TripCard>>>();
        ///////END OF LOADED INFORMATION


        //Important List
        //these are going to be the NEW Trip Cards that need to be created!!!!!!!!!!!!
        private static List<TripCard> newTripCardsList = new List<TripCard>();

        /// this is something that Andrew wanted created but I am not sure why
        /// not necesary right now
        //public static Dictionary<TripCard, Asset> tripCardListAss = new Dictionary<TripCard, Asset>();


        #region getters_and_setters
        //we will need to be able to set data as well 
        public ObservableCollection<Asset> getAssetList()
        {
            return assetList;
        }
        public void setAssetList(ObservableCollection<Asset> ass)
        {
            assetList = ass;
        }
        public ObservableCollection<TripCard> getTripCardList()
        {
            return tripCardList;
        }
        public void setTripCardList(ObservableCollection<TripCard> tp)
        {
            tripCardList = tp;
        }
        public ObservableCollection<Worker> getWorkerList()
        {
            return workerList;
        }
        public void setWorkerList(ObservableCollection<Worker> wk)
        {
            workerList = wk;
        }
        public List<TripCard> getNewTripCards()
        {
            return newTripCardsList;
        }
        public void setNewTripCards(List<TripCard> newCards)
        {
            newTripCardsList = newCards;
        }
        public ObservableCollection<Mapper<string,ObservableCollection<TripCard>>> getListOfGrid()
        {
            return listViewContainGridView;
        }
        


        /*
        public Dictionary<TripCard, Asset> getTripCardListAss()
        {
            return tripCardListAss;
        }
        public void setTripCardListAss(Dictionary<TripCard, Asset> newTripList)
        {
            tripCardListAss = newTripList;
        }
         */
        #endregion




    }
}
