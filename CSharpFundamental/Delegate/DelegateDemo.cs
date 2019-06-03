using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamental.Delegate
{
    class DelegateDemo
    {
        internal delegate void Feedback(int value);

        public void DoDelegateThing()
        {
            // 创建委托实例，不易变
            var fb = new Feedback(GiveMeFeedback);

            fb(10086);
        }

        private void GiveMeFeedback(int value1)
        {
            Console.WriteLine("Your feedback is: " + value1);
        }
    }
}
