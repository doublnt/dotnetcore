using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.GarbageCollection
{
    class GarbageCollectionDemo
    {
        private const int maxGarbage = 1000;

        public void GetTheMemory()
        {
            GarbageCollectionDemo.MakeSomeGarbage();

            Console.WriteLine("Memory used before GC.Collect()" + GC.GetTotalMemory(false));

            Console.WriteLine(GC.GetGeneration(maxGarbage));

            Console.WriteLine(GC.CollectionCount(0));
            Console.WriteLine(GC.CollectionCount(1));
            Console.WriteLine(GC.CollectionCount(2));

            GC.Collect();

            Console.WriteLine(GC.GetTotalMemory(true));

            Console.WriteLine(GC.MaxGeneration);
        }

        private static void MakeSomeGarbage()
        {
            Dictionary<string, string> dict;

            for (int i = 0; i < maxGarbage; ++i)
            {
                dict = new Dictionary<string, string>();
            }
        }
    }
}
