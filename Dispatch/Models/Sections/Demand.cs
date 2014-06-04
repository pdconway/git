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
        private Address address;
        //weight = importance != pounds
        private UInt16 weight;
        private string weight_UOM = "percentage";
        public enum Pickup { Inbound, Outbound, Inbound_Outbound};
        //so inbound = 0, outbound = 1; inbound_outbound = 2;

        #region getSet
        public Address getAddress()
        {
            return this.address;
        }
        public void setAddress(Address ad)
        {
            this.address = ad;
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
