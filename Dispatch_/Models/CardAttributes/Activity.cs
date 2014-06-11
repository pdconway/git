using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;
using Models.Sections;

namespace Models.CardAttributes
{
    public class Activity
    {
        private static int newID = 0;
        private int TripCard_ID;
        private Asset Activity_Asset;
        private Worker Activity_Line_Worker;
        //still trying to understand this whole demand thing
        //mean path?
        private Demand Activity_Line;


        public Activity(Asset addAsset, Worker addWorker)
        {
            this.TripCard_ID = newID;
            this.Activity_Asset = addAsset;
            this.Activity_Line_Worker = addWorker;
            newID++;
        }

        
        public Activity(Asset addAsset, Worker addWorker, Demand addDemand)
        {
            this.TripCard_ID = newID;
            this.Activity_Asset = addAsset;
            this.Activity_Line_Worker = addWorker;
            this.Activity_Line = addDemand;
            newID++;
        }

        public Asset getAsset()
        {
            return this.Activity_Asset;
        }
        public Worker getWorker()
        {
            return this.Activity_Line_Worker;
        }


    }
}
