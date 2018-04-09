using System;
using System.Threading.Tasks;

namespace EventDemo {
    public class Program {
        public delegate string SendMessage (string sender, string receiver);
        public static void Main (string[] args) { 
            SendMessage mailSend = new SendMessage(new Program().MailSendMessage);

            Console.WriteLine(mailSend("Robert","Mike"));
        }
        public string MailSendMessage (string sender, string receiver) {
            return "From:" + sender + "\nTo:" + receiver;
        }
    }
}