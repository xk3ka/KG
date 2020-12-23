using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation05
{
    public class Element
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Value { get; set; }

        public Color Color { get; set; }

        public Element(int x, int y, int value, Color color)
        {
            X = x;
            Y = y;
            Value = value;
            Color = color;
        }
    }
}
