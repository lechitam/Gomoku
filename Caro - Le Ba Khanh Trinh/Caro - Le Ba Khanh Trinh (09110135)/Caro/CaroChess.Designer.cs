namespace Caro
{
    partial class CaroChess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaroChess));
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLoad = new System.Windows.Forms.Label();
            this.lbSave = new System.Windows.Forms.Label();
            this.lbUndo = new System.Windows.Forms.Label();
            this.lbExit = new System.Windows.Forms.Label();
            this.lbNew = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Papyrus", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(538, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 60);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sinh viên: Lê Bá Khánh Trình\r\nMSSV: 09110135";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Caro.Properties.Resources.Caroo;
            this.pictureBox1.Location = new System.Drawing.Point(538, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 121);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(653, 420);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 55);
            this.label2.TabIndex = 7;
            this.label2.Text = "About Us";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            this.label2.MouseLeave += new System.EventHandler(this.label2_MouseLeave);
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(532, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 55);
            this.label1.TabIndex = 6;
            this.label1.Text = "Option";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // lbLoad
            // 
            this.lbLoad.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoad.ForeColor = System.Drawing.Color.Black;
            this.lbLoad.Image = ((System.Drawing.Image)(resources.GetObject("lbLoad.Image")));
            this.lbLoad.Location = new System.Drawing.Point(653, 363);
            this.lbLoad.Name = "lbLoad";
            this.lbLoad.Size = new System.Drawing.Size(125, 55);
            this.lbLoad.TabIndex = 5;
            this.lbLoad.Text = "Load";
            this.lbLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoad.Click += new System.EventHandler(this.lbLoad_Click);
            this.lbLoad.MouseLeave += new System.EventHandler(this.lbLoad_MouseLeave);
            this.lbLoad.MouseHover += new System.EventHandler(this.lbLoad_MouseHover);
            // 
            // lbSave
            // 
            this.lbSave.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSave.ForeColor = System.Drawing.Color.Black;
            this.lbSave.Image = ((System.Drawing.Image)(resources.GetObject("lbSave.Image")));
            this.lbSave.Location = new System.Drawing.Point(533, 361);
            this.lbSave.Name = "lbSave";
            this.lbSave.Size = new System.Drawing.Size(125, 55);
            this.lbSave.TabIndex = 4;
            this.lbSave.Text = "Save";
            this.lbSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbSave.Click += new System.EventHandler(this.lbSave_Click);
            this.lbSave.MouseLeave += new System.EventHandler(this.lbSave_MouseLeave);
            this.lbSave.MouseHover += new System.EventHandler(this.lbSave_MouseHover);
            // 
            // lbUndo
            // 
            this.lbUndo.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUndo.ForeColor = System.Drawing.Color.Black;
            this.lbUndo.Image = ((System.Drawing.Image)(resources.GetObject("lbUndo.Image")));
            this.lbUndo.Location = new System.Drawing.Point(538, 306);
            this.lbUndo.Name = "lbUndo";
            this.lbUndo.Size = new System.Drawing.Size(240, 55);
            this.lbUndo.TabIndex = 2;
            this.lbUndo.Text = "Undo";
            this.lbUndo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUndo.Click += new System.EventHandler(this.lbUndo_Click);
            this.lbUndo.MouseLeave += new System.EventHandler(this.lbUndo_MouseLeave);
            this.lbUndo.MouseHover += new System.EventHandler(this.lbUndo_MouseHover);
            // 
            // lbExit
            // 
            this.lbExit.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExit.ForeColor = System.Drawing.Color.Black;
            this.lbExit.Image = ((System.Drawing.Image)(resources.GetObject("lbExit.Image")));
            this.lbExit.Location = new System.Drawing.Point(538, 475);
            this.lbExit.Name = "lbExit";
            this.lbExit.Size = new System.Drawing.Size(240, 55);
            this.lbExit.TabIndex = 1;
            this.lbExit.Text = "Exit";
            this.lbExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbExit.Click += new System.EventHandler(this.lbExit_Click);
            this.lbExit.MouseLeave += new System.EventHandler(this.lbExit_MouseLeave);
            this.lbExit.MouseHover += new System.EventHandler(this.lbExit_MouseHover);
            // 
            // lbNew
            // 
            this.lbNew.Font = new System.Drawing.Font("Curlz MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNew.ForeColor = System.Drawing.Color.Black;
            this.lbNew.Image = ((System.Drawing.Image)(resources.GetObject("lbNew.Image")));
            this.lbNew.Location = new System.Drawing.Point(538, 244);
            this.lbNew.Name = "lbNew";
            this.lbNew.Size = new System.Drawing.Size(240, 55);
            this.lbNew.TabIndex = 0;
            this.lbNew.Text = "New Game";
            this.lbNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbNew.Click += new System.EventHandler(this.label1_Click);
            this.lbNew.MouseLeave += new System.EventHandler(this.lbNew_MouseLeave);
            this.lbNew.MouseHover += new System.EventHandler(this.lbNew_MouseHover);
            // 
            // CaroChess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 570);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbLoad);
            this.Controls.Add(this.lbSave);
            this.Controls.Add(this.lbUndo);
            this.Controls.Add(this.lbExit);
            this.Controls.Add(this.lbNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "CaroChess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbNew;
        private System.Windows.Forms.Label lbExit;
        private System.Windows.Forms.Label lbUndo;
        private System.Windows.Forms.Label lbSave;
        private System.Windows.Forms.Label lbLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}

