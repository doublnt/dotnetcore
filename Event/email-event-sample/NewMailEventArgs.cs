using System;
using System.Collections.Generic;
using System.Text;

namespace email_event_sample
{
    class NewMailEventArgs : EventArgs
    {
        private readonly String m_from, m_to, m_subject;

        public NewMailEventArgs(String from, String to, String subject)
        {
            m_from = from;
            m_subject = subject;
            m_to = to;
        }

        public String From
        {
            get { return m_from; }
        }

        public String To
        {
            get { return m_to; }
        }

        public String Subject
        {
            get { return m_subject; }
        }
    }
}
