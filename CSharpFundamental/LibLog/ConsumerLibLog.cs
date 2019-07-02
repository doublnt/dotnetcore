using System;
using System.Threading.Tasks;

using LibLogSample;

using NLog;
using NLog.Config;
using NLog.Targets;

namespace CSharpFundamental.LibLog
{
    internal class ConsumerLibLog
    {
        public void BeginToLogTheLibraryEvent(object state)
        {
            #region serilog demo

            //var log = new LoggerConfiguration()
            //    .WriteTo.ColoredConsole(
            //        outputTemplate: "{Timestamp:yyyy:MM:dd:HH:mm} [{Level}] {Message}{NewLine}{Exception}{NewLine}{NewLine}")
            //    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();
            //Log.Logger = log;
            //Log.Information($"This is client logger info, ID:{Thread.CurrentThread.ManagedThreadId} State:{state}");

            #endregion

            #region log4Net demo

            //XmlDocument log4netConfig = new XmlDocument();
            //log4netConfig.Load(File.OpenRead("log4net.config"));

            //var repo = log4net.LogManager.CreateRepository(Assembly.GetEntryAssembly(),
            //    typeof(log4net.Repository.Hierarchy.Hierarchy));
            //XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
            //ILog log = LogManager.GetLogger(typeof(ConsumerLibLog));
            //log.Error("Cleint Error.");

            #endregion

            #region NLog demo

            var config = new LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new FileTarget("logfile") {FileName = "file.txt"};
            var logconsole = new ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            LogManager.Configuration = config;
            var Logger = LogManager.GetCurrentClassLogger();
            Logger.Info("Test this is from client logger.");

            #endregion

            var commonLibLog = new CommonLibLog();
        }

        public void OpenNewTaskToHandleThisAsync()
        {
            var currentTask = Task.Run(() => BeginToLogTheLibraryEvent(10));

            Console.WriteLine(currentTask.Status);

            MultipleThreadToLogger();
        }

        private void MultipleThreadToLogger()
        {
            var taskCount = 10;

            var tasks = new Task[taskCount];

            for (var i = 0; i < taskCount; ++i)
            {
                var temp = i;
                tasks[i] = Task.Run(() => BeginToLogTheLibraryEvent(temp));
            }

            // Task.WhenAll();
            //var index = Task.WaitAny(tasks);

            // Parallel.Invoke

            var actions = new Action[taskCount];

            for (var i = 0; i < taskCount; ++i)
            {
                var temp = i;
                actions[i] = () => BeginToLogTheLibraryEvent(temp);
            }

            Parallel.Invoke(actions);

            // Output the tasks id and status
            //for (int i = 0; i < taskCount; ++i)
            //{
            //    Console.WriteLine(tasks[i].Id + " | " + tasks[i].Status);
            //}
        }
    }
}
