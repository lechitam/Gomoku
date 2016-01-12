using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Caro
{
    public partial class CaroChess : Form
    {
        Graphic graph = new Graphic();
        Graphics gr;        
        EvalBoard eBoard;
        List<Point> listUndo = new List<Point>();

        public int[,] BoardArr = new int[20, 20]; //Nguoi 1 May 2 Chua 0
        int playerFlag = 2; //Biến cờ xác định máy đi hay người đi.
        int _x, _y; //Tọa độ nước cờ mà máy đi.

        public static int maxDepth = 11;
        public static int maxMove = 3;
        public int depth = 0;

        public bool fWin = false;
        public int fEnd = 1;

        public int[] DScore = new int[5] { 0, 1, 9, 81, 729 };
        
        //public int[] AScore = new int[5] { 0, 3, 24, 243, 2197 };
        public int[] AScore = new int[5] { 0, 2, 18, 162, 1458 };
        
        //public int[] AScore = new int[5] { 0, 1, 9, 81, 729 };


        Point[] PCMove = new Point[maxMove+2];
        Point[] HumanMove = new Point[maxMove+2];
        Point[] WinMove = new Point[maxDepth+2];
        Point[] LoseMove = new Point[maxDepth + 2];

        

        public CaroChess()
        {
            InitializeComponent();
            Width = 800;
            Height = 600;
            Paint += new PaintEventHandler(Form1_Paint);

            for (int i = 0; i < graph.Row * graph.Row; i++)
                BoardArr[i % graph.Row, i / graph.Row] = 0;
            eBoard = new EvalBoard(graph);

            //Buttons
            //label3.Image = Properties.Resources.Khung11;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            gr = e.Graphics;
            graph.DrawBanCo(gr);
            
        }

        //Hàm xử lí sự kiện click
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X >= graph.Left && e.X <= graph._Right && e.Y >= graph.Up && e.Y <= graph.Down && fEnd == 0 && playerFlag == 1)
            {
                int x = e.X / graph._Size - 1;
                int y = e.Y / graph._Size - 1;
                if (BoardArr[x, y] == 0)
                {
                    
                    BoardArr[x, y] = 1;
                    listUndo.Add(new Point(x, y));
                    gr = this.CreateGraphics();
                    graph.DrawQuanCo(x, y, BoardArr[x, y], gr);

                    if (CheckEnd(x, y) == 1) { MessageBox.Show("Thang"); fEnd = 1; return; }
                    
                    //May di

                    AI();
                    if (fWin)
                    {
                        _x = WinMove[0].X;
                        _y = WinMove[0].Y;
                    }
                    else
                    {
                        EvalChessBoard(2, ref eBoard);
                        Point temp = new Point();
                        temp = eBoard.MaxPos();
                        _x = temp.X;
                        _y = temp.Y;
                    }
                    BoardArr[_x, _y] = 2;
                    listUndo.Add(new Point(_x, _y));
                    graph.DrawQuanCo(_x, _y, BoardArr[_x, _y], gr);
                    if (CheckEnd(_x, _y) == 2) { MessageBox.Show("Thua"); fEnd = 2; return; }
                    //MessageBox.Show(CheckEnd(x, y).ToString());
                    //CheckEnd(_x, _y);
                }
            }
        }

       

        #region TÌM NƯỚC ĐI TỐI ƯU CHO MÁY
        //Ham tinh gia tri cho bang luong gia
        private void EvalChessBoard(int player,ref EvalBoard eBoard)
        {
            int rw, cl, ePC, eHuman;
            eBoard.ResetBoard();
            
            //Danh gia theo hang
            for (rw = 0; rw < graph.Row; rw++)            
                for (cl = 0; cl < graph.Col - 4; cl++)
                {
                    ePC = 0; eHuman = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (BoardArr[rw, cl + i] == 1) eHuman++;
                        if (BoardArr[rw, cl + i] == 2) ePC++;
                    }

                    if (eHuman * ePC == 0 && eHuman != ePC)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (BoardArr[rw, cl + i] == 0) // Neu o chua duoc danh
                            {
                                if (eHuman == 0)
                                    if (player == 1)
                                        eBoard.EBoard[rw, cl + i] += DScore[ePC];
                                    else eBoard.EBoard[rw, cl + i] += AScore[ePC];
                                if (ePC == 0)
                                    if (player == 2)
                                        eBoard.EBoard[rw, cl + i] += DScore[eHuman];
                                    else eBoard.EBoard[rw, cl + i] += AScore[eHuman];
                                if (eHuman == 4 || ePC == 4)
                                    eBoard.EBoard[rw, cl + i] *= 2;
                            }
                        }
                        
                    }                
                 }

            //Danh gia theo cot
            for (cl = 0; cl < graph.Col; cl++)
                for (rw = 0; rw < graph.Row - 4; rw++)
                {
                    ePC = 0; eHuman = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (BoardArr[rw + i, cl] == 1) eHuman++;
                        if (BoardArr[rw + i, cl] == 2) ePC++;
                    }

                    if (eHuman * ePC == 0 && eHuman != ePC)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (BoardArr[rw + i, cl] == 0) // Neu o chua duoc danh
                            {
                                if (eHuman == 0)
                                    if (player == 1)
                                        eBoard.EBoard[rw + i, cl] += DScore[ePC];
                                    else eBoard.EBoard[rw + i, cl] += AScore[ePC];
                                if (ePC == 0)
                                    if (player == 2)
                                        eBoard.EBoard[rw + i, cl] += DScore[eHuman];
                                    else eBoard.EBoard[rw + i, cl] += AScore[eHuman];
                                if (eHuman == 4 || ePC == 4)
                                    eBoard.EBoard[rw + i, cl] *= 2;
                            }
                        }

                    }
                }

            //Danh gia duong cheo xuong
            for (cl = 0; cl < graph.Col - 4; cl++)
                for (rw = 0; rw < graph.Row - 4; rw++)
                {
                    ePC = 0; eHuman = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (BoardArr[rw + i, cl + i] == 1) eHuman++;
                        if (BoardArr[rw + i, cl + i] == 2) ePC++;
                    }

                    if (eHuman * ePC == 0 && eHuman != ePC)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (BoardArr[rw + i, cl + i] == 0) // Neu o chua duoc danh
                            {
                                if (eHuman == 0)
                                    if (player == 1)
                                        eBoard.EBoard[rw + i, cl + i] += DScore[ePC];
                                    else eBoard.EBoard[rw + i, cl + i] += AScore[ePC];
                                if (ePC == 0)
                                    if (player == 2)
                                        eBoard.EBoard[rw + i, cl + i] += DScore[eHuman];
                                    else eBoard.EBoard[rw + i, cl + i] += AScore[eHuman];
                                if (eHuman == 4 || ePC == 4)
                                    eBoard.EBoard[rw + i, cl + i] *= 2;
                            }
                        }

                    }
                }

            //Danh gia duong cheo len
            for (rw = 4; rw < graph.Row; rw++)
                for (cl = 0; cl < graph.Col - 4; cl++)
                {
                    ePC = 0; eHuman = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (BoardArr[rw - i, cl + i] == 1) eHuman++;
                        if (BoardArr[rw - i, cl + i] == 2) ePC++;
                    }

                    if (eHuman * ePC == 0 && eHuman != ePC)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (BoardArr[rw - i, cl + i] == 0) // Neu o chua duoc danh
                            {
                                if (eHuman == 0)
                                    if (player == 1)
                                        eBoard.EBoard[rw - i, cl + i] += DScore[ePC];
                                    else eBoard.EBoard[rw - i, cl + i] += AScore[ePC];
                                if (ePC == 0)
                                    if (player == 2)
                                        eBoard.EBoard[rw - i, cl + i] += DScore[eHuman];
                                    else eBoard.EBoard[rw - i, cl + i] += AScore[eHuman];
                                if (eHuman == 4 || ePC == 4)
                                    eBoard.EBoard[rw - i, cl + i] *= 2;
                            }
                        }

                    }
                }
            
        }

        
        //Ham tim nuoc di cho may
        private void FindMove()
        {
            if (depth > maxDepth) return;
            depth++;
            fWin = false;
            bool fLose = false;
            Point pcMove = new Point();
            Point humanMove = new Point();
            int countMove = 0;

            EvalChessBoard(2, ref eBoard);

            //Lay ra MaxMove buoc di co diem cao nhat
            Point temp = new Point();
            for (int i = 0; i < maxMove; i++)
            {
                temp = eBoard.MaxPos();
                PCMove[i] = temp;
                eBoard.EBoard[temp.X, temp.Y] = 0;
            }

            //Lay nuoc di trong PCMove[] ra danh thu
            countMove = 0;
            while (countMove < maxMove)
            {

                pcMove = PCMove[countMove++];
                BoardArr[pcMove.X, pcMove.Y] = 2;
                WinMove.SetValue(pcMove, depth - 1);

                //Tim cac nuoc di toi uu cua nguoi
                eBoard.ResetBoard();
                EvalChessBoard(1,ref eBoard);
                //Lay ra maxMove nuoc di co diem cao nhat cua nguoi
                for (int i = 0; i < maxMove; i++)
                {
                    temp = eBoard.MaxPos();
                    HumanMove[i] = temp;
                    eBoard.EBoard[temp.X, temp.Y] = 0;
                }
                //Danh thu cac nuoc di
                for (int i = 0; i < maxMove; i++)
                {
                    humanMove = HumanMove[i];
                    BoardArr[humanMove.X, humanMove.Y] = 1;
                    if (CheckEnd(humanMove.X, humanMove.Y) == 2)
                    {
                        fWin = true;
                        //MessageBox.Show("fwin" + fWin.ToString());
                    }
                    if (CheckEnd(humanMove.X, humanMove.Y) == 1)
                    {
                        fLose = true;
                        //MessageBox.Show("flose" + fLose.ToString());
                    }
                    if (fLose)
                    {
                        BoardArr[pcMove.X, pcMove.Y] = 0;
                        BoardArr[humanMove.X, humanMove.Y] = 0;
                        break;
                    }
                    if (fWin)
                    {
                        BoardArr[pcMove.X, pcMove.Y] = 0;
                        BoardArr[humanMove.X, humanMove.Y] = 0;
                        return;
                    }
                    FindMove();
                    BoardArr[humanMove.X, humanMove.Y] = 0;
                }
                BoardArr[pcMove.X, pcMove.Y] = 0;

            }

        }


        private void AI()
        {
            for (int i = 0; i < maxMove; i++)
            {
                WinMove[i] = new Point();
                PCMove[i] = new Point();
                HumanMove[i] = new Point();
            }

            depth = 0;
            FindMove();
            //MessageBox.Show(depth.ToString());
        }
        #endregion

        #region KIỂM TRA KẾT THÚC
        private int CheckEnd(int cl, int rw)
        {
            int r = 0, c = 0;
            int i;
            bool human, pc;
            //Check hàng ngang
            while (c < graph.Col - 5)
            {
                human = true; pc = true;
                for (i = 0; i < 5; i++)
                {
                    if (BoardArr[cl, c + i] != 1)
                        human = false;
                    if (BoardArr[cl, c + i] != 2)
                        pc = false;
                }
                if (human) return 1;
                if (pc) return 2;
                c++;
            }
            
            //Check hàng dọc
            while (r < graph.Row - 5)
            {
                human = true; pc = true;
                for (i = 0; i < 5; i++)
                {
                    if (BoardArr[r + i, rw] != 1)
                        human = false;
                    if (BoardArr[r + i, rw] != 2)
                        pc = false;
                }
                if (human) return 1;
                if (pc) return 2;
                r++;
            }
            
            //Check duong cheo xuong
            r = rw; c = cl;
            while (r > 0 && c > 0) { r--; c--; }
            while (r <= graph.Row - 5 && c <= graph.Col - 5)
            {
                human = true; pc = true;
                for (i = 0; i < 5; i++)
                {
                    if (BoardArr[c + i, r + i] != 1)
                        human = false;
                    if (BoardArr[c + i, r + i] != 2)
                        pc = false;
                }
                if (human) return 1;
                if (pc) return 2;
                r++; c++;
            }
            
            //Check duong cheo len
            r = rw; c = cl;
            while (r < graph.Row - 1 && c > 0) { r++; c--; }
            while (r >= 4 && c <= graph.Col - 5)
            {
                human = true; pc = true;
                for (i = 0; i < 5; i++)
                {
                    if (BoardArr[r - i, c + i] != 1)
                        human = false;
                    if (BoardArr[r - i, c + i] != 2)
                        pc = false;
                }
                if (human) return 1;
                if (pc) return 2;
                r--; c++;
            }
            return 0;
        }
        #endregion

        
        private void label1_Click(object sender, EventArgs e)
        {
            
            //Paint += new PaintEventHandler(Form1_Paint);
            
            for (int i = 0; i < graph.Row * graph.Row; i++)
                if (BoardArr[i % graph.Row, i / graph.Row] != 0)
                {
                    BoardArr[i % graph.Row, i / graph.Row] = 0;
                    graph.DrawQuanCo(i % graph.Row, i / graph.Row, 0, gr);
                }
            Paint += new PaintEventHandler(Form1_Paint);
            if (fEnd == 1)
                playerFlag = 2;
            else playerFlag = 1;
            if (playerFlag == 2)
            {
                Random r = new Random();
                _x = r.Next(3);
                _y = r.Next(3);
                BoardArr[_x + 7, _y + 7] = 2;
                listUndo.Add(new Point(_x+7, _y+7));
                gr = this.CreateGraphics();
                graph.DrawQuanCo(_x + 7, _y + 7, BoardArr[_x + 7, _y + 7], gr);
                playerFlag = 1;
            }
            fEnd = 0;
        }
        

      
        private void lbExit_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this);
            f.Show();
        }


        //SAVE
        public void lbSave_Click(object sender, EventArgs e)
        {
            string path = @"Caro.sav";
            FileStream f = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(f);
            for (int i = 0; i < graph.Row; i++)
            {
                for (int j = 0; j < graph.Col; j++)
                {
                    sw.Write(BoardArr[i, j].ToString()); //+ " ");
                }
                sw.Write("\n");
            }
            sw.Flush();
            sw.Close();
            f.Close();
            MessageBox.Show("Done!");
        }
       

        //LOAD
        private void lbLoad_Click(object sender, EventArgs e)
        {
            string path = @"Caro.sav";
            FileStream f = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(f);
            
            gr = this.CreateGraphics();

            for (int i = 0; i < graph.Row * graph.Row; i++)
                if (BoardArr[i % graph.Row, i / graph.Row] != 0)
                {
                    BoardArr[i % graph.Row, i / graph.Row] = 0;
                    graph.DrawQuanCo(i % graph.Row, i / graph.Row, 0, gr);
                }
            Paint += new PaintEventHandler(Form1_Paint);

            for (int i = 0; i < graph.Row; i++)
            {
                string s = sr.ReadLine();
                for (int j = 0; j < graph.Col; j++)
                {
                    BoardArr[i, j] = (int)(s[j] - 48);
                    if(BoardArr[i, j] != 0)
                        graph.DrawQuanCo(i, j, BoardArr[i, j], gr);
                }
            }

            /*int l = Convert.ToInt32(sr.ReadLine());
            for (int i = 0; i < l; i++)
            {
                
                int xx = Convert.ToInt32(sr.ReadLine());
                int yy = Convert.ToInt32(sr.ReadLine());
                listUndo.Add(new Point(xx, yy));
           // }        */
            playerFlag = 1;
            fEnd = 0;
            sr.Close();
            f.Close();
        } 
             
        
        //UNDO
        private void lbUndo_Click(object sender, EventArgs e)
        {
            if (listUndo.Count > 1)
            {
                Point p = listUndo.Last();
                listUndo.RemoveAt(listUndo.Count() - 1);
                BoardArr[p.X, p.Y] = 0;
                graph.DrawQuanCo(p.X, p.Y, 0, gr);
                if (listUndo.Count > 0)
                {
                    p = listUndo.Last();
                    listUndo.RemoveAt(listUndo.Count() - 1);
                    BoardArr[p.X, p.Y] = 0;
                    graph.DrawQuanCo(p.X, p.Y, 0, gr);
                }
                fEnd = 0;
            }
        }

        #region XỬ LÍ CÁC BUTTONS
        private void lbNew_MouseHover(object sender, EventArgs e)
        {
            lbNew.Image = Properties.Resources.To2;
        }

        private void lbUndo_MouseHover(object sender, EventArgs e)
        {
            lbUndo.Image = Properties.Resources.To2;
        }

        private void lbSave_MouseHover(object sender, EventArgs e)
        {
            lbSave.Image = Properties.Resources.Nho2;
        }

        private void lbLoad_MouseHover(object sender, EventArgs e)
        {
            lbLoad.Image = Properties.Resources.Nho2;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.Image = Properties.Resources.Nho2;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.Image = Properties.Resources.Nho2;
        }

        private void lbExit_MouseHover(object sender, EventArgs e)
        {
            lbExit.Image = Properties.Resources.To2;
        }

        private void lbNew_MouseLeave(object sender, EventArgs e)
        {
            lbNew.Image = Properties.Resources.KhungTo;
        }

        private void lbUndo_MouseLeave(object sender, EventArgs e)
        {
            lbUndo.Image = Properties.Resources.KhungTo;
        }

        private void lbSave_MouseLeave(object sender, EventArgs e)
        {
            lbSave.Image = Properties.Resources.KhungNho;
        }

        private void lbLoad_MouseLeave(object sender, EventArgs e)
        {
            lbLoad.Image = Properties.Resources.KhungNho;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.Image = Properties.Resources.KhungNho;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Image = Properties.Resources.KhungNho;
        }

        private void lbExit_MouseLeave(object sender, EventArgs e)
        {
            lbExit.Image = Properties.Resources.KhungTo;
        }

        #endregion

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        

    }
}
