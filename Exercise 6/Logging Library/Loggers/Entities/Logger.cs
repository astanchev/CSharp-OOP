﻿namespace LoggingLibrary.Loggers.Entities
{
    using System.Text;
    using System.Collections.Generic;
    
    using Contracts;
    using Errors.Contracts;
    using Appenders.Contracts;

    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>) this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.Appenders)
            {
                if (appender.Level <= error.Level)
                {
                    appender.Append(error);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Logger info");

            foreach (IAppender appender in this.Appenders)
            {
                result.AppendLine(appender.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}