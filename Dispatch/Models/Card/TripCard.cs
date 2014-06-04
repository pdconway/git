using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.CardAttributes;

namespace Models.Card
{
    public class TripCard
    {
        private int tripCard_ID;
        private Activity activity;
        private MyAction action = new MyAction(); 
        //truck and trail are assets
        //driver is a worker 
        private bool isTruck, isTrailer, isDriver = true;
    }
}
