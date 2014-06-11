using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Classes;


namespace Models.Sections
{
    public class Demand
    {
        //CLASS VARIABLES
        private Address endAddress;
        private Address startAddress;
        //weight = importance != pounds
        private UInt16 weight;
        private static readonly string weight_UOM = "percentage";
        
        //so inbound = 0, outbound = 1; inbound_outbound = 2;

        #region getSet
        public Address getStartAddress()
        {
            return this.startAddress;
        }
        public void setStartAddress(Address ad)
        {
            this.startAddress = ad;
        }
        public Address getEndAddress()
        {
            return this.endAddress;
        }
        public void setEndAddress(Address ad)
        {
            this.endAddress = ad;
        }
        public UInt16 getWeight()
        {
            return this.weight;
        }
        public void setWeight(UInt16 wt)
        {
            this.weight = wt;
        }
        public void setWeight(int wt)
        {
            this.weight = (UInt16)wt;
        }
        #endregion


    }
}
