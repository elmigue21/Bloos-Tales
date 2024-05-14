using System;
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

        Character Enemy { get; set; }

        List<Character> characters;

        Button[] skillButtons = new Button[4];


        Character currentTurn;



        public static Form1 Instance { get; private set; }

        public Form1()
        {
            InitializeComponent();
            // pag lagay sa array ng buttons para pwede sya iloop
            skillButtons[0] = button1;
            skillButtons[1] = button2;
            skillButtons[2] = button3;
            skillButtons[3] = button4;
            directory = AppDomain.CurrentDomain.BaseDirectory;
            Instance = this;


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // pag call kay bloo/player from the characters class
            Bloo bloo = new Bloo("Bloo");
            Player = bloo;
            ////





            ////
            currentTurn = Player;

            // pag call ng enemy from characters class
            Knight soulknight = new Knight("Soul Knight");
            Wizard wizard = new Wizard("wizard");
            Priest priest = new Priest("priest");
            Rogue rogue = new Rogue("rogue");
            Archer archer = new Archer("archer");
            FireWizard firewiz = new FireWizard("firewiz");
            WaterWizard waterwiz = new WaterWizard("waterwiz");
            WindWizard windwiz = new WindWizard("windwiz");
            EarthWizard earthwiz = new EarthWizard("earthwiz");
            HostileChest hostilechest = new HostileChest("evil chest");
            characters = new List<Character>();
            characters.Add(soulknight);
            characters.Add(wizard);
            characters.Add(priest);
            characters.Add(rogue);
            characters.Add(archer);
            characters.Add(firewiz);
            characters.Add(waterwiz);
            characters.Add(windwiz);
            characters.Add(earthwiz);
            characters.Add(hostilechest);

            comboBox1.Items.Add("Knight");
            comboBox1.Items.Add("Wizard");
            comboBox1.Items.Add("Priest");
            comboBox1.Items.Add("Rogue");
            comboBox1.Items.Add("Archer");
            comboBox1.Items.Add("Fire Wizard");
            comboBox1.Items.Add("Water Wizard");
            comboBox1.Items.Add("Wind Wizard");
            comboBox1.Items.Add("Earth Wizard");
            comboBox1.Items.Add("Hostile Chest");
            comboBox1.SelectedIndex = 4;


            Enemy = characters[comboBox1.SelectedIndex];
            Player.Opposition = Enemy;
            Enemy.Opposition = Player;

            currentTurn = Player;


            // pag set ng image ng picturebox
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directory = AppDomain.CurrentDomain.BaseDirectory;
            playerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            updateLabels();
            runTurn();

        }
        private void runTurn()
        {
            // effects only trigger on current turn character, may need fix



            // pag trigger ng status effects sa character
            for (int i = 0; i < currentTurn.CharStatEffects.Count; i++)
            {
                currentTurn.CharStatEffects[i].Trigger(currentTurn);
            }

            // pag set ng buttons text according sa skills ng current turn na character
            for(int i = 0; i < 4; i++)
            {
                if (i >= currentTurn.CharSkills.Count)
                {
                    skillButtons[i].Text = "";
                }
                else
                {
                    skillButtons[i].Text = currentTurn.CharSkills[i].Name;
                }
            }

            
        }
        // buttons para sa skills
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentTurn.CharSkills.Count >= 1)
            {
                currentTurn.UseSkill1(currentTurn);
                if (currentTurn.Opposition.hasTurn)
                {
                    currentTurn = currentTurn.Opposition;
                }
                else
                {
                    currentTurn.Opposition.hasTurn = true;
                }
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
                updateLabels();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentTurn.CharSkills.Count >= 2)
            {
                currentTurn.UseSkill2(currentTurn);
                if (currentTurn.Opposition.hasTurn)
                {
                    currentTurn = currentTurn.Opposition;
                }
                else
                {
                    currentTurn.Opposition.hasTurn = true;
                }
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
                updateLabels();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentTurn.CharSkills.Count >= 3)
            {
                currentTurn.UseSkill3(currentTurn);
                if (currentTurn.Opposition.hasTurn)
                {
                    currentTurn = currentTurn.Opposition;
                }
                else
                {
                    currentTurn.Opposition.hasTurn = true;
                }
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
                updateLabels();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentTurn.CharSkills.Count >= 4)
            {
                currentTurn.UseSkill4(currentTurn);
                if (currentTurn.Opposition.hasTurn)
                {
                    currentTurn = currentTurn.Opposition;
                }
                else
                {
                    currentTurn.Opposition.hasTurn = true;
                }

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
            playerPictureBox.Image = Image.FromFile(Path.Combine(directory, "assets", Player.Image));

            enemyLabelName.Text = Enemy.Name;
            enemyLabelHealth.Text = "Health:" + Enemy.Health.ToString();
            enemyLabelAccuracy.Text = "Accuracy:" + Enemy.Accuracy.ToString();
            enemyLabelAttackDamage.Text = "Attack Damage:" + Enemy.AttackDamage.ToString();
            enemyLabelSpeed.Text = "Speed:" + Enemy.Speed.ToString();
            enemyLabelRizz.Text = "Rizz:" + Enemy.Rizz.ToString();
            enemyLabelDefense.Text = "Defense:" + Enemy.Defense.ToString();
            enemyPictureBox.Image = Image.FromFile(Path.Combine(directory, "assets", Enemy.Image));

            /*
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
            */




        }

        private void testButton_Click(object sender, EventArgs e)
        {
            //MasterGooway master = new MasterGooway();
            //master.Perform(Player);

            AppleTree appletree = new AppleTree();
            appletree.Perform(Player);
            if (Player.PlayerItems.Count > 0)
            {
                MessageBox.Show(Player.PlayerItems[0].ToString());
            }
            updateLabels();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selectedItem = comboBox1.SelectedItem;

            string selectedText = selectedItem.ToString();

            switch (selectedText)
            {
                case "Knight":
                    Enemy = characters[0];             
                    break;
                case "Wizard":
                    Enemy = characters[1];
                    break;
                case "Priest":
                    Enemy = characters[2];
                    break;
                case "Rogue":
                    Enemy = characters[3];
                    break;
                case "Archer":
                    Enemy = characters[4];
                    break;
                case "Fire Wizard":
                    Enemy= characters[5];
                    break;
                case "Water Wizard":
                    Enemy = characters[6];
                    break;
                case "Wind Wizard":
                    Enemy = characters[7];
                    break;
                case "Earth Wizard":
                    Enemy = characters[8];
                    break;
                case "Hostile Chest":
                    Enemy = characters[9];
                    break;
            }
            Player.Opposition = Enemy;
            Enemy.Opposition = Player;
            updateLabels();
        }
    }
}