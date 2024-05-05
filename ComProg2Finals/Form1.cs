using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public partial class Form1 : Form
    {
        Character currentNpc { get; set; }
        Character[] characters;
        string directory;
        public Form1()
        {
            InitializeComponent();

            characters = new Character[2];

            Knight soulknight = new Knight("Soul Knight");
            label1.Text = soulknight.Name;
            currentNpc = soulknight;
            Wizard wizard = new Wizard("GANDALF THE GREY");


            characters[0] = soulknight;
            characters[1] = wizard;

            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directory = programDirectory;

            pictureBox1.Image = Image.FromFile(Path.Combine(programDirectory, "assets", soulknight.Image));



        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentNpc = characters[0];
            label1.Text = currentNpc.Name;
            pictureBox1.Image = Image.FromFile(Path.Combine(directory, "assets", currentNpc.Image));

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentNpc.UseSkill1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentNpc.UseSkill2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentNpc.UseSkill3();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentNpc.UseSkill4();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentNpc = characters[1];
            label1.Text = currentNpc.Name;
            pictureBox1.Image = Image.FromFile(Path.Combine(directory, "assets", currentNpc.Image));
        }
    }
}
