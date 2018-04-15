using System;
using System.Threading.Tasks;
using EventDemo.ButtonDemo;
using EventDemo.CarDemo;
using EventDemo.EventBus;
using EventDemo.FishDemo;
using Microsoft.Extensions.DependencyInjection;

namespace EventDemo {
    public class Program {
        public delegate string SendMessage (string sender, string receiver);

        public void RegisterService (IServiceCollection services) {

        }

        public static void Main (string[] args) {

            #region Message And CarDemo
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

            #region CarDemo
            CarManager car = new CarManager ();
            Driver driver = new Driver (car) { Name = "lao si ji" };
            Passenger passenger = new Passenger (car) { Name = "cheng ke xiaobai" };
            CarNotificationEventData carNotificationEvent = new CarNotificationEventData (driver.Name, passenger.Name);

            car.RunCar (driver, passenger);

            //纯委托版本
            // CarNotificationEventHandler carHandler = null;
            // carHandler += driver.DriverHandle;
            // carHandler += passenger.PassengerHandle;
            // carHandler.Invoke (carNotificationEvent);

            //避免因为委托的某个回调方法调用失败，阻塞
            // Delegate[] arrayDelegate = carHandler.GetInvocationList ();

            // foreach (CarNotificationEventHandler item in arrayDelegate) {
            //     item.Invoke (carNotificationEvent);
            // }

            // Console.WriteLine (carHandler.Target + "\n" + carHandler.Method + "\n" + carHandler.GetInvocationList ());
            // carHandler.Invoke (carNotificationEvent);

            //司机和乘客分别订阅发车通知事件
            // car.CarNumberNotification += driver.DriveCar;
            // car.CarNumberNotification += passenger.BoardCar;
            // car.RunCar ();
            #endregion

            #region FishDemo

            // FishingMan fm = new FishingMan { Name = "Robert" };
            // #region general event and delegte demo
            // // FishingPole fp = new FishingPole ();

            // // fm.FishingPole = fp;

            // // // fp.FishingEvent += fm.Update;

            // // // fp.FishingEvent += new FishingEventHandler ().EventHandle;

            // // while (fm.Count < 5) {
            // //     fm.Fishing ();
            // //     System.Console.WriteLine ("------");
            // // }
            // #endregion

            // FishingEventData fishingEventData = new FishingEventData { FishingMan = fm };

            // EventBusManager eventBusManager = EventBusManager.Default;
            // eventBusManager.Trigger<FishingEventData> (fishingEventData);

            #endregion
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