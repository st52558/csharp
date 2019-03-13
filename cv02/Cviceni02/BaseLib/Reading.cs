using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fei.BaseLip
{
    public class MathConvertor
    {
        /// <summary>
        /// Prevod z desitkove na binarni soustavu
        /// </summary>
        /// <param name="dec"></param>
        /// <returns></returns>
        public static string DecToBin(int dec)
        {
            return Convert.ToString(dec, 2);
        }
        /// <summary>
        /// Prevod z binarni na desitkovou soustavu
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        public static int BinToDec(string bin)
        {
            return Convert.ToInt32(bin, 2);
        }
        /// <summary>
        /// Prevod z desitkove na rimskou soustavu
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string DecToRom(int number)
        {
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + DecToRom(number - 1000);
            if (number >= 900) return "CM" + DecToRom(number - 900);
            if (number >= 500) return "D" + DecToRom(number - 500);
            if (number >= 400) return "CD" + DecToRom(number - 400);
            if (number >= 100) return "C" + DecToRom(number - 100);
            if (number >= 90) return "XC" + DecToRom(number - 90);
            if (number >= 50) return "L" + DecToRom(number - 50);
            if (number >= 40) return "XL" + DecToRom(number - 40);
            if (number >= 10) return "X" + DecToRom(number - 10);
            if (number >= 9) return "IX" + DecToRom(number - 9);
            if (number >= 5) return "V" + DecToRom(number - 5);
            if (number >= 4) return "IV" + DecToRom(number - 4);
            if (number >= 1) return "I" + DecToRom(number - 1);
            return string.Empty;
        }
        public static int RomToDec(string rom)
        {
            return 1;
        }

    }


    public class ExtraMath
    {
        /// <summary>
        /// Vypocet kvadraticke rovnice
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns>Vraci true pokud ma real. koreny</returns>
        public bool korenKvadr(double a, double b, double c, out double? x1, out double? x2)
        {
            double dis = b * b - 4 * a * c;
            if(dis > 0)
            {
                x1 = (-b + Math.Sqrt(dis)) / 2 * a;
                x2 = (-b - Math.Sqrt(dis)) / 2 * a;
                return true;
            }
            else if (dis == 0)
            {
                x1 = (-2) / 2 * a;
                x2 = null;
                return true;
            }
            else
            {
            x1 = null;
            x2 = null;
                return false;
            }            
        }

        /// <summary>
        /// Generuje nahodne double cislo
        /// </summary>
        /// <param name="r"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>Vraci double</returns>
        public double genNagCislo(Random r,double min, double max)
        {
            r = new Random();

            return (r.NextDouble()*(max-min)+min);
        }

    }


   public class Reading
   {
        /// <summary>
        /// Trida na precteni Integeru
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>Vraci int</returns>
        public static int ReadInt(string prompt)
        {
            //osetrit, dokumentacni komentare
            /*Console.Write(prompt + ": ");
            bool ee = int.TryParse(Console.ReadLine(), out int res);
            if (ee)
                return res;
            int i = 0;
            while (!ee)
            {
                Console.Write("Zkuste znovu: ");
                ee = int.TryParse(Console.ReadLine(), out res);
                if (ee)
                    return res;
                i++;
                if (i > 10)
                    break;
            }

            return int.MinValue;*/
            Console.Write(prompt + ": ");
            bool ee = int.TryParse(Console.ReadLine(), out int res);
            if (ee)
            {
                return res;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Trida na precteni Doublu
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>Vraci double</returns>
        public static double ReadDouble(string prompt)
        {
            Console.Write(prompt + ": ");
            bool ee = double.TryParse(Console.ReadLine(), out double res);
            if (ee)
            {
                return res;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Trida na precteni Stringu
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>Vraci string</returns>
        public static String ReadString(string prompt)
        {
            Console.Write(prompt + ": ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Trida na precteni Charu
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns>Vraci char</returns>
        public static char ReadChar(string prompt)
        {
            //osetrit, dokumentacni komentare
            Console.Write(prompt + ": ");
            bool ee = char.TryParse(Console.ReadLine(), out char res);
            if (ee)
            {
                return res;
            }
            else
            {
                throw new Exception();
            }
        }

    }
    
}
