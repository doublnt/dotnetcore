//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Reflection;
//using log4net.Config;
//using log4net.Core;
//using log4net.Repository;
//using NLog;
//using Serilog;
//using Serilog.Events;
//using Serilog.Parsing;

//namespace LibLogSample
//{
//    public class CommonLog
//    {
//        private static readonly LogLevel[] nLogLevelArray =
//        {
//            LogLevel.Trace,
//            LogLevel.Debug,
//            LogLevel.Info,
//            LogLevel.Warn,
//            LogLevel.Error,
//            LogLevel.Fatal
//        };

//        private static readonly MessageTemplateParser serilogMessageTemplateParser = new MessageTemplateParser();
//        private static LoggerConfiguration loggerConfig;

//        private static readonly LogEventLevel[] serLogEventLevels =
//        {
//            LogEventLevel.Verbose,
//            LogEventLevel.Debug,
//            LogEventLevel.Information,
//            LogEventLevel.Warning,
//            LogEventLevel.Error,
//            LogEventLevel.Fatal
//        };

//        private static readonly Level[] log4NetLogLevelArray =
//        {
//            Level.Trace,
//            Level.Debug,
//            Level.Info,
//            Level.Warn,
//            Level.Error,
//            Level.Fatal
//        };

//        private static ILoggerRepository log4netLogRepo;

//        private static readonly Logger logger = Logger.GetLoggerFor<CommonLog>();

//        private static Action<DateTime, int, string, Exception> NLogHandlerProvider(string loggerName)
//        {
//            var nLogger = LogManager.GetLogger(loggerName);

//            return delegate(DateTime timeStamp, int logLevel, string message, Exception exception)
//            {
//                var logEvent = new LogEventInfo(nLogLevelArray[logLevel], loggerName, message);
//                logEvent.TimeStamp = timeStamp;
//                nLogger.Log(logEvent);
//            };
//        }

//        private static Action<DateTime, int, string, Exception> SerilogHandlerProvider(string loggerName)
//        {
//            var serilog = new LoggerConfiguration()
//                .MinimumLevel.Verbose()
//                .WriteTo.Console()
//                .WriteTo.File("serilog\\serilog.log")
//                .CreateLogger();

//            return delegate(DateTime timeStamp, int logLevel, string message, Exception exception)
//            {
//                var timeStampOffset = new DateTimeOffset(timeStamp);

//                var tokens = new List<MessageTemplateToken>();
//                var parser = new MessageTemplateParser();

//                var messageTemplate = serilogMessageTemplateParser.Parse(message);

//                var properties = new List<LogEventProperty>();

//                var logEvent = new LogEvent(timeStampOffset, serLogEventLevels[logLevel], exception, messageTemplate,
//                    properties);

//                serilog.Write(logEvent);
//            };
//        }


//        private static Action<DateTime, int, string, Exception> Log4NetLogHandlerProvider(string loggerName)
//        {
//            if (log4netLogRepo == null)
//            {
//                log4netLogRepo = log4net.LogManager.GetRepository(Assembly.GetEntryAssembly());
//                XmlConfigurator.ConfigureAndWatch(log4netLogRepo, new FileInfo("log4net.config"));
//            }

//            var log4netLogger = log4netLogRepo.GetLogger(loggerName);

//            return delegate(DateTime timeStamp, int logLevel, string message, Exception exception)
//            {
//                var logEventData = new LoggingEventData();

//                logEventData.Level = log4NetLogLevelArray[logLevel];
//                logEventData.TimeStampUtc = timeStamp.ToUniversalTime();

//                logEventData.Message = message;

//                if (exception != null)
//                {
//                    logEventData.ExceptionString = exception.ToString();
//                }

//                var logEvent = new LoggingEvent(logEventData);
//                log4netLogger.Log(logEvent);
//            };
//        }


//        public static void ExecuteTheLogger()
//        {
//            Logger.LoggerHandlerProvider = NLogHandlerProvider;

//            Logger.LoggerHandlerProvider = Log4NetLogHandlerProvider;

//            Logger.LoggerHandlerProvider = SerilogHandlerProvider;

//            Logger.EventLogged += LoggerEventLoggered;

//            logger.Debug("Test Debug");
//            logger.Info("Test Info");
//            logger.Error("Test Error");
//            logger.Fatal("Test Fatal");
//        }

//        private static void LoggerEventLoggered(object sender, Logger.LogEventArgs e)
//        {
//            Console.WriteLine($"{nameof(Logger)}.{nameof(Logger.EventLogged)}[{e.LogLevel}] {e.Message}");
//        }
//    }
//}
