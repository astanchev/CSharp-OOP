namespace P02.Graphic_Editor
{
    public class Program
    {
        static void Main()
        {
            var circle = new Circle();
            var rectangle = new Rectangle();
            var square = new Square();

            var graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(circle);
            graphicEditor.DrawShape(rectangle);
            graphicEditor.DrawShape(square);
        }
    }
}
