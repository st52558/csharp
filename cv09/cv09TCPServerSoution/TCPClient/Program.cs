using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1200);

           
            try
            {
                socket.Connect(remoteEP);
                while (true)
                {
                    Console.Write("> ");
                    string message = Console.ReadLine();
                    byte[] data = Encoding.Default.GetBytes(message);
                    socket.Send(data);
                }
            } catch (Exception e)
            {
                Console.WriteLine($"TCP CLient cannot be connected to {remoteEP.ToString()} . {e.Message}");
            }
            
            //socket.Send()

        }
    }
}
