﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
        string directory;

        public List<Character> turnOrder;
        private int currentTurnIndex;

        Character Enemy { get; set; }
        Character opps;
        Character currentTurnCharacter;

        Button[] skillButtons = new Button[4];

        public Form1()
        {
            InitializeComponent();
            // pag lagay sa array ng buttons para pwede sya iloop
            skillButtons[0] = button1;
            skillButtons[1] = button2;
            skillButtons[2] = button3;
            skillButtons[3] = button4;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // turns logic
            turnOrder = new List<Character>();
            currentTurnIndex = 0;

            // pag call kay bloo/player from the characters class
            Bloo bloo = new Bloo("Bloo");
            Player = bloo;
            playerLabelName.Text = bloo.Name;
            playerLabelHealth.Text = "Health: " + bloo.Health.ToString();
            playerLabelName.ForeColor = Color.White;

            // pag call ng enemy from characters class
            Knight soulknight = new Knight("Soul Knight");
            enemyLabelName.Text = soulknight.Name;
            Enemy = soulknight;

            // pag set ng image ng picturebox
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directory = programDirectory;
            pictureBox1.Image = Image.FromFile(Path.Combine(programDirectory, "assets", soulknight.Image));
            pictureBox2.Image = Image.FromFile(Path.Combine(programDirectory, "assets", bloo.Image));
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            updateLabels();
            runTurn();

        }
        private void runTurn()
        {
            // pag add ng enemy and player sa turn order
            turnOrder.Add(Player);
            turnOrder.Add(Enemy);
            currentTurnCharacter = turnOrder[currentTurnIndex];

            // pag trigger ng status effects sa character
            for (int i = 0; i < currentTurnCharacter.CharStatEffects.Count; i++)
            {
                currentTurnCharacter.CharStatEffects[i].Trigger(turnOrder[(currentTurnIndex) % turnOrder.Count]);
            }

            // pag set ng buttons text according sa skills ng current turn na character
            for(int i = 0; i < 4; i++)
            {
                if (i >= currentTurnCharacter.CharSkills.Length)
                {
                    skillButtons[i].Text = "";
                }
                else
                {
                    skillButtons[i].Text = currentTurnCharacter.CharSkills[i].Name;
                }
            }

            currentTurnIndex = (currentTurnIndex + 1) % turnOrder.Count;
            opps = turnOrder[(currentTurnIndex) % turnOrder.Count];
        }
        // buttons para sa skills
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentTurnCharacter.CharSkills.Length >= 1)
            {
                currentTurnCharacter.UseSkill1(opps);
                updateLabels();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentTurnCharacter.CharSkills.Length >= 2)
            {
                currentTurnCharacter.UseSkill2(opps);
                updateLabels();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentTurnCharacter.CharSkills.Length >= 3)
            {
                currentTurnCharacter.UseSkill3(opps);
                updateLabels();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentTurnCharacter.CharSkills.Length >= 4)
            {
                currentTurnCharacter.UseSkill4(opps);
                updateLabels();
            }
        }
        /////////


        // for updating ng labels ng player and character | and checking narin ng win/lose
        public void updateLabels()
        {
            playerLabelName.Text = Player.Name;
            playerLabelHealth.Text = "Health:"+Player.Health.ToString();
            playerLabelAccuracy.Text = "Accuracy:" + Player.Accuracy.ToString();
            playerLabelAttackDamage.Text = "Attack Damage:" + Player.AttackDamage.ToString();
            playerLabelSpeed.Text = "Speed:" + Player.Speed.ToString();
            playerLabelRizz.Text = "Rizz:" + Player.Rizz.ToString();
            playerLabelDefense.Text = "Defense:" + Player.Defense.ToString();
            playerLabelLives.Text = "Lives:" + Player.Lives.ToString();
            playerLabelCoins.Text = "Coins:" + Player.Coins.ToString();

            enemyLabelName.Text = Enemy.Name;
            enemyLabelHealth.Text = "Health:" + Enemy.Health.ToString();
            enemyLabelAccuracy.Text = "Accuracy:" + Enemy.Accuracy.ToString();
            enemyLabelAttackDamage.Text = "Attack Damage:" + Enemy.AttackDamage.ToString();
            enemyLabelSpeed.Text = "Speed:" + Enemy.Speed.ToString();
            enemyLabelRizz.Text = "Rizz:" + Enemy.Rizz.ToString();
            enemyLabelDefense.Text = "Defense:" + Enemy.Defense.ToString();


            if (Player.Health <= 0)
            {
                MessageBox.Show("Bloo has lost!");
                this.Close();
            }
            else if (Enemy.Health <= 0)
            {
                MessageBox.Show("Bloo has won!");
                this.Close();
            }
            else
            {
                runTurn();
            }




        }

        private void testButton_Click(object sender, EventArgs e)
        {
            SwordInStone excalibur = new SwordInStone();
            excalibur.Perform(Player);
            updateLabels();
        }
    }
}