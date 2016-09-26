using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Nexus.Web.Infrastructure
{
    public class LogWriter : ILogWriter
    {
        //private readonly ILogFormatter formatter;
        //private static readonly ILog logger = LogManager.GetLogger(typeof(LogWriter));
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Force log4net to load the configuration details.
        /// </summary>
        static LogWriter()
        {
            //XmlConfigurator.Configure();
        }

        //public LogWriter(ILogFormatter formatter)
        //{
        //    this.formatter = formatter;
        //}

        //public void LogError(IExceptionClassifier classifier)
        //{
        //    IExceptionClass exceptionClass = classifier.GetEventClass();
        //    string msg = formatter.GetFormattedMessage(exceptionClass.Subsystem, exceptionClass.LastException);

        //    Error(exceptionClass.GetEventId(), msg, exceptionClass.LastException);
        //}

        public void Error(int eventId, IEnumerable<string> messages)
        {
            Error(eventId, string.Join(",", messages.ToArray()));
        }

        /// <summary>
        /// Logs the specified error message.
        /// </summary>
        /// <param name="eventId">The id of the event</param>
        /// <param name="message">The message.</param>
        public void Error(int eventId, string message)
        {
            Error(eventId, message, null);
        }

        /// <summary>
        /// Logs the specified error message and exception.
        /// We need to use a new transaction here as we do not want logging to fail because a transaction fails.
        /// </summary>
        /// <param name="eventId">The id of the event</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Error(int eventId, string message, Exception exception)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                if (logger.IsErrorEnabled)
                {
                    WriteLog(eventId, message, NLog.LogLevel.Error, exception);
                }
            }
        }

        /// <summary>
        /// Logs the specified fatal error message.
        /// </summary>
        /// <param name="eventId">The id of the event</param>
        /// <param name="message">The message.</param>
        public void Fatal(int eventId, string message)
        {
            Fatal(eventId, message, null);
        }

        /// <summary>
        /// Logs the specified fatal error message and exception.
        /// </summary>
        /// <param name="eventId">The id of the event</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public void Fatal(int eventId, string message, Exception exception)
        {
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                if (logger.IsFatalEnabled)
                {
                    WriteLog(eventId, message, NLog.LogLevel.Fatal, exception);
                }
            }
        }

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="eventId">The id of the event</param>
        public void Debug(int eventId, string message)
        {
            if (logger.IsDebugEnabled)
            {
                WriteLog(eventId, message, NLog.LogLevel.Debug, null);
            }
        }

        public void Info(int eventId, string message)
        {
            if (logger.IsInfoEnabled)
            {
                WriteLog(eventId, message, NLog.LogLevel.Info, null);
            }
        }

        public void Warn(int eventId, string message)
        {
            if (logger.IsWarnEnabled)
            {
                WriteLog(eventId, message, NLog.LogLevel.Warn, null);
            }
        }

        public IList<Tuple<string, string, string>> GetAppendersAndLevels()
        {
            throw new NotImplementedException();
            //return
            //    logger.Logger.Repository.GetAppenders()
            //        .Select(appender => new Tuple<string, string, string>(appender.Name, LogLevel(appender.Name), GetFilePath(appender.Name)))
            //        .ToList();
        }

        //public string GetFilePath(string appenderName)
        //{
        //    var appender = logger.Logger.Repository.GetAppenders().SingleOrDefault(a => a.Name == appenderName);
        //    if (appender != null)
        //    {
        //        if (appender is RollingFileAppender)
        //        {
        //            return ((RollingFileAppender)appender).File;
        //        }
        //    }
        //    return "";
        //}

        public string LogLevel(string appenderAString)
        {
            //var appender = logger.Logger.Repository.GetAppenders().SingleOrDefault(a => a.Name == appenderAString);
            //if (appender != null)
            //{
            //    return
            //        ((log4net.Filter.LevelRangeFilter)(((log4net.Appender.AppenderSkeleton)(appender)).FilterHead))
            //            .LevelMin.DisplayName;
            //}

            if (logger.IsDebugEnabled)
                return "Debug";
            if (logger.IsInfoEnabled)
                return "Info";
            if (logger.IsWarnEnabled)
                return "Warn";
            if (logger.IsErrorEnabled)
                return "Error";
            if (logger.IsFatalEnabled)
                return "Fatal";

            return "None";
        }

        //public void ChangeLogLevel(string levelAsString, string appenderName)
        //{

        //    LogLevel level = GetLevel(levelAsString);

        //    var appender = logger.Logger.Repository.GetAppenders().SingleOrDefault(a => a.Name == appenderName);
        //    if (appender != null)
        //    {
        //        ((log4net.Filter.LevelRangeFilter)(((log4net.Appender.AppenderSkeleton)(appender)).FilterHead))
        //            .LevelMin = level;
        //    }
        //}

        private LogLevel GetLevel(string levelAsString)
        {
            switch (levelAsString)
            {
                case "OFF":
                    return NLog.LogLevel.Off;
                case "INFO":
                    return NLog.LogLevel.Info;
                case "ERROR":
                    return NLog.LogLevel.Error;
                case "DEBUG":
                    return NLog.LogLevel.Debug;
                case "FATAL":
                    return NLog.LogLevel.Fatal;
                case "WARN":
                    return NLog.LogLevel.Warn;
                default:
                    return NLog.LogLevel.Off;
                //    return NLog.LogLevel.AllLevels;

            }
        }

        private static void WriteLog(int eventId, string message, LogLevel level, Exception exception)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Suppress))
            {
                LogEventInfo logInfo = new LogEventInfo(level, logger.Name, message);
                logger.Log(logInfo);
            }
            //using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Suppress))
            //{
            //    LoggingEvent loggingEvent = new LoggingEvent(logger.GetType(), logger.Logger.Repository, logger.Logger.Name, level, message, exception);
            //    loggingEvent.Properties["EventID"] = eventId;
            //    logger.Logger.Log(loggingEvent);

            //    transactionScope.Complete();
            //}
        }
    }
}
