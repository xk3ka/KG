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
        public Bitmap bitmap;

        public Graphics gBitmap;

        public Graphics gScreen;

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

        private void button1_Click(object sender, EventArgs e)
        {
            //solution.Sort();

            Solution solution = new Solution(new Data(gBitmap,gScreen,bitmap,ClientRectangle));
            solution.Generate(10);
            solution.Sort();
        }
    }
}
