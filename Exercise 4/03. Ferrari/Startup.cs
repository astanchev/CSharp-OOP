namespace Ferrari
{
    using System;
    public class Startup
    {
        public static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            Ferrari ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari.ToString());
        }
    }
}
