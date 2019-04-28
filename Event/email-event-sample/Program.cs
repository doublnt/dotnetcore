using System;

namespace email_event_sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager mm = new MailManager();
            Fax fax = new Fax(mm);

            mm.SimulateNewMail("Robert", "Mike", "This is a test subject!");
        }
    }
}
