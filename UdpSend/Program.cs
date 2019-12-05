using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UdpSend
{
    class Program
    {
        static void Main(string[] args)
        {
            Send();
        }

        private static void Send()
        {
            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            var boardCast = IPAddress.Parse("127.0.0.1");


            var buffer = Encoding.ASCII.GetBytes("Udp Send Test...");

            var ipEndpoint = new IPEndPoint(boardCast, 11000);

            socket.SendTo(buffer, ipEndpoint);

            Console.WriteLine("Message have sent to the broadcast.");
        }
    }
}
