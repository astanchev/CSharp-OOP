namespace P03_JediGalaxy
{
    using System;
    using System.Linq;
    class Program
    {
        private static int[,] galaxy;
        static long sum = 0;
        static void Main()
        {
            FillMatrix();

            string command = Console.ReadLine();
            
            while (command != "Let the Force be with you")
            {
                int[] startCoordinatesIvo = command
                                 .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

                EvilStarEater();

                SumStarsIvo(startCoordinatesIvo);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        private static void SumStarsIvo(int[] startCoordinatesIvo)
        {
            int startRowIvo = startCoordinatesIvo[0];
            int startColIvo = startCoordinatesIvo[1];

            while (startRowIvo >= 0
                   && startColIvo < galaxy.GetLength(1))
            {
                if (AreCoordinatesCorrect(startRowIvo, startColIvo))
                {
                    sum += galaxy[startRowIvo, startColIvo];
                }

                startColIvo++;
                startRowIvo--;
            }
        }

        private static void EvilStarEater()
        {
            int[] startCoordinatesEvil = ConsoleToArray();

            int startRowEvil = startCoordinatesEvil[0];
            int startColEvil = startCoordinatesEvil[1];

            while (startRowEvil >= 0
                   && startColEvil >= 0)
            {
                if (AreCoordinatesCorrect(startRowEvil, startColEvil))
                {
                    galaxy[startRowEvil, startColEvil] = 0;
                }

                startRowEvil--;
                startColEvil--;
            }
        }

        private static bool AreCoordinatesCorrect(int row, int col)
        {
            return row >= 0 
                   && row < galaxy.GetLength(0) 
                   && col >= 0 
                   && col < galaxy.GetLength(1);
        }

        private static int[] ConsoleToArray()
        {
            return Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static void FillMatrix()
        {
            int[] dimestions = ConsoleToArray();

            int rows = dimestions[0];
            int cols = dimestions[1];

            galaxy = new int[rows, cols];

            int value = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    galaxy[row, col] = value++;
                }
            }
        }
    }
}
