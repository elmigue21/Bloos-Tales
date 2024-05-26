using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public partial class CustomButton : UserControl
    {
        public CustomButton()
        {
            InitializeComponent();
        }

        //Custom event handler , USE FOR CLICK EVENTS
        public event EventHandler BtnClick;

        protected virtual void OnBtnClick(EventArgs e)
        {
            BtnClick?.Invoke(this, e);
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            OnBtnClick(EventArgs.Empty);
        }
        //---------------------
        public string ButtonText
        {
            get { return actionBtn_Text.Text; }
            set { actionBtn_Text.Text = value;
                actionBtn_Text.TextAlign = ContentAlignment.MiddleCenter;
                actionBtn_Text.AutoSize = false;
            }
        }

        public Font ButtonFont
        {
            get { return actionBtn_Text.Font; }
            set { actionBtn_Text.Font = value; }
        }

        public Image BgImage
        {
            get { return this.BackgroundImage; }
            set { this.BackgroundImage = value; }
        }

        public Color TextBgColor
        {
            get { return actionBtn_Text.BackColor; }
            set { actionBtn_Text.BackColor = value; }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Control s = (Control)sender;
            if(s is UserControl)
            {
                foreach (Control control in s.Controls)
                {
                    if (control is Label)
                    {
                        Label btnLbl = (Label)control;
                        btnLbl.BackColor = Color.FromArgb(225, 154, 0);
                    }

                }
            }

            if(s is Label)
            {
                Label btnLbl = (Label)s;
                btnLbl.BackColor = Color.FromArgb(225, 154, 0);
            }
            this.BackgroundImage = Properties.Resources.ButtonClicked;
        }
        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Control s = (Control)sender;

            if (s is UserControl)
            {
                foreach (Control control in s.Controls)
                {
                    if (control is Label)
                    {
                        Label btnLbl = (Label)control;
                        btnLbl.BackColor = Color.FromArgb(255, 192, 0);
                    }

                }
            }
            if (s is Label)
            {
                Label btnLbl = (Label)s;
                btnLbl.BackColor = Color.FromArgb(255, 192, 0);
            }

            this.BackgroundImage = Properties.Resources.Button;
        }

        
    }
}
