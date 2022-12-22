using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SlidersOOP;

RenderWindow rw = new RenderWindow(new VideoMode(512, 512), "Sliders!");
rw.SetFramerateLimit(30);
rw.Closed += OnClose;

Slider r = new Slider(rw, 100, 0, 255);
Slider g = new Slider(rw, 256, 0, 255);
Slider b = new Slider(rw, 412, 0, 255);
Display d = new Display(0, 256, 512, 256);

while (rw.IsOpen)
{
    rw.DispatchEvents();
    rw.Clear();
    r.Display(rw);
    g.Display(rw);
    b.Display(rw);
    d.Draw(rw, (byte)(r.value * 255), (byte)(g.value * 255), (byte)(b.value * 255));
    rw.Display();
}


void OnClose(object sender, EventArgs e)
{
    rw.Close();
}