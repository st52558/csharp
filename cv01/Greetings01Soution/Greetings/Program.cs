using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greetings
{
    class Program
    {
        const uint default_count = 100;
        static uint GetCount(string[] args)
        {
            if (args.Length == 0) return default_count;
            if (uint.TryParse(args[0], out uint temp)) return temp;
            return default_count;
            
        }
        static void Main(string[] args)
        {
            /*Console.Write("Hello World");
            Console.WriteLine("Hello World again");
            
            String greetings = "Hello World ";
            for (uint i = 0; i < GetCount(args); i++)
            {
                greetings += "again ";
            }
            greetings = greetings.Remove(greetings.Length - 1);
            greetings += "!";

            Console.WriteLine(greetings);*/

            StringBuilder greetingsBuilder = new StringBuilder();
            greetingsBuilder.Append("Hello world again");
            for (int i = 1; i < GetCount(args); i++)
            {
                greetingsBuilder.Append(" again");

            }
            greetingsBuilder.Append("!");
            Console.WriteLine(greetingsBuilder.ToString());
        
        }
    }
}
