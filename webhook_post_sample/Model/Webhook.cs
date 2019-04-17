using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace webhook_post_sample.Model
{
    class WebhookCommit
    {
        public string ID { get; set; }
        public string Tree_ID { get; set; }
        public bool Distinct { get; set; }
        public string Message { get; set; }
        public string TimeStamp { get; set; }
        public string Url { get; set; }
        public AuthorInfo Author { get; set; }
        public AuthorInfo Committer { get; set; }
        public List<string> Added { get; set; }
        public List<string> Removed { get; set; }
        public List<string> Modified { get; set; }
    }

    internal class AuthorInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
