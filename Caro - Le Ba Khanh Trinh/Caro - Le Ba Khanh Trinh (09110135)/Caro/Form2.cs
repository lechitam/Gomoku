using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Caro
{
    public partial class Form2 : Form
    {
        CaroChess F;
        public Form2(CaroChess f)
        {
            InitializeComponent();
            F = f;
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            F.Close();
        }
    }
}
