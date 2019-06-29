using System.Linq;

namespace _2.PointInRectangle
{
    using System;
    public class PointInRectangle
    {
        public static void Main(string[] args)
        {
            int[] inputRectangleCoordinates = ParseIntArray();

            Rectangle rectangle = CreateRectangle(inputRectangleCoordinates);

            int numberPoints = int.Parse(Console.ReadLine());

            CheckPoints(numberPoints, rectangle);
        }

        private static Rectangle CreateRectangle(int[] inputRectangleCoordinates)
        {
            Point topLeft = new Point(inputRectangleCoordinates[0], 
                                      inputRectangleCoordinates[1]);
            Point bottomRight = new Point(inputRectangleCoordinates[2], 
                                          inputRectangleCoordinates[3]);

            return new Rectangle(topLeft, bottomRight);
        }

        private static int[] ParseIntArray()
        {
            return Console.ReadLine()
                ?.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static void CheckPoints(int numberPoints, Rectangle rectangle)
        {
            for (int i = 0; i < numberPoints; i++)
            {
                int[] currentPointCoordinates = ParseIntArray();
                Point currentPoint = new Point(currentPointCoordinates[0],
                                               currentPointCoordinates[1]);

                Console.WriteLine(rectangle.Contains(currentPoint));
            }
        }
    }
}
