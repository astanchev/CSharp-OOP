namespace LoggingLibrary.Appenders.Contracts
{
    using Errors.Contracts;
    using Layouts.Contracts;
    using Common.Enumerations;
    
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}