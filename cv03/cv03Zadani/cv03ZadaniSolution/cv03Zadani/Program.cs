using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fei.BaseLip;

namespace cv03Zadani
{
    delegate bool Nazev(Student obj1, Student obj2, int c);
    enum Fakulta
    {
        FEI, FES, FF, FCHT
    }

    class Student
    {
        public Student(string j, int c, Fakulta f)
        {
            jmeno = j;
            cislo = c;
            fakulta = f;
        }
        public string jmeno { get; set; }
        public int cislo { get; set; }
        public Fakulta fakulta { get; set; }

        public override string ToString()
        {
            return "Jméno: " + jmeno + ", Číslo: " + cislo + ", Fakulta: " + fakulta;
        }
    }

    class Studenti
    {
        public int pocetPrvku;
        public Student[] pole;

        public Studenti()
        {
            pocetPrvku = 0;
            pole = new Student[10];
        }
    }

    class Program
    {
        static Studenti p;


        static void Main(string[] args)
        {
            p = new Studenti();
            int c;
            do
            {


                Console.WriteLine("1) Načtení studentů z klávesnice");
                Console.WriteLine("2) Výpis studentů na obrazovku");
                Console.WriteLine("3) Seřazení studentů podle čísla");
                Console.WriteLine("4) Seřazení studentů podle jména");
                Console.WriteLine("5) Seřazení studentů podle fakulty");
                Console.WriteLine("0) Konec programu");

                c = Reading.ReadInt($"Zadej číslo");
                switch (c)
                {
                    case 1:
                        nactiZKlavesnice();
                        break;
                    case 2:
                        vypisStudenty();
                        break;
                    case 3:
                        seradit(c);
                        break;
                    case 4:
                        seradit(c);
                        break;
                    case 5:
                        seradit(c);
                        break;
                    default:
                        break;
                }
            } while (c != 0);
        }

        private static void seradit(int c)
        { Nazev nz = porovnej;
            for (int i = 0; i < p.pocetPrvku; i++)
            {
                for (int j = 0; j < p.pocetPrvku -1; j++)
                {
                    if(nz(p.pole[i], p.pole[j], c))
                    {
                        Student tmp = p.pole[i];
                        p.pole[i] = p.pole[j];
                        p.pole[j] = tmp;
                    }
                }
                
            }
        }

        private static void vypisStudenty()
        {
            for (int i = 0; i < p.pocetPrvku; i++)
            {
                Console.WriteLine(p.pole[i].ToString());
            }
        }

        private static void nactiZKlavesnice()
        {
            Console.WriteLine();
            string jmeno = Reading.ReadString("Zadej jméno");
            int cislo = Reading.ReadInt("Zadej číslo");
            string temp = Reading.ReadString("Zadej fakultu (FEI, FES, FF, FCHT)");
            Fakulta fak = 0;
            switch (temp)
            {
                case "FEI":
                    fak = Fakulta.FEI;
                    break;
                case "FES":
                    fak = Fakulta.FES;
                    break;
                case "FF":
                    fak = Fakulta.FF;
                    break;
                case "FCHT":
                    fak = Fakulta.FCHT;
                    break;
                default:
                    //TODO
                    break;

            }
            p.pole[p.pocetPrvku] = new Student(jmeno, cislo, fak);
            p.pocetPrvku++;
        }

        private static bool porovnej(Student obj1, Student obj2, int c)
        {
            if (c == 3)
            {
                return obj1.cislo > obj2.cislo;
            }
            else if (c == 4)
            {
                if (obj1.jmeno.CompareTo(obj2.jmeno)>0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return obj1.fakulta > obj2.fakulta;
            }
        }
    }
}





