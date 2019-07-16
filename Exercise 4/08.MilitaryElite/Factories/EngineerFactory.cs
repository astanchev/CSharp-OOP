namespace MilitaryElite.Factories
{
    using Models;

    public static class EngineerFactory
    {
        public static Engineer CreateEngineer(string id, string firstName, string lastName, decimal salary,
            string corps)
        {
            return new Engineer(id, firstName, lastName, salary, corps);
        }
    }
}