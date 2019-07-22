namespace LoggingLibrary.Appenders.Entities
{
    using Contracts;
    using Errors.Contracts;
    using Layouts.Contracts;
    using Common.Enumerations;

    public abstract class Appender : IAppender
    {
        protected int messagesAppended;

        public Appender()
        {
            this.messagesAppended = 0;
        }
        public Appender(ILayout layout, Level level)
            :this()
        {
            this.Layout = layout;
            this.Level = level;
        }

        public ILayout Layout { get; private set; }

        public Level Level { get; private set; }
        public abstract void Append(IError error);

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.Level.ToString()}, Messages appended: {this.messagesAppended}";
        }
    }
}