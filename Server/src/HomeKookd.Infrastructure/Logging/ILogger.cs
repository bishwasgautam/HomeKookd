using System;
using System.Collections.Generic;

namespace HomeKookd.Infrastructure.Logging
{
    public interface ILogger<T> where T : class
    {
        void Trace(string message);
        void Trace(string message, Exception exception);
        void Trace(string message, IDictionary<object, object> properties);
        void Trace(string message, Exception exception, IDictionary<object, object> properties);

        void Trace(LogEventId eventId, string message);
        void Trace(LogEventId eventId, string message, Exception exception);
        void Trace(LogEventId eventId, string message, IDictionary<object, object> properties);
        void Trace(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties);


        void Debug(string message);
        void Debug(string message, Exception exception);
        void Debug(string message, IDictionary<object, object> properties);
        void Debug(string message, Exception exception, IDictionary<object, object> properties);

        void Debug(LogEventId eventId, string message);
        void Debug(LogEventId eventId, string message, Exception exception);
        void Debug(LogEventId eventId, string message, IDictionary<object, object> properties);
        void Debug(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties);


        void Info(string message);
        void Info(string message, Exception exception);
        void Info(string message, IDictionary<object, object> properties);
        void Info(string message, Exception exception, IDictionary<object, object> properties);

        void Info(LogEventId eventId, string message);
        void Info(LogEventId eventId, string message, Exception exception);
        void Info(LogEventId eventId, string message, IDictionary<object, object> properties);
        void Info(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties);


        void Warn(string message);
        void Warn(string message, Exception exception);
        void Warn(string message, IDictionary<object, object> properties);
        void Warn(string message, Exception exception, IDictionary<object, object> properties);

        void Warn(LogEventId eventId, string message);
        void Warn(LogEventId eventId, string message, Exception exception);
        void Warn(LogEventId eventId, string message, IDictionary<object, object> properties);
        void Warn(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties);


        void Error(string message);
        void Error(string message, Exception exception);
        void Error(string message, IDictionary<object, object> properties);
        void Error(string message, Exception exception, IDictionary<object, object> properties);

        void Error(LogEventId eventId, string message);
        void Error(LogEventId eventId, string message, Exception exception);
        void Error(LogEventId eventId, string message, IDictionary<object, object> properties);
        void Error(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties);


        void Fatal(string message);
        void Fatal(string message, Exception exception);
        void Fatal(string message, IDictionary<object, object> properties);
        void Fatal(string message, Exception exception, IDictionary<object, object> properties);

        void Fatal(LogEventId eventId, string message);
        void Fatal(LogEventId eventId, string message, Exception exception);
        void Fatal(LogEventId eventId, string message, IDictionary<object, object> properties);
        void Fatal(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties);
    }
}