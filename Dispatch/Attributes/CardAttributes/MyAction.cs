﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.CardAttributes
{

    /*
     * •	For the given status of an "trip card", list which "actions" I have available
o	EX:
•	100 - Quality Control - status < 100
•	200 - Depart - status between 100 & 200
•	Breakdown - status between 100 & 300
•	300 Arrive - status > 200
•	400 - Finalize status > 300

     * 
     * */
    public class MyAction
    {
        //statius_identification is number 1-400 that identifies action of truck
        private UInt16 status_identification; 
        private enum action { depart, arrive };
        private Dictionary<action, bool> enumDict = new Dictionary<action, bool>();
        private List<action> act = new List<action>();
       // private Dictionary<string, bool> stringDict = new Dictionary<string, bool>();

        public MyAction()
        {
            this.enumDict.Add(action.arrive, false);
            this.enumDict.Add(action.depart, false);
            this.act.Add(action.arrive);
            this.act.Add(action.depart);
        }
        public MyAction(UInt16 num)
        {
            this.status_identification = num;
            this.enumDict.Add(action.arrive, false);
            this.enumDict.Add(action.depart, false);
        }

        public bool setActionStatus(action act, bool b)
        {
            if (this.enumDict.ContainsKey(act))
            {
                this.enumDict.Remove(act);
                this.enumDict.Add(act, b);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<action> getAvailableActions()
        {
            List<action> arr = new List<action>();
            var idk = (IEnumerable<object>)this.enumDict;
            for(object item in idk)
            {
                var uh = (Dictionary<action, bool>)item;
                if(uh.)
            }
        }



    }
}
