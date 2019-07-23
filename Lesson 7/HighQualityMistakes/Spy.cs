﻿namespace _02.HighQualityMistakes
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] searchedFields)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] classFields = classType.GetFields(
                                BindingFlags.Instance |
                                          BindingFlags.NonPublic |
                                          BindingFlags.Public |
                                          BindingFlags.Static)
                                .Where(f => searchedFields.Contains(f.Name))
                                .ToArray();

            Object instance = Activator.CreateInstance(classType, new object[] { });


            var builder = new StringBuilder();

            builder.AppendLine($"Class under investigation: {className}");

            foreach (var field in classFields)
            {
                builder.AppendLine($"{field.Name} = {field.GetValue(instance)}");
            }

            return builder.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fields = classType.GetFields(
                                                    BindingFlags.Instance 
                                                    | BindingFlags.Public 
                                                    | BindingFlags.Static);

            MethodInfo[] publicMethods = classType.GetMethods(
                                                           BindingFlags.Instance 
                                                         | BindingFlags.Public);

            MethodInfo[] nonPublicMethods = classType.GetMethods(
                                                          BindingFlags.Instance 
                                                         | BindingFlags.NonPublic);

            var builder = new StringBuilder();

            foreach (var field in fields)
            {
                builder.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in nonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                builder.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                builder.AppendLine($"{method.Name} have to be private!");
            }

            return builder.ToString().Trim();
        }

    }
}