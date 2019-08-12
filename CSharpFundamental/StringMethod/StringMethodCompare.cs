using System;

using NLog.Targets;

namespace CSharpFundamental.StringMethod
{
    public class StringMethodCompare
    {
        public void TestIndexOfAndContains()
        {
            string a = "fdsfsadgsdagadsgasfdgfdsaf?";


            /*
             *    /// <summary>Returns a value indicating whether a specified substring occurs within this string.</summary>
               /// <param name="value">The string to seek. </param>
               /// <returns>
               /// <see langword="true" /> if the <paramref name="value" /> parameter occurs within this string, or if <paramref name="value" /> is the empty string (""); otherwise, <see langword="false" />.</returns>
               /// <exception cref="T:System.ArgumentNullException">
               /// <paramref name="value" /> is <see langword="null" />. </exception>
               [__DynamicallyInvokable]
               public bool Contains(string value)
               {
               return this.IndexOf(value, StringComparison.Ordinal) >= 0;
               }
             */
            Console.WriteLine(a.IndexOf("?"));


            /*
             *     [SecuritySafeCritical]
               [__DynamicallyInvokable]
               [MethodImpl(MethodImplOptions.InternalCall)]
               public extern int IndexOfAny(char[] anyOf, int startIndex, int count);
               
               /// <summary>Reports the zero-based index of the first occurrence of the specified string in this instance.</summary>
               /// <param name="value">The string to seek. </param>
               /// <returns>The zero-based index position of <paramref name="value" /> if that string is found, or -1 if it is not. If <paramref name="value" /> is <see cref="F:System.String.Empty" />, the return value is 0.</returns>
               /// <exception cref="T:System.ArgumentNullException">
               /// <paramref name="value" /> is <see langword="null" />. </exception>
               [__DynamicallyInvokable]
               public int IndexOf(string value)
               {
               return this.IndexOf(value, StringComparison.CurrentCulture);
               }
             */

            Console.WriteLine(a.Contains("?"));

            int b = 1;
        }
    }
}
