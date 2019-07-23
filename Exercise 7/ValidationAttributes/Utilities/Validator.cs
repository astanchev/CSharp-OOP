namespace ValidationAttributes.Utilities
{
    using System.Linq;
    using System.Reflection;
    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                                            .GetType()
                                            .GetProperties();

            foreach (PropertyInfo property in propertyInfos)
            {
                MyValidationAttribute[] atts = property
                                .GetCustomAttributes()
                                .Where(a => a is MyValidationAttribute)
                                .Cast<MyValidationAttribute>()
                                .ToArray();

                foreach (MyValidationAttribute attribute in atts)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}