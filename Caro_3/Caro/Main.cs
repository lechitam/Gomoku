using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Caro
{

    public partial class Main : Form
    {
        private DataTable optionsTable;
        private bool cursorChanged=false;
        public string playerName = "Player Name";
      // CELL_SIZE = 
        
        public Main()
        {
            InitializeComponent();
            optionsTable = new DataTable("Options");
            optionsTable.Columns.Add("C", typeof(string));
            optionsTable.Columns.Add("V", typeof(string));
           // board.Resize(Main.)
        }
        private void LoadOptions(Control ctr)
        {
            string name = ctr.Name;
            if (name.StartsWith("op_"))
            {
                DataRow[] R = optionsTable.Select("[C]='" + name + "'");
                if (R.Length > 0)
                {

                    DataRow r = R[0];
                    if (name.Contains("check"))
                    {
                        CheckBox chk = (CheckBox)ctr;
                        if ((string)r[1] == "False")
                            chk.Checked = false;
                        else chk.Checked = true;
                    }
                    if (name.Contains("combo"))
                    {
                        ComboBox cb = (ComboBox)ctr;
                        cb.Text = r[1].ToString();
                    }
                    if (name.Contains("track"))
                    {
                        TrackBar tr = (TrackBar)ctr;
                        tr.Value = Convert.ToInt32(r[1]);
                    }
                    if (name.Contains("numeric"))
                    {
                        NumericUpDown ud = (NumericUpDown)ctr;
                        ud.Value = Convert.ToInt32(r[1]);
                    }
                }
            }
            if (ctr.HasChildren)
                foreach (Control child in ctr.Controls)
                    LoadOptions(child);
        }
        private void SaveOptions(Control ctr)
        {
            if (ctr.Name.StartsWith("op_"))
            {
                DataRow r = optionsTable.NewRow();
                r[0] = ctr.Name;
                if (ctr.Name.Contains("check"))
                {
                    CheckBox chk = (CheckBox)ctr;
                    r[1] = chk.Checked.ToString();
                }
                if (ctr.Name.Contains("combo"))
                {
                    ComboBox cb = (ComboBox)ctr;
                    r[1] = cb.Text;
                }
                if (ctr.Name.Contains("track"))
                {
                    TrackBar tr = (TrackBar)ctr;
                    r[1] = tr.Value;
                }
                if (ctr.Name.Contains("numeric"))
                {
                    NumericUpDown ud = (NumericUpDown)ctr;
                    r[1] = ud.Value;
                }
                optionsTable.Rows.Add(r);
            }
            if (ctr.HasChildren)
                foreach (Control child in ctr.Controls)
                {
                    SaveOptions(child);
                }
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (board.processing) return;
            try
            {
                optionsTable.Rows.Clear();
                optionsTable.ReadXml("Options.xml");
                LoadOptions(this);
                bool playerFirst = op_comboFirstPlayer.Text == "Player" ? true : false;
                char playerSymbol = op_comboPlayerSymbol.Text == "X" ? 'x' : 'o';
                int level = op_trackComputerLevel.Value;
                board.NewGame1(playerFirst, playerSymbol);
               // board.NewGame(playerFirst, playerSymbol, level);

                //MessageBox.Show("hi");

            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
               // board.NewGame(true, 'x',3);
                board.NewGame1(true, 'x');
            }
            timer1.Start();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            options.ShowInTaskbar = false;
            options.ShowDialog();
            SaveSettings();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (board.processing)
            {
                if (!cursorChanged)
                {
                    cursorChanged = true;
                    Cursor = Cursors.WaitCursor;
                }
            }
            else
            {
                if(cursorChanged)
                {
                    cursorChanged = false;
                    Cursor = Cursors.Arrow;
                }
            }
            if(board.GameOver)
            {
                Cursor = Cursors.Arrow;
                timer1.Stop();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            board.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            board.Redo();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The goal is to get five X's (or O's) in a row\n while preventing your opponent\n from getting five O's (X's) in a row.\n (Horizontal, vertical and diagonal\n rows are all allowed.)","Help", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void resetScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            board.ResetScores();
        }

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (board.GameOver || board.processing) return;
            saveFileDialog1.ShowDialog();
            try
            {
                board.SaveGame(saveFileDialog1.FileName);
            }
            catch{}
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (board.processing) return;
            openFileDialog1.ShowDialog();
            try
            {
                board.LoadGame(openFileDialog1.FileName);
            }
            catch
            {
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            SaveSettings();
        }
        private void SaveSettings()
        {
            try
            {
                optionsTable.Rows.Clear();
                optionsTable.ReadXml("Options.xml");
                LoadOptions(this);
                bool playerFirst = op_comboFirstPlayer.Text == "Player" ? true : false;
                char playerSymbol = op_comboPlayerSymbol.Text == "X" ? 'x' : 'o';
                int level = op_trackComputerLevel.Value;
                board.ComputerAI = level;
                board.PlayerSymbol = playerSymbol;
            }
            catch { }
        }

        

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!board.GameOver)
                if (MessageBox.Show("Do you want to save current game?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    saveGameToolStripMenuItem_Click(sender, e);
        }

        private void board_Load(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
       // private void txt_Mess_
        private void txt_Mess_TextChanged(object sender, EventArgs e)
        {
           
            //txt_Mess.Font.FontFamily. = new SolidBrush(Color.Black);
            txt_Mess.ForeColor = Color.Black;
        }
        private void txtMessage_GotFocus(object sender, EventArgs e)
        {
            if (txt_Mess.Text == "Type your message...")
            {
                txt_Mess.Text = "";
                txt_Mess.ForeColor = Color.Black;
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("hi");
            
            //ChatBoxShow chatMess = new ChatBoxShow(playerName, txt_Mess.Text);
          if (txt_Mess.Text != "")
          { 
              chatBox.Items.Add("hi");
                ChatBoxShow chatMess = new ChatBoxShow(playerName, txt_Mess.Text);
               // CaroBoardUI caro = new CaroBoardUI();

                chatBox.Items.Add(chatMess);
                //chatBox.Items.Add(caro);
              
            }
        }

        private void txt_Mess_MouseDown(object sender, MouseEventArgs e)
        {
            if (txt_Mess.Text == "Type your message...")
            {
                txt_Mess.Text = "";
                txt_Mess.ForeColor = Color.Black;
            }
        }

       
    }
}
