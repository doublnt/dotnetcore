using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using CSharpFundamental.GarbageCollection;
using CSharpFundamental.LazyInitialization;
using CSharpFundamental.LibLog;
using CSharpFundamental.MultipleThread;
using CSharpFundamental.MultipleThread.Book;
using CSharpFundamental.NetWorkDemoAnalyse;
using CSharpFundamental.Operation;

namespace CSharpFundamental
{
    internal class Program
    {
        //        public static int x;
        //        public static int y;

        private static async Task Main(string[] args)
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

            //var staticType = new StaticTypeDemo();
            //staticType.DoStaticTypeThing();

            //var reflectDemo = new ReflectSample();

            //reflectDemo.DoRelectThing();

            //new UriSample().PrintTheSegmentOfUri();

            //new PoseSample().PoseMethod();

            //new ExpressionTreeSample().DoExpressionThing();

            //new ExtendsMethodExprssionTree().PrintEnumerable();

            //var asyncDemo = new AsyncDemo();

            //Console.WriteLine(await asyncDemo.GetValue());

            //await asyncDemo.ThrowExcpetionMethod();

            //new ActionSampleWithClosure().TestAction();


            //new PartialClass.Partial().DisplayPartial();

            //new DynamicSample().DynamicExecute();


            //new LibLogTest().DoCommonLog();

            //LibLogger.WriteLog();

            //new ConsumerLibLog().OpenNewTaskToHandleThisAsync();

            //var item2 = TupleSample.GetStructureTuple();
            //Console.WriteLine(item2.name + "\t" + item2.address + "\t" + item2.age);

            //new LazyInitializationSample().LazyDemo();

            //Console.WriteLine(sizeof(char) + "|" + sizeof(byte) + sizeof(int));

            //AddRandomNumToArray.ExecuteTheCode();

            //new ParallelInvoke().RunTheThread();

            //new MultipleThreadAddDemo().RunTheLogic

            //await new TaskDelayDemo().DoSomethingAsync();

            //new GarbageCollectionDemo().GetTheMemory();

            //new AnonymousDemo().DoTheAnonymousSample();

            new Final().TestCode();
        }
    }
}
