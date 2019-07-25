namespace _04.FixingVol2
{
    using System;

    class FixingVol2
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;

            num1 = 30;
            num2 = 60;

            result = Convert.ToByte(num1 * num2);

            Console.WriteLine($"{num1} x {num2} = {result}");

            try
            {
                result = Convert.ToByte(num1 * num2);

                Console.WriteLine($"{num1} x {num2} = {result}");

            }
            catch (OverflowException ofe)
            {
                Console.WriteLine("Cannot convert this result to byte! The value is too big.");
            }

            Console.ReadLine();
        }
    }
}
