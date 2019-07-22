namespace LoggingLibrary.Appenders.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Common;
    using Entities;
    using Contracts;
    using Files.Entities;
    using Files.Contracts;
    using Layouts.Contracts;
    using Layouts.Factories;
    using Common.Exceptions;
    using Common.Enumerations;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender GetAppender(string appenderType, string layoutType, string levelStr)
        {
            Level level = MessageParameters.ParseLevel(levelStr);

            ILayout layout = this.layoutFactory.GetLayout(layoutType);

            Assembly assembly = Assembly.GetExecutingAssembly();

            Type typeToCreate = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name == appenderType);

            if (typeToCreate == null)
            {
                throw new InvalidLayoutTypeException();
            }

            List<object> args = new List<object>()
            {
                layout,
                level
            };

            if (appenderType == "FileAppender")
            {
                IFile file = new LogFile();
                args.Add(file);
            }

            IAppender appender = (IAppender)Activator.CreateInstance(typeToCreate, args.ToArray());

            //WITHOUT REFLECTION:

            //Level level = MessageParameters.ParseLevel(levelStr);
            //ILayout layout = this.layoutFactory.GetLayout(layoutType);
            //IAppender appender;
            //if (appenderType == "ConsoleAppender")
            //{
            //    appender = new ConsoleAppender(layout, level);
            //}
            //else if (appenderType == "FileAppender")
            //{
            //    IFile file = new LogFile();
            //    appender = new FileAppender(layout, level, file);
            //}
            //else
            //{
            //    throw new InvalidAppenderTypeException();
            //}

            return appender;
        }
    }
}