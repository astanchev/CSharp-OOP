namespace _02.EnterNumbers
{
    using System;
    using System.Collections.Generic;

    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            while (true)
            {
                try
                {
                    List<int> result = new List<int>();

                    for (int i = 0; i < 10; i++)
                    {
                        int number = ReadNumber(start, end);

                        result.Add(number);
                    }

                    Console.WriteLine(string.Join(", ", result));

                    break;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("You entered text, not number!");
                }
                catch (ArgumentOutOfRangeException aore)
                {
                    Console.WriteLine(aore.Message);
                }
            }

        }

        private static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            int number = int.Parse(input);

            if (number < start || number > end)
            {
                throw new ArgumentOutOfRangeException("Number is out of Range!", (Exception) null);
            }

            return number;
        }
    }

    
}


