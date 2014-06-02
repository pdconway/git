using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dispatch.CardAttributes;

namespace Dispatch.Card
{
    public class TripCard
    {
        private Activity activity = new Activity();
        private MyAction action = new MyAction();
        private bool isTruck, isTrailer, isWorker = true;
        private bool isAssets; 
    }
}
