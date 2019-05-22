using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.CaptureVariables
{
    class CaptureVariableSample
    {
        delegate void SomeAction();

        private SomeAction MakeDelegate()
        {
            Random random = new Random();

            return () => { Console.WriteLine(random.Next()); };
        }

        internal void DoCaptureThing()
        {
            SomeAction action = MakeDelegate();

            action();
            action();
        }

        internal void SomeActionList()
        {
            SomeAction[] someActions = new SomeAction[10];

            int x;
            for (int i = 0; i < 10; ++i)
            {
                x = 0;
                int y = 0;
                someActions[i] = delegate
                {
                    Console.WriteLine("{0}, {1}", x, y);
                    x++;
                    y++;
                };
            }


            someActions[0](); // Prints 0, 0
            someActions[0](); // Prints 1, 1
            someActions[0](); // Prints 2, 2
            someActions[1](); // Prints 3, 0
            someActions[0](); // Prints 4, 3
            x = 10;
            someActions[2](); // Prints 10, 0
        }
    }
}
