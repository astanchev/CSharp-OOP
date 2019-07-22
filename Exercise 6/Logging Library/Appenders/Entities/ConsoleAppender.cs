namespace LoggingLibrary.Appenders.Entities
{
    using System;

    using Common;
    using Errors.Contracts;
    using Layouts.Contracts;
    using Common.Enumerations;

    public class ConsoleAppender : Appender
    {
        
        public ConsoleAppender(ILayout layout, Level level)
            :base(layout, level)
        {
        }

        public override void Append(IError error)
        {
            string formattedMessage = MessageParameters.GetFormattedMessage(this.Layout, error);

            Console.WriteLine(formattedMessage);
            this.messagesAppended++;
        }

    }
}