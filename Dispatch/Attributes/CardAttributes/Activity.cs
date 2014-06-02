using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attributes.Classes;

namespace Attributes.CardAttributes
{
    public class Activity
    {
        private int TripCard_ID; 
        private Asset Activity_Asset = new Asset();
        private Worker Activity_Line_Worker = new Worker();
        private Demand Activity_Line = new Demand();

        public Activity() { }
        public Activity(int id)
        {
            this.TripCard_ID = id;
        }

    }
}
