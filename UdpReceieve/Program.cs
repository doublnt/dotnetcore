using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpReceive
{
    class Program
    {
        private static readonly int _port = 11000;

        static void Main(string[] args)
        {
            var udpListener = new UdpClient(_port);
            var ipEndpoint = new IPEndPoint(IPAddress.Any, _port);

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");

                    var bytes = udpListener.Receive(ref ipEndpoint);

                    Console.WriteLine($"Receive broadcast from {ipEndpoint}");

                    Console.WriteLine($"Encoding {Encoding.ASCII.GetString(bytes)}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                udpListener.Close();
            }

            Console.WriteLine("Hello World!");
        }
    }
}
