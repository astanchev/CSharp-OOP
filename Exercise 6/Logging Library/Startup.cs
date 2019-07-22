namespace LoggingLibrary
{
    using Core;
    using Loggers.Contracts;

    public class Startup
    {
        public static void Main(string[] args)
        {
            ILogger logger = InputReader.GetLogger();
            
            Engine engine = new Engine(logger);
            engine.Run();
        }
    }
}


