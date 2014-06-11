using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.Classes
{
    public class Address
    {
        private string State;
        private string City;
        private UInt16 Postal;
        private UInt16 Latitude;
        private UInt16 Longitude;

        public Address() { }
        public Address(string st, string c, UInt16 post, UInt16 lat, UInt16 log)
        {
            this.State = st;
            this.City = c;
            this.Postal = post;
            this.Latitude = lat;
            this.Longitude = log;
        }
        public Address(string st, string c, int post, int lat, int log)
        {
            this.State = st;
            this.City = c;
            this.Postal = (UInt16)post;
            this.Latitude = (UInt16)lat;
            this.Longitude = (UInt16)log;
        }


        #region getSet
        public void setAddress(string st, string c, UInt16 post, UInt16 lat, UInt16 log)
        {
            this.State = st;
            this.City = c;
            this.Postal = post;
            this.Latitude = lat;
            this.Longitude = log;
        }
        public void setAddress(string st, string c, int post, int lat, int log)
        {
            this.State = st;
            this.City = c;
            this.Postal = (UInt16)post;
            this.Latitude = (UInt16)lat;
            this.Longitude = (UInt16)log;
        }
        public string getState()
        {
            return this.State;
        }
        public string getCity()
        {
            return this.City;
        }
        public UInt16 getPostal()
        {
            return this.Postal;
        }
        public UInt16 getLatitude()
        {
            return this.Latitude;
        }
        public UInt16 getLongitude()
        {
            return this.Longitude;
        }
        #endregion





    }
}
