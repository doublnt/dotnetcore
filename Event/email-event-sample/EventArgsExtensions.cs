using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace email_event_sample
{
    public static class EventArgsExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e, object sender,
            ref EventHandler<TEventArgs> eventDelegate)
        {
            EventHandler<TEventArgs> temp = Volatile.Read(ref eventDelegate);

            if (temp != null) temp(sender, e);
        }
    }
}
