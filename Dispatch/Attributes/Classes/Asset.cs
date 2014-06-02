using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.Classes
{
    public class Asset
    {
        private int asset_ID;
        private string name;

        //constructors 
        public Asset() { }
        public Asset(string name)
        {
            this.name = name;
        }
        public Asset(int ID)
        {
            this.asset_ID = ID;
        }
        public Asset(int ID, string name)
        {
            this.asset_ID = ID;
            this.name = name;
        }
        //end constructors

        //all of the following are assets but they are also might have their own 
        //specific properties one day when they are all big boy classes
        public class Truck : Asset
        {
           
        }
        public class Trailer : Asset
        {
            
        }
        public class Connector : Asset
        {

        }


    }
}
