using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispatch.CardAttributes
{

    /*
     * •	For the given status of an "trip card", list which "actions" I have available
o	EX:
•	100 - Quality Control - status < 100
•	200 - Depart - status between 100 & 200
•	Breakdown - status between 100 & 300
•	300 Arrive - status > 200
     * •	400 - Finalize status > 300

     * 
     * */
    public class MyAction
    {
        private UInt16 status_id; 
        private enum action { depart, arrive };

        public MyAction() { }
        public MyAction(UInt16 num)
        {
            this.status_id = num;
        }

    }
}
