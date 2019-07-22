namespace LoggingLibrary.Core
{
    using System;
    using Errors.Contracts;
    using Errors.Factories;
    using Loggers.Contracts;

    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine()
        {
            errorFactory = new ErrorFactory();
        }
        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] errorArgs = input.Split('|');

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                try
                {
                    IError error = this.errorFactory.GetError(date, level, message);

                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}