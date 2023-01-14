using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    // class code from https://www.youtube.com/watch?v=HG7hi9s7YhQ
    internal class ButtonEllipse : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(graphics);
            base.OnPaint(pevent);
        }
    }
}