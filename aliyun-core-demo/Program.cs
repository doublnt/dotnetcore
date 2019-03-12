using System;
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Ecs.Model.V20140526;

namespace Aliyun.Core.Demo
{
    class Program
    {
        private static string regionId = "cn-hangzhou";
        private static string accessKey;
        private static string accessKeySecret;

        private static IClientProfile profile;
        private static DefaultAcsClient client;

        static void Main(string[] args)
        {
            Console.WriteLine(System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory());
            accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";

            profile = DefaultProfile.GetProfile(regionId, accessKey, accessKeySecret);
            client = new DefaultAcsClient(profile);

            try
            {
                DescribeRegionsRequest request = new DescribeRegionsRequest();
                DescribeRegionsResponse response = client.GetAcsResponse(request);

                foreach (KeyValuePair<string, string> item in request.Headers)
                {
                    Console.WriteLine("Key: " + item.Key + "   Value: " + item.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
