namespace MilitaryElite.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }
        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();
        public void AddPrivate(IPrivate @private)
        {
            this.privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(base.ToString())
                .AppendLine("Privates: ");

            foreach (var @private in this.Privates)
            {
                result.AppendLine("  " + @private.ToString().TrimEnd());
            }

            return result.ToString().TrimEnd();
        }
    }
}