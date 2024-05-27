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
        public SoundPlayer musicBattle;
        public Bloo Player;
        string directory;
        bool PlayerWin;
        public Character Enemy { get; set; }

        List<Character> characters;

        CustomButton[] skillButtons = new CustomButton[4];


        Character currentTurn;



        public List<Action> skillsQueue = new List<Action>();


        public Form2 form2 = Form2.Instance;
        public static Form1 Instance { get; private set; }
        private static Form1 instance;

        public Form1()
        {
            InitializeComponent();
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
            playerPictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            dialoguePanel.Visible = false;
            // form instance
 
            
            currentTurn = Player;
            updateLabels();
            for (int i = 0; i < 4; i++)
            {
                if (i >= Player.CharSkills.Count)
                {
                    skillButtons[i].ButtonText = "";
                    skillButtons[i].ButtonFont = new Font(Program.CustomFont, 10, FontStyle.Regular);
                }
                else
                {
                    skillButtons[i].ButtonText = Player.CharSkills[i].Name;
                    skillButtons[i].ButtonFont = new Font(Program.CustomFont, 10, FontStyle.Regular);
                }
            }
            runButton.ForeColor = Color.Black;

            Player.Opposition = Enemy;
            Enemy.Opposition = Player;

        }
        private void runTurn()
        {
                runEnemy();
                testButton_Click(null, EventArgs.Empty);

        }
        private void runEnemy()
        {
            Random random = new Random();
            int chance = random.Next(0, 101);

            if(chance <= Enemy.skillProbability[0] && chance >= 0)
            {
                Enemy.CharSkills[0].Perform(Enemy);
            }
            else if(chance > Enemy.skillProbability[0] && chance <= Enemy.skillProbability[1] + Enemy.skillProbability[0])
            {
                Enemy.CharSkills[1].Perform(Enemy);
            }
            else if(chance > Enemy.skillProbability[1] && chance <= Enemy.skillProbability[2] + Enemy.skillProbability[1] + Enemy.skillProbability[0])
            {
                Enemy.CharSkills[2].Perform(Enemy);
            }
            else if(chance > Enemy.skillProbability[2] && chance <= Enemy.skillProbability[3] + Enemy.skillProbability[2] + Enemy.skillProbability[1] + Enemy.skillProbability[0])
            {
                Enemy.CharSkills[3].Perform(Enemy);
            }


        }
        // buttons para sa skills
        private void button1_Click(object sender, EventArgs e)
        {
            if (Player.CharSkills.Count >= 1)
            {
                if (Player.hasTurn)
                {
                    Player.UseSkill1(Player);
                }
                else
                {
                    MessageBox.Show("Bloo is stunned, can't move");
                    Player.hasTurn = true;
                }
                    runTurn();
                    updateLabels();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Player.CharSkills.Count >= 2)
            {

                if (Player.hasTurn)
                {
                    Player.UseSkill2(Player);
                }
                else
                {
                    MessageBox.Show("Bloo is stunned, can't move");
                    Player.hasTurn = true;
                }
                    runTurn();
                    updateLabels();
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
                    MessageBox.Show("Bloo is stunned, can't move");
                    Player.hasTurn = true;
                }
                    runTurn();
                    updateLabels();
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
                    MessageBox.Show("Bloo is stunned, can't move");
                    Player.hasTurn = true;
                }
                    runTurn();
                    updateLabels();

            }
        }
        public void updateLabels()
        {
            playerLabelName.Text = Player.Name;
            playerLabelName.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);

            playerLabelHealth.Text = "Health:"+Player.Health.ToString();
            playerLabelHealth.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);

            playerLabelAttackDamage.Text = "Attack Damage:" + Player.AttackDamage.ToString();
            playerLabelAttackDamage.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);

            playerLabelDefense.Text = "Defense:" + Player.Defense.ToString();
            playerLabelDefense.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);

            playerPictureBox.Image = Image.FromFile(Path.Combine(directory, "assets", Player.picImage));
            


            enemyLabelName.Text = Enemy.Name;
            enemyLabelName.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);

            enemyLabelHealth.Text = "Health:" + Enemy.Health.ToString();
            enemyLabelHealth.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);

            enemyLabelAttackDamage.Text = "Attack Damage:" + Enemy.AttackDamage.ToString();
            enemyLabelAttackDamage.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);

            enemyLabelDefense.Text = "Defense:" + Enemy.Defense.ToString();
            enemyLabelDefense.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);

            enemyPictureBox.Image = Image.FromFile(Path.Combine(directory, "assets", Enemy.picImage));
 

        }
        public async Task checkWinner()
        {
            if (Player.Health <= 0)
            {
                instance.dialogueTextBox.Text = "Bloo has lost!";
                Stream soundStreams = Properties.Resources.Lose;
                musicBattle = new SoundPlayer(soundStreams);
                musicBattle.PlayLooping();
                await Task.Delay(4000);
                this.Close();
                form2.Show();
            }
            else if (Enemy.Health <= 0)
            {
                if (Enemy is Priest priest)
                {
                    if (priest.canRevive)
                    {
                        instance.dialogueTextBox.Text = "Priest comes back to life!";
                        priest.canRevive = false;
                        Enemy.Health = Enemy.MaxHealth;
                        updateLabels();
                    }
                    else
                    {
                        instance.dialogueTextBox.Text = "Bloo has won!";
                        Stream soundStreams = Properties.Resources.Win;
                        musicBattle = new SoundPlayer(soundStreams);
                        musicBattle.PlayLooping();
                        await Task.Delay(4000);
                        this.Close();
                        form2.Show();
                    }
                }
                else
                {
                    instance.dialogueTextBox.Text = "Bloo has won!";
                    Stream soundStreams = Properties.Resources.Win;
                    musicBattle = new SoundPlayer(soundStreams);
                    musicBattle.PlayLooping();
                    await Task.Delay(4000);
                    this.Close();
                    form2.Show();
                }
            }
            Stream soundStream = Properties.Resources.Adventure;
            musicBattle = new SoundPlayer(soundStream);
            musicBattle.PlayLooping();
        }
        private void playerRunBtn(object sender, EventArgs e)
        {
            this.Close();
            form2.Show();
            Stream soundStream = Properties.Resources.Adventure;
            musicBattle = new SoundPlayer(soundStream);
            musicBattle.PlayLooping();
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
            checkWinner();
            if (Enemy.Health > 0)
            {
                foreach (Action skills in Enemy.skillQueue)
                {
                    skills();
                }
            }
            
            Enemy.skillQueue.Clear();
            checkWinner();
            updateLabels();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Player.CharStatEffects.Clear();
            form2.encounterCount++;
           form2.runNextEncounter();
        }
    }
}