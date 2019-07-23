using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aliyun.Acs.Core.Utils;

namespace CSharpFundamental.ThreadSafe
{
    class DicThreadTest
    {
        private Dictionary<string, string> testDic = new Dictionary<string, string>();

        public void InsertTest()
        {
            Task[] tasks = new Task[10];

            for (int i = 0; i < 10; i++)
            {
                int temp = i;
                tasks[temp] = Task.Run(() => DictionaryUtil.Add(testDic, "value1" + temp, "etstset"));
            }

            Task.WaitAll(tasks);


            Console.WriteLine(testDic.Count);
        }
    }
}
