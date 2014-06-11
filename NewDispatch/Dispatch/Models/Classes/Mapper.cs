using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Mapper<O, T>
        where O : class
        where T : class
    {

        public O key { get; set; }
        public T value { get; set; }

        public Mapper(O k, T v)
        {
            this.key = k;
            this.value = v;
        }
        
    }
}
