using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Classes
{
    public class Input<O, T>
        where O : class
        where T : class
    {

        private O key;
        private T value;

        public Input(O k, T v)
        {
            this.key = k;
            this.value = v;
        }

        public O getKey()
        {
            return this.key;
        }
        public T getValue()
        {
            return this.value;
        }
        public void setKey(O k)
        {
            this.key = k;
        }
        public void setValue(T v)
        {
            this.value = v;
        }

        
    }
}
