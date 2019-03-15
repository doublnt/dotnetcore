using System;
using System.Net;

namespace CSharpFundamental
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Public get and set method
            PrivateClass pClass = new PrivateClass();
            pClass.Name = "Robert";
            Console.WriteLine(pClass.Name);

            pClass.Version = "1.0";
            Console.WriteLine(pClass.Version);

            pClass = new PrivateClass("Robert", "2.0", "fakeHashcode");

            Console.WriteLine(pClass.Name + "|" + pClass.Version + "|" + pClass.HashCode);

            new AnonymousType().CreateAnonymousAndExecute();

            TestConstrcutor tc = new TestConstrcutor("222");

            tc.SetNamespaceParams(y: 1, x: 2);
            tc.SetNamespaceParams(1, 2);

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create("https://www.alibabacloud.com");
            request.Timeout = 1000;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();

            request = (HttpWebRequest) WebRequest.Create("https://www.cnblogs.com");
            response = (HttpWebResponse) request.GetResponse();

            AnonymousType.DoTheFollowing doTheFollowing = new AnonymousType.DoTheFollowing(DoFollowing);
            doTheFollowing("Hello");
        }

        public static void DoFollowing(string msg)
        {
            Console.WriteLine("I will do the following!");
        }
    }

    class TestConstrcutor : ConstructorClass
    {
        public TestConstrcutor() : base() { }

        public TestConstrcutor(string param1) : base(param1) { }

        public void SetNamespaceParams(int x, int y)
        {
            Console.WriteLine("X: {0} Y: {1}", x, y);
        }
    }
}
