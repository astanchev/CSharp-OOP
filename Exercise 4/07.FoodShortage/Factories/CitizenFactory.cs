namespace FoodShortage.Factories
{
    using Models;

    public static class CitizenFactory
    {
        public static Citizen CreateCitizen(string[] commandArgs)
        {
            string name = commandArgs[0];
            int age = int.Parse(commandArgs[1]);
            string id = commandArgs[2];
            string birthdate = commandArgs[3];

            return new Citizen(name, age, id, birthdate);
        }
    }
}