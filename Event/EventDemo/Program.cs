using System;
using System.Threading.Tasks;

namespace EventDemo {
    public class Program {
        public delegate string SendMessage (string sender, string receiver);
        public static void Main (string[] args) {
            SendMessage mailSend = new SendMessage (new Program ().MailSendMessage);
            Console.WriteLine (mailSend ("Robert", "Mike"));

            // Action delActions = OneVoke;
            // delActions += TwoVoke;

            // try {
            //     delActions.Invoke ();
            // } catch (Exception ex) {
            //     Console.WriteLine ("I Caught you,", ex);
            // }

            // Action delActions = OneVoke;
            // delActions += TwoVoke;

            // Delegate[] delegates = delActions.GetInvocationList ();
            // foreach (Action item in delegates) {
            //     try {
            //         item.Invoke ();
            //     } catch (Exception ex) {
            //         Console.WriteLine ($"I Caught you,{ex}");
            //     }
            // }

            MyButton myButton = new MyButton ();
            myButton.OnClick += new MyButton.ClickHandler (btn_OnClick);
            myButton.OnClick += new MyButton.ClickHandler (btn_DoubleClick);

            myButton.Click ();
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

        static void btn_OnClick (object sender, ButtonClickArgs e) {
            Console.WriteLine ("You click me!" + e.Clicker.ToString ());
        }

        static void btn_DoubleClick (object sender, ButtonClickArgs e) {
            Console.WriteLine ("You double click me!");
        }
    }
}