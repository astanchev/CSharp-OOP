namespace LoggingLibrary.Layouts.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Common.Exceptions;
    
    public class LayoutFactory
    {
        public ILayout GetLayout(string type)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type typeToCreate = assembly
                                  .GetTypes()
                                  .FirstOrDefault(t => t.Name == type);

            if (typeToCreate == null)
            {
                throw new InvalidLayoutTypeException();
            }

            ILayout layout = (ILayout)Activator.CreateInstance(typeToCreate);
            
            return layout;
        }
    }
}