using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;

namespace SlidersOOP
{
    internal class Display
    {
        Vector2f position, size;

        public Display(float x, float y, float width, float heigth)
        {
            position = new Vector2f(x, y);
            size = new Vector2f(width, heigth);
        }

        public void Draw(RenderWindow rw, byte r, byte g, byte b)
        {
            RectangleShape shape = new RectangleShape();
            shape.Position = position;
            shape.Size = size;
            shape.FillColor = new Color(r, g, b);
            rw.Draw(shape);
        }
    }
}
