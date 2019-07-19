namespace P02.Graphic_Editor
{
    using System;

    public class Square : IShape
    {
        public void Draw(IShape shape)
        {
            Console.WriteLine("I'm Square");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Square)
            {
                return true;
            }

            return false;
        }
    }
}
