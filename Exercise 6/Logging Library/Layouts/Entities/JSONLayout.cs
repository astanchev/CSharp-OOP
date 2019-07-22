namespace LoggingLibrary.Layouts.Entities
{
    using System.Text;

    using Contracts;

    public class JSONLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("\"log\":{{")
                .AppendLine("\t\"date\": \"{0}\",")
                .AppendLine("\t\"level\": \"{1}\",")
                .AppendLine("\t\"message\": \"{2}\"")
                .AppendLine("}}");

            return result.ToString().TrimEnd();
        }
    }
}