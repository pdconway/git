using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;

namespace Models.Sections
{
    public class Asset
    {
        //CLASS VARIABLES
        private int asset_ID;
        private string name;
        private LocationPoint location;

        //create empty constructor because of build problem
        public Asset() { }
        //constructors 
        //IMPORTANT! every asset HAS to be instantiated with an ID!
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

        #region getters_setters
        public void setName(string na)
        {
            this.name = na;
        }
        public string getName()
        {
            return this.name;
        }
        public void setID(int id)
        {
            this.asset_ID = id;
        }
        public int getID()
        {
            return this.asset_ID;
        }
        public void setLocation(LocationPoint pt)
        {
            this.location = pt;
        }
        public LocationPoint getLocation()
        {
            return this.location;
        }
        #endregion

        //SUBCLASSES
        //all of the following are assets but they are also might have their own 
        //specific properties one day when they are all big boy classes
        public class Truck : Asset
        {
            private UInt16 towWeight; 
            private bool broken;

            #region getSet
            public UInt16 getTowWeight()
            {
                return this.towWeight;
            }
            public void setTowWeight(UInt16 wt)
            {
                this.towWeight = wt;
            }
            public void setTowWeight(int wt)
            {
                this.towWeight = (UInt16)wt;
            }
            public bool isBroken(){
                return this.broken;
            }
            public void setIsBroken(bool tf)
            {
                this.broken = tf;
            }
            #endregion
        }
        public class Trailer : Asset
        {
            private UInt16 towVolume;

            public void setTowVolume(UInt16 tv)
            {
                this.towVolume = tv;
            }
            public void setTowVolume(int tv)
            {
                this.towVolume = (UInt16)tv;
            }
            public UInt16 getTowVolume()
            {
                return this.towVolume;
            }

        }
        public class Connector : Asset
        {

        }


    }
}
