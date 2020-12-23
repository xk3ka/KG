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
        ArrayUtils arrayUtils { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arrayUtils = new ArrayUtils();
        }
    }
}
