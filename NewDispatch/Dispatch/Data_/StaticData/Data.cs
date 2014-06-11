using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;
using Models.Card;
using Models.Sections;

namespace Data_.StaticData
{
    public class Data
    {
        
        ///////THESE ARE LOADED INFORMATION
        //created these to be static so that they are the SAME DATA throughout the entire SLN 
        //THESE ASSETS ARE ALLLLLLLLLL ASSETS
        private static List<Asset> assetList = new List<Asset>();
        //THESE WORKERS ARE ALLLLLLLLL WORKERS
        private static List<Worker> workerList = new List<Worker>();
        //dont know if you want it to be just a list or a list that has the ID of the assests associated to it. 
        //REMEMBER... even if you just do the list you can find the assests as they are this.MyActions.Assets 
        //THESE TRIP CARDS WILL GO TO THE MAP
        private static List<TripCard> tripCardList = new List<TripCard>();
        ///////END OF LOADED INFORMATION


        //Important List
        //these are going to be the NEW Trip Cards that need to be created!!!!!!!!!!!!
        private static List<TripCard> newTripCardsList = new List<TripCard>();
       
        /// this is something that Andrew wanted created but I am not sure why
        /// not necesary right now
        //public static Dictionary<TripCard, Asset> tripCardListAss = new Dictionary<TripCard, Asset>();

        public static List<Asset> AssetList
        {
            get
            {
                return assetList;
            }
        }
        public static List<Worker> WorkerList
        {
            get
            {
                return workerList;
            }
        }
        public static List<TripCard> TripCardList
        {
            get
            {
                return tripCardList;
            }
        }





        public static void useSampleData()
        {
            //instantiate Assets


            //add Assets to the assetList


            //instantiate Workers

           
            //add Workers to the workerList


            //instantiate TripCards that are already made


            //add TripCards to the tripCardList


            //instantiate TripCards that are orders

            
            //add TripCards to the newTripCardsList

        }


    }
}
