using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cv09TCPServer
{
    public class TCPServer
    {
        public const String address = "127.0.0.1";
        public const int port = 1200;
        public const int ListenerCount = 1;
        private IMessageProcessor processor;


        public TCPServer(IMessageProcessor p, string ipAdrress, int port)
        {
            string message;
            do
            {
                processor = p;
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAdrress), port);
                processor?.Process($"TCP Server listening on {endPoint.ToString()}");
                socket.Bind(endPoint);

                socket.Listen(ListenerCount);

                Socket acceptedSocket = socket.Accept();
                byte[] acceptedData = new byte[acceptedSocket.SendBufferSize];
                int bufferCount = acceptedSocket.Receive(acceptedData);
                byte[] data = new byte[bufferCount];
                for (int i = 0; i < bufferCount; i++)
                {
                    data[i] = acceptedData[i];
                }
                message = Encoding.Default.GetString(data);
                // Console.WriteLine(message);
                processor?.Process(message);

            } while (message == "exit");
            
        }
    }
}
