using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation05
{
    public class Painter
    {
        public Element[] Data { get; set; }

        public Graphics GBitmap { get; set; }

        public Graphics GScreen { get; set; }

        public PointF ClientRectangle { get; set; }

        public Bitmap Bitmap { get; set; }

        private Pen Pen { get; set; } = new Pen(Color.Black);

        private Font Font { get; set; } = new Font("Courier New", 12);

        public Painter(Element[] data,Graphics gbitmap, Graphics gscreen, Bitmap bitmap)
        {
            Data = data;
            GBitmap = gbitmap;
            GScreen = gscreen;
            Bitmap = bitmap;
        }

        public void Paint(int n, int m)
        {
            const int d = 15;
            int L = Data.Length;
            string s;
            SizeF size;
            GBitmap.Clear(Color.White);
            for (int i = 0; i <= L - 1; i++)
            {
                Pen.Color = Data[i].Color;
                GBitmap.DrawEllipse(Pen, Data[i].X - d, Data[i].Y - d, 2 * d, 2 * d);
                s = Convert.ToString(Data[i].Value);
                size = GBitmap.MeasureString(s, Font);
                GBitmap.DrawString(s, Font, Brushes.Black, Data[i].X - size.Width / 2, Data[i].Y - size.Height / 2);
            }

            if (n != -1)
            {

                Pen.Color = Color.Black;
                GBitmap.DrawLine(Pen, 120, Data[n].Y, 140, Data[n].Y);
                s = "I = " + Convert.ToString(n);
                size = GBitmap.MeasureString(s, Font);
                GBitmap.DrawString(s, Font, Brushes.Black, 150, Data[n].Y - size.Height / 2);

            }

            if (m != -1)
            {

                Pen.Color = Color.Red;
                GBitmap.DrawLine(Pen, 120, Data[m].Y, 140, Data[m].Y);
                s = "J = " + Convert.ToString(m);
                size = GBitmap.MeasureString(s, Font);
                GBitmap.DrawString(s, Font, Brushes.Black, 150, Data[m].Y - size.Height / 2);
            }
            GScreen.DrawImage(Bitmap, ClientRectangle);
        }
    }
}
