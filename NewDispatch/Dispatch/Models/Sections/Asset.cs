using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;

namespace Models.Sections
{
    public abstract class Asset
    {
        //CLASS VARIABLES
        private int asset_ID;
        public string Name { get; set; }
        private LocationPoint location;

        //create empty constructor because of build problem
        //public Asset() { }
        //constructors 
        //IMPORTANT! every asset HAS to be instantiated with an ID!
        public Asset(int ID)
        {
            this.asset_ID = ID;
        }
        public Asset(int ID, string name)
        {
            this.asset_ID = ID;
            this.Name = name;
        }
        //end constructors

        #region getters_setters
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

            public Truck(int id)
                : base(id)
            {
                this.asset_ID = id;
            }
            public Truck(int id, string name)
                : base(id, name)
            {
                this.asset_ID = id;
                this.Name = name;
            }

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

            public Trailer(int id)
                : base(id)
            {
                this.asset_ID = id;
            }
            public Trailer(int id, string name)
                : base(id, name)
            {
                this.asset_ID = id;
                this.Name = name;
            }

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

            public Connector(int id)
                : base(id)
            {
                this.asset_ID = id;
            }
            public Connector(int id, string name)
                : base(id, name)
            {
                this.asset_ID = id;
                this.Name = name;
            }
        }


    }
}
