using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.NAS.Model.V20170626;

namespace netframeworkdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 

            var accessKeyId = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";

            string regionId = "cn-shanghai";
            IClientProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);
            var client = new DefaultAcsClient(profile);

            var request = new DescribeRegionsRequest();

            try
            {
                var response = client.GetAcsResponse(request);
                Console.WriteLine(Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
