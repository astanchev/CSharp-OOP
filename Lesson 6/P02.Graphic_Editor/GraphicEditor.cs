namespace P02.Graphic_Editor
{
    using System.Collections.Generic;
    using System.Linq;
    public class GraphicEditor
    {
        private List<IShape> shapes = new List<IShape>()
        {
            new Circle(),
            new Rectangle(),
            new Square()
        };
        public void DrawShape(IShape shape)
        {
            this.shapes.First(s => s.IsMatch(shape)).Draw(shape);
        }
    }
}
