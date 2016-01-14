using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Caro
{
    public partial class ChatBoxShow : UserControl
    {
        private string playerName;
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        private string message;
        private DateTime time;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        public ChatBoxShow()
        {
            InitializeComponent();
        }

        public ChatBoxShow(string playerName, string message,DateTime time)
        {
              
            InitializeComponent();
            this.playerName = playerName;
           lblName.Text = playerName;
            
            this.message = message;
            lblContent.Text = message;

            this.time = time;
            lblTime.Text = time.ToString();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
