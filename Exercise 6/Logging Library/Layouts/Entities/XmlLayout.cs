﻿namespace LoggingLibrary.Layouts.Entities
{
    using System.Text;

    using Contracts;

    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("<log>")
                  .AppendLine("\t<date>{0}</date>")
                  .AppendLine("\t<level>{1}</level>")
                  .AppendLine("\t<message>{2}</message>")
                  .AppendLine("</log>");

            return result.ToString().TrimEnd();
        }
    }
}