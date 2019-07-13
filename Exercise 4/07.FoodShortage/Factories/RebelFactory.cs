namespace FoodShortage.Factories
{
    using Models;

    public class RebelFactory
    {
        public static Rebel CreateRebel(string[] commandArgs)
        {
            string name = commandArgs[0];
            int age = int.Parse(commandArgs[1]);
            string group = commandArgs[2];

            return new Rebel(name, age, group);
        }
    }
}