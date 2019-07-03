namespace P06_Sneaking
{
    using System;
    using System.Collections.Generic;

    class Sneaking
    {
        private static char[,] field;
        private static bool isNikKilled;
        private static bool isSamKilled;
        private static int rowSam;
        private static int colSam;
        private static int rowNik;
        private static int colNik;
        private static List<int[]> enemies = new List<int[]>();
        static void Main(string[] args)
        {
            int numberRows = int.Parse(Console.ReadLine());

            List<char[]> inputRows = new List<char[]>();
            int numberCols = 0;

            for (int row = 0; row < numberRows; row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                numberCols = currentRow.Length;
                inputRows.Add(currentRow);
            }

            field = new char[numberRows, numberCols];

            FillField(inputRows);

            char[] inputDirections = Console.ReadLine().ToCharArray();
            Queue<char> directions = new Queue<char>(inputDirections);

            while (directions.Count > 0)
            {
                char currentDirection = directions.Dequeue();

                MoveEnemies();

                LookAround();

                if (isSamKilled)
                {
                    field[rowSam, colSam] = 'X';
                    break;
                }

                switch (currentDirection)
                {
                    case 'U':
                        MoveSam(-1, 0);
                        break;
                    case 'D':
                        MoveSam(+1, 0);
                        break;
                    case 'L':
                        MoveSam(0, -1);
                        break;
                    case 'R':
                        MoveSam(0, +1);
                        break;
                    case 'W':
                        continue;
                    default: break;
                }

                if (rowSam == rowNik)
                {
                    isNikKilled = true;
                }

                if (isNikKilled)
                {
                    field[rowNik, colNik] = 'X';
                    break;
                }
            }

            Console.WriteLine();
            if (isSamKilled)
            {
                Console.WriteLine($"Sam died at {rowSam}, {colSam}");
            }
            else if (isNikKilled)
            {
                Console.WriteLine("Nikoladze killed!");
            }

            Print(field);
        }

        private static void LookAround()
        {
            LookLeft();
            LookRight();
        }

        private static void LookRight()
        {
            for (int i = colSam + 1; i < field.GetLength(1); i++)
            {
                if (field[rowSam, i] == 'd')
                {
                    isSamKilled = true;
                    return;
                }

                if (field[rowSam, i] == 'N')
                {
                    isNikKilled = true;
                    return;
                }
            }
        }

        private static void LookLeft()
        {
            for (int i = 0; i < colSam; i++)
            {
                if (field[rowSam, i] == 'b')
                {
                    isSamKilled = true;
                    return;
                }

                if (field[rowSam, i] == 'N')
                {
                    isNikKilled = true;
                    return;
                }
            }
        }

        private static void MoveSam(int rowUpdate, int colUpdate)
        {
            int oldRow = rowSam;
            int oldCol = colSam;
            field[oldRow, oldCol] = '.';

            rowSam += rowUpdate;
            colSam += colUpdate;
            field[rowSam, colSam] = 'S';
            
            if (field[rowSam, colSam] == 'd' ||
                     field[rowSam, colSam] == 'b')
            {
                field[rowSam, colSam] = 'S';
                int[] currentEnemy = { rowSam, colSam };
                enemies.Remove(currentEnemy);
            }
        }

        private static void MoveEnemies()
        {
            FindEnemies();
            for (int i = 0; i < enemies.Count; i++)
            {
                int[] currentEnemy = enemies[i];
                int row = currentEnemy[0];
                int col = currentEnemy[1];

                char symb = field[row, col];

                if (symb == 'b')
                {
                    MoveEnemyRight(row, col);
                }
                else if (symb == 'd')
                {
                    MoveEnemyLeft(row, col);
                }
            }
            enemies.Clear();
        }

        private static void FindEnemies()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    if (field[row, col] == 'd'
                             || field[row, col] == 'b')
                    {
                        int[] enemy = { row, col };
                        enemies.Add(enemy);
                    }
                }
            }
        }

        private static void MoveEnemyLeft(int row, int col)
        {
            if (col == 0)
            {
                field[row, col] = 'b';
            }
            else
            {
                field[row, col] = '.';
                field[row, col - 1] = 'd';
            }
        }

        private static void MoveEnemyRight(int row, int col)
        {
            int[] currentEnemy = { row, col };
            if (col == (field.GetLength(1) - 1))
            {
                field[row, col] = 'd';
            }
            else
            {
                field[row, col] = '.';
                field[row, col + 1] = 'b';
            }
        }

        private static void FillField(List<char[]> inputRows)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = inputRows[row][col];

                    if (field[row, col] == 'S')
                    {
                        rowSam = row;
                        colSam = col;
                    }
                    else if (field[row, col] == 'N')
                    {
                        rowNik = row;
                        colNik = col;
                    }
                }
            }
        }

        private static void Print(char[,] field)
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}

