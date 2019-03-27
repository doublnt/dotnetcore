using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

using NuGet;

namespace CSharpFundamental
{
    class Program
    {
        static void Main(string[] args)
        {
            // PythonDemo();
            //CLRDemo();

            // var type = Type.GetType("System.Int32");
            // var typeInfo = type.GetTypeInfo();

            // Console.WriteLine(typeInfo.Name);

            
        }

        public static void Relection()
        {
            var demo = new ReflectionDemo();
            demo.RelectionResovle();
        }

        public static void CLRDemo()
        {
            CLRStackDemo demo = new CLRStackDemo();
            demo.M1();
        }

        public static void PythonDemo()
        {
            PythonEmbedded pythonEmbedded = new PythonEmbedded();

            pythonEmbedded.ExecutePythonCode();
            pythonEmbedded.ExecutePythonMethodInCode();
        }

        public static void DynamicDemo()
        {
            RefTestDemo refTestDemo = new RefTestDemo();
            int[] array = new int[5];
            refTestDemo.RefMethodTest(ref array);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            dynamic array2 = new System.Collections.Generic.List<int>() { 1, 2, 3 };

            dynamic addtoInt = 111;

            foreach (var item in array2)
            {
                dynamic value = item + addtoInt;
                Console.WriteLine(value);
            }
        }

        public static void DoFollowing(string msg)
        {
            Console.WriteLine("I will do the following!");
        }

        public void DoSomething()
        {
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
