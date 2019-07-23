namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandArgs = args.Split();

            string command = commandArgs[0];

            var commandToCreate = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => 
                    t.Name.ToLower() == command.ToLower() + "command");

            if (commandToCreate == null)
            {
                throw new ArgumentException("There is no such command");
            }

            ICommand createdCommand = (ICommand)Activator.CreateInstance(commandToCreate);

           return createdCommand.Execute(commandArgs.Skip(1).ToArray());
        }
    }
}