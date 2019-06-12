using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Http;
using Aliyun.Acs.Core.Profile;

namespace aliyun_sms_winform
{
    public partial class Form1 : Form
    {
        private delegate void NotifyMe(string args);

        private event NotifyMe notify;

        public Form1()
        {
            InitializeComponent();
            notify += NotifyMeRobert;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Second % 2 == 0)
            {
                notify(DateTime.Now.Second.ToString());
            }
        }

        private void NotifyMeRobert(string args)
        {
            Console.WriteLine(args + "1400874454654");

            label1.Text = args + "10086";
        }

        private void SendMessageToMe()
        {
            var profile = DefaultProfile.GetProfile("cn-hangzhou", "", "");

            var client = new DefaultAcsClient(profile);

            CommonRequest request = new CommonRequest()
            {
                Method = MethodType.POST,
                Domain = "dysmsapi.aliyuncs.com",
                Version = "2017-05-25",
                Action = "SendSms",
            };

            request.AddQueryParameters("PhoneNumbers", "123456789");
            request.AddQueryParameters("SignName", "晚归提醒");
            request.AddQueryParameters("TemplateCode", "SMS_164590230");
            request.AddQueryParameters("TemplateParam", "{code:200}");

            try
            {
                CommonResponse response = client.GetCommonResponse(request);

                label1.Text = Encoding.UTF8.GetString(response.HttpResponse.Content);
            }
            catch (Exception e)
            {
                label1.Text = e.ToString();
                throw;
            }
        }
    }
}
