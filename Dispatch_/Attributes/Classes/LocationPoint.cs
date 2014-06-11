using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.Classes
{
    public class LocationPoint
    {
        //CLASS VARIABLES
        private float latitude;
        private float longitude;

        //CONSTRUCTORS
        public LocationPoint() { }
        public LocationPoint(float x, float y)
        {
            this.latitude = x;
            this.longitude = y;
        }

        public float getLat()
        {
            return this.latitude;
        }

        public float getLong()
        {
            return this.longitude;
        }

        public void setPoint(float x, float y){
            this.latitude = x;
            this.longitude = y;
        }

    }
}
