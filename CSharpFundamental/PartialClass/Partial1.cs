using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace CSharpFundamental.PartialClass
{
    internal partial class Partial
    {
        public string Name { get; set; } = "Robert";

        static Partial()
        {
            Console.WriteLine("Static Constructor!");
        }

        public void RunThePartial1()
        {
            Console.WriteLine(this.GetType());
        }
    }
}
