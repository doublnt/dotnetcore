using LibLogSample;

using Serilog;

namespace CSharpFundamental.LibLog
{
    internal class ConsumerLibLog
    {
        public void BeginToLogTheLibraryEvent()
        {
            var log = new LoggerConfiguration()
                .WriteTo.ColoredConsole(
                    outputTemplate: "{Timestamp:yyyy:MM:dd:HH:mm} [{Level}] ({Name:l}) {Message}{NewLine}{Exception}")
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Logger = log;

            var commonLibLog = new CommonLibLog();

            Log.Information("This is client logger info.");
        }
    }
}
