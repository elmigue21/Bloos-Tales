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
            this.btnText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnText
            // 
            this.btnText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnText.Location = new System.Drawing.Point(0, 0);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(199, 58);
            this.btnText.TabIndex = 0;
            this.btnText.Text = "TEXT";
            this.btnText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnText.Click += new System.EventHandler(this.CustomButton_Click);
            this.btnText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.btnText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // CustomButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::ComProg2Finals.Properties.Resources.Button;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.btnText);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.Name = "CustomButton";
            this.Size = new System.Drawing.Size(199, 58);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label btnText;
    }
}
