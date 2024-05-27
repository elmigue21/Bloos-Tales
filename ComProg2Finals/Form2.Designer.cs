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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.WalkChar = new System.Windows.Forms.Button();
            this.flowPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPanelItems = new System.Windows.Forms.FlowLayoutPanel();
            this.playerPictureBox = new System.Windows.Forms.PictureBox();
            this.pauseBtn = new System.Windows.Forms.PictureBox();
            this.audioBtn = new System.Windows.Forms.PictureBox();
            this.levelsBar = new System.Windows.Forms.Panel();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.flowPanelLife = new System.Windows.Forms.FlowLayoutPanel();
            this.defStat = new System.Windows.Forms.Label();
            this.coinStat = new System.Windows.Forms.Label();
            this.atkStat = new System.Windows.Forms.Label();
            this.rizzStat = new System.Windows.Forms.Label();
            this.dialoguePanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dialogueTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioBtn)).BeginInit();
            this.statsPanel.SuspendLayout();
            this.dialoguePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WalkChar
            // 
            this.WalkChar.BackColor = System.Drawing.Color.Transparent;
            this.WalkChar.Location = new System.Drawing.Point(1162, 77);
            this.WalkChar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WalkChar.Name = "WalkChar";
            this.WalkChar.Size = new System.Drawing.Size(75, 23);
            this.WalkChar.TabIndex = 15;
            this.WalkChar.Text = "Next";
            this.WalkChar.UseVisualStyleBackColor = false;
            this.WalkChar.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowPanelButtons
            // 
            this.flowPanelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowPanelButtons.AutoSize = true;
            this.flowPanelButtons.BackColor = System.Drawing.Color.Transparent;
            this.flowPanelButtons.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelButtons.Location = new System.Drawing.Point(1021, 420);
            this.flowPanelButtons.Margin = new System.Windows.Forms.Padding(4);
            this.flowPanelButtons.Name = "flowPanelButtons";
            this.flowPanelButtons.Size = new System.Drawing.Size(220, 245);
            this.flowPanelButtons.TabIndex = 16;
            // 
            // flowPanelItems
            // 
            this.flowPanelItems.BackColor = System.Drawing.Color.Transparent;
            this.flowPanelItems.Location = new System.Drawing.Point(13, 68);
            this.flowPanelItems.Name = "flowPanelItems";
            this.flowPanelItems.Size = new System.Drawing.Size(421, 152);
            this.flowPanelItems.TabIndex = 23;
            // 
            // playerPictureBox
            // 
            this.playerPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.playerPictureBox.Image = global::ComProg2Finals.Properties.Resources.bloo_idle;
            this.playerPictureBox.Location = new System.Drawing.Point(230, 127);
            this.playerPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.playerPictureBox.Name = "playerPictureBox";
            this.playerPictureBox.Size = new System.Drawing.Size(192, 192);
            this.playerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerPictureBox.TabIndex = 7;
            this.playerPictureBox.TabStop = false;
            // 
            // pauseBtn
            // 
            this.pauseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pauseBtn.BackColor = System.Drawing.Color.Transparent;
            this.pauseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pauseBtn.Image = ((System.Drawing.Image)(resources.GetObject("pauseBtn.Image")));
            this.pauseBtn.Location = new System.Drawing.Point(89, 602);
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(64, 63);
            this.pauseBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pauseBtn.TabIndex = 22;
            this.pauseBtn.TabStop = false;
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // audioBtn
            // 
            this.audioBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.audioBtn.BackColor = System.Drawing.Color.Transparent;
            this.audioBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.audioBtn.Image = ((System.Drawing.Image)(resources.GetObject("audioBtn.Image")));
            this.audioBtn.Location = new System.Drawing.Point(19, 602);
            this.audioBtn.Name = "audioBtn";
            this.audioBtn.Size = new System.Drawing.Size(64, 63);
            this.audioBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.audioBtn.TabIndex = 21;
            this.audioBtn.TabStop = false;
            this.audioBtn.Click += new System.EventHandler(this.audioBtn_Click);
            // 
            // levelsBar
            // 
            this.levelsBar.BackColor = System.Drawing.Color.Transparent;
            this.levelsBar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("levelsBar.BackgroundImage")));
            this.levelsBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.levelsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.levelsBar.Location = new System.Drawing.Point(0, 0);
            this.levelsBar.Margin = new System.Windows.Forms.Padding(4);
            this.levelsBar.Name = "levelsBar";
            this.levelsBar.Size = new System.Drawing.Size(1262, 60);
            this.levelsBar.TabIndex = 20;
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.Transparent;
            this.statsPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statsPanel.BackgroundImage")));
            this.statsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.statsPanel.Controls.Add(this.flowPanelLife);
            this.statsPanel.Controls.Add(this.defStat);
            this.statsPanel.Controls.Add(this.coinStat);
            this.statsPanel.Controls.Add(this.atkStat);
            this.statsPanel.Controls.Add(this.rizzStat);
            this.statsPanel.Location = new System.Drawing.Point(19, 420);
            this.statsPanel.Margin = new System.Windows.Forms.Padding(4);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(226, 167);
            this.statsPanel.TabIndex = 19;
            // 
            // flowPanelLife
            // 
            this.flowPanelLife.Location = new System.Drawing.Point(12, 11);
            this.flowPanelLife.Name = "flowPanelLife";
            this.flowPanelLife.Size = new System.Drawing.Size(200, 38);
            this.flowPanelLife.TabIndex = 24;
            this.flowPanelLife.WrapContents = false;
            // 
            // defStat
            // 
            this.defStat.AutoSize = true;
            this.defStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defStat.Location = new System.Drawing.Point(156, 103);
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
            this.coinStat.Location = new System.Drawing.Point(60, 103);
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
            this.atkStat.Location = new System.Drawing.Point(156, 58);
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
            this.rizzStat.Location = new System.Drawing.Point(60, 58);
            this.rizzStat.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rizzStat.Name = "rizzStat";
            this.rizzStat.Size = new System.Drawing.Size(47, 20);
            this.rizzStat.TabIndex = 20;
            this.rizzStat.Text = "Rizz";
            this.rizzStat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dialoguePanel
            // 
            this.dialoguePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dialoguePanel.BackColor = System.Drawing.Color.Transparent;
            this.dialoguePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("dialoguePanel.BackgroundImage")));
            this.dialoguePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dialoguePanel.Controls.Add(this.label1);
            this.dialoguePanel.Controls.Add(this.dialogueTextBox);
            this.dialoguePanel.Location = new System.Drawing.Point(253, 404);
            this.dialoguePanel.Margin = new System.Windows.Forms.Padding(4);
            this.dialoguePanel.Name = "dialoguePanel";
            this.dialoguePanel.Size = new System.Drawing.Size(757, 261);
            this.dialoguePanel.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // dialogueTextBox
            // 
            this.dialogueTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(138)))));
            this.dialogueTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dialogueTextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dialogueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueTextBox.Location = new System.Drawing.Point(78, 74);
            this.dialogueTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dialogueTextBox.Multiline = true;
            this.dialogueTextBox.Name = "dialogueTextBox";
            this.dialogueTextBox.ReadOnly = true;
            this.dialogueTextBox.Size = new System.Drawing.Size(599, 129);
            this.dialogueTextBox.TabIndex = 14;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.playerPictureBox);
            this.Controls.Add(this.flowPanelItems);
            this.Controls.Add(this.pauseBtn);
            this.Controls.Add(this.audioBtn);
            this.Controls.Add(this.levelsBar);
            this.Controls.Add(this.statsPanel);
            this.Controls.Add(this.dialoguePanel);
            this.Controls.Add(this.flowPanelButtons);
            this.Controls.Add(this.WalkChar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pauseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioBtn)).EndInit();
            this.statsPanel.ResumeLayout(false);
            this.statsPanel.PerformLayout();
            this.dialoguePanel.ResumeLayout(false);
            this.dialoguePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox playerPictureBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        public TextBox dialogueTextBox;
        private System.Windows.Forms.Button WalkChar;
        private System.Windows.Forms.FlowLayoutPanel flowPanelButtons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel dialoguePanel;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label defStat;
        private System.Windows.Forms.Label coinStat;
        private System.Windows.Forms.Label atkStat;
        private System.Windows.Forms.Label rizzStat;
        private System.Windows.Forms.Panel levelsBar;
        private PictureBox audioBtn;
        private PictureBox pauseBtn;
        private FlowLayoutPanel flowPanelLife;
        private FlowLayoutPanel flowPanelItems;
        //private System.Windows.Forms.TextBox dialogueTextBox;
    }
}