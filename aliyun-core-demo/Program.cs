using System;
using System.Collections.Generic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;

using Aliyun.Acs.BssOpenApi.Model.V20171214;

namespace CommonRequestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";

            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKey, accessKeySecret);
            DefaultAcsClient client = new DefaultAcsClient(profile);

            var request = new DescribeResourcePackageProductRequest();
            request.ProductCode = "live";
            try {
                var response = client.GetAcsResponse(request);
                Console.WriteLine(System.Text.Encoding.Default.GetString(response.HttpResponse.Content));
            }
            catch (ServerException e)
            {
                Console.WriteLine(e);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
