using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation05
{
    public class Solution
    {
        const int DEFAULT_SIZE = 10;

        private readonly Random rnd = new Random();

        public Element[] Data { get; set; }

        public Painter painter { get; set; }

        public Graphics GBitmap { get; set; }

        public Graphics GScreen { get; set; }

        public Bitmap Bitmap { get; set; }

        public Solution(Graphics gbitmap, Graphics gscreen, Bitmap bitmap)
        {
            GBitmap = gbitmap;
            GScreen = gscreen;
            Bitmap = bitmap;
            Data = new Element[DEFAULT_SIZE];
            Generate();
        }

        public Solution(int length)
        {
            Data = new Element[length];
            Generate();
        }

        public Solution(params int[] array)
        {
            Data = new Element[array.Length];
            Load(array);
        }

        private void Generate()
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = new Element(20 + i * 40, 100, rnd.Next(0, 100), Color.Black);
            }
        }

        private void Load(int[] array)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = new Element(20 + i * 40, 100, rnd.Next(0, 100), Color.Black);
            }
        }

        public void Sort()
        {
            painter = new Painter(Data, GBitmap, GScreen, Bitmap);
            int leftSite = 0;
            int rightSite = Data.Length - 1;
            bool sortedFront = false;
            bool sortedBack = false;
            int last = 0;
            while (leftSite < rightSite)
            {
                sortedFront = false;
                for (int index = leftSite; index < rightSite; index++)
                {
                    if (Data[index].Value > Data[index + 1].Value)
                    {
                        Swap(index, index + 1);
                        sortedFront = true;
                        last = index;
                    }
                }
                rightSite = last;
                if (!sortedFront && !sortedBack) break;
                sortedBack = false;
                for (int index = rightSite; index > leftSite; index--)
                {
                    if (Data[index].Value < Data[index - 1].Value)
                    {
                        Swap(index, index - 1);
                        sortedBack = true;
                        last = index;
                    }
                }
                leftSite = last;
                if (!sortedFront) break;
            }
        }

        private void Swap(int i, int j)
        {
            Change(j, j - 1, i, j);
            int tmp = Data[i].Value;
            Data[i] = Data[j];
            Data[j].Value = tmp;
        }

        private void Change(int n1, int n2, int n, int m)
        {
            Data[n1].Color = Color.Red;
            Data[n2].Color = Color.Red;

            int x1 = Data[n1].X;
            int y1 = Data[n1].Y;
            int x2 = Data[n2].X;
            int y2 = Data[n2].Y;

            double y;

            //double x;

            for (int t = 1; t <= 15; t++)
            {
                y = (x2 - x1) * t / 15;
               // x = (y2 - y1) * t / 15;

                Data[n1].X = x1 + (int)(y);

               // Data[n1].Y = y1 + (int)(x);

                switch (t)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        y = 40 * t / 4;
                        // x = 40 * t / 4;
                        Data[n2].Y = y1 - (int)(y);
                       // Data[n2].X = x1 - (int)(x);
                        break;
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                        y = (x1 - x2) * (t - 4) / 7;
                        Data[n2].X = x2 + (int)(y);

                       // x = (y1 - y2) * (t - 4) / 7;
                       // Data[n2].Y = y2 + (int)(x);
                        break;
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        y = 40 * (t - 11) / 4;
                        Data[n2].Y = y1 - 40 + (int)(y);

                       // x = 40 * (t - 11) / 4;
                       // Data[n2].X = x1 - 40 + (int)x;
                        break;
                }
                painter.Paint(n, m);
                //Drawing(n, m);
            }

            Data[n1].Color = Color.Red;
            Data[n2].Color = Color.Red;
            painter.Paint(n, m);
            //Drawing(n, m);

        }
    }
}