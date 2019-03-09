using System;
using System.Reflection;

namespace dotnet_core_version
{
    class Program
    {
        static void Main(string[] args)
        {

            var framework_Version = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
            Console.WriteLine(framework_Version);
            framework_Version = System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
            Console.WriteLine(framework_Version);
             framework_Version = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory();
            Console.WriteLine(framework_Version);
        }
    }
}
