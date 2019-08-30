using System.Collections.Generic;

namespace CSharpFundamental.Dictionary
{
    public class TestNull
    {
        public static void RunWillNullDic()
        {
            var dic = new Dictionary<int, string>();

            dic.Add(1, "111");

            dic[1] = null;
        }
    }
}
