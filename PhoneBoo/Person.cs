using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBoo
{
    abstract public class Person
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }

        public abstract override string ToString();
    }
}
