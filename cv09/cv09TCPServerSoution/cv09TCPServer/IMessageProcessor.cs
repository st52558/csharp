using System;
using System.Text;

namespace cv09TCPServer
{
    public interface IMessageProcessor
    {
        void Process(string message);
    }

    public class ConsoleMessageProcessor : IMessageProcessor
    {
        public void Process(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow.ToString()}: {message}");
        }
    }
}