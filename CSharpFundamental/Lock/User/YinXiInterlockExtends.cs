using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental.Lock
{
    internal class YinXiInterlockExtends
    {
        public static int Maximum(ref int target, int value)
        {
            int currentVal = target, startVal, desiredVal;
            do
            {
                startVal = currentVal;
                desiredVal = Math.Max(startVal, value);
                currentVal = Interlocked.CompareExchange(ref target, desiredVal, startVal);
            } while (currentVal != startVal);

            return desiredVal;
        }

        delegate int Morpher<TResult, TArgument>(int startValue, TArgument argument, out TResult morphResult);

        static TResult Morph<TResult, TArgument>(ref int target, TArgument argument,
            Morpher<TResult, TArgument> morpher)
        {   
            TResult morphResult;
            int currentValue = target, startVal, desiredVal;

            do
            {
                startVal = currentValue;
                desiredVal = morpher(startVal, argument, out morphResult);
                currentValue = Interlocked.CompareExchange(ref target, desiredVal, startVal);
            } while (startVal != currentValue);

            return morphResult;
        }
    }
}
