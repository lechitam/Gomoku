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
    class Graphic : Form
    {
        const int row = 20, col = 20, left = 25, up = 25, size = 25, right = col * size + left, down = up + row * size;
        Color bgColor = Color.YellowGreen;
        Image imageO = new Bitmap(Properties.Resources.o);
        Image imageX = new Bitmap(Properties.Resources.x);
        public Graphic() { }

        public int _Left {get {return left;}}
        public int _Right {get {return right;}}
        public int Up { get { return up; } }
        public int Down { get { return down; } }
        public int _Size { get { return size; } }
        public int Row { get { return row; } }
        public int Col { get { return col; } }

        public void DrawBanCo(Graphics graph)
        {
            Brush b = new SolidBrush(bgColor);
            graph.FillRectangle(b, left, up, row * size, col * size);
            //MessageBox.Show("hello");
            Pen pen = new Pen(Color.Green);
            for (int i = 0; i < 21; i++)
            {
                graph.DrawLine(pen, left, size * (i + 1), right, size * (i + 1));
                graph.DrawLine(pen, size * (i + 1), up, size * (i + 1), down);
            }
        }

        public void DrawQuanCo(int x, int y, int val, Graphics gr)
        {
            
            if (val == 1)
            {
                Pen p = new Pen(Color.Blue, 4f);
                gr.DrawImage(imageO, new Point((x+1)*size, (y+1)*size));
            }
            else if (val == 2)
            {
                Pen p = new Pen(Color.Red, 4f);
                gr.DrawImage(imageX, new Point((x + 1) * size, (y + 1) * size));
            }
            else
            {
                gr.FillRectangle(new SolidBrush(bgColor), (x + 1) * size, (y + 1) * size, size, size);
                Pen pen = new Pen(Color.Green);
                gr.DrawRectangle(pen, (x + 1) * size, (y + 1) * size, size, size);
            }
        }


    }
}
