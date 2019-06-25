using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSharpFundamental.Logging;


namespace CSharpFundamental.LibLog
{
    internal class LibLogger
    {
        private static readonly ILog logger = LogProvider.GetCurrentClassLogger();

        public static void WriteLog()
        {
            logger.Debug("Error Expected.");
        }
    }
}
