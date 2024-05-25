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
            this.playerPictureBox = new System.Windows.Forms.PictureBox();
            this.charactersPictureBox = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dialogueTextBox = new System.Windows.Forms.TextBox();
            this.WalkChar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.dialoguePanel = new System.Windows.Forms.Panel();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.rizzStat = new System.Windows.Forms.Label();
            this.atkStat = new System.Windows.Forms.Label();
            this.coinStat = new System.Windows.Forms.Label();
            this.defStat = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charactersPictureBox)).BeginInit();
            this.dialoguePanel.SuspendLayout();
            this.statsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialogue_box
            // 
            this.dialogue_box.AutoSize = true;
            this.dialogue_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogue_box.Location = new System.Drawing.Point(292, 170);
            this.dialogue_box.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dialogue_box.Name = "dialogue_box";
            this.dialogue_box.Size = new System.Drawing.Size(23, 33);
            this.dialogue_box.TabIndex = 6;
            this.dialogue_box.Text = " ";
            // 
            // playerPictureBox
            // 
            this.playerPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.playerPictureBox.Location = new System.Drawing.Point(243, 205);
            this.playerPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.playerPictureBox.Name = "playerPictureBox";
            this.playerPictureBox.Size = new System.Drawing.Size(150, 150);
            this.playerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerPictureBox.TabIndex = 7;
            this.playerPictureBox.TabStop = false;
            this.playerPictureBox.Click += new System.EventHandler(this.player_Click);
            // 
            // charactersPictureBox
            // 
            this.charactersPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.charactersPictureBox.Location = new System.Drawing.Point(772, 190);
            this.charactersPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.charactersPictureBox.Name = "charactersPictureBox";
            this.charactersPictureBox.Size = new System.Drawing.Size(147, 145);
            this.charactersPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.charactersPictureBox.TabIndex = 9;
            this.charactersPictureBox.TabStop = false;
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
            this.dialogueTextBox.Location = new System.Drawing.Point(55, 36);
            this.dialogueTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.dialogueTextBox.Multiline = true;
            this.dialogueTextBox.Name = "dialogueTextBox";
            this.dialogueTextBox.ReadOnly = true;
            this.dialogueTextBox.Size = new System.Drawing.Size(408, 76);
            this.dialogueTextBox.TabIndex = 14;
            // 
            // WalkChar
            // 
            this.WalkChar.BackColor = System.Drawing.Color.Transparent;
            this.WalkChar.Location = new System.Drawing.Point(877, 11);
            this.WalkChar.Margin = new System.Windows.Forms.Padding(2);
            this.WalkChar.Name = "WalkChar";
            this.WalkChar.Size = new System.Drawing.Size(56, 19);
            this.WalkChar.TabIndex = 15;
            this.WalkChar.Text = "Next";
            this.WalkChar.UseVisualStyleBackColor = false;
            this.WalkChar.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(772, 380);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(182, 160);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(826, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // dialoguePanel
            // 
            this.dialoguePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dialoguePanel.BackColor = System.Drawing.Color.Transparent;
            this.dialoguePanel.Controls.Add(this.dialogueTextBox);
            this.dialoguePanel.Location = new System.Drawing.Point(243, 380);
            this.dialoguePanel.Name = "dialoguePanel";
            this.dialoguePanel.Size = new System.Drawing.Size(523, 160);
            this.dialoguePanel.TabIndex = 18;
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
            this.statsPanel.Location = new System.Drawing.Point(12, 380);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(225, 160);
            this.statsPanel.TabIndex = 19;
            // 
            // rizzStat
            // 
            this.rizzStat.AutoSize = true;
            this.rizzStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rizzStat.Location = new System.Drawing.Point(69, 57);
            this.rizzStat.Name = "rizzStat";
            this.rizzStat.Size = new System.Drawing.Size(36, 16);
            this.rizzStat.TabIndex = 20;
            this.rizzStat.Text = "Rizz";
            this.rizzStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // atkStat
            // 
            this.atkStat.AutoSize = true;
            this.atkStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.atkStat.Location = new System.Drawing.Point(164, 57);
            this.atkStat.Name = "atkStat";
            this.atkStat.Size = new System.Drawing.Size(29, 16);
            this.atkStat.TabIndex = 21;
            this.atkStat.Text = "Atk";
            this.atkStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // coinStat
            // 
            this.coinStat.AutoSize = true;
            this.coinStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coinStat.Location = new System.Drawing.Point(69, 110);
            this.coinStat.Name = "coinStat";
            this.coinStat.Size = new System.Drawing.Size(38, 16);
            this.coinStat.TabIndex = 22;
            this.coinStat.Text = "Coin";
            this.coinStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // defStat
            // 
            this.defStat.AutoSize = true;
            this.defStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defStat.Location = new System.Drawing.Point(164, 110);
            this.defStat.Name = "defStat";
            this.defStat.Size = new System.Drawing.Size(31, 16);
            this.defStat.TabIndex = 23;
            this.defStat.Text = "Def";
            this.defStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 552);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.dialoguePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.WalkChar);
            this.Controls.Add(this.charactersPictureBox);
            this.Controls.Add(this.playerPictureBox);
            this.Controls.Add(this.dialogue_box);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charactersPictureBox)).EndInit();
            this.dialoguePanel.ResumeLayout(false);
            this.dialoguePanel.PerformLayout();
            this.statsPanel.ResumeLayout(false);
            this.statsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dialogue_box;
        private System.Windows.Forms.PictureBox playerPictureBox;
        private System.Windows.Forms.PictureBox charactersPictureBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox dialogueTextBox;
        private System.Windows.Forms.Button WalkChar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel dialoguePanel;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label defStat;
        private System.Windows.Forms.Label coinStat;
        private System.Windows.Forms.Label atkStat;
        private System.Windows.Forms.Label rizzStat;
    }
}