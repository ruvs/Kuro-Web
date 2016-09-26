using System;
using System.Collections.Generic;

namespace Nexus.Web.Infrastructure
{
    public interface ILogWriter
    {
        void Error(int eventId, string message);
        void Error(int eventId, string message, Exception exception);
        void Fatal(int eventId, string message);
        void Fatal(int eventId, string message, Exception exception);
        void Info(int eventId, string message);
        void Warn(int eventId, string message);
        void Debug(int eventId, string message);
        //void LogError(IExceptionClassifier classifier);
        void Error(int eventId, IEnumerable<string> messages);
        string LogLevel(string appenderAsString);
        //void ChangeLogLevel(string level, string appenderName);
        IList<Tuple<string, string, string>> GetAppendersAndLevels();
    }
}
