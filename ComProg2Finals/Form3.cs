using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public partial class Form3 : Form
    {
        public SoundPlayer musicTitle;
        Form3 Instance;
        public Form3()
        {
            InitializeComponent();
            Instance = this;
            Stream soundStream = Properties.Resources.Title;
            musicTitle = new SoundPlayer(soundStream);
            musicTitle.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Instance.Hide(); 
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
