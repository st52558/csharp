using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplesLibrary
{

    internal class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return ID + Name;
        }

        public Person(int id)
        {
            ID = id;
        }

        public static explicit operator Person(int v)
        {
            return new Person(v);
        }

        public static implicit operator int(Person v)
        {
            return v.ID;
        }
    }
    public static class ConversionTest
    {
        public static void DoIt()
        {
            Double realNumber = 3.14;
            realNumber = Math.PI;
            realNumber = 10;
            realNumber = 10.0;
            realNumber = (double)10;

            int integerNumber = 3;
            integerNumber = (int)3.99;
            integerNumber = (int)Math.Floor(Math.PI);

            Person person = new Person(1);         
            Person person02 =(Person)integerNumber;
            int integerNumber2 = person02;

            Object person2 = new Person(2);
            (person2 as Person).Name = "Jarda";
            if (person2 is Person)
            {
                //person2 je objekt třídy Person
            }

            if (person2.GetType() == typeof(Person))
            {
                //person2 je objekt třídy Person
            }
        }
         
    }
}
