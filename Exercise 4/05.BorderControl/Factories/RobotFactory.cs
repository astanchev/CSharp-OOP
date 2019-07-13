namespace FoodShortage.Factories
{
    using Models;

    public static class RobotFactory
    {
        public static Robot CreateRobot(string[] commandArgs)
        {
            string model = commandArgs[0];
            string id = commandArgs[1];

            return new Robot(model, id);
        }
    }
}