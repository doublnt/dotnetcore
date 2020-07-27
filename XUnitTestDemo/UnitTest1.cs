using System;
using Xunit;

namespace XUnitTestDemo
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Asssert.True(1 == 1);
        }
    }
}
