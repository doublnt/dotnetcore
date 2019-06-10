using System;
using System.IO;
using System.Net;

using Moq;

using Pose;

namespace CSharpFundamental
{
    internal class PoseSample
    {
        private void PrintMsg()
        {
            Console.WriteLine("THIS IS ROBERT");
        }

        private int ReturnAgeValue()
        {
            return 10086;
        }

        public void PoseMethod()
        {
            var replaceMethod = Shim.Replace(() => Is.A<PoseSample>().PrintMsg())
                .With(delegate (PoseSample @this) { Console.WriteLine("122"); });

            var replaceReturnInt = Shim.Replace(() => Is.A<PoseSample>().ReturnAgeValue())
                .With(delegate (PoseSample @this)
                {
                    throw new IOException();
                    return 100;
                });

            PoseContext.Isolate(() =>
            {
                var poseSample = new PoseSample();
                poseSample.PrintMsg();

                var age = poseSample.ReturnAgeValue();
                Console.WriteLine(age);
            }, replaceMethod, replaceReturnInt);
        }

        public void MockGetResponse()
        {
            var request = WebRequest.Create("Https://www.baidu.com");

            var mockResonse = new Mock<HttpWebRequest>();
            mockResonse.Setup(f => f.GetResponse())
            .Throws(new IOException());

            mockResonse.Object.GetResponse();
        }
    }
}
