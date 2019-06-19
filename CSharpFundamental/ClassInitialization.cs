using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    static class ClassInitialization
    {
        public static bool ThrowException { get; set; } = true;

        private static System.String valueString = "10086";
    }

    class FailingClass
    {
        static FailingClass()
        {
            if (ClassInitialization.ThrowException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public class TestA
    {

    }

    public class TestB
    {

    }

    // It can support multiple public class in one file
}
