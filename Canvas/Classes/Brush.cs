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
        //public Boolean PointToPoint = false;
        
        
        //My Shit
        Random Rnd = new Random();
        public void stamp(Main main, int style, System.Drawing.Color color, PictureBox image, int x, int y, int width, int height, Boolean offssetForCanvas)
           
        {
            
            //--------------------------------------------//
            if (offssetForCanvas)
            {
                x = x - Main.PaintOffsetX - (width / 2);
                y = y - Main.PaintOffsetY - (height / 2);
            }

            if (main.OptionsPane.Visible)
            {
                x -= main.OptionsPane.Size.Width;
            }


            //--------------------------------------------//
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);
            switch (style)
            {

                case 0:

                    image.CreateGraphics().FillEllipse(myBrush, new Rectangle(x, y, width, height));
                    break;
                case 1:
                    image.CreateGraphics().FillRectangle(myBrush, new Rectangle(x, y, width, height));
                    break;

                case 2:
                    int X, Y;
                    for (int i = 0; i < Main.BrushModInt2; i++)
                    {
                        X = Rnd.Next(Main.BrushModInt1);
                        Y = Rnd.Next(Main.BrushModInt1);
                        image.CreateGraphics().FillEllipse(myBrush, new Rectangle(x + X, y + Y, width, height));
                    }
                    break;
                case 3:
                    myBrush = new SolidBrush(Color.White);
                    image.CreateGraphics().FillEllipse(myBrush, new Rectangle(x, y, width, height));
                    break;
                case 4:
                    int currentX = x;
                    int currentY = y;
                    int DrawingX = x;
                    int DrawingY = y;

                    if (Main.PointToPoint) {
                       
                       
                        Main.PointToPoint = false;
                    }
                    

                    while (!(DrawingX == currentX && DrawingY == currentY))
                    {
                        if (DrawingX > currentX) { DrawingX--; }
                        if (DrawingX < currentX) { DrawingX++; }
                        if (DrawingY > currentY) { DrawingY--; }
                        if (DrawingY < currentY) { DrawingY++; }
                        image.CreateGraphics().FillEllipse(myBrush, new Rectangle(DrawingX, DrawingY, width, height));

                    }
                   

                    break;
            }


        }


        public void initialiseBrush(Main main, int style) { 
                switch (style)
                {
                    case 0:
                        main.BrushLabel1.Text = "";
                        main.BrushLabel2.Text = "";
                        main.BrushLabel3.Text = "";
                        main.BrushMod1.Enabled = false;
                        main.BrushMod2.Enabled = false;
                        main.BrushMod3.Enabled = false;
                     break;
                    case 1:
                        main.BrushLabel1.Text = "";
                        main.BrushLabel2.Text = "";
                        main.BrushLabel3.Text = "";
                        main.BrushMod1.Enabled = false;
                        main.BrushMod2.Enabled = false;
                        main.BrushMod3.Enabled = false;
                        break;
                    case 2:
                        main.BrushMod1.Text = "50";
                        main.BrushMod2.Text = "2";
                        main.BrushLabel1.Text = "Spread";
                        main.BrushLabel2.Text = "Density";
                        main.BrushLabel3.Text = "";
                        main.BrushMod1.Enabled = true;
                        main.BrushMod2.Enabled = true;
                        main.BrushMod3.Enabled = false;
                        break;
                    case 3:
                    main.BrushLabel1.Text = "";
                    main.BrushLabel2.Text = "";
                    main.BrushLabel3.Text = "";
                    main.BrushMod1.Enabled = false;
                    main.BrushMod2.Enabled = false;
                    main.BrushMod3.Enabled = false;
                    break;

            }
            }
    }   


}

    