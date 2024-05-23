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
            this.rizz_btn = new System.Windows.Forms.PictureBox();
            this.fight_btn = new System.Windows.Forms.PictureBox();
            this.charactersPictureBox = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dialogueTextBox = new System.Windows.Forms.TextBox();
            this.WalkChar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rizz_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fight_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.charactersPictureBox)).BeginInit();
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
            this.playerPictureBox.Location = new System.Drawing.Point(112, 75);
            this.playerPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.playerPictureBox.Name = "playerPictureBox";
            this.playerPictureBox.Size = new System.Drawing.Size(150, 150);
            this.playerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerPictureBox.TabIndex = 7;
            this.playerPictureBox.TabStop = false;
            this.playerPictureBox.Click += new System.EventHandler(this.player_Click);
            // 
            // rizz_btn
            // 
            this.rizz_btn.Location = new System.Drawing.Point(303, 136);
            this.rizz_btn.Margin = new System.Windows.Forms.Padding(2);
            this.rizz_btn.Name = "rizz_btn";
            this.rizz_btn.Size = new System.Drawing.Size(137, 110);
            this.rizz_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rizz_btn.TabIndex = 11;
            this.rizz_btn.TabStop = false;
            // 
            // fight_btn
            // 
            this.fight_btn.Location = new System.Drawing.Point(-16, 284);
            this.fight_btn.Margin = new System.Windows.Forms.Padding(2);
            this.fight_btn.Name = "fight_btn";
            this.fight_btn.Size = new System.Drawing.Size(136, 57);
            this.fight_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fight_btn.TabIndex = 10;
            this.fight_btn.TabStop = false;
            // 
            // charactersPictureBox
            // 
            this.charactersPictureBox.Location = new System.Drawing.Point(515, 101);
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
            this.dialogueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogueTextBox.Location = new System.Drawing.Point(139, 319);
            this.dialogueTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.dialogueTextBox.Multiline = true;
            this.dialogueTextBox.Name = "dialogueTextBox";
            this.dialogueTextBox.ReadOnly = true;
            this.dialogueTextBox.Size = new System.Drawing.Size(486, 103);
            this.dialogueTextBox.TabIndex = 14;
            // 
            // WalkChar
            // 
            this.WalkChar.Location = new System.Drawing.Point(569, 426);
            this.WalkChar.Margin = new System.Windows.Forms.Padding(2);
            this.WalkChar.Name = "WalkChar";
            this.WalkChar.Size = new System.Drawing.Size(56, 19);
            this.WalkChar.TabIndex = 15;
            this.WalkChar.Text = "Next";
            this.WalkChar.UseVisualStyleBackColor = true;
            this.WalkChar.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(656, 296);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(108, 160);
            this.flowLayoutPanel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(569, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "label1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 456);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.WalkChar);
            this.Controls.Add(this.dialogueTextBox);
            this.Controls.Add(this.rizz_btn);
            this.Controls.Add(this.fight_btn);
            this.Controls.Add(this.charactersPictureBox);
            this.Controls.Add(this.playerPictureBox);
            this.Controls.Add(this.dialogue_box);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rizz_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fight_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.charactersPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dialogue_box;
        private System.Windows.Forms.PictureBox playerPictureBox;
        private System.Windows.Forms.PictureBox rizz_btn;
        private System.Windows.Forms.PictureBox fight_btn;
        private System.Windows.Forms.PictureBox charactersPictureBox;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox dialogueTextBox;
        private System.Windows.Forms.Button WalkChar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
    }
}