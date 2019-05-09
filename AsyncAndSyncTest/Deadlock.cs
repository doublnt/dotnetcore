using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAndSyncTest
{
    public class Deadlock
    {
        public async Task<string> GetResponseValue()
        {
            return await GetResponseAsync();
        }

        public async Task<string> GetResponseAsync()
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://baidu.com");

            var response = await httpWebRequest.GetResponseAsync();
            return response.ContentType;
        }
    }
}
