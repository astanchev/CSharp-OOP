using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public interface IShape
    {
        void Draw(IShape shape);
        bool IsMatch(IShape shape);
    }
}
