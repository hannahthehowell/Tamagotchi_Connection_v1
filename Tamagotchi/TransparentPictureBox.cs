using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi
{
    // Code in class found at https://stackoverflow.com/questions/36099017/how-to-make-two-transparent-layer-with-c
    // Author: Reza Aghaei
    internal class TransparentPictureBox : PictureBox
    {
        public TransparentPictureBox()
        {
            this.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Parent != null && this.BackColor == Color.Transparent)
            {
                using (var bmp = new Bitmap(Parent.Width, Parent.Height))
                {
                    Parent.Controls.Cast<Control>()
                          .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                          .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                          .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                          .ToList()
                          .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));

                    e.Graphics.DrawImage(bmp, -Left, -Top);

                }
            }
            base.OnPaint(e);
        }
    }
}
