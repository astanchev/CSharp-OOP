namespace MilitaryElite.Factories
{
    using Models;

    public static class PrivateFactory
    {
        public static Private CreatePrivate(string id, string firstName, string lastName, decimal salary)
        {
            return new Private(id, firstName, lastName, salary);
        }
    }
}