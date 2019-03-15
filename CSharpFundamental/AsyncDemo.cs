using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    public class AsyncDemo
    {
        public async Task<string> GetValue(string url)
        {
            using(HttpClient httpClient = new HttpClient())
            {
                Task<string> fetchText = httpClient.GetStringAsync(url);

                return await fetchText;
            }
        }
    }
}
