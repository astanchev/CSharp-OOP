namespace _05.ConvertToDouble
{
    using System;

    class ConvertToDouble
    {
        static void Main(string[] args)
        {
            string value = Console.ReadLine();

            try
            {
                double result = ConvertStringToDouble(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            Console.ReadLine();
        }

        private static double ConvertStringToDouble(string value)
        {
            double result;

            try 
            {
                result = Convert.ToDouble(value);
                Console.WriteLine($"Converted '{value}' to {result}.");
            }   
            catch (FormatException fe) 
            {
                throw new FormatException($"Unable to convert '{value}' to a Double.", fe);
            }               
            catch (OverflowException ofe)
            {
                throw new OverflowException($"'{value}' is outside the range of a Double.", ofe);
            }

            return result;
        }
    }
}
