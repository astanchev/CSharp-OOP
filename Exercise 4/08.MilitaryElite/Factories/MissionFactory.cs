namespace MilitaryElite.Factories
{
    using Models;

    public static class MissionFactory
    {
        public static Mission CreateMission(string codeName, string state)
        {
            return new Mission(codeName, state);
        }
    }
}