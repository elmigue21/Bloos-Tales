using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;



namespace ComProg2Finals
{

    public partial class Form2 : Form
    {
        public SoundPlayer musicWalk;
        Character Enemy;
        public static Form2 Instance { get; private set; }
        public static Bloo Player { get; private set; }
        string directory;
        public EncounterClass currentEncounter;
        public int encounterCount;
        private System.Windows.Forms.Timer timer;
        private static Form2 instance;
        Form1 f1 = Form1.GetInstance();
        public List<Character> bossFights = new List<Character>();
        public Shopkeeper shopkeeper = new Shopkeeper();
        public MasterGooway mastergooway = new MasterGooway();

        //loc ni bloo sa level/stat bar
        public Point[] levelsPoint = {
            new Point(  33  ,12),
            new Point(  91  ,12),
            new Point(  136 ,12),
            new Point(  176 ,12),
            new Point(  220 ,12),
            new Point(  261 ,12),
            new Point(  319 ,12),
            new Point(  376 ,12),
            new Point(  421 ,12),
            new Point(  463 ,12),
            new Point(  506 ,12),
            new Point(  550 ,12),
            new Point(  606 ,12),
            new Point(  664 ,12),
            new Point(  710 ,12),
            new Point(  750 ,12),
            new Point(  792 ,12),
            new Point(  835 ,12),
            new Point(  892 ,12),
            new Point(  951 ,12),
            new Point(  994 ,12),
            new Point(  1038,12),
            new Point(  1078,12),
            new Point(  1122,12),
            new Point(  1178,12)
        };
        public Form2()
        {
            Instance = this;
            InitializeComponent();
            this.DoubleBuffered = true;
            dialogueTextBox.ReadOnly = true;

            Bloo bloo = new Bloo("Bloo");
            Player = bloo;
            f1.form2 = this;
            Instance = this;
            Stream soundStream = Properties.Resources.Adventure;
            musicWalk = new SoundPlayer(soundStream);
            musicWalk.PlayLooping();

        }
        //============== UPDATED =====================
        Image layer1 = Properties.Resources.Layer1_Sky;
        Image layer2 = Properties.Resources.Layer2_Clouds;
        Image layer3 = Properties.Resources.Layer3_Clouds;
        Image layer4 = Properties.Resources.Layer4_Hills;
        Image layer5 = Properties.Resources.Layer5_Hills;
        Image layer6 = Properties.Resources.Layer6_Trees;
        Image layer7 = Properties.Resources.Layer7_Bushes;
        Image layer8 = Properties.Resources.Layer8_Platform;

        Image encounterImg = Properties.Resources.Archer;//placeholder lang yung archer para di mag-error

        int s1 = 0, s2 = 1277, cb1 = 0, cb2 = 1277, cf1 = 0, cf2 = 1277, hb1 = 0, hb2 = 1277, 
            hf1 = 0, hf2 = 1277, p1 = 0, p2 = 1277, t1 = 0, t2 = 1277, b1 = 0, b2 = 1277,
            charLocX=1280, charLocY=320;

        bool move = false, paused = false, muted = false, hasEncounter = false;
        //===========================================

        Image imgChar = null;
        

        int dialogue_count, event_dialogue_count = 0;

        

        int count = 0;
        bool fightClicked, rizzClicked = false;
        private async void Form2_Load(object sender, EventArgs e)
        {
            dialogueTextBox.Font = new Font(Program.CustomFont, 9, FontStyle.Regular);
            PrologueDialogue prologue = new PrologueDialogue();
            dialogueTextBox.Text = prologue.IntroductionDialogue;
            label1.Visible = false;
            await Task.Delay(8000);
            label1.Visible = true;
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directory = AppDomain.CurrentDomain.BaseDirectory;

            dialogueTextBox.Font = new Font(Program.CustomFont,10,FontStyle.Regular);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            encounterCount = 1;
            blooLevel.Location = levelsPoint[0];

            Instance = this;
            Wizard wizard = Wizard.CreateRandomWizard();
            List<Character> bosses = new List<Character> { new Knight("Knight"), wizard, 
                new Rogue("Rogue"), new Archer("Archer"), new Priest("Priest") };
            Random rand1 = new Random();
            for (int i = 0; i < 3; i++)
            {
                Random random = new Random();
                int rand = random.Next(0, bosses.Count);
                bossFights.Add(bosses[rand]);
                bosses.Remove(bosses[rand]);
            }

            bossFights.Add(new Peech("Peech"));


            //dialoguePanel.BackgroundImage = Image.FromFile(Path.Combine(directory, "assets", "scroll.png"));
            //statsPanel.BackgroundImage = Image.FromFile(Path.Combine(directory, "assets", "statsPanel.png"));
            //dialoguePanel.BackgroundImageLayout = ImageLayout.Stretch;
            //statsPanel.BackgroundImageLayout = ImageLayout.Zoom;
            runNextEncounter();
            UpdateStats();
            //KingDebuff kingdebuff = new KingDebuff();
           // kingdebuff.Acquired(Player);
        }
        

        //========= PAUSE AND AUDIO BUTTONS ===========
        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (paused == false)
            {
                pauseBtn.Image = Properties.Resources.PausePlayButton2;
                paused = true;
            }
            else if (paused == true)
            {
                pauseBtn.Image = Properties.Resources.PausePlayButton1;
                paused = false;
            }

        }

        private void audioBtn_Click(object sender, EventArgs e)
        {
            if (muted == false)
            {
                audioBtn.Image = Properties.Resources.AudioButton2;
                muted = true;
            }
            else if (muted == true)
            {
                audioBtn.Image = Properties.Resources.AudioButton1;
                muted = false;
            }

        }

        //========================================
        void moveBG() //UPDATED
        {
            //clouds back positions redraw
            if (cb1 <= -1267)
            {
                cb1 = 1280;
            }

            if (cb2 <= -1267)
            {
                cb2 = 1280;
            }

            //clouds front redraw
            if (cf1 <= -1267)
            {
                cf1 = 1280;
            }

            if (cf2 <= -1268)
            {
                cf2 = 1280;
            }

            //hills back redraw
            if (hb1 <= -1267)
            {
                hb1 = 1280;
            }

            if (hb2 <= -1267)
            {
                hb2 = 1280;
            }

            //hills front redraw
            if (hf1 <= -1267)
            {
                hf1 = 1280;
            }

            if (hf2 <= -1267)
            {
                hf2 = 1280;
            }

            //trees redraw
            if (t1 <= -1267)
            {
                t1 = 1280;
            }

            if (t2 <= -1267)
            {
                t2 = 1280;
            }

            //bushes redraw
            if (b1 <= -1267)
            {
                b1 = 1280;
            }

            if (b2 <= -1267)
            {
                b2 = 1280;
            }

            //platform redraw
            if (p1 <= -1267)
            {
                p1 = 1280;
            }

            if (p2 <= -1267)
            {
                p2 = 1280;
            }


            //movement speed, back layers are slower; adjust to preference
            if (move)
            {
                cb1 -= 3;
                cb2 -= 3;

                cf1 -= 5;
                cf2 -= 5;

                hb1 -= 7;
                hb2 -= 7;

                hf1 -= 9;
                hf2 -= 9;

                t1 -= 11;
                t2 -= 11;

                b1 -= 13;
                b2 -= 13;

                p1 -= 15;
                p2 -= 15;
            }
            Invalidate();
        }

        //=============== TIMERS ===================
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveBG();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (hasEncounter)
            {
                encounterExit();
            }
            else
            {
                encounterEntrance();
            }
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            

            timer.Stop();
            for (int i = 0; i < Player.PlayerItems.Count; i++)
            {
                Player.PlayerItems[i].Encountered(Player);
            }

            

            if (currentEncounter != mastergooway && currentEncounter != shopkeeper)
            {
                for (int i = 0; i < currentEncounter.Interactions.Length; i++)
                {
                    CustomButton button = new CustomButton();

                    button.ButtonText = currentEncounter.Interactions[i];
                    button.ButtonFont = new Font(Program.CustomFont, 10, FontStyle.Regular);
                    
                    switch (i)
                        {
                            case 0:
                                button.BtnClick += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction1(Player));
                                break;
                            case 1:
                                button.BtnClick += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction2(Player));
                                break;
                            case 2:
                                button.BtnClick += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction3(Player));
                                break;
                            case 3:
                                button.BtnClick += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction4(Player));
                                break;
                            case 4:
                                button.BtnClick += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction5(Player));
                                break;
                            case 5:
                                button.BtnClick += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction6(Player));
                                break;

                        }
                    flowPanelButtons.Controls.Add(button);
                }
            }
            else
            {
                if(currentEncounter == shopkeeper)
                {
                    LoadItemShop();
                }
                else if(currentEncounter == mastergooway)
                {
                    LoadSkillShop();
                }
            }
            label1.Text = currentEncounter.Name.ToUpper();
            label1.Font = new Font(Program.CustomFont, 12, FontStyle.Regular);
            dialogueTextBox.Text = currentEncounter.EncounterDialogue;

            //charactersPictureBox.Image = Image.FromFile(Path.Combine(directory, "assets", currentEncounter.picImage));

            

            if (currentEncounter is Character)
            {
                for (int i = 0; i < Player.PlayerItems.Count; i++)
                {
                    if (Player.PlayerItems[i].GetType() == currentEncounter.KeyItem)
                    {
                        MessageBox.Show("PLAYER HAS KEY ITEM");
                        Player.PlayerItems[i].Lost(Player);
                        encounterCount++;
                        runNextEncounter();
                        break;
                    }
                }
            }
            else
            {
                encounterCount++;
            }



        }

        //============= ENCOUNTER MOVEMENT =================
        private void encounterEntrance()
        {
            if (move)
            {
                charLocX -= 15;
                if (charLocX <= 900)
                {
                    move = false;
                    playerPictureBox.Image = Properties.Resources.bloo_idle;
                    playerPictureBox.Location = new System.Drawing.Point(230, 127);
                    blooLevel.Location = levelsPoint[encounterCount];
                    timer.Start();
                    hasEncounter = true;

                }
            }
            Invalidate();
        }

        private void encounterExit()
        {
            if (move)
            {
                if (hasEncounter)
                {
                    charLocX -= 15;
                    if(charLocX <= -200)
                    {
                        charLocX = 1280;
                        encounterImg = Image.FromFile(Path.Combine(directory, "assets", currentEncounter.picImage));
                        charLocY = 320 - encounterImg.Height;
                        hasEncounter = false;
                    }
                }
            }
            Invalidate();
        }

        //=================================================
        public void EnterBattle()
        {
            this.Hide();
            Stream soundStream = Properties.Resources.Battle;
            musicWalk = new SoundPlayer(soundStream);
            musicWalk.PlayLooping();
            f1 = Form1.GetInstance();
            f1.Enemy = currentEncounter as Character;
            Player.Health = Player.MaxHealth;
            f1.Player = Player;
            f1.Player.Opposition = f1.Enemy;
            f1.Enemy.Opposition = f1.Player;
            for (int i = 0; i < Player.PlayerItems.Count; i++)
            {
                Player.PlayerItems[i].BattleAddItem(Player);
            }
          
            f1.Show();
            
        }
        private void HandleButtonClick(object sender, EventArgs e, Action eventAction)
        {
            foreach(CustomButton btn in flowPanelButtons.Controls)
            {
                btn.Enabled = false;
            }
            UpdateStats();
            eventAction?.Invoke();
            UpdateStats();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            runNextEncounter();
        }
        int lastEnc;
        public void runNextEncounter()
        {
            
            Player.ChangeRizz(2);
            UpdateStats();
            if(Player.Health <= 0 && Player.Lives > 0)
            {
                Player.Lives--;
            }
            if(Player.Lives <= 0)
            {
                MessageBox.Show("Lose");
            }

            switch (encounterCount % 5)
            {
                case 0:
                    int bossIndex = encounterCount / 5;

                    currentEncounter = bossFights[bossIndex-1];

                    break;
                case 4:
                    Random rand2 = new Random();
                    int qqq2 = rand2.Next(0, 2);
                    switch (qqq2)
                    {
                        case 0:
                            currentEncounter = shopkeeper;
                            break;
                        case 1:
                            
                            currentEncounter = mastergooway;
                            break;
                    }
                    break;
                default:
                    Random rand3 = new Random();
                    int qqq3;
                    do
                    {
                        qqq3 = rand3.Next(0, 11);
                    } while (qqq3 == lastEnc);
                    switch (qqq3)
                    {
                        case 0:
                            currentEncounter = new Chest();
                            break;
                        case 1: 
                            currentEncounter = new Cave();
                            break;
                        case 2:
                            currentEncounter = new SwordInStone();
                            break;
                        case 3:
                            currentEncounter = new Bonfire();
                            break;
                        case 4:
                            currentEncounter = new MysteriousMan();
                            break;
                        case 5:
                            currentEncounter = new Jester();
                            break;
                        case 6:
                            currentEncounter = new Seer();
                            break;
                        case 7:
                            currentEncounter = new WishingWell();
                            break;
                        case 8:
                            currentEncounter = new King();
                            break;
                        case 9:
                            currentEncounter = new GobletEvent();
                            break;
                        case 10:
                            currentEncounter = new AppleTree();
                            break;
                    }
                    lastEnc = qqq3;
                    break;
            }
            label1.Text = "";
            dialogueTextBox.Text = currentEncounter.befEncounter;
            flowPanelButtons.Controls.Clear();
            //charactersPictureBox.Image = null;

            if (hasEncounter==false)
            {
                encounterImg = Image.FromFile(Path.Combine(directory, "assets", currentEncounter.picImage));
                charLocY = 320 - encounterImg.Height;
            }

            playerPictureBox.Image = Properties.Resources.bloo_walk;
            move = true;
            //timer.Start();
        }
        public void LoadItemShop()
        {
            flowPanelButtons.Controls.Clear();
            for (int i = 0; i < shopkeeper.itemshop.Count; i++)
            {
                int index = i;
                CustomButton button = new CustomButton();
                
                button.ButtonText = shopkeeper.itemshop[i].Name + " $" + (shopkeeper.itemshop[index].Price*Player.discount).ToString();
                button.ButtonFont = new Font(Program.CustomFont, 10, FontStyle.Regular);

                button.BtnClick += (Btnsender, args) =>
                {
                    if ((shopkeeper.itemshop[index].Price * Player.discount) <= Player.Coins)
                    {
                        shopkeeper.itemshop[index].Acquired(Player, this);
                        Player.Coins -= shopkeeper.itemshop[index].Price * Player.discount;
                      //  MessageBox.Show($"Price: {shopkeeper.itemshop[index].Price}\nDiscounted Price: {shopkeeper.itemshop[index].Price * Player.discount}\n\"Coins left : {Player.Coins}");

                        shopkeeper.itemshop.Remove(shopkeeper.itemshop[index]);
                        //flowLayoutPanel1.Controls.Remove(button);
                        LoadItemShop();
                    }
                    else
                    {
                        dialogueTextBox.Text = "Not enough coins";
                       // MessageBox.Show("You don't have enough coins");
                      //  MessageBox.Show($"Price: {shopkeeper.itemshop[index].Price}\nDiscounted Price: {shopkeeper.itemshop[index].Price * Player.discount}\nCoins left : {Player.Coins}");
                        LoadItemShop();
                    }
                };
                flowPanelButtons.Controls.Add(button);
            }

            CustomButton btncheck = new CustomButton();
            btncheck.ButtonText = "Next";
            btncheck.ButtonFont = new Font(Program.CustomFont, 10, FontStyle.Regular);
            btncheck.BtnClick += (qqqsender, qe) =>
            {
                runNextEncounter();
            };
            flowPanelButtons.Controls.Add(btncheck);
            UpdateStats();
        }
        public void LoadSkillShop()
        {
            flowPanelButtons.Controls.Clear();
            for (int i = 0; i < mastergooway.skillshop.Count; i++)
            {
                int index = i;
                CustomButton button = new CustomButton();
                
                button.ButtonText = mastergooway.skillshop[i].Name + " $" + (mastergooway.skillshop[index].Price *Player.discount).ToString();
                button.ButtonFont = new Font(Program.CustomFont, 10, FontStyle.Regular);
                button.BtnClick += (Btnsender, args) =>
                {
                    if (Player.CharSkills.Count < 4)
                    {
                        if (mastergooway.skillshop[index].Price * Player.discount <= Player.Coins)
                        {
                            Player.Coins -= mastergooway.skillshop[index].Price * Player.discount;
                            mastergooway.skillshop[index].Learn(Player);
                          //  MessageBox.Show($"Price: {mastergooway.skillshop[index].Price}\nDiscounted Price: {mastergooway.skillshop[index].Price * Player.discount}\nCoins left : {Player.Coins}");
                            mastergooway.skillshop.Remove(mastergooway.skillshop[index]);
                            LoadSkillShop();
                        }
                        else
                        {
                            dialogueTextBox.Text = "Not Enough Coins";
                            //MessageBox.Show("You don't have enough coins");
                          //  MessageBox.Show($"Price: {mastergooway.skillshop[index].Price}\nDiscounted Price: {mastergooway.skillshop[index].Price * Player.discount}\nCoins left : {Player.Coins}");
                            LoadSkillShop();
                        }
                    }
                    else
                    {
                        dialogueTextBox.Text = "You cannot learn any more skills!";
                       // MessageBox.Show("You cannot learn any more skills!");
                    }
                };
                flowPanelButtons.Controls.Add(button);
            }
            CustomButton btncheck = new CustomButton();
            btncheck.ButtonText = "Next";
            btncheck.ButtonFont = new Font(Program.CustomFont, 10, FontStyle.Regular);
            btncheck.BtnClick += (qqqsender, qe) =>
            {
                runNextEncounter();
            };
            flowPanelButtons.Controls.Add(btncheck);
            UpdateStats();
        }
        public void UpdateStats()
        {
            rizzStat.Text = Player.Rizz.ToString();
            coinStat.Text = Player.Coins.ToString();
            atkStat.Text = Player.AttackDamage.ToString();
            defStat.Text = Player.Defense.ToString();
            //may stat ba for life? yung hearts?
            rizzStat.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);
            coinStat.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);
            atkStat.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);
            defStat.Font = new Font(Program.CustomFont, 10, FontStyle.Regular);
        }
        private void Form2_Paint(object sender, PaintEventArgs e) //UPDATED, W/O CHARACTER PAINT YET
        {
            e.Graphics.DrawImage(layer1, s1, 0, 1280, 720);
            e.Graphics.DrawImage(layer1, s2, 0, 1280, 720);
            e.Graphics.DrawImage(layer2, cb1, 0, 1280, 720);
            e.Graphics.DrawImage(layer2, cb2, 0, 1280, 720);
            e.Graphics.DrawImage(layer3, cf1, 0, 1280, 720);
            e.Graphics.DrawImage(layer3, cf2, 0, 1280, 720);
            e.Graphics.DrawImage(layer4, hb1, 0, 1280, 720);
            e.Graphics.DrawImage(layer4, hb2, 0, 1280, 720);
            e.Graphics.DrawImage(layer5, hf1, 0, 1280, 720);
            e.Graphics.DrawImage(layer5, hf2, 0, 1280, 720);
            e.Graphics.DrawImage(layer6, t1, 0, 1280, 720);
            e.Graphics.DrawImage(layer6, t2, 0, 1280, 720);
            e.Graphics.DrawImage(layer7, b1, 0, 1280, 720);
            e.Graphics.DrawImage(layer7, b2, 0, 1280, 720);
            e.Graphics.DrawImage(layer8, p1, 0, 1280, 720);
            e.Graphics.DrawImage(layer8, p2, 0, 1280, 720);

            e.Graphics.DrawImage(encounterImg, charLocX, charLocY);
        }
    }
}
