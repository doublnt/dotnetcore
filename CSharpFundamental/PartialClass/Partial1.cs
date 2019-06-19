using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.PartialClass
{
    internal partial class Partial
    {
        public string Name { get; set; } = "Robert";

        public void RunThePartial1()
        {
            Console.WriteLine(this.GetType());
        }
    }
}
