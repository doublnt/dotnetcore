using System;

namespace CustomEvent {

    public delegate void CustomEventDelegate (object sender, CustomEventArgs e);
    
    public class CustomEventArgs : EventArgs {

        public CustomEventArgs (string s) {
            message = s;
        }

        private string message;

        public string Message {
            get {
                return message;
            }
            set {
                message = value;
            }
        }
    }
    class Publisher {
        public event CustomEventDelegate RaiseCustomEvent;

        public void DoSomething () {
            OnRaiseCustomEvent (new CustomEventArgs ("Did something"));
        }

        protected virtual void OnRaiseCustomEvent (CustomEventArgs e) {
            CustomEventDelegate handler = RaiseCustomEvent;

            if (handler != null) {
                e.Message += String.Format ("at {0}", DateTime.Now.ToString ());

                handler (this, e);
            }
        }
    }

    class Subscriber {
        private string id;

        public Subscriber (string ID, Publisher pub) {
            id = ID;
            pub.RaiseCustomEvent += HandleCustomEvent;
        }

        void HandleCustomEvent (object sender, CustomEventArgs e) {
            Console.WriteLine (id + " received this message: {0}", e.Message);
        }
    }

    class Program {
        static void Main (string[] args) {
            Publisher pub = new Publisher ();
            Subscriber sub1 = new Subscriber ("sub1", pub);
            Subscriber sub2 = new Subscriber ("sub2", pub);

            pub.DoSomething ();
        }
    }
}