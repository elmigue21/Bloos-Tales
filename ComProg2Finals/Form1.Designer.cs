namespace ComProg2Finals
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.playerLabelName = new System.Windows.Forms.Label();
            this.playerLabelHealth = new System.Windows.Forms.Label();
            this.enemyLabelName = new System.Windows.Forms.Label();
            this.enemyLabelHealth = new System.Windows.Forms.Label();
            this.playerLabelAttackDamage = new System.Windows.Forms.Label();
            this.playerLabelDefense = new System.Windows.Forms.Label();
            this.enemyLabelDefense = new System.Windows.Forms.Label();
            this.enemyLabelAttackDamage = new System.Windows.Forms.Label();
            this.enemyPictureBox = new System.Windows.Forms.PictureBox();
            this.playerPictureBox = new System.Windows.Forms.PictureBox();
            this.playerStatsPanel = new System.Windows.Forms.Panel();
            this.enemyStatsPanel = new System.Windows.Forms.Panel();
            this.dialogueTextBox = new System.Windows.Forms.TextBox();
            this.dialoguePanel = new System.Windows.Forms.Panel();
            this.button3 = new ComProg2Finals.CustomButton();
            this.button4 = new ComProg2Finals.CustomButton();
            this.runButton = new ComProg2Finals.CustomButton();
            this.button2 = new ComProg2Finals.CustomButton();
            this.button1 = new ComProg2Finals.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.enemyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).BeginInit();
            this.playerStatsPanel.SuspendLayout();
            this.enemyStatsPanel.SuspendLayout();
            this.dialoguePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerLabelName
            // 
            this.playerLabelName.AutoSize = true;
            this.playerLabelName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerLabelName.Location = new System.Drawing.Point(93, 19);
            this.playerLabelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerLabelName.Name = "playerLabelName";
            this.playerLabelName.Size = new System.Drawing.Size(105, 16);
            this.playerLabelName.TabIndex = 5;
            this.playerLabelName.Text = "Character Name";
            // 
            // playerLabelHealth
            // 
            this.playerLabelHealth.AutoSize = true;
            this.playerLabelHealth.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerLabelHealth.Location = new System.Drawing.Point(36, 70);
            this.playerLabelHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerLabelHealth.Name = "playerLabelHealth";
            this.playerLabelHealth.Size = new System.Drawing.Size(107, 16);
            this.playerLabelHealth.TabIndex = 9;
            this.playerLabelHealth.Text = "Character Health";
            // 
            // enemyLabelName
            // 
            this.enemyLabelName.AutoSize = true;
            this.enemyLabelName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enemyLabelName.Location = new System.Drawing.Point(105, 19);
            this.enemyLabelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enemyLabelName.Name = "enemyLabelName";
            this.enemyLabelName.Size = new System.Drawing.Size(105, 16);
            this.enemyLabelName.TabIndex = 10;
            this.enemyLabelName.Text = "Character Name";
            // 
            // enemyLabelHealth
            // 
            this.enemyLabelHealth.AutoSize = true;
            this.enemyLabelHealth.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enemyLabelHealth.Location = new System.Drawing.Point(27, 69);
            this.enemyLabelHealth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enemyLabelHealth.Name = "enemyLabelHealth";
            this.enemyLabelHealth.Size = new System.Drawing.Size(107, 16);
            this.enemyLabelHealth.TabIndex = 11;
            this.enemyLabelHealth.Text = "Character Health";
            // 
            // playerLabelAttackDamage
            // 
            this.playerLabelAttackDamage.AutoSize = true;
            this.playerLabelAttackDamage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerLabelAttackDamage.Location = new System.Drawing.Point(33, 114);
            this.playerLabelAttackDamage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerLabelAttackDamage.Name = "playerLabelAttackDamage";
            this.playerLabelAttackDamage.Size = new System.Drawing.Size(161, 16);
            this.playerLabelAttackDamage.TabIndex = 13;
            this.playerLabelAttackDamage.Text = "Character Attack Damage";
            // 
            // playerLabelDefense
            // 
            this.playerLabelDefense.AutoSize = true;
            this.playerLabelDefense.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerLabelDefense.Location = new System.Drawing.Point(33, 156);
            this.playerLabelDefense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerLabelDefense.Name = "playerLabelDefense";
            this.playerLabelDefense.Size = new System.Drawing.Size(116, 16);
            this.playerLabelDefense.TabIndex = 16;
            this.playerLabelDefense.Text = "CharacterDefense";
            // 
            // enemyLabelDefense
            // 
            this.enemyLabelDefense.AutoSize = true;
            this.enemyLabelDefense.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enemyLabelDefense.Location = new System.Drawing.Point(27, 159);
            this.enemyLabelDefense.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enemyLabelDefense.Name = "enemyLabelDefense";
            this.enemyLabelDefense.Size = new System.Drawing.Size(116, 16);
            this.enemyLabelDefense.TabIndex = 21;
            this.enemyLabelDefense.Text = "CharacterDefense";
            // 
            // enemyLabelAttackDamage
            // 
            this.enemyLabelAttackDamage.AutoSize = true;
            this.enemyLabelAttackDamage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enemyLabelAttackDamage.Location = new System.Drawing.Point(27, 113);
            this.enemyLabelAttackDamage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enemyLabelAttackDamage.Name = "enemyLabelAttackDamage";
            this.enemyLabelAttackDamage.Size = new System.Drawing.Size(161, 16);
            this.enemyLabelAttackDamage.TabIndex = 18;
            this.enemyLabelAttackDamage.Text = "Character Attack Damage";
            // 
            // enemyPictureBox
            // 
            this.enemyPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.enemyPictureBox.Location = new System.Drawing.Point(1074, 199);
            this.enemyPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.enemyPictureBox.Name = "enemyPictureBox";
            this.enemyPictureBox.Size = new System.Drawing.Size(133, 119);
            this.enemyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.enemyPictureBox.TabIndex = 6;
            this.enemyPictureBox.TabStop = false;
            // 
            // playerPictureBox
            // 
            this.playerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.playerPictureBox.Location = new System.Drawing.Point(74, 199);
            this.playerPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.playerPictureBox.Name = "playerPictureBox";
            this.playerPictureBox.Size = new System.Drawing.Size(133, 119);
            this.playerPictureBox.TabIndex = 8;
            this.playerPictureBox.TabStop = false;
            // 
            // playerStatsPanel
            // 
            this.playerStatsPanel.BackColor = System.Drawing.Color.Transparent;
            this.playerStatsPanel.BackgroundImage = global::ComProg2Finals.Properties.Resources.BlankStatsPanel;
            this.playerStatsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playerStatsPanel.Controls.Add(this.playerLabelName);
            this.playerStatsPanel.Controls.Add(this.playerLabelHealth);
            this.playerStatsPanel.Controls.Add(this.playerLabelAttackDamage);
            this.playerStatsPanel.Controls.Add(this.playerLabelDefense);
            this.playerStatsPanel.Location = new System.Drawing.Point(13, 429);
            this.playerStatsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.playerStatsPanel.Name = "playerStatsPanel";
            this.playerStatsPanel.Size = new System.Drawing.Size(300, 197);
            this.playerStatsPanel.TabIndex = 23;
            // 
            // enemyStatsPanel
            // 
            this.enemyStatsPanel.BackColor = System.Drawing.Color.Transparent;
            this.enemyStatsPanel.BackgroundImage = global::ComProg2Finals.Properties.Resources.BlankStatsPanel;
            this.enemyStatsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enemyStatsPanel.Controls.Add(this.enemyLabelName);
            this.enemyStatsPanel.Controls.Add(this.enemyLabelHealth);
            this.enemyStatsPanel.Controls.Add(this.enemyLabelAttackDamage);
            this.enemyStatsPanel.Controls.Add(this.enemyLabelDefense);
            this.enemyStatsPanel.Location = new System.Drawing.Point(938, 429);
            this.enemyStatsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.enemyStatsPanel.Name = "enemyStatsPanel";
            this.enemyStatsPanel.Size = new System.Drawing.Size(300, 197);
            this.enemyStatsPanel.TabIndex = 24;
            // 
            // dialogueTextBox
            // 
            this.dialogueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(138)))));
            this.dialogueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.dialogueTextBox.Location = new System.Drawing.Point(61, 45);
            this.dialogueTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.dialogueTextBox.Multiline = true;
            this.dialogueTextBox.Name = "dialogueTextBox";
            this.dialogueTextBox.Size = new System.Drawing.Size(492, 135);
            this.dialogueTextBox.TabIndex = 25;
            // 
            // dialoguePanel
            // 
            this.dialoguePanel.BackColor = System.Drawing.Color.Transparent;
            this.dialoguePanel.BackgroundImage = global::ComProg2Finals.Properties.Resources.scroll;
            this.dialoguePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.dialoguePanel.Controls.Add(this.dialogueTextBox);
            this.dialoguePanel.Location = new System.Drawing.Point(312, 416);
            this.dialoguePanel.Name = "dialoguePanel";
            this.dialoguePanel.Size = new System.Drawing.Size(619, 227);
            this.dialoguePanel.TabIndex = 30;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.ButtonBg = ((System.Drawing.Image)(resources.GetObject("button3.ButtonBg")));
            this.button3.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ButtonText = "TEXT";
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Location = new System.Drawing.Point(428, 501);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(199, 58);
            this.button3.TabIndex = 29;
            this.button3.BtnClick += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button4.ButtonBg = ((System.Drawing.Image)(resources.GetObject("button4.ButtonBg")));
            this.button4.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ButtonText = "TEXT";
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.Location = new System.Drawing.Point(634, 501);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(199, 58);
            this.button4.TabIndex = 29;
            this.button4.BtnClick += new System.EventHandler(this.button4_Click);
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.Transparent;
            this.runButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("runButton.BackgroundImage")));
            this.runButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.runButton.ButtonBg = ((System.Drawing.Image)(resources.GetObject("runButton.ButtonBg")));
            this.runButton.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runButton.ButtonText = "RUN";
            this.runButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.runButton.Location = new System.Drawing.Point(532, 565);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(199, 58);
            this.runButton.TabIndex = 28;
            this.runButton.BtnClick += new System.EventHandler(this.playerRunBtn);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.ButtonBg = ((System.Drawing.Image)(resources.GetObject("button2.ButtonBg")));
            this.button2.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ButtonText = "TEXT";
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(634, 437);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 58);
            this.button2.TabIndex = 27;
            this.button2.BtnClick += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.ButtonBg = ((System.Drawing.Image)(resources.GetObject("button1.ButtonBg")));
            this.button1.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ButtonText = "TEXT";
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(428, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 58);
            this.button1.TabIndex = 26;
            this.button1.BtnClick += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::ComProg2Finals.Properties.Resources.staticBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.dialoguePanel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playerPictureBox);
            this.Controls.Add(this.enemyPictureBox);
            this.Controls.Add(this.enemyStatsPanel);
            this.Controls.Add(this.playerStatsPanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.enemyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).EndInit();
            this.playerStatsPanel.ResumeLayout(false);
            this.playerStatsPanel.PerformLayout();
            this.enemyStatsPanel.ResumeLayout(false);
            this.enemyStatsPanel.PerformLayout();
            this.dialoguePanel.ResumeLayout(false);
            this.dialoguePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label playerLabelName;
        private System.Windows.Forms.Label playerLabelHealth;
        private System.Windows.Forms.Label enemyLabelName;
        private System.Windows.Forms.Label enemyLabelHealth;
        private System.Windows.Forms.Label playerLabelAttackDamage;
        private System.Windows.Forms.Label playerLabelDefense;
        private System.Windows.Forms.Label enemyLabelDefense;
        private System.Windows.Forms.Label enemyLabelAttackDamage;
        public System.Windows.Forms.TextBox dialogueTextBox;
        private System.Windows.Forms.Panel enemyStatsPanel;
        private System.Windows.Forms.Panel playerStatsPanel;
        private System.Windows.Forms.PictureBox playerPictureBox;
        private System.Windows.Forms.PictureBox enemyPictureBox;
        private CustomButton button1;
        private CustomButton button2;
        private CustomButton runButton;
        private CustomButton button4;
        private CustomButton button3;
        public System.Windows.Forms.Panel dialoguePanel;
    }
}

