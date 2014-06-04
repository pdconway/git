using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Worker
    {
        //CLASS VARIABLES
        private int Worker_ID;
        private string name;
        private LocationPoint location;
        private UInt16 hourlyRate;

        //created empty constructor b/c build problems 
        //>>>QUESTION<<< base is same as super() ???
        public Worker() { }
        //constructors 
        //IMPORTANT! each Worker is instantiated with ID!
        public Worker(int id)
        {
            this.Worker_ID = id;
        }
        public Worker(int id, string na)
        {
            this.Worker_ID = id;
            this.name = na;
        }

        #region getSet
        public int getID()
        {
            return this.Worker_ID;
        }
        public void setID(int id)
        {
            this.Worker_ID = id;
        }
        public string getName()
        {
            return this.name;
        }
        public void setName(string na)
        {
            this.name = na;
        }
        public LocationPoint getLocation()
        {
            return this.location;
        }
        public void setLocation(LocationPoint loc)
        {
            this.location = loc;
        }
        public UInt16 getHourly()
        {
            return this.hourlyRate;
        }
        public void setHourlyRate(UInt16 rt)
        {
            this.hourlyRate = rt;
        }
        public void setHourlyRate(int rt)
        {
            this.hourlyRate = (UInt16)rt;
        }
        #endregion

        //SUBCLASSES
        //like asset... driver is a worker but is also a worker
        public class Driver : Worker
        {
            private UInt16 hoursWorked;

            public void setHoursWorked(UInt16 hours)
            {
                this.hoursWorked = hours;
            }
            public void setHoursWorked(int hours)
            {
                this.hoursWorked = (UInt16)hours;
            }
            public UInt16 getHoursWorked()
            {
                return this.hoursWorked;
            }
        }
    }
}
