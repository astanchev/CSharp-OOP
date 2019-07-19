namespace P02.Graphic_Editor
{
    using System;

    public class Rectangle : IShape
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("I'm Rectangle");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Rectangle)
            {
                return true;
            }

            return false;
        }
    }
}
