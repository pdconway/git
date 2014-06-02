using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dispatch.Classes;

namespace Dispatch.CardAttributes
{
    public class Activity
    {
        private int Activity_ID; 
        private Assets Activity_Asset = new Assets();
        private Worker Activity_Line_Worker = new Worker();
        private Demand Activity_Line = new Demand();
    }
}
