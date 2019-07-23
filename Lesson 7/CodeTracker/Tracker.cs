﻿namespace _06.CodeTracker
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);

            MethodInfo[] methods = type.GetMethods(
                BindingFlags.Instance
                | BindingFlags.Public 
                | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes
                    .Any(m => m.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }

            }
        }
    }
}