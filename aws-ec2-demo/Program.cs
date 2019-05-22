using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

namespace aws_ec2_demo
{
    class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            InitializeProfile();

            var chain = new CredentialProfileStoreChain();

            if (chain.TryGetAWSCredentials("basic_profile", out AWSCredentials credential))
            {
                var ec2Client = new AmazonEC2Client(credential, RegionEndpoint.APSoutheast2);

                var response = await ec2Client.DescribeAccountAttributesAsync();

                foreach (var item in response.AccountAttributes)
                {
                    Console.WriteLine(item.AttributeName + "|" + item.AttributeValues.Count);
                }
            }
        }

        static void InitializeProfile()
        {
            var options = new CredentialProfileOptions
            {
                AccessKey = "33",
                SecretKey = "444+Puwxq+"
            };

            var profile = new CredentialProfile("basic_profile", options)
            {
                Region = RegionEndpoint.APSoutheast2
            };

            var netSDKFile = new NetSDKCredentialsFile();
            netSDKFile.RegisterProfile(profile);
        }
    }
}
