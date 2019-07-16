namespace MilitaryElite.Factories
{
    using Models;

    public static class RepairFactory
    {
        public static Repair CreateRepair(string name, int hoursWorked)
        {
            return  new Repair(name, hoursWorked);
        }
    }
}