using System;
using System.Threading.Tasks;
using WebSocketClient;

namespace WSRecieveConsoleDemo
{
    public class Program
    {
        private static Connection _connection;

        //The function of this project is to recieve the message.
        public static void Main(string[] args)
        {
            StartConnectionAsync().ConfigureAwait(false);

            _connection.On("receieveMessage", (arguments) =>
            {
                Console.WriteLine($"Hello World! We are Connected by WebSocket! {arguments[0]} said: {arguments[1]}");
            });
            Console.ReadLine();

            StopConnectionAsync().ConfigureAwait(false);

        }

        public static async Task StartConnectionAsync()
        {
            _connection = new Connection();
            await _connection.StartConnectionAsync("ws://localhost:5000/chat");
        }

        public static async Task StopConnectionAsync()
        {
            await _connection.StopConnectionAsync();
        }
    }
}
