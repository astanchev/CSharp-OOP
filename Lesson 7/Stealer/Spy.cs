namespace _01.Stealer
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
    }
}