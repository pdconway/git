using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Card;
using Models.Classes;
using Data_.Classes;
using Models.Sections;
using System.Collections.ObjectModel;

namespace Dispatch.Transfer
{
    public class DataTransfer
    {
        public static int isFirstTimeEntered = 0;
        public static bool existsNewData = false;
        public static bool existsNewListData = false;


        private string name = "";
        private static ObservableCollection<Asset> assetList;
        private static ObservableCollection<Worker> workerList;

        //this is not used in the new data structure stuff
        private static ObservableCollection<TripCard> tripCardList;

        private static List<TripCard> newTripCardsList;
        //the services class seems pointless but whatever........
        private static Services services = new Services();
        private static Model model;

        //da new guy
        //WEIRD DATA STRUCTURE SO LEARN HOW WE IMPORT DATA AND CHANGE AS NEEDED 
        //just roll with what works for now 
        private static ObservableCollection<Mapper<string, ObservableCollection<TripCard>>> listOfGridViewsContainingCards; 
        

        
        public DataTransfer()
        {
            model = services.RetrieveData();
            assetList = model.getAssetList();
            workerList = model.getWorkerList();
            tripCardList = model.getTripCardList();
            newTripCardsList = model.getNewTripCards();
            listOfGridViewsContainingCards = model.getListOfGrid();
        }
        public DataTransfer(string na)
        {
            this.name = na;
            model = services.RetrieveData();
            assetList = model.getAssetList();
            workerList = model.getWorkerList();
            tripCardList = model.getTripCardList();
            newTripCardsList = model.getNewTripCards();
            listOfGridViewsContainingCards = model.getListOfGrid();
        }


        public static ObservableCollection<Asset> AssetList
        {
            get
            {
                return assetList;
            }
        }
        public static ObservableCollection<Worker> WorkerList
        {
            get
            {
                return workerList;
            }
        }
        public static ObservableCollection<TripCard> TripCardList
        {
            get
            {
                return tripCardList;
            }
        }
        public static ObservableCollection<Mapper<string,ObservableCollection<TripCard>>> ListOfGridViewsContainingCards
        {
            get
            {
                return listOfGridViewsContainingCards;
            }
        }


        //I dont think I use this but I was trying things with the instantiation of page and showing data
        public static void clearData()
        {
            assetList = new ObservableCollection<Asset>();
            workerList = new ObservableCollection<Worker>();
            tripCardList = new ObservableCollection<TripCard>();
            listOfGridViewsContainingCards = new ObservableCollection<Mapper<string, ObservableCollection<TripCard>>>();
        }
        public static void setTripCardList(ObservableCollection<TripCard> makeDataStaySame)
        {
            tripCardList = makeDataStaySame;
        }
        //this method is called in ActivityCardsPage.xaml.cs in order to add a new Trip Card... 
        //the existsNewData is necessary to only load the new information into the page ONCE
        //THIS METHOD ENDS UP NOT BEING USED 
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public static void addTripCard(TripCard newTripCard)
        {
            tripCardList.Add(newTripCard);
            existsNewData = true;
        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public static void addNewTripCardList(Mapper<string, ObservableCollection<TripCard>> newList)
        {
            listOfGridViewsContainingCards.Add(newList);
            existsNewListData = true;
        }












        //****************************************************************************************************************************
        //THE FOLLOWING IS SIMPLY SAMPLE DATA THAT IS USED ON THE ACTIVITYCARDSPAGE
        //****************************************************************************************************************************

        //OKAY NEW IDEA AS OF 06/09/2014... should make list view that contains grid views 
        //the rows will have titles (string) and contain a list of tripCards that will be associated to that particular string 
        //ex:
        //|ARRIVE
        //|[CARD] [CARD] [CARD] [CARD]
        //|DEPART
        //|[CARD] [CARD] [CARD] [CARD]
        public static void useSampleDataWithNewDataStructure()
        {
            int fidy = 0;
            //remember we are going to be binding data 
            //therefore we are going to binding to the Mapper class 
            //for this reason we can simply instantiate list of TripCards here
            ObservableCollection<TripCard> tripCardListArrive = new ObservableCollection<TripCard>();
            ObservableCollection<TripCard> tripCardListDepart = new ObservableCollection<TripCard>();
            Mapper<string, ObservableCollection<TripCard>> arriveMap = new Mapper<string,ObservableCollection<TripCard>>("Arrive", tripCardListArrive);
            Mapper<string, ObservableCollection<TripCard>> departMap = new Mapper<string,ObservableCollection<TripCard>>("Depart", tripCardListDepart);
            listOfGridViewsContainingCards.Add(arriveMap);
            listOfGridViewsContainingCards.Add(departMap);
            while (fidy < 50)
            {
                Asset.Truck truck = new Asset.Truck(fidy, "Name of Truck");
                Asset.Trailer trailer = new Asset.Trailer(fidy, "Name of Trailer");
                Worker.Driver driver = new Worker.Driver(fidy, "Name of Driver");
                TripCard tripCard = new TripCard();
                assetList.Add(truck);
                assetList.Add(trailer);
                workerList.Add(driver);
                tripCardList.Add(tripCard);
                //alternate to different lists 
                if ((fidy % 2) == 0)
                    tripCardListArrive.Add(tripCard);
                else
                    tripCardListDepart.Add(tripCard);

                fidy++;
            }
        }









        public static void useMoreSampleData()
        {
            int hundai = 100;
            while (hundai > 0)
            {
                hundai--;
                Asset.Truck truck = new Asset.Truck(hundai, "Name of Truck");
                Asset.Trailer trailer = new Asset.Trailer(hundai, "Name of Trailer");
                Worker.Driver driver = new Worker.Driver(hundai, "Name of Driver");
                TripCard tripCard = new TripCard();
                assetList.Add(truck);
                assetList.Add(trailer);
                workerList.Add(driver);
                tripCardList.Add(tripCard);
            }
        }



        public static void useSampleData()
        {
            //instantiate Assets (but remember Asset is abstract)

            //Trucks
            Asset.Truck oneTruck = new Asset.Truck(3425, "Big");
            Asset.Truck twoTruck = new Asset.Truck(7243, "Bigger");
            //Trailers
            Asset.Trailer oneTrailer = new Asset.Trailer(2347, "Con-way");
            Asset.Trailer twoTrialer = new Asset.Trailer(6234, "Roadway");
            Asset.Trailer threeTrailer = new Asset.Trailer(2342, "Extra");

            //add Assets to the assetList


            assetList.Add(oneTruck);
            assetList.Add(twoTruck);
            assetList.Add(oneTrailer);
            assetList.Add(twoTrialer);
            assetList.Add(threeTrailer);


            //instantiate Workers (but remember Worker is abstract)


            //Driver
            Worker.Driver oneDriver = new Worker.Driver(532, "Billy");
            Worker.Driver twoDriver = new Worker.Driver(236, "Richard");
            Worker.Driver threeDriver = new Worker.Driver(834, "Dick");
            Worker.Driver fourDriver = new Worker.Driver(624, "Joe");


            //add Workers to the workerList


            workerList.Add(oneDriver);
            workerList.Add(twoDriver);
            workerList.Add(threeDriver);
            workerList.Add(fourDriver);


            //instantiate TripCards that are "already made"


            TripCard zero = new TripCard();
            TripCard one = new TripCard();
            TripCard two = new TripCard();
            TripCard three = new TripCard();


            //add TripCards to the tripCardList


            tripCardList.Add(zero);
            tripCardList.Add(one);
            tripCardList.Add(two);
            tripCardList.Add(three);


            //instantiate TripCards that are orders


            //add TripCards to the newTripCardsList

        }

    }
}
