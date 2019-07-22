namespace LoggingLibrary.Errors.Contracts
{
    using System;

    using Common.Enumerations;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        Level Level { get; }
    }
}