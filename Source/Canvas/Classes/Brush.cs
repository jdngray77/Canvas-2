using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Canvas.Classes
{
    public class CustomBrushes
    {

        Random Rnd = new Random();
        public void stamp(int style, System.Drawing.Color color, System.Drawing.Graphics graphics, int x, int y, int width, int height, Boolean offssetForCanvas)

        {
            if (offssetForCanvas)
            {
                x = x - Main.PaintOffsetX - (width / 2);
                y = y - Main.PaintOffsetY - (height / 2);
            }

            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);
            switch (style)
            {

                case 0:
                    graphics.FillEllipse(myBrush, new Rectangle(x, y, width, height));
                    break;
                case 1:
                    graphics.FillRectangle(myBrush, new Rectangle(x, y, width, height));

                    break;

                case 2:
                    int X, Y;
                    for (int i = 0; i < Main.BrushModInt2; i++)
                    {
                        X = Rnd.Next(Main.BrushModInt1);
                        Y = Rnd.Next(Main.BrushModInt1);
                        graphics.FillEllipse(myBrush, new Rectangle(x + X, y + Y, width, height));
                    }
                    break;
                    }
            }
    }
}
    