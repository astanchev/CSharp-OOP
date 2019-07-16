namespace MilitaryElite.Factories
{
    using Models;

    public static class CommandoFactory
    {
        public static Commando CreateCommando(string id, string firstName, string lastName, decimal salary,
            string corps)
        {
            return new Commando(id, firstName, lastName, salary, corps);
        }
    }
}