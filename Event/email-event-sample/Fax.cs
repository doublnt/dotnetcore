using System;
using System.Collections.Generic;
using System.Text;

namespace email_event_sample
{
    internal sealed class Fax
    {
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(Object sender, NewMailEventArgs e)
        {
            Console.WriteLine("Faxing mail message:");
            Console.WriteLine($"From{e.From}, To {e.To}, Subject {e.Subject}");
        }

        public void UnRegister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }
}
