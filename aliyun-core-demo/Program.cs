using System;
using System.Collections.Generic;
using System.Dynamic;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;
// using Aliyun.Acs.Domain_intl.Model.V20171218;
// using Aliyun.Acs.industry_brain.Model.V20180712;
// using Aliyun.Acs.ImageSearch.Model.V20190325;
// using Aliyun.Acs.Iot.Model.V20180120;

using Aliyun.Acs.Sts.Model.V20150401;
using Aliyun.Acs.vod.Model.V20170321;

using Newtonsoft.Json;

namespace CommonRequestDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var accessKey = Environment.GetEnvironmentVariable("ACCESS_KEY_ID") ?? "AccessKeyId";
            var accessKeySecret = Environment.GetEnvironmentVariable("ACCESS_KEY_SECRET") ?? "AccessKeySecret";

            //DefaultProfile.AddEndpoint ("cn-hangzhou", "cn-hangzhou", "industry_brain", "industrial-brain.cn-hangzhou.aliyuncs.com");
            //IClientProfile profile = DefaultProfile.GetProfile("cn-shanghai", accessKey, accessKeySecret);
            //DefaultAcsClient client = new DefaultAcsClient(profile);

            var client = InitVodClient(accessKey, accessKeySecret);

            #region commend code
            // var request = new SubmitJobsRequest();
            // request.Input="{\"Bucket\":\"sgfa-sdf\",\"Location\":\"oss-cn-hangzhou\",\"Object\":\"test.flv\"}";
            // request.OutputBucket = "bucket-output-template";
            // request.OutputLocation="oss-cn-hangzhou";
            // request.PipelineId = "testpinpsfsd";
            // request.Outputs = "[{\"OutputObject\":\"test-output.flv\",\"TemplateId\":\"testtempalte\",\"UserData\":\"testid-001\"}]";

            //AddImageRequest request = new AddImageRequest();
            //request.InstanceName = "testinstance";
            //request.ProductId = "test";
            //request.PicName = "test";
            //byte[] img = System.IO.File.ReadAllBytes("D:/test.jpg");
            //string pic = Convert.ToBase64String(img);
            //request.PicContent = pic;

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

            //var request = new QueryDevicePropertyStatusRequest();
            //request.ProductKey = "a1xplY8eBQT";
            //request.DeviceName = "SzAfkec0rv0RgfdnicbK";

            //var request = new SetDevicePropertyRequest();
            //request.ProductKey = "a1xplY8eBQT";
            //request.DeviceName = "SzAfkec0rv0RgfdnicbK";

            //request.Items = "{\"AlarmText\":\"E7BB93E69D9FE5BE85E69CBAE4B8AD20202020202020202020202020202020202020202020202020202020202030303830202020202020202020202020202020207C4F50454E2054484520444F4F52205448454E20434C4F5345207C\"}";

            #endregion

            var request = new CreateUploadVideoRequest();
            request.FileName = "03552d1d9235583a5e20ce3b677ea176.mp4";
            request.Title = null;

            try
            {
                var response = client.GetAcsResponse(request);
                Console.WriteLine(response.UploadAddress);
                Console.WriteLine(response.UploadAddress);
                Console.WriteLine(response.RequestId);
                Console.WriteLine(response.VideoId);
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

        public static DefaultAcsClient InitVodClient(string accessKeyId, string accessKeySecret)
        {
            // 点播服务接入区域
            string regionId = "cn-shanghai";
            IClientProfile profile = DefaultProfile.GetProfile(regionId, accessKeyId, accessKeySecret);
            // DefaultProfile.AddEndpoint(regionId, regionId, "vod", "vod." + regionId + ".aliyuncs.com");
            return new DefaultAcsClient(profile);
        }
    }
}
