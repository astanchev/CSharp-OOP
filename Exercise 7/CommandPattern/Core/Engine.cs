﻿namespace CommandPattern.Core
{
    using System;
    using Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string inputArgs = Console.ReadLine();

                Console.WriteLine(commandInterpreter.Read(inputArgs));


            }
        }
    }
}