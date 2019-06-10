using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class UriSample
    {
        private Uri uri = new Uri("https://www.aliyun.com/test.html?id=100");

        public void PrintTheSegmentOfUri()
        {
            var part1 = uri.AbsolutePath;
            var part2 = uri.AbsoluteUri;
            var part3 = uri.Authority;

            Console.WriteLine(part1 + "\n" + part2 + "\n" + part3);
        }
    }
}
