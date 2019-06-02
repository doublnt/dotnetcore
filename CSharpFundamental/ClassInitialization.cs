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
}
