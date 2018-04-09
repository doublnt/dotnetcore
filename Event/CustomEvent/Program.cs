using System;

namespace CustomEvent {
    // public class CustomEventArgs : EventArgs {
    //     public CustomEventArgs (string s) {
    //         message = s;
    //     }

    //     private string message;

    //     public string Mesage {
    //         get {
    //             return message
    //         }
    //         set {
    //             message = value;
    //         }
    //     }
    // }

    // class Publisher {
    //     public event EventHandler<CustomEventArgs> RaiseCustomEvent;

    //     public void DoSomething(){
    //         OnRaiseCustomEvent()
    //     }

    //     protected virtual void OnRaiseCustomEvent(CustomEventArgs e){
    //         EventHandler<CustomEventArgs> handler = RaiseCustomEvent;
    //         if (handler != null){
    //             e.Mesage += String.Format("at {0}",DateTime.Now.ToString)
    //         }
    //     }
    // }

    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
        }
    }
}