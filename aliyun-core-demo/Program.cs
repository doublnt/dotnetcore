using System;
using System.Collections.Generic;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Mts.Model.V20140618;

namespace CommonRequestDemo {
    class Program {
        static void Main (string[] args) {
            var accessKey = Environment.GetEnvironmentVariable ("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable ("ACCESS_KEY_SECRET") ?? "AccessKeySecret";

            IClientProfile profile = DefaultProfile.GetProfile ("cn-hangzhou", accessKey, accessKeySecret);
            DefaultAcsClient client = new DefaultAcsClient (profile);

            var request = new SubmitJobsRequest();
            request.Input="{\"Bucket\":\"sgfa-sdf\",\"Location\":\"oss-cn-hangzhou\",\"Object\":\"test.flv\"}";
            request.OutputBucket = "bucket-output-template";
            request.OutputLocation="oss-cn-hangzhou";
            request.PipelineId = "testpinpsfsd";
            request.Outputs = "[{\"OutputObject\":\"test-output.flv\",\"TemplateId\":\"testtempalte\",\"UserData\":\"testid-001\"}]";

            try {
                var response = client.GetAcsResponse (request);
                Console.WriteLine (System.Text.Encoding.Default.GetString (response.HttpResponse.Content));
            } catch (ServerException e) {
                Console.WriteLine (e);
            } catch (ClientException e) {
                Console.WriteLine (e);
            }
        }
    }
}