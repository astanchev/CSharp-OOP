namespace MXGP
{
    using System;
    using Core;
    using Core.Contracts;
    using Models.Motorcycles;
    using Models.Motorcycles.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();

        }
    }
}
