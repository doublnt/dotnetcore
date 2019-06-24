using System;
using System.Reflection;

namespace CSharpFundamental
{
    public class ReflectionDemo
    {
        public void RelectionResovle()
        {
            Assembly assembly = Assembly.LoadFile("D:\\Working\\dotnetcore\\CSharpFundamental\\System.IO.dll");
            var types = assembly.GetTypes();

            foreach (var item in types)
            {
                Console.WriteLine(item.FullName + "\n" + item.Assembly);
            }
        }

        public void LoadAssemblyWithPublicTypes()
        {
            string dataAssembly = "System.Data, version=4.0.0.0, "
                                  + "culture=neutral, PublicKeyToken=b77a5c561934e089";
            Assembly a = Assembly.Load(dataAssembly);

            foreach (Type t in a.ExportedTypes)
            {
                Console.WriteLine(t.FullName);
            }
        }

        public static void Relection()
        {
            var demo = new ReflectionDemo();
            demo.RelectionResovle();
        }
    }
}
