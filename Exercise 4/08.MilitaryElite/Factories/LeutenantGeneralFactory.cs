namespace MilitaryElite.Factories
{
    using Models;

    public static class LieutenantGeneralFactory
    {
        public static LieutenantGeneral CreateLieutenantGeneral(string id, string firstName, string lastName, decimal salary)
        {
            return new LieutenantGeneral(id, firstName, lastName, salary);
        }
    }
}