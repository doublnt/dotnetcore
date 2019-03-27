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
                System.Console.WriteLine(item.FullName + "\n" + item.Assembly);
            }
        }
    }
}
