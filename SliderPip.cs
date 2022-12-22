using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace SlidersOOP
{
    internal class SliderPip
    {
        Slider owner;
        float grabOffset;
        public float offset = 0;
        bool grabbed = false;

        public SliderPip(RenderWindow rw, Slider sender)
        {
            rw.MouseButtonPressed += MousePressed;
            rw.MouseButtonReleased += (sender, e) => grabbed = false;
            rw.MouseMoved += MouseMoved;

            owner = sender;
        }

        private void MousePressed(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine(" < " + e.Y + " > " );
            if(e.Button != Mouse.Button.Left)
                return;

            if (e.X > owner.position.X && e.X < owner.position.X + owner.size && e.Y > owner.position.Y + offset && e.Y < owner.position.Y + offset + owner.size)
            {
                grabbed = true;
                grabOffset = e.Y - (owner.position.Y + offset);
            }
        }

        private void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            if (grabbed)
            {
                offset = e.Y - owner.position.Y - grabOffset;
                if(offset < 0)
                    offset = 0;
                if(offset > owner.length - owner.size)
                    offset = owner.length - owner.size;
            }
        }

        public void Display(RenderWindow rw)
        {
            CircleShape shape = new CircleShape();
            shape.Position = owner.position + new Vector2f(0, offset);
            shape.Radius = owner.size / 2;
            shape.FillColor = new Color(128, 128, 128);
            rw.Draw(shape);
        }
    }
}
