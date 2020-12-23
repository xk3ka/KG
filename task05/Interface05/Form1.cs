using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Implementation05;

namespace Interface05
{
    public partial class Form1 : Form
    {
        Graphics gBitmap { get; set; }

        Graphics gScreen { get; set; }

        Bitmap bitmap { get; set; }

        Solution solution { get; set; }

        Painter painter { get; set; }

        public Form1()
        {
            gBitmap = this.CreateGraphics();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gScreen = CreateGraphics();
            bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            gBitmap = Graphics.FromImage(bitmap);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            MyDraw();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            solution = new Solution(gBitmap,gScreen,bitmap);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            solution.Sort();
        }

        private void MyDraw()
        {

            gBitmap.Dispose();
            gScreen.Dispose();
            bitmap.Dispose();
        }
    }
}
