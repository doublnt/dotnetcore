using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace LibLogSample
{
    public class Logger
    {
        private static readonly IDictionary<string, Logger> loggers = new ConcurrentDictionary<string, Logger>();
        private static Func<string, Action<DateTime, int, string, Exception>> loggerHandlerProvider;

        private Logger(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public static Func<string, Action<DateTime, int, string, Exception>> LoggerHandlerProvider
        {
            get { return loggerHandlerProvider; }
            set
            {
                if (loggerHandlerProvider != value)
                {
                    loggerHandlerProvider = value;

                    foreach (var logger in loggers.Values)
                    {
                        logger.RefreshLogHandler();
                    }
                }
            }
        }

        private Action<DateTime, int, string, Exception> LogHandler { get; set; }

        private string Name { get; }

        internal static event EventHandler<LogEventArgs> EventLogged;

        private void RefreshLogHandler()
        {
            if (LoggerHandlerProvider != null)
            {
                LogHandler = LoggerHandlerProvider(Name);
            }
            else
            {
                LogHandler = null;
            }
        }

        internal static Logger GetLogger(string name)
        {
            if (!loggers.ContainsKey(name))
            {
                var logger = new Logger(name);
                loggers.Add(logger.Name, logger);
            }

            return loggers[name];
        }

        internal static Logger GetLoggerFor<T>()
        {
            var type = typeof(T);
            return GetLogger(type.FullName);
        }

        internal void Log(LogLevel logLevel, string message, Exception exception, params object[] args)
        {
            if ((LogHandler != null) | (EventLogged != null))
            {
                var timeStamp = DateTime.Now;

                var formattedMessage = string.Format(message, args);

                var eventLoggdHandler = EventLogged;

                if (eventLoggdHandler != null)
                {
                    var logEventArgs = new LogEventArgs(Name, timeStamp, logLevel, message, exception);
                    eventLoggdHandler.Invoke(null, logEventArgs);
                }

                LogHandler?.Invoke(timeStamp, (int)logLevel, formattedMessage, exception);
            }
        }

        internal void Log(LogLevel level, string message, params object[] args)
        {
            Log(level, message, null, args);
        }

        internal void Debug(string message, params object[] args)
        {
            Log(LogLevel.Debug, message, args);
        }

        internal void Debug(string message, Exception excption, params object[] args)
        {
            Log(LogLevel.Debug, message, excption, args);
        }

        internal void Error(string message, params object[] args)
        {
            Log(LogLevel.Error, message, args);
        }

        internal void Error(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Error, message, exception, args);
        }

        internal void Fatal(string message, params object[] args)
        {
            Log(LogLevel.Fatal, message, args);
        }

        internal void Fatal(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Fatal, message, exception, args);
        }

        internal void Info(string message, params object[] args)
        {
            Log(LogLevel.Info, message, args);
        }

        internal void Info(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Info, message, exception, args);
        }

        internal void Trace(string message, params object[] args)
        {
            Log(LogLevel.Trace, message, args);
        }

        internal void Trace(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Trace, message, exception, args);
        }

        internal void Warn(string message, params object[] args)
        {
            Log(LogLevel.Warn, message, args);
        }

        internal void Warn(string message, Exception exception, params object[] args)
        {
            Log(LogLevel.Warn, message, exception, args);
        }

        internal enum LogLevel
        {
            Fatal = 5,
            Error = 4,
            Warn = 3,
            Info = 2,
            Debug = 1,
            Trace = 0
        }

        internal class LogEventArgs
        {
            public LogEventArgs(string loggerName, DateTime timeStamp, LogLevel logLevel, string message,
                Exception exception)
            {
                LoggerName = loggerName ?? throw new ArgumentNullException(nameof(LoggerName));
                TimeStamp = timeStamp;
                LogLevel = logLevel;
                Message = message;
                TimeStamp = timeStamp;
                Exception = exception;
            }

            public Exception Exception { get; }
            public string LoggerName { get; }
            public LogLevel LogLevel { get; }
            public string Message { get; }
            public DateTime TimeStamp { get; }
        }
    }
}
