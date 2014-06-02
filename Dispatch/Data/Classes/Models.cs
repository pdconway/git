using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dispatch.Classes;

namespace Data.Classes
{
    public class Models
    {
        //created these to be static so that they are the SAME DATA throughout the entire SLN 
        private static ArraySegment<Assets> assetList = new ArraySegment<Assets>();
        private static ArraySegment<Worker> workerList = new ArraySegment<Worker>();
        private static ArraySegment<TripCard> tripCardList = new ArraySegment<TripCard>();

        //we will need to be able to set data as well 
    }
}
