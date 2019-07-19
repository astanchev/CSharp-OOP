namespace P02.Graphic_Editor
{
    using System;
    public class Circle : IShape
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("I'm Circle");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Circle)
            {
                return true;
            }

            return false;
        }
    }
}
