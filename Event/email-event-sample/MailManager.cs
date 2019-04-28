using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace email_event_sample
{
    class MailManager
    {
        /// <summary>
        /// public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
        /// </summary>
        public event EventHandler<NewMailEventArgs> NewMail;

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            EventHandler<NewMailEventArgs> temp = Volatile.Read(ref NewMail);

            if (temp != null)
            {
                temp(this, e);
            }

            //e.Raise(this, ref m_NewMail);
        }

        public void SimulateNewMail(String from, String to, String subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);

            OnNewMail(e);
        }
    }
}
