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
    public partial class Form3 : Form
    {
        Form3 Instance;
        public Form3()
        {
            InitializeComponent();
            Instance = this;
            playBtn.Click += new System.EventHandler(button1_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Instance.Hide();
        }

        

        private void Form3_Load(object sender, EventArgs e)
        {
            FontFamily PressStart2P = Program.initCustomFont();
            playBtn.ButtonFont = new Font(PressStart2P, 14, FontStyle.Regular);
            exitBtn.ButtonFont = new Font(PressStart2P, 14, FontStyle.Regular);
        }

        private void exitBtn_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
