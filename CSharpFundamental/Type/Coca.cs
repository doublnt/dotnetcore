using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Type
{
    class Coca
    {
        public string Name { get; set; }

        public void TestCoca()
        {
            Coca coca1 = new Coca();
            coca1.Name = "10076";

            Coca coca2 = coca1;
            coca2.Name = "yinxi";

            Console.WriteLine(coca1.Name);
        }

        private void MakeCocaNull(Coca coca)
        {
            coca = null;
        }

        public void TestVector()
        {
            Vector v1 = new Vector();
            v1.x = 1;
            v1.y = 3;

            Vector v2 = v1;

            v2.x = 0;
            v2.y = 0;

            Console.WriteLine(v1.x + " | " + v1.y);


            MakeVectorNull(v1);

            Console.WriteLine(v1.x + " | " + v1.y);
        }

        private void MakeVectorNull(Vector x)
        {
            x.x = 0;
            x.y = 0;
        }
    }
}

struct Vector
{
    public int x;
    public int y;
}
