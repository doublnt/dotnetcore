using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFundamental
{
    class TimerTest
    {
        private static Timer _sTimer;

        public void DoTimerThing()
        {
            //The Timer delegate declare is :
            //delegate void TimerCallback(Object state)

            Console.WriteLine("Checking Status every 2 seconds");

            _sTimer = new Timer(Status, null, Timeout.Infinite, Timeout.Infinite);

            ////相当于启动计时器。
            //_sTimer.Change(0, Timeout.Infinite);

            Status();

            //因为在多个线程中调用，防止进程被终止。
            Console.ReadLine();

        }

        private void Status(Object status)
        {
            Console.WriteLine("In status at:{0}", DateTime.Now);

            Thread.Sleep(1000);

            _sTimer.Change(2000, Timeout.Infinite);
        }

        private async void Status()
        {
            while (true)
            {
                Console.WriteLine("Checking Status at {0}", DateTime.Now);

                //在不阻塞线程的前提下延迟 2 秒
                await Task.Delay(2000);
            }
        }
    }
}
