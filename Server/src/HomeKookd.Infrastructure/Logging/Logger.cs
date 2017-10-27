using System;
using System.Collections.Generic;

namespace HomeKookd.Infrastructure.Logging
{
   public class Logger<T> : ILogger<T> where T: class
   {
        internal static void LogMessage(LogEventId eventId, LogLevel level, string message, IDictionary<object, object> properties)
        {
            LogMessage(eventId, level, message, null, properties);
        }

        internal static void LogMessage(LogEventId eventId, LogLevel level, string message)
        {
            LogMessage(eventId, level, message, null, null);
        }

        internal static void LogMessage(LogEventId eventId, LogLevel level, string message, Exception exception)
        {
            LogMessage(eventId, level, message, exception, null);
        }

        internal static void LogMessage(LogEventId eventId, LogLevel level, string message, Exception exception, IDictionary<object, object> properties)
        {
            var type = typeof(T);
            NLog.Logger logger = NLog.LogManager.GetLogger(type.FullName);
            NLog.LogLevel logLevel = NLog.LogLevel.Info; // Default level to info

            switch (level)
            {
                case LogLevel.Warn:
                    logLevel = NLog.LogLevel.Warn;
                    break;
                case LogLevel.Info:
                    logLevel = NLog.LogLevel.Info;
                    break;
                case LogLevel.Fatal:
                    logLevel = NLog.LogLevel.Fatal;
                    break;
                case LogLevel.Error:
                    logLevel = NLog.LogLevel.Error;
                    break;
                case LogLevel.Debug:
                    logLevel = NLog.LogLevel.Debug;
                    break;
                case LogLevel.Trace:
                    logLevel = NLog.LogLevel.Trace;
                    break;
            }


            NLog.LogEventInfo logEvent = new NLog.LogEventInfo(logLevel, type.Name, message);
            logEvent.Exception = exception;

            CombineProperties(logEvent.Properties, properties);

            if (logEvent.Properties.ContainsKey(LoggingAttributes.LOG_OBJECT))
                logEvent.Properties[LoggingAttributes.LOG_OBJECT] =
                    Newtonsoft.Json.JsonConvert.SerializeObject(logEvent.Properties[LoggingAttributes.LOG_OBJECT]);

            //Add event id to the properties
            if (!logEvent.Properties.ContainsKey("EventId.Id"))
                logEvent.Properties.Add("EventId.Id", (int)eventId);
            else
                logEvent.Properties["EventId.Id"] = (int)eventId;

            logger.Log(type, logEvent);
        }

        private static void CombineProperties(IDictionary<object, object> properties, IDictionary<object, object> newProperties)
        {
            if (newProperties == null) return;
            foreach (var newProperty in newProperties)
            {
                if (!properties.ContainsKey(newProperty.Key))
                    properties.Add(newProperty.Key, newProperty.Value);
                else
                    properties[newProperty.Key] = newProperty.Value;
            }
        }

        public void Trace(string message)
        {
            LogMessage(LogEventId.None, LogLevel.Trace, message, null, null);
        }

        public void Trace(string message, Exception exception)
        {
            LogMessage(LogEventId.None, LogLevel.Trace, message, exception, null);
        }

        public void Trace(string message, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Trace, message, null, properties);
        }

        public void Trace(string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Trace, message, exception, properties);
        }

        public void Trace(LogEventId eventId, string message)
        {
            LogMessage(eventId, LogLevel.Trace, message, null, null);
        }

        public void Trace(LogEventId eventId, string message, Exception exception)
        {
            LogMessage(eventId, LogLevel.Trace, message, exception, null);
        }

        public void Trace(LogEventId eventId, string message, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Trace, message, null, properties);
        }

        public void Trace(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Trace, message, exception, properties);
        }


        public void Debug(string message)
        {
            LogMessage(LogEventId.None, LogLevel.Debug, message, null, null);
        }

        public void Debug(string message, Exception exception)
        {
            LogMessage(LogEventId.None, LogLevel.Debug, message, exception, null);
        }

        public void Debug(string message, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Debug, message, null, properties);
        }

        public void Debug(string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Debug, message, exception, properties);
        }

        public void Debug(LogEventId eventId, string message)
        {
            LogMessage(eventId, LogLevel.Debug, message, null, null);
        }

        public void Debug(LogEventId eventId, string message, Exception exception)
        {
            LogMessage(eventId, LogLevel.Debug, message, exception, null);
        }

        public void Debug(LogEventId eventId, string message, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Debug, message, null, properties);
        }

        public void Debug(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Debug, message, exception, properties);
        }


        public void Info(string message)
        {
            LogMessage(LogEventId.None, LogLevel.Info, message, null, null);
        }

        public void Info(string message, Exception exception)
        {
            LogMessage(LogEventId.None, LogLevel.Info, message, exception, null);
        }

        public void Info(string message, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Info, message, null, properties);
        }

        public void Info(string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Info, message, exception, properties);
        }

        public void Info(LogEventId eventId, string message)
        {
            LogMessage(eventId, LogLevel.Info, message, null, null);
        }

        public void Info(LogEventId eventId, string message, Exception exception)
        {
            LogMessage(eventId, LogLevel.Info, message, exception, null);
        }

        public void Info(LogEventId eventId, string message, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Info, message, null, properties);
        }

        public void Info(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Info, message, exception, properties);
        }


        public void Warn(string message)
        {
            LogMessage(LogEventId.None, LogLevel.Warn, message, null, null);
        }

        public void Warn(string message, Exception exception)
        {
            LogMessage(LogEventId.None, LogLevel.Warn, message, exception, null);
        }

        public void Warn(string message, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Warn, message, null, properties);
        }

        public void Warn(string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Warn, message, exception, properties);
        }

        public void Warn(LogEventId eventId, string message)
        {
            LogMessage(eventId, LogLevel.Warn, message, null, null);
        }

        public void Warn(LogEventId eventId, string message, Exception exception)
        {
            LogMessage(eventId, LogLevel.Warn, message, exception, null);
        }

        public void Warn(LogEventId eventId, string message, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Warn, message, null, properties);
        }

        public void Warn(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Warn, message, exception, properties);
        }


        public void Error(string message)
        {
            LogMessage(LogEventId.None, LogLevel.Error, message, null, null);
        }

        public void Error(string message, Exception exception)
        {
            LogMessage(LogEventId.None, LogLevel.Error, message, exception, null);
        }

        public void Error(string message, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Error, message, null, properties);
        }

        public void Error(string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Error, message, exception, properties);
        }

        public void Error(LogEventId eventId, string message)
        {
            LogMessage(eventId, LogLevel.Error, message, null, null);
        }

        public void Error(LogEventId eventId, string message, Exception exception)
        {
            LogMessage(eventId, LogLevel.Error, message, exception, null);
        }

        public void Error(LogEventId eventId, string message, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Error, message, null, properties);
        }

        public void Error(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Error, message, exception, properties);
        }


        public void Fatal(string message)
        {
            LogMessage(LogEventId.None, LogLevel.Fatal, message, null, null);
        }

        public void Fatal(string message, Exception exception)
        {
            LogMessage(LogEventId.None, LogLevel.Fatal, message, exception, null);
        }

        public void Fatal(string message, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Fatal, message, null, properties);
        }

        public void Fatal(string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(LogEventId.None, LogLevel.Fatal, message, exception, properties);
        }

        public void Fatal(LogEventId eventId, string message)
        {
            LogMessage(eventId, LogLevel.Fatal, message, null, null);
        }

        public void Fatal(LogEventId eventId, string message, Exception exception)
        {
            LogMessage(eventId, LogLevel.Fatal, message, exception, null);
        }

        public void Fatal(LogEventId eventId, string message, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Fatal, message, null, properties);
        }

        public void Fatal(LogEventId eventId, string message, Exception exception, IDictionary<object, object> properties)
        {
            LogMessage(eventId, LogLevel.Fatal, message, exception, properties);
        }
    }
}
