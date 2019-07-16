namespace MilitaryElite.Factories
{
    using Models;

    public static class SpyFactory
    {
        public static Spy CreateSpy(string id, string firstName, string lastName, int codeNumber)
        {
            return new Spy(id, firstName, lastName, codeNumber);
        }
    }
}