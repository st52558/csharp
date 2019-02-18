using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv01
{

    class Program
    {
        static void RodneCislo(string rc)
        {
            if (rc[2] == '5' || rc[2] == '6')
            {
                Console.WriteLine("Žena");
            }
            else if (rc[2] == '1' || rc[2] == '0')
            {
                Console.WriteLine("Muž");
            }
            else
            {
                Console.WriteLine("Neplatný měsíc");
            }
        }
        static void Main(string[] args)
        {
            //příklad 1
            Console.WriteLine("Josef Novák");
            Console.WriteLine("Jindrišská 16");
            Console.WriteLine("111 50, Praha 1");

            //příklad 2
            for (int i = 0; i < 26; i++)
            {
                Console.Write(Convert.ToChar(i + 65));
            }

            //příklad 3
            string rc = "5655203565";
            RodneCislo(rc);

            //příklad 4
            Random RNG = new Random();
            int cislo = RNG.Next(0,100);
            int hadani = int.Parse(Console.ReadLine());
            while (cislo != hadani)
            {
                
                if (cislo > hadani)
                {
                    Console.WriteLine("přidej");
                } else
                {
                    Console.WriteLine("uber");
                }
                hadani = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("uhodnuto");
            Console.WriteLine(cislo);

            //příklad 5
        }
    }
}
