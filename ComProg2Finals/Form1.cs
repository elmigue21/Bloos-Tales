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
        Bloo Player;
        Character currentNpc { get; set; }
        List<Character> characters;
        string directory;
        public Form1()
        {
            InitializeComponent();

            characters = new List<Character>();

            Knight soulknight = new Knight("Soul Knight");
            currentNpc = soulknight;
            Wizard wizard = new Wizard("GANDALF THE GREY");

            Priest priest = new Priest("RAFAELLA");
            Rogue rogue = new Rogue("miROGUEl");
            Archer archer = new Archer("legolas");



            Bloo bloo = new Bloo("Bloo");
            Player = bloo;

            label1.Text = bloo.Name;
            label2.Text = "Health: " + bloo.Health.ToString();

            label1.ForeColor = Color.White;

            characters.Add(soulknight);
            characters.Add(wizard);
            characters.Add(priest);
            characters.Add(rogue);
            characters.Add(archer);



            /*
            characters[0] = soulknight;
            characters[1] = wizard;
            characters[2] = priest;
            characters[3] = rogue;
            characters[4] = archer;
            */



            label3.Text = soulknight.Name;



            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directory = programDirectory;

            pictureBox1.Image = Image.FromFile(Path.Combine(programDirectory, "assets", soulknight.Image));
            pictureBox2.Image = Image.FromFile(Path.Combine(programDirectory, "assets", bloo.Image));
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;


            
            button1.Text = currentNpc.CharSkills[0].Name;
            button2.Text = currentNpc.CharSkills[1].Name;
            button3.Text = currentNpc.CharSkills[2].Name;
            button4.Text = currentNpc.CharSkills[3].Name;



        }
        private void updateLabels()
        {
            label3.Text = currentNpc.Name;
            pictureBox1.Image = Image.FromFile(Path.Combine(directory, "assets", currentNpc.Image));

            button1.Text = currentNpc.CharSkills[0].Name;
            button2.Text = currentNpc.CharSkills[1].Name;
            button3.Text = currentNpc.CharSkills[2].Name;
            button4.Text = currentNpc.CharSkills[3].Name;

            label2.Text = "Health: " + Player.Health.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currentNpc = characters[0];
            updateLabels();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            currentNpc.UseSkill1(Player);
            label2.Text = "Health: " + Player.Health.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            currentNpc.UseSkill2(Player);
            label2.Text = "Health: " + Player.Health.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentNpc.UseSkill3(Player);
            label2.Text = "Health: " + Player.Health.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentNpc.UseSkill4(Player);
            label2.Text = "Health: " + Player.Health.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            currentNpc = characters[1];
            updateLabels();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for(int i =0; i < Player.CharStatEffects.Count; i++)
            {
                Player.CharStatEffects[i].Trigger(Player);
            }
            updateLabels();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            currentNpc = characters[2]; updateLabels();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            currentNpc = characters[3]; updateLabels();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            currentNpc = characters[4]; updateLabels();
        }
    }
}
