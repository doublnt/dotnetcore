
using System;

using LibLogSample.Logging;

namespace LibLogSample
{
    public class CommonLog
    {
        private static readonly ILog Logger = LogProvider.For<CommonLog>();

        public CommonLog()
        {
            using (LogProvider.OpenNestedContext("message"))
            using (LogProvider.OpenMappedContext("key", "value"))
            {
                Logger.Log(LogLevel.Info, () => "test message");
            }
        }
    }
}
