using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    internal sealed class Type1 { }

    internal sealed class Type2 { }


    class StateMachine
    {
#pragma warning disable 1998
        private async Task<Type1> Method1Async()
#pragma warning restore 1998
        {
            return new Type1();
        }

#pragma warning disable 1998
        private async Task<Type2> Method2Async()
#pragma warning restore 1998
        {
            return new Type2();
        }

        private async Task<string> MyMthodAsync(int argument)
        {
            int local = argument;

            try
            {
                Type1 result1 = await Method1Async();

                for (int i = 0; i < 3; i++)
                {
                    Type2 result2 = await Method2Async();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            return "done";
        }
    }
}
