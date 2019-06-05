using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Reflect
{
    class ReflectSample
    {
        public void DoRelectThing()
        {
            GenericTypeReflect();
        }

        private void GenericTypeReflect()
        {
            var type = typeof(Dictionary<,>);

            var dictonary = type.MakeGenericType(typeof(string), typeof(string));

            Console.WriteLine(type.FullName);

            Console.WriteLine(dictonary.FullName);
        }
    }
}
