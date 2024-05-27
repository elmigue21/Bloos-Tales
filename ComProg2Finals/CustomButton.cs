using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        /*
        
        HOW TO USE:
         
        CustomButton btn = new CustomButton();

        btn.ButtonText = "Change the text inside the button";
        btn.ButtonBg = "Change the bg image of the button";
        btn.ButtonFont = new Font(FontFamily. Size, FontStyle);

        To set click event handler, look for 'BtnClick' in properties
        under misc category. Use this instead of 'Click'

        */


        //===== Custom event handler , USE FOR CLICK EVENTS =====
        public event EventHandler BtnClick;

        protected virtual void OnBtnClick(EventArgs e)
        {
            BtnClick?.Invoke(this, e);
        }

        private void CustomButton_Click(object sender, EventArgs e)
        {
            OnBtnClick(EventArgs.Empty);
        }
        

        //============== SET CUSTOM PROPERTIES ===========
        public string ButtonText
        {
            get { return btnText.Text; }
            set { 
                btnText.Text = value;
                btnText.TextAlign = ContentAlignment.MiddleCenter;
                btnText.AutoSize = false;
            }
        }

        public Image ButtonBg
        {
            get { return this.BackgroundImage; }
            set { this.BackgroundImage = value; }
        }

        public Font ButtonFont
        {
            get { return btnText.Font; }
            set { btnText.Font = value; }
        }

        //=============== BUTTON STATES ================
        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Properties.Resources.ButtonClicked;
        }
        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Button;
        }


    }
}
