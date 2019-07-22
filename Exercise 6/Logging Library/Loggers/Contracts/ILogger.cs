namespace LoggingLibrary.Loggers.Contracts
{
    using System.Collections.Generic;
    
    using Errors.Contracts;
    using Appenders.Contracts;

    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}