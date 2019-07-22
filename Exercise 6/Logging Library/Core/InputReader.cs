namespace LoggingLibrary.Core
{
    using System;
    using System.Collections.Generic;

    using Loggers.Entities;
    using Loggers.Contracts;
    using Appenders.Contracts;
    using Appenders.Factories;
    
    public static class InputReader
    {
        private static ICollection<IAppender> appenders;
        private static AppenderFactory appenderFactory;

        public static ILogger GetLogger()
        {
            appenders = new List<IAppender>();
            appenderFactory = new AppenderFactory();

            int appendersCount = int.Parse(Console.ReadLine());

            ReadAppendersData(appendersCount);
            
            ILogger logger = new Logger(appenders);

            return logger;
        }
        private static void ReadAppendersData(int appendersCount)
        {
            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersInfo = Console.ReadLine().Split();

                string appenderType = appendersInfo[0];
                string layoutType = appendersInfo[1];
                string levelStr = "INFO";

                if (appendersInfo.Length == 3)
                {
                    levelStr = appendersInfo[2];
                }

                try
                {
                    IAppender appender = appenderFactory.GetAppender(appenderType, layoutType, levelStr);

                    appenders.Add(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}