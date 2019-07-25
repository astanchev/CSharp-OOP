namespace _01.SquareRoot
{
    using System;

    class SquareRoot
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            try
            {
                int number = int.Parse(input);

                if (number < 0)
                {
                    throw new ArgumentException("Invalid number! - Argument Exception");
                }

                Console.WriteLine(Math.Sqrt(number));

            }
            catch (FormatException fe)
            {
                Console.WriteLine("Invalid number! - Format Exception");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }

        }
    }
}
