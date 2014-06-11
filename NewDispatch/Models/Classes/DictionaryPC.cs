using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    class DictionaryPC<P,C> : Dictionary<P,C> 
        where P : class
        where C : class
    {
        public string Name { get; set; }
    }
}
