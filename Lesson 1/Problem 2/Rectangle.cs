namespace _2.PointInRectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }
        public Point BottomRight { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        public bool Contains(Point point)
        {
            return point.CoordinateX >= this.TopLeft.CoordinateX
                   && point.CoordinateX <= this.BottomRight.CoordinateX
                   && point.CoordinateY >= this.TopLeft.CoordinateY
                   && point.CoordinateY <= this.BottomRight.CoordinateY;
        }
    }
}