using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading;
using CSharpFundamental.CSharpVersion1;

namespace CSharpFundamental
{
    internal class Program
    {
        //        public static int x;
        //        public static int y;

        private static void Main(string[] args)
        {
            #region comment code

            //            Console.WriteLine(x + " | " + y);
            //
            //            x = 20;
            //            y = 1;
            //            Console.WriteLine(x + " | " + y);
            //
            //            x = 30;
            //            y = x;
            //            Console.WriteLine(x + " | " + y);
            // PythonDemo();

            //CLRDemo();

            // var type = Type.GetType("System.Int32");
            // var typeInfo = type.GetTypeInfo();

            // Console.WriteLine(typeInfo.Name);

            //            var reflect = new ReflectionDemo();
            //            reflect.LoadAssemblyWithPublicTypes();
            //
            //            var serialize = new Serialize();
            //
            //            serialize.ExecuteMemory();

            //var threadPool = new ThreadPoolClass();
            //threadPool.MonitorTheThreadPool();

            //            var parallel = new ParallelTest();
            //            parallel.Parallel1();
            //
            //            var parallelLinq = new ParallelLinq();
            //            parallelLinq.DoParallelLinq();
            //
            //            var timerTest = new TimerTest();
            //            timerTest.DoTimerThing();

            //            var fileStreamTest = new FileStreamTest();
            //            fileStreamTest.GetFileBytes();

            //var parallelHttp = new ParallelHttpClientFactory();

            //await parallelHttp.DoParallelThing();

            Console.WriteLine("Current Managed Thread Id = {0}", Thread.CurrentThread.ManagedThreadId);

            //            var primitiveDemo = new PrimitiveConstruct();
            //
            //            primitiveDemo.DoWorkerThing();


            //            var threadSharingData = new ThreadSharingData();
            //            threadSharingData.DoThreadThing1();
            //            threadSharingData.DoThreadThing2();

            //var multipleWebRequest = new MultipleWebRequest();

            //Console.ReadLine();

            //Console.WriteLine("Item\tData");
            //char split = '-';

            //Console.WriteLine(String.Concat(Enumerable.Repeat(split, "item".Length)));

            #endregion

            //var actionSample = new ActionSampleWithClosure();
            //actionSample.TimeCallbackFunc();

            //var captureClass = new CaptureVariableSample();
            //captureClass.DoCaptureThing();

            //captureClass.SomeActionList();

            //var multipleThread = new MultipleThreadCompete();
            //multipleThread.DoTheCompete();


            //var linqClass = new LinqTest();
            //linqClass.ExecuteLinqFunc();

            //Func<string, string, string> returnMyName = (str1, str2) => str1 + str2;

            //Action<string, string> printMyAge = (str1, str2) => Console.WriteLine(str1 + str2 + "is 50 years old");

            //Console.WriteLine(returnMyName("Hello", "World!"));
            //printMyAge("Robert", "Mike ");

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

            //var nullReference = new HandleNullReference();
            //nullReference.DoTheNullConditions();

            //var instance = new FailingClass();

            //try
            //{
            //    var instance = new FailingClass();
            //}
            //catch (TypeInitializationException)
            //{
            //    ClassInitialization.ThrowException = false;
            //    var instance = new FailingClass();
            //}

            //var operators = new OperationTest();
            //operators.ComputeShiftOperators();

            //var bitwiseOperation = new BitwiseOperationSample();

            //bitwiseOperation.DoBitwiseOperation();

            //var staticConstructor = new StaticConstructorSample();
            //staticConstructor.PrintTheStaticValue();

            //var delegateDemo = new DelegateDemo();
            //delegateDemo.DoDelegateThing();

            var staticType = new StaticTypeDemo();
            staticType.DoStaticTypeThing();
        }

        public static void Relection()
        {
            var demo = new ReflectionDemo();
            demo.RelectionResovle();
        }

        public static void CLRDemo()
        {
            var demo = new CLRStackDemo();
            demo.M1();
        }

        public static void DynamicDemo()
        {
            var refTestDemo = new RefTestDemo();
            var array = new int[5];
            refTestDemo.RefMethodTest(ref array);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            dynamic array2 = new List<int>
                {1, 2, 3};

            dynamic addtoInt = 111;

            //            foreach (var item in array2)
            //            {
            //                dynamic value = item + addtoInt;
            //                Console.WriteLine(value);
            //            }
        }

        public static void DoFollowing(string msg)
        {
            Console.WriteLine("I will do the following!");
        }

        public void DoSomething()
        {
            //Public get and set method
            var pClass = new PrivateClass();
            pClass.Name = "Robert";
            Console.WriteLine(pClass.Name);

            pClass.Version = "1.0";
            Console.WriteLine(pClass.Version);

            pClass = new PrivateClass("Robert", "2.0", "fakeHashcode");

            Console.WriteLine(pClass.Name + "|" + pClass.Version + "|" + pClass.HashCode);

            new AnonymousType().CreateAnonymousAndExecute();

            var tc = new TestConstrcutor("222");

            tc.SetNamespaceParams(y: 1, x: 2);
            tc.SetNamespaceParams(1, 2);

            var request = (HttpWebRequest)WebRequest.Create("https://www.alibabacloud.com");
            request.Timeout = 1000;
            var response = (HttpWebResponse)request.GetResponse();

            request = (HttpWebRequest)WebRequest.Create("https://www.cnblogs.com");
            response = (HttpWebResponse)request.GetResponse();

            var doTheFollowing = new AnonymousType.DoTheFollowing(DoFollowing);
            doTheFollowing("Hello");
        }
    }

    internal class TestConstrcutor : ConstructorClass
    {
        public TestConstrcutor()
        {
        }

        public TestConstrcutor(string param1) : base(param1)
        {
        }

        public void SetNamespaceParams(int x, int y)
        {
            Console.WriteLine("X: {0} Y: {1}", x, y);
        }
    }
}
