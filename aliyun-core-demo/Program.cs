using System;
using System.Collections.Generic;
using System.Dynamic;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.industry_brain.Model.V20180712;
using Newtonsoft.Json;

namespace CommonRequestDemo {
    class Program {
        static void Main (string[] args) {
            var accessKey = Environment.GetEnvironmentVariable ("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable ("ACCESS_KEY_SECRET") ?? "AccessKeySecret";

            DefaultProfile.AddEndpoint ("cn-hangzhou", "cn-hangzhou", "industry_brain", "industrial-brain.cn-hangzhou.aliyuncs.com");
            IClientProfile profile = DefaultProfile.GetProfile ("cn-hangzhou", accessKey, accessKeySecret);
            DefaultAcsClient client = new DefaultAcsClient (profile);

            // var request = new SubmitJobsRequest();
            // request.Input="{\"Bucket\":\"sgfa-sdf\",\"Location\":\"oss-cn-hangzhou\",\"Object\":\"test.flv\"}";
            // request.OutputBucket = "bucket-output-template";
            // request.OutputLocation="oss-cn-hangzhou";
            // request.PipelineId = "testpinpsfsd";
            // request.Outputs = "[{\"OutputObject\":\"test-output.flv\",\"TemplateId\":\"testtempalte\",\"UserData\":\"testid-001\"}]";

            var request = new GetIndustryInfoChildrenListRequest();

            // var items = new List<dynamic> ();

            // dynamic obj = new ExpandoObject ();

            // obj.key = "LightAdjustLevel";
            // obj.value = 1;
            // items.Add (obj);

            // request.ProductKey = "a1LsCUpgf5n";
            // request.DeviceName = "yinxi-test";

            // var jsonItem = JsonConvert.SerializeObject(items);
            // Console.WriteLine(jsonItem);

            // jsonItem = "{LightAdjustLevel:1}";
            // request.Items = jsonItem;

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