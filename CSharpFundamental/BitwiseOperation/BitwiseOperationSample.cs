using System;

namespace CSharpFundamental.BitwiseOperation
{
    /// <summary>
    ///     Bitwise Complement(~), Bitwise And(&)
    ///     Bitwise Or(|), Bitwise Exclusive OR(^)
    ///     Bitwise Left Shift("<<"), Bitwise Right Shift(">>")
    /// </summary>
    internal class BitwiseOperationSample
    {
        private const int value1 = 14;
        private const int value2 = 11;

        public void DoBitwiseOperation()
        {
            OrOperation();
            AndOperation();
            XorOperation();
            ComplementOperation();
            LeftShiftOpearation();
            RightShiftOperation();
        }

        private void OrOperation()
        {
            var orValue = value1 | value2;

            Console.WriteLine("OR Operation result: " + orValue);
        }

        private void AndOperation()
        {
            var andValue = value1 & value2;

            Console.WriteLine("And Operation result: " + andValue);
        }

        /// <summary>
        ///     Value same is 0, different is 1
        /// </summary>
        private void XorOperation()
        {
            var xorValue = value1 ^ value2;

            Console.WriteLine("XOR Operation result: " + xorValue);
        }

        /// <summary>
        ///     The ~ operator inverts each bits i.e. changes 1 to 0 and 0 to 1.
        ///     We got -27 as output when we were expecting 229.Why did this happen?
        ///     It happens because the binary value 11100101 which we expect to be 229 is actually a 2's complement representation
        ///     of -27. Negative numbers in computer are represented in 2's complement representation.
        ///     For any integer n, 2's complement of n will be -(n+1).
        /// </summary>
        private void ComplementOperation()
        {
            // 0001
            var value = 1;

            var complement = ~value;

            Console.WriteLine("The Complement value result:" + complement);
        }


        /// <summary>
        ///     In decimal, it is equivalent to
        ///     num * 2bits
        /// </summary>
        private void LeftShiftOpearation()
        {
            var leftShiftValue = value1 << 1;

            Console.WriteLine("Left shift value result(28):" + leftShiftValue);
        }

        /// <summary>
        ///     In decimal, it is equivalent to
        ///     floor(num / 2bits)
        /// </summary>
        private void RightShiftOperation()
        {
            var rightShiftValue = value2 >> 1;

            Console.WriteLine("Right shift value result(5): " + rightShiftValue);
        }
    }
}