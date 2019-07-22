namespace LoggingLibrary.Appenders.Entities
{
    using System;
    using Files.Contracts;
    using Errors.Contracts;
    using Layouts.Contracts;
    using Common.Enumerations;

    public class FileAppender : Appender
    {
        public FileAppender(ILayout layout, Level level, IFile file)
            :base(layout, level)
        {
            this.File = file;
        }
       
        public IFile File { get; private set; }

        public override void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error) + Environment.NewLine;

            System.IO.File.AppendAllText(this.File.Path, formattedMessage);

            messagesAppended++;
        }

        public override string ToString()
        {
            return base.ToString() 
                   + $", File size {this.File.Size}";
        }
    }
}