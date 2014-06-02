using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dispatch.Card;
using Data.Classes;

namespace Dispatch.Classes
{
    public class DataTransfer
    {
        private string name = "";
        private ArraySegment<Assets> assetList;
        private ArraySegment<Worker> workerList;
        private ArraySegment<TripCard> tripCardList;
        private Services services = new Services();

        public DataTransfer()
        {

        }

    }
}
