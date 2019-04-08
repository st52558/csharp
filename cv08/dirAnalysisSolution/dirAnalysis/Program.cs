using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dirAnalysis
{
    public class Soubor
    {
        public String typ;
        public int pocet;

        public Soubor(String t)
        {
            typ = t;
            pocet = 1;
        }
    }

    class Program
    {
        static StringBuilder builder = new StringBuilder("");
        static bool writeToFile = false;
        static StreamWriter writer;
        static Soubor[] types = new Soubor[0];
        static void Main(string[] args)
        {
            String nazev = "";
            String soubor;
            do
            {
                Console.WriteLine("Budete chtít výstup zapsat do souboru? y/n");
                soubor = Console.ReadLine();
            } while (!soubor.Equals("y") && !soubor.Equals("n"));


            
            if (soubor.Equals("y")){
                
                    Console.WriteLine("Zadejte název souboru např. soubor.txt");
                    nazev = Console.ReadLine();
                    
                    writeToFile = true;
            }
                

            
            Console.WriteLine("Zadejte relativní cestu ke složce (při prázdném vstupu se využije současná složka)");
            String dir = Console.ReadLine();
            String vypis;
            do
            {
                Console.WriteLine("Chcete vypsat soubory a jejich podsoubory? y/n");
                vypis = Console.ReadLine();
            } while (!vypis.Equals("y") && !vypis.Equals("n"));
            

            if (dir.Equals(""))
            {
                if (exist())
                {
                    DirectoryInfo di = new DirectoryInfo(".\\");
                    writeFiles(di, vypis.Equals("y"));

                }
            } else
            {
                if (exist(dir))
                {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    writeFiles(di, vypis.Equals("y"));

                }
            }
            String result;
            do
            {
                Console.WriteLine("Chcete vypsat seznam přípon souborů a jejich počet? y/n");
                result = Console.ReadLine();
            } while (!result.Equals("y") && !result.Equals("n"));
            if (result.Equals("y"))
            {
                for (int i = 0; i < types.Length; i++)
                {
                    if (writeToFile)
                    {
                        builder.AppendLine(types[i].typ + " " + types[i].pocet);
                    }
                    Console.WriteLine(types[i].typ + " " + types[i].pocet);
                }
            }
            if (writeToFile)
            {
                using (StreamWriter writer = new StreamWriter(new FileStream(nazev, FileMode.OpenOrCreate), Encoding.UTF8))
                {
                    writer.Write(builder);
                }
            }
            


    }

    private static bool exist()
        {
            return Directory.Exists(".\\");
        }

        private static bool exist(String dir)
        {
            return Directory.Exists(dir);
        }

        private static void writeFiles(DirectoryInfo di, bool vypis)
        {
            if (vypis)
            {
                if (writeToFile)
                {
                    builder.AppendLine(di.Name);
                }
                Console.WriteLine(di.Name);
            }
            
            
            foreach (FileInfo file in di.EnumerateFiles())
            {
                if (checkNewType(file))
                {
                    Soubor[] temp = new Soubor[types.Length + 1];
                    for (int i = 0; i < types.Length; i++)
                    {
                        temp[i] = types[i];
                    }
                    temp[temp.Length - 1] = new Soubor(file.Extension.ToString());
                    types = temp;
                }
                else
                {
                    for (int i = 0; i < types.Length; i++)
                    {
                        if (types[i].typ.Equals(file.Extension.ToString())){
                            types[i].pocet++;
                        }
                    }
                }
                if (vypis)
                {
                    if (writeToFile)
                    {
                        builder.AppendLine(file.Name + "\t" + file.Extension + "\t" + file.LastAccessTime);
                    }
                    Console.WriteLine(file.Name + "\t" + file.Extension + "\t" + file.LastAccessTime);
                }
                
                
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                writeFiles(dir, vypis);
            }
            
        }

        private static bool checkNewType(FileInfo f)
        {
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].typ.Equals(f.Extension.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private static void doSouboru(String soubor)
        {
            
        }
    }
}
