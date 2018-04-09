using System;
using System.Threading.Tasks;

namespace EventDemo {
    public class Program {
        public delegate string SendMessage (string sender, string receiver);
        public static void Main (string[] args) {
            SendMessage mailSend = new SendMessage (new Program ().MailSendMessage);
            Console.WriteLine (mailSend ("Robert", "Mike"));

            Action delActions = OneVoke;
            delActions += TwoVoke;

            try {
                delActions.Invoke ();
            } catch (Exception ex) {
                Console.WriteLine ("I Caught you,", ex);
            }
        }
        public string MailSendMessage (string sender, string receiver) {
            return "From:" + sender + "\nTo:" + receiver;
        }

        static void OneVoke () {
            Console.WriteLine ("One invoked!");
            throw new Exception ("Error in one invoke");
        }

        static void TwoVoke () {
            Console.WriteLine ("Two invoked!");
        }
    }
}