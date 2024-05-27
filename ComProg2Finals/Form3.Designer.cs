namespace ComProg2Finals
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.customButton2 = new ComProg2Finals.CustomButton();
            this.customButton1 = new ComProg2Finals.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::ComProg2Finals.Properties.Resources.titleScreen;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(229, 38);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(805, 540);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // customButton2
            // 
            this.customButton2.BackColor = System.Drawing.Color.Transparent;
            this.customButton2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customButton2.BackgroundImage")));
            this.customButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.customButton2.ButtonBg = ((System.Drawing.Image)(resources.GetObject("customButton2.ButtonBg")));
            this.customButton2.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton2.ButtonText = "EXIT";
            this.customButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton2.Location = new System.Drawing.Point(642, 585);
            this.customButton2.Name = "customButton2";
            this.customButton2.Size = new System.Drawing.Size(199, 58);
            this.customButton2.TabIndex = 3;
            this.customButton2.BtnClick += new System.EventHandler(this.exitBtn_Click);
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.Transparent;
            this.customButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("customButton1.BackgroundImage")));
            this.customButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.customButton1.ButtonBg = ((System.Drawing.Image)(resources.GetObject("customButton1.ButtonBg")));
            this.customButton1.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customButton1.ButtonText = "PLAY";
            this.customButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customButton1.Location = new System.Drawing.Point(422, 585);
            this.customButton1.Name = "customButton1";
            this.customButton1.Size = new System.Drawing.Size(199, 58);
            this.customButton1.TabIndex = 2;
            this.customButton1.BtnClick += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::ComProg2Finals.Properties.Resources.staticBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.customButton2);
            this.Controls.Add(this.customButton1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomButton customButton1;
        private CustomButton customButton2;
    }
}