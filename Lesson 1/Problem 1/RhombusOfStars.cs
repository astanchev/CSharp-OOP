namespace _1._Rhombus_of_Stars
{
    using System;

    class RhombusOfStars
    {
        static void Main(string[] args)
        {
            int numberRows = int.Parse(Console.ReadLine());
            
            PrintTriangle(numberRows);
        }

        private static void PrintTriangle(int numberRows)
        {
            PrintUpperPart(numberRows);
            PrintLowerPart(numberRows);
        }

        private static void PrintUpperPart(int numberRows)
        {
            for (int row = 1; row <= numberRows; row++)
            {
                PrintRow(numberRows, row);
            }
        }

        private static void PrintLowerPart(int numberRows)
        {
            for (int row = numberRows - 1; row >= 1; row--)
            {
                PrintRow(numberRows, row);
            }
        }

        private static void PrintRow(int numberRows, int currentRow)
        {
            Console.Write(new string(' ', numberRows - currentRow));
            for (int star = 1; star < currentRow; star++)
            {
                Console.Write("* ");
            }
            Console.WriteLine('*');
        }
    }
}
