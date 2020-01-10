using NLog;
using System;
using System.Collections.Generic;

namespace LoggingRabbit.Services
{
    public class LogNLog : ILog
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LogNLog()
        {
        }

        public void Debug(string message)
        {
            Logger logger = LogManager.GetLogger("RmqTarget");
            var logEventInfo = new LogEventInfo(LogLevel.Debug, "RmqLogMessage", $"{message}, generated at {DateTime.UtcNow}.");
            logger.Log(logEventInfo);
            //LogManager.Shutdown();  
        }

        public void Error(string message)
        {
            Logger logger = LogManager.GetLogger("RmqTarget");
            var logEventInfo = new LogEventInfo(LogLevel.Error, "RmqLogMessage", $"{message}, generated at {DateTime.UtcNow}.");
            logger.Log(logEventInfo);
        }

        public void Information(string message)
        {
            Logger logger = LogManager.GetLogger("RmqTarget");
            var logEventInfo = new LogEventInfo(LogLevel.Info, "RmqLogMessage", $"{message}, generated at {DateTime.UtcNow}.");
            logger.Log(logEventInfo);
        }

        public void Warning(string message)
        {
            Logger logger = LogManager.GetLogger("RmqTarget");
            var logEventInfo = new LogEventInfo(LogLevel.Warn, "RmqLogMessage", $"{message}, generated at {DateTime.UtcNow}.");
            logger.Log(logEventInfo);
        }
    }
}
