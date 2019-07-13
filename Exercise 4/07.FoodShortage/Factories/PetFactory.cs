namespace FoodShortage.Factories
{
    using Models;

    public static class PetFactory
    {
        public static Pet CreatePet(string[] commandArgs)
        {
            string name = commandArgs[0];
            string birthdate = commandArgs[1];

            return new Pet(name, birthdate);
        }
    }
}