namespace Class_Box
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            decimal lenght = decimal.Parse(Console.ReadLine());
            decimal width = decimal.Parse(Console.ReadLine());
            decimal height = decimal.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(lenght, width, height);

                Console.WriteLine(box);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
