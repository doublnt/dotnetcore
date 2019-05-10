namespace CSharpFundamental
{
    public class CLRStackDemo
    {
        public void M1()
        {
            string name = "robert";
            M2(name);
            return;
        }

        public void M2(string name)
        {
            int length = name.Length;

            return;
        }
    }
}
