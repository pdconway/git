using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CardAttributes;
using Models.Sections;

namespace Models.Card
{

    //should TripCards have some type of folder assortment???
    //HAHAHAHA WHO CARES ITS FRIDAY!!!!!!!!!!!!!!!!!


    public class TripCard
    {
        //this variable can be set but it has to be through the setID function
        //possibly recieve the last ID when we retrieve data???? who knows we dont know anything about this project
        private static int newID = 0;
        private int id;
        //any information you want displayed HAS to be PUBLIC!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public string IDString { get; set; }
        private Activity activity;
        private CardAction action;
        //truck and trail are assets
        //driver is a worker 
        private bool isTruck, isTrailer, isDriver = true;


        //this makes it so that TripCards HAVE to have an ID
        //after user places activity and action it will contain activities and actions
        public TripCard()
        {
            this.id = newID;
            //this way you get a new id every time a tripcard is made
            newID++;
            IDString = Convert.ToString(this.id);
        }

        public TripCard(Activity addActivity)
        {
            this.id = newID;
            newID++;
            IDString = Convert.ToString(this.id);
            this.activity = addActivity;
        }

        #region getSet

        public void setActivity(Activity act)
        {
            this.activity = act;
        }
        public Activity getActivity()
        {
            return this.activity;
        }
        public void setAction(CardAction ca)
        {
            this.action = ca;
        }
        public CardAction getAction()
        {
            return this.action;
        }
        public void setID(int newStartingID)
        {
            newID = newStartingID;
        }


        #endregion



    }
}
