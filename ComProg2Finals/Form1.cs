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

        Character[] turns { get; set; }
        Character currentTurn { get; set; }
        Character Enemy { get; set; }


        public Form1()
        {
            InitializeComponent();


        }


        private void Form1_Load(object sender, EventArgs e)
        {



            Knight soulknight = new Knight("Soul Knight");
            currentNpc = soulknight;


            Bloo bloo = new Bloo("Bloo");
            Player = bloo;

            label1.Text = bloo.Name;
            label2.Text = "Health: " + bloo.Health.ToString();

            label1.ForeColor = Color.White;

            //characters.Add(soulknight);

            label3.Text = soulknight.Name;



            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directory = programDirectory;

            pictureBox1.Image = Image.FromFile(Path.Combine(programDirectory, "assets", soulknight.Image));
            pictureBox2.Image = Image.FromFile(Path.Combine(programDirectory, "assets", bloo.Image));
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;


            /*
            button1.Text = currentNpc.CharSkills[0].Name;
            button2.Text = currentNpc.CharSkills[1].Name;
            button3.Text = currentNpc.CharSkills[2].Name;
            button4.Text = currentNpc.CharSkills[3].Name;
            */


            Enemy = soulknight;

            Enemy.Opposition = Player;
            Player.Opposition = Enemy;

            currentTurn = Enemy;
            //currentTurn = Player;
            runTurn();


        }
        private void runTurn()
        {
            for(int i = 0; i < currentTurn.CharStatEffects.Count; i++)
            {
                currentTurn.CharStatEffects[i].Trigger(currentTurn);
            }




                label1.Text = Player.Name;
                label2.Text = "Health: " + Player.Health.ToString();
                label3.Text = Enemy.Name;
                label4.Text = "Health: " + Enemy.Health.ToString();


                button1.Text = currentTurn.CharSkills[0].Name;
                button2.Text = currentTurn.CharSkills[1].Name;
                button3.Text = currentTurn.CharSkills[2].Name;
                button4.Text = currentTurn.CharSkills[3].Name;         
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            currentTurn.UseSkill1(currentTurn.Opposition);
            currentTurn = currentTurn.Opposition;
            if (Player.Health <= 0)
            {
                MessageBox.Show("Fight has ended");
            }
            else
            {
                runTurn();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            currentTurn.UseSkill2(currentTurn.Opposition);
            currentTurn = currentTurn.Opposition;
            if (Player.Health <= 0)
            {
                MessageBox.Show("Fight has ended");
            }
            else
            {
                runTurn();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentTurn.UseSkill3(currentTurn.Opposition);
            currentTurn = currentTurn.Opposition;
            if (Player.Health <= 0)
            {
                MessageBox.Show("Fight has ended");
            }
            else
            {
                runTurn();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            currentTurn.UseSkill4(currentTurn.Opposition);
            currentTurn = currentTurn.Opposition;
            if (Player.Health <= 0 )
            {
                MessageBox.Show("Fight has ended");
            }
            else
            {
                runTurn();
            }
        }

    }
}
