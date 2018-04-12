using System;
using System.Threading.Tasks;
using EventDemo.EventBus;
using EventDemo.FishDemo;

namespace EventDemo {
    public class Program {
        public delegate string SendMessage (string sender, string receiver);
        public static void Main (string[] args) {

            #region Commentcode
            // SendMessage mailSend = new SendMessage (new Program ().MailSendMessage);
            // Console.WriteLine (mailSend ("Robert", "Mike"));

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

            // MyButton myButton = new MyButton ();
            // myButton.OnClick += btn_OnClick;
            // myButton.OnClick += btn_DoubleClick;

            // myButton.Click ();
            #endregion

            // MyCar benz = new MyCar { Name = "Benz" };

            // Passenger p1 = new Passenger { Name = "xiaoming" };
            // Passenger p2 = new Passenger { Name = "xiaohong" };

            // benz.CarNumberNotification += p1.BeginToCar;
            // benz.CarNumberNotification += p2.BeginToCar;

            // benz.RunCar ();

            FishingMan fm = new FishingMan { Name = "Robert" };
            // FishingPole fp = new FishingPole ();

            // fm.FishingPole = fp;

            // // fp.FishingEvent += fm.Update;

            // // fp.FishingEvent += new FishingEventHandler ().EventHandle;

            // while (fm.Count < 5) {
            //     fm.Fishing ();
            //     System.Console.WriteLine ("------");
            // }
            FishingEventData fishingEventData = new FishingEventData { FishingMan = fm };

            EventBusManager eventBusManager = EventBusManager.Default;
            eventBusManager.Trigger<FishingEventData> (fishingEventData);
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