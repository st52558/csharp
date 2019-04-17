using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDesk.Options;

namespace cv09TCPServer
{
    class Program
    {
        static (string, int, bool) ProcessArgs(string[] args)
        {
            string ipAddress = TCPServer.address;
            string portStr = TCPServer.port.ToString();
            bool showHelp = false;

            var options = new OptionSet
            {
                { "i|ipadrress", "IP address", val => ipAddress = val },
                { "p|port", "port", val => portStr = val },
                { "h|help=", "help", val => showHelp = val != null }
            };

            IList<string> extra = options.Parse(args);
            if (extra.Count > 0)
            {
                throw new ArgumentException("Illegal parameters");
            }
            if (showHelp)
            {
                ShowHelp(options);
            }
            if (!int.TryParse(portStr, out int port))
            {
                port = 1200;
            }
            return (ipAddress, port, showHelp);
                
        }

        private static void ShowHelp(OptionSet optionSet)
        {
            
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to TCP Server");

            string ipAddress;
            int port;
            bool showHelp;

            try
            {
                (ipAddress, port, showHelp) = ProcessArgs(args);
                if (showHelp) return;
                StartTCPServer(ipAddress, port);
            } catch (OptionException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
           
        }

        private static void StartTCPServer(string ipAddress, int port)
        {
            TCPServer server = new TCPServer(new ConsoleMessageProcessor(), ipAddress, port);
        }
    }
}
