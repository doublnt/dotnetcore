namespace CSharpFundamental
{
    public class RefTestDemo
    {
        public void RefMethodTest(ref int[] value1)
        {
            for (int i = 0; i < value1.Length; ++i)
            {
                value1[i] = 10086 + i;
            }
        }
    }
}
