namespace ComProg2Finals
{
    partial class CustomButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.actionBtn_Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // actionBtn_Text
            // 
            this.actionBtn_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionBtn_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.actionBtn_Text.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actionBtn_Text.Location = new System.Drawing.Point(12, 12);
            this.actionBtn_Text.MaximumSize = new System.Drawing.Size(177, 30);
            this.actionBtn_Text.MinimumSize = new System.Drawing.Size(177, 30);
            this.actionBtn_Text.Name = "actionBtn_Text";
            this.actionBtn_Text.Size = new System.Drawing.Size(177, 30);
            this.actionBtn_Text.TabIndex = 13;
            this.actionBtn_Text.Text = "button";
            this.actionBtn_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.actionBtn_Text.Click += new System.EventHandler(this.CustomButton_Click);
            this.actionBtn_Text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.actionBtn_Text.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // CustomButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::ComProg2Finals.Properties.Resources.Button;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.actionBtn_Text);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(200, 55);
            this.MinimumSize = new System.Drawing.Size(200, 55);
            this.Name = "CustomButton";
            this.Size = new System.Drawing.Size(200, 55);
            this.Click += new System.EventHandler(this.CustomButton_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label actionBtn_Text;
    }
}
