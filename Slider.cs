using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace SlidersOOP
{
    public class Slider
    {
        public Vector2f position;
        SliderPip pip;
        public int length, size = 20;
        public float value { get { return pip.offset / (length - size); } }

        public Slider(RenderWindow rw, int x, int y, int l)
        {
            position = new Vector2f(x, y);
            pip = new SliderPip(rw, this);
            length = l;
        }


        public void Display(RenderWindow rw)
        {
            RectangleShape shape = new RectangleShape();
            shape.Position = position;
            shape.Size = new Vector2f(size, length);
            shape.FillColor = Color.White;
            rw.Draw(shape);

            pip.Display(rw);
        }
    }
}
