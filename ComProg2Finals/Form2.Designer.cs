using System.Windows.Forms;

namespace ComProg2Finals
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.dialogue_box = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dialogueTextBox = new System.Windows.Forms.TextBox();
            this.WalkChar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dialoguePanel = new System.Windows.Forms.Panel();
            this.dialogueNextBtn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.defStat = new System.Windows.Forms.Label();
            this.coinStat = new System.Windows.Forms.Label();
            this.atkStat = new System.Windows.Forms.Label();
            this.rizzStat = new System.Windows.Forms.Label();
            this.charactersPictureBox = new System.Windows.Forms.PictureBox();
            this.playerPictureBox = new System.Windows.Forms.PictureBox();
            this.dialoguePanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charactersPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dialogue_box
            // 
            this.dialogue_box.AutoSize = true;
            this.dialogue_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogue_box.Location = new System.Drawing.Point(389, 209);
            this.dialogue_box.Name = "dialogue_box";
            this.dialogue_box.Size = new System.Drawing.Size(28, 42);
            this.dialogue_box.TabIndex = 6;
            this.dialogue_box.Text = " ";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            // 
            // dialogueTextBox
            // 
            this.dialogueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dialogueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueTextBox.Location = new System.Drawing.Point(73, 44);
            this.dialogueTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dialogueTextBox.Multiline = true;
            this.dialogueTextBox.Name = "dialogueTextBox";
            this.dialogueTextBox.ReadOnly = true;
            this.dialogueTextBox.Size = new System.Drawing.Size(543, 93);
            this.dialogueTextBox.TabIndex = 14;
            // 
            // WalkChar
            // 
            this.WalkChar.BackColor = System.Drawing.Color.Transparent;
            this.WalkChar.Location = new System.Drawing.Point(1169, 14);
            this.WalkChar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WalkChar.Name = "WalkChar";
            this.WalkChar.Size = new System.Drawing.Size(75, 23);
            this.WalkChar.TabIndex = 15;
            this.WalkChar.Text = "Next";
            this.WalkChar.UseVisualStyleBackColor = false;
            this.WalkChar.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1029, 468);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 197);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1101, 420);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // dialoguePanel
            // 
            this.dialoguePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dialoguePanel.BackColor = System.Drawing.Color.Transparent;
            this.dialoguePanel.Controls.Add(this.dialogueNextBtn);
            this.dialoguePanel.Controls.Add(this.dialogueTextBox);
            this.dialoguePanel.Location = new System.Drawing.Point(324, 468);
            this.dialoguePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dialoguePanel.Name = "dialoguePanel";
            this.dialoguePanel.Size = new System.Drawing.Size(697, 197);
            this.dialoguePanel.TabIndex = 18;
            // 
            // dialogueNextBtn
            // 
            this.dialogueNextBtn.AutoSize = true;
            this.dialogueNextBtn.Location = new System.Drawing.Point(576, 140);
            this.dialogueNextBtn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dialogueNextBtn.Name = "dialogueNextBtn";
            this.dialogueNextBtn.Size = new System.Drawing.Size(58, 16);
            this.dialogueNextBtn.TabIndex = 15;
            this.dialogueNextBtn.Text = "Next >>>";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::ComProg2Finals.Properties.Resources.levelsProgress;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Location = new System.Drawing.Point(60, 62);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 47);
            this.panel1.TabIndex = 20;
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.Transparent;
            this.statsPanel.BackgroundImage = global::ComProg2Finals.Properties.Resources.statsPanel;
            this.statsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.statsPanel.Controls.Add(this.defStat);
            this.statsPanel.Controls.Add(this.coinStat);
            this.statsPanel.Controls.Add(this.atkStat);
            this.statsPanel.Controls.Add(this.rizzStat);
            this.statsPanel.Location = new System.Drawing.Point(16, 468);
            this.statsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(300, 197);
            this.statsPanel.TabIndex = 19;
            // 
            // defStat
            // 
            this.defStat.AutoSize = true;
            this.defStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defStat.Location = new System.Drawing.Point(219, 135);
            this.defStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.defStat.Name = "defStat";
            this.defStat.Size = new System.Drawing.Size(39, 20);
            this.defStat.TabIndex = 23;
            this.defStat.Text = "Def";
            this.defStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // coinStat
            // 
            this.coinStat.AutoSize = true;
            this.coinStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coinStat.Location = new System.Drawing.Point(92, 135);
            this.coinStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.coinStat.Name = "coinStat";
            this.coinStat.Size = new System.Drawing.Size(47, 20);
            this.coinStat.TabIndex = 22;
            this.coinStat.Text = "Coin";
            this.coinStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // atkStat
            // 
            this.atkStat.AutoSize = true;
            this.atkStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atkStat.Location = new System.Drawing.Point(219, 70);
            this.atkStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.atkStat.Name = "atkStat";
            this.atkStat.Size = new System.Drawing.Size(36, 20);
            this.atkStat.TabIndex = 21;
            this.atkStat.Text = "Atk";
            this.atkStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rizzStat
            // 
            this.rizzStat.AutoSize = true;
            this.rizzStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rizzStat.Location = new System.Drawing.Point(92, 70);
            this.rizzStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rizzStat.Name = "rizzStat";
            this.rizzStat.Size = new System.Drawing.Size(47, 20);
            this.rizzStat.TabIndex = 20;
            this.rizzStat.Text = "Rizz";
            this.rizzStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // charactersPictureBox
            // 
            this.charactersPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.charactersPictureBox.Location = new System.Drawing.Point(1029, 234);
            this.charactersPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.charactersPictureBox.Name = "charactersPictureBox";
            this.charactersPictureBox.Size = new System.Drawing.Size(196, 178);
            this.charactersPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.charactersPictureBox.TabIndex = 9;
            this.charactersPictureBox.TabStop = false;
            // 
            // playerPictureBox
            // 
            this.playerPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.playerPictureBox.Location = new System.Drawing.Point(312, 246);
            this.playerPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerPictureBox.Name = "playerPictureBox";
            this.playerPictureBox.Size = new System.Drawing.Size(150, 150);
            this.playerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerPictureBox.TabIndex = 7;
            this.playerPictureBox.TabStop = false;
            this.playerPictureBox.Click += new System.EventHandler(this.player_Click);
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.dialoguePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.WalkChar);
            this.Controls.Add(this.charactersPictureBox);
            this.Controls.Add(this.playerPictureBox);
            this.Controls.Add(this.dialogue_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.dialoguePanel.ResumeLayout(false);
            this.dialoguePanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.statsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charactersPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dialogue_box;
        private System.Windows.Forms.PictureBox playerPictureBox;
        private System.Windows.Forms.PictureBox charactersPictureBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        public TextBox dialogueTextBox;
        private System.Windows.Forms.Button WalkChar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel dialoguePanel;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label defStat;
        private System.Windows.Forms.Label coinStat;
        private System.Windows.Forms.Label atkStat;
        private System.Windows.Forms.Label rizzStat;
        private System.Windows.Forms.Panel panel1;
        private Label dialogueNextBtn;
        //private System.Windows.Forms.TextBox dialogueTextBox;
    }
}