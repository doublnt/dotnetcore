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
        private async Task<Type1> Method1Async()
        {
            return new Type1();
        }

        private async Task<Type2> Method2Async()
        {
            return new Type2();
        }

        private async Task<String> MeMthodAsync(Int32 argument)
        {
            Int32 local = argument;

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
