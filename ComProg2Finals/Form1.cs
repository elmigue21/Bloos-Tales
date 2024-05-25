using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public partial class Form1 : Form
    {
        public Bloo Player;
        string directory;
        bool PlayerWin;
        public Character Enemy { get; set; }
        //public Character Enemy;

        List<Character> characters;

        Button[] skillButtons = new Button[4];


        Character currentTurn;



        public List<Action> skillsQueue = new List<Action>();


        public Form2 form2 = Form2.Instance;
        public static Form1 Instance { get; private set; }
        private static Form1 instance;

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

       
        public static Form1 GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new Form1();
            }
            return instance;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // pag set ng image ng picturebox
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directory = AppDomain.CurrentDomain.BaseDirectory;
            playerPictureBox.SizeMode = PictureBoxSizeMode.Zoom;



            // form instance
            Instance.BackgroundImage = Image.FromFile(Path.Combine(directory, "assets", "00Sky.png"));

            platform05.BackgroundImage = Image.FromFile(Path.Combine(directory, "assets", "05platform.png"));
            clouds01Back.Image = Image.FromFile(Path.Combine(directory, "assets", "01cloudsBack.png"));
            clouds02Front.Image = Image.FromFile(Path.Combine(directory, "assets", "02cloudsFront.png"));
            hills03Back.Image = Image.FromFile(Path.Combine(directory, "assets", "03hillsBack.png"));
            hills04Front.BackgroundImage = Image.FromFile(Path.Combine(directory, "assets", "04hillsFront.png"));
            //MessageBox.Show
            // string soundFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "battlemusic.wav");
            // SoundPlayer battlemusicplayer = new SoundPlayer(soundFilePath);
            //  battlemusicplayer.Play();
            // currentTurn = Player;

            // pag call ng enemy from characters class
            /*
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
            comboBox1.SelectedIndex = 0;
            */


            //Enemy = characters[comboBox1.SelectedIndex];
            //Player.Opposition = Enemy;
            // Enemy.Opposition = Player;
           // Player.CharStatEffects.Add(new MultiHitChance("Attackboost"));
            
            currentTurn = Player;


        

            updateLabels();
            // runTurn();


            for (int i = 0; i < 4; i++)
            {
                if (i >= Player.CharSkills.Count)
                {
                    skillButtons[i].Text = "";
                }
                else
                {
                    skillButtons[i].Text = Player.CharSkills[i].Name;
                }
            }


            testButton.Enabled = false;

            Player.Opposition = Enemy;
            Enemy.Opposition = Player;

        }
        private void runTurn()
        {
               // runEnemy();
                testButton_Click(null, EventArgs.Empty);

        }
        private void runEnemy()
        {
            Random random = new Random();
            int chance = random.Next(0, 101);

            if(chance <= Enemy.skillProbability[0] && chance >= 0)
            {

                //Enemy.skillQueued = Enemy.CharSkills[0];
               // Enemy.skillQueue.Add(() => Enemy.CharSkills[0].Perform(Enemy));
                Enemy.CharSkills[0].Perform(Enemy);
            }
            else if(chance > Enemy.skillProbability[0] && chance <= Enemy.skillProbability[1] + Enemy.skillProbability[0])
            {
               // Enemy.skillQueue.Add(() => Enemy.CharSkills[1].Perform(Enemy));
                Enemy.CharSkills[1].Perform(Enemy);
                //Enemy.skillQueued = Enemy.CharSkills[1];
            }
            else if(chance > Enemy.skillProbability[1] && chance <= Enemy.skillProbability[2] + Enemy.skillProbability[1] + Enemy.skillProbability[0])
            {
               // Enemy.skillQueue.Add(() => Enemy.CharSkills[2].Perform(Enemy));
                Enemy.CharSkills[2].Perform(Enemy);
                // Enemy.skillQueued = Enemy.CharSkills[2];
            }
            else if(chance > Enemy.skillProbability[2] && chance <= Enemy.skillProbability[3] + Enemy.skillProbability[2] + Enemy.skillProbability[1] + Enemy.skillProbability[0])
            {
               // Enemy.skillQueue.Add(() => Enemy.CharSkills[3].Perform(Enemy));
                Enemy.CharSkills[3].Perform(Enemy);
                // Enemy.skillQueued = Enemy.CharSkills[3];
            }


        }
        // buttons para sa skills
        private void button1_Click(object sender, EventArgs e)
        {
            if (Player.CharSkills.Count >= 1)
            {
                if (Player.hasTurn)
                {
                   // Player.skillQueue.Add(() => Player.CharSkills[0].Perform(Player));
                    Player.UseSkill1(Player);
                }
                else
                {
                    Player.hasTurn = true;
                }
                if (Player.Health <= 0)
                {
                    MessageBox.Show("Bloo has lost!");
                    this.Hide();
                }
                else if (Enemy.Health <= 0)
                {
                    MessageBox.Show("Bloo has won!");
                    this.Hide();
                }
                else
                {
                    //runEnemy();
                    runTurn();
                    updateLabels();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Player.CharSkills.Count >= 2)
            {

                if (Player.hasTurn)
                {
                   // Player.skillQueue.Add(() => Player.CharSkills[0].Perform(Player));
                    Player.UseSkill2(Player);
                }
                else
                {
                    Player.hasTurn = true;
                }

                if (Player.Health <= 0)
                {
                    MessageBox.Show("Bloo has lost!");
                    this.Hide();
                }
                else if (Enemy.Health <= 0)
                {
                    MessageBox.Show("Bloo has won!");
                    this.Hide();
                }
                else
                {
                    runTurn();
                    updateLabels();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Player.CharSkills.Count >= 3)
            {
                if (Player.hasTurn)
                {
                    Player.UseSkill3(Player);
                }
                else
                {
                    Player.hasTurn = true;
                }

                if (Player.Health <= 0)
                {
                    MessageBox.Show("Bloo has lost!");
                    this.Hide();
                }
                else if (Enemy.Health <= 0)
                {
                    MessageBox.Show("Bloo has won!");
                    this.Hide();
                }
                else
                {
                    runTurn();
                    updateLabels();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Player.CharSkills.Count >= 4)
            {

                if (Player.hasTurn)
                {
                    Player.UseSkill4(Player);
                }
                else
                {
                    Player.hasTurn = true;
                }

                if (Player.Health <= 0)
                {
                    MessageBox.Show("Bloo has lost!");
                    this.Hide();
                }
                else if (Enemy.Health <= 0)
                {
                    MessageBox.Show("Bloo has won!");
                    this.Hide();
                }
                else
                {
                    runTurn();
                    updateLabels();
                }

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
            playerPictureBox.Image = Image.FromFile(Path.Combine(directory, "assets", Player.picImage));

            enemyLabelName.Text = Enemy.Name;
            enemyLabelHealth.Text = "Health:" + Enemy.Health.ToString();
            enemyLabelAccuracy.Text = "Accuracy:" + Enemy.Accuracy.ToString();
            enemyLabelAttackDamage.Text = "Attack Damage:" + Enemy.AttackDamage.ToString();
            enemyLabelSpeed.Text = "Speed:" + Enemy.Speed.ToString();
            enemyLabelRizz.Text = "Rizz:" + Enemy.Rizz.ToString();
            enemyLabelDefense.Text = "Defense:" + Enemy.Defense.ToString();
            enemyPictureBox.Image = Image.FromFile(Path.Combine(directory, "assets", Enemy.picImage));
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Player.CharStatEffects.Count; i++)
            {
                Player.CharStatEffects[i].Trigger(Player);
            }
            for (int i = 0; i < Enemy.CharStatEffects.Count; i++)
            {
                Enemy.CharStatEffects[i].Trigger(Enemy);
            }
            

            
            foreach (Action skills in Player.skillQueue)
            {
                skills();
            }
            
            Player.skillQueue.Clear();


            runEnemy();


            foreach (Action skills in Enemy.skillQueue)
            {
                skills();
            }
            
            Enemy.skillQueue.Clear();

            if (Player.hasTurn)
            {
                if (Player.Health <= 0)
                {
                    MessageBox.Show("Bloo has lost!");
                    form2.runNextEncounter();
                    this.Hide();
                }
                else if (Enemy.Health <= 0)
                {
                    MessageBox.Show("Bloo has won!");
                    form2.runNextEncounter();
                    this.Hide();
                }
            }
            else
            {
            }
            if (Enemy.hasTurn)
            {
                if (Player.Health <= 0)
                {
                    MessageBox.Show("Bloo has lost!");
                    this.Hide();
                }
                else if (Enemy.Health <= 0)
                {
                    MessageBox.Show("Bloo has won!");
                    this.Hide();   
                }
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

            
            if(currentTurn == Player)
            {

            }
            else
            {
                currentTurn = Enemy;
            }
            


            for (int i = 0; i < 4; i++)
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
            updateLabels();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           form2.runNextEncounter();
        }
    }
}