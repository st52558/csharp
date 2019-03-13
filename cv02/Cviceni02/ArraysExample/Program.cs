using Fei.BaseLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysExample
{
    class Program
    {
        static int[] pole;
        static void Main(string[] args)
        {
            while (true)
            {   try {
                Console.WriteLine("\n1. zadani pole \n2. vypis pole\n3. setrideni\n4. min hodnota\n5. prvni vyskyt\n6. posledni vyskyt\n7. konec\n");
                int c = Reading.ReadInt($"Zadej moznost: ");
                if (c==1)
                {
                    
                 PoleZKvesnice(5);
                    
                    
                }else if (c==2)
                {
                    PoleVypis();
                }else if (c == 3)
                {
                    PoleSetrid();
                }else if (c == 4)
                {
                    PoleMin();
                }
                else if (c == 5)
                {
                    PolePrvni();
                }
                else if (c == 6)
                {
                    PolePosledni();
                }
                else { Console.WriteLine("Konec"); break; }


                }
                catch (Exception e)
                {
                    Console.WriteLine("Vyvolana vyjimka. Konec.");
                    break;
                }

            }



           

            Console.ReadKey();
        }

        private static void PolePosledni()
        {
            if(pole != null) {
            int hledane = Reading.ReadInt($"Zadej hledane cislo: ");

            for (int i = pole.Length-1; i > 0; i--)
            {
                if (hledane == pole[i])
                {
                    Console.WriteLine($"Cislo {hledane} nalezeno na indexu {i}");
                    return;
                }
            }
            Console.WriteLine($"Cislo {hledane} nenalezeno");
            }
        }

        private static void PolePrvni()
        {
            if (pole != null)
            {
                int hledane = Reading.ReadInt($"Zadej hledane cislo: ");

                for (int i = 0; i < pole.Length; i++)
                {
                    if (hledane == pole[i])
                    {
                        Console.WriteLine($"Cislo {hledane} nalezeno na indexu {i}");
                        return;
                    }
                }
                Console.WriteLine($"Cislo {hledane} nenalezeno");
            }
        }

        private static void PoleMin()
        {
            if (pole != null)
            {
                int min = int.MaxValue;
                for (int i = 0; i < pole.Length; i++)
                {
                    if (min > pole[i])
                    {
                        min = pole[i];
                    }
                }
                Console.WriteLine($"Min prvek je: {min}");
            }
        }


        private static void PoleSetrid()
        {
            if (pole != null)
            {
                Array.Sort(pole);
            }

        }

        private static void PoleVypis()
        {
            if (pole != null)
            {
                for (int i = 0; i < pole.Length; i++)
                {
                    Console.Write(pole[i] + ", ");
                }
                Console.WriteLine(" ");
            }
        }

        private static void PoleZKvesnice(int vel)
        {
            pole = new int[vel];

            for (int i = 0; i < vel; i++)
            {
                pole[i] = Reading.ReadInt($"Zadej {i+1} cislo: ");
            }

           

        }

    }
}
