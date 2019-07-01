using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

using LibLogSample.Logging;
using LibLogSample.Logging.LogProviders;

namespace LibLogSample
{
    public class CommonLibLog
    {
        private static readonly ILog logger = LogProvider.For<CommonLibLog>();

        public CommonLibLog()
        {
            logger.Error("This is class library test Error." + Thread.CurrentThread.ManagedThreadId);
        }
    }

    //internal class ColoredConsoleLogProvider : LogProviderBase
    //{
    //    private static readonly Dictionary<LogLevel, ConsoleColor> Colors = new Dictionary<LogLevel, ConsoleColor>
    //    {
    //        {LogLevel.Fatal, ConsoleColor.Red},
    //        {LogLevel.Error, ConsoleColor.Yellow},
    //        {LogLevel.Warn, ConsoleColor.Magenta},
    //        {LogLevel.Info, ConsoleColor.White},
    //        {LogLevel.Debug, ConsoleColor.Gray},
    //        {LogLevel.Trace, ConsoleColor.DarkGray}
    //    };

    //    public override Logging.Logger GetLogger(string name)
    //    {
    //        return (logLevel, messageFunc, exception, formatParameters) =>
    //        {
    //            if (messageFunc == null)
    //            {
    //                return true; // All log levels are enabled
    //            }

    //            if (Colors.TryGetValue(logLevel, out var consoleColor))
    //            {
    //                var originalForeground = Console.ForegroundColor;
    //                try
    //                {
    //                    Console.ForegroundColor = consoleColor;
    //                    WriteMessage(logLevel, name, messageFunc, formatParameters, exception);
    //                }
    //                finally
    //                {
    //                    Console.ForegroundColor = originalForeground;
    //                }
    //            }
    //            else
    //            {
    //                WriteMessage(logLevel, name, messageFunc, formatParameters, exception);
    //            }

    //            return true;
    //        };
    //    }

    //    private static void WriteMessage(
    //        LogLevel logLevel,
    //        string name,
    //        Func<string> messageFunc,
    //        object[] formatParameters,
    //        Exception exception)
    //    {
    //        var message = string.Format(CultureInfo.InvariantCulture, messageFunc(), formatParameters);

    //        if (exception != null)
    //        {
    //            message = message + "|" + exception;
    //        }

    //        Console.WriteLine("{0} | {1} | {2} | {3}", DateTime.UtcNow, logLevel, name, message);
    //    }
    //}
}
