using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes.Classes
{
    public class Worker
    {
        private int Worker_ID;
        private string name;

        //like asset... driver is a worker but is also a worker
        public class Driver : Worker
        {

        }
    }
}
