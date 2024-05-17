namespace parallaxPractice
{
    partial class GameFlow
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.dialogue_box = new System.Windows.Forms.Label();
            this.rizz_btn = new System.Windows.Forms.PictureBox();
            this.fight_btn = new System.Windows.Forms.PictureBox();
            this.characters = new System.Windows.Forms.PictureBox();
            this.scroll_panel = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rizz_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fight_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 3000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // dialogue_box
            // 
            this.dialogue_box.AutoSize = true;
            this.dialogue_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogue_box.Location = new System.Drawing.Point(497, 537);
            this.dialogue_box.Name = "dialogue_box";
            this.dialogue_box.Size = new System.Drawing.Size(28, 42);
            this.dialogue_box.TabIndex = 5;
            this.dialogue_box.Text = " ";
            // 
            // rizz_btn
            // 
            this.rizz_btn.Image = global::parallaxPractice.Properties.Resources.rizz;
            this.rizz_btn.Location = new System.Drawing.Point(848, 481);
            this.rizz_btn.Name = "rizz_btn";
            this.rizz_btn.Size = new System.Drawing.Size(183, 135);
            this.rizz_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rizz_btn.TabIndex = 4;
            this.rizz_btn.TabStop = false;
            this.rizz_btn.Click += new System.EventHandler(this.rizz_btn_Click);
            // 
            // fight_btn
            // 
            this.fight_btn.Image = global::parallaxPractice.Properties.Resources.fight;
            this.fight_btn.Location = new System.Drawing.Point(243, 515);
            this.fight_btn.Name = "fight_btn";
            this.fight_btn.Size = new System.Drawing.Size(181, 70);
            this.fight_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fight_btn.TabIndex = 3;
            this.fight_btn.TabStop = false;
            this.fight_btn.Click += new System.EventHandler(this.fight_btn_Click);
            // 
            // characters
            // 
            this.characters.Location = new System.Drawing.Point(890, 150);
            this.characters.Name = "characters";
            this.characters.Size = new System.Drawing.Size(196, 178);
            this.characters.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.characters.TabIndex = 2;
            this.characters.TabStop = false;
            // 
            // scroll_panel
            // 
            this.scroll_panel.Image = global::parallaxPractice.Properties.Resources.scroll;
            this.scroll_panel.Location = new System.Drawing.Point(444, 471);
            this.scroll_panel.Name = "scroll_panel";
            this.scroll_panel.Size = new System.Drawing.Size(380, 160);
            this.scroll_panel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.scroll_panel.TabIndex = 1;
            this.scroll_panel.TabStop = false;
            this.scroll_panel.Click += new System.EventHandler(this.scroll_panel_Click);
            // 
            // player
            // 
            this.player.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.Image = global::parallaxPractice.Properties.Resources.blooIdle;
            this.player.Location = new System.Drawing.Point(221, 179);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(150, 150);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.dialogue_box);
            this.Controls.Add(this.rizz_btn);
            this.Controls.Add(this.fight_btn);
            this.Controls.Add(this.characters);
            this.Controls.Add(this.scroll_panel);
            this.Controls.Add(this.player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.rizz_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fight_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scroll_panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox scroll_panel;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox characters;
        private System.Windows.Forms.PictureBox fight_btn;
        private System.Windows.Forms.PictureBox rizz_btn;
        private System.Windows.Forms.Label dialogue_box;
    }
}

