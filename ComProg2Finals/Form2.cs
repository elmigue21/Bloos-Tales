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
using System.Timers;


namespace ComProg2Finals
{

    public partial class Form2 : Form
    {
        Character Enemy;
        public static Form2 Instance { get; private set; }
        public static Bloo Player { get; private set; }
        //public Bloo Player;
        string directory;
        public EncounterClass currentEncounter;
        int encounterCount;
        private System.Windows.Forms.Timer timer;
        public Form2()
        {
            Instance = this;
            InitializeComponent();
            this.DoubleBuffered = true;

            dialogueTextBox.ReadOnly = true;
            // MessageBox.Show(Player.Name);

            //Instance = this;
            Instance = this;



        }
        Image layer1 = ComProg2Finals.Properties.Resources._00Sky;
        Image layer2 = ComProg2Finals.Properties.Resources._01cloudsBack;
        Image layer3 = ComProg2Finals.Properties.Resources._02cloudsFront;
        Image layer4 = ComProg2Finals.Properties.Resources._03hillsBack;
        Image layer5 = ComProg2Finals.Properties.Resources._04hillsFront;
        Image layerTrees = ComProg2Finals.Properties.Resources.trees;
        Image layerBush = ComProg2Finals.Properties.Resources.bushes;
        Image layer6 = ComProg2Finals.Properties.Resources._05platform;

        int s1 = 0, s2 = 1277, cb1 = 0, cb2 = 1277, cf1 = 0, cf2 = 1277, hb1 = 0, hb2 = 1277, hf1 = 0, hf2 = 1277, p1 = 0, p2 = 1277, t1 = 0, t2 = 1277, b1 = 0, b2 = 1277;

        Image imgChar = null;

        private void player_Click(object sender, EventArgs e)
        {

        }

        int dialogue_count, event_dialogue_count = 0;
        int count = 0;
        bool fightClicked, rizzClicked = false;
        private void Form2_Load(object sender, EventArgs e)
        {
            string programDirectory = AppDomain.CurrentDomain.BaseDirectory;
            directory = AppDomain.CurrentDomain.BaseDirectory;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;

            Bloo bloo = new Bloo("Bloo");
            Player = bloo;

            encounterCount = 1;


        }
        bool right, hold = true;

        void moveBG()
        {
            //clouds back positions redraw
            if (cb1 <= -1268)
            {
                cb1 = 1280;
            }

            if (cb2 <= -1268)
            {
                cb2 = 1280;
            }

            //clouds front redraw
            if (cf1 <= -1268)
            {
                cf1 = 1280;
            }

            if (cf2 <= -1268)
            {
                cf2 = 1280;
            }

            //hills back redraw
            if (hb1 <= -1268)
            {
                hb1 = 1280;
            }

            if (hb2 <= -1268)
            {
                hb2 = 1280;
            }

            //hills front redraw
            if (hf1 <= -1268)
            {
                hf1 = 1280;
            }

            if (hf2 <= -1268)
            {
                hf2 = 1280;
            }

            //trees redraw
            if (t1 <= -1268)
            {
                t1 = 1280;
            }

            if (t2 <= -1268)
            {
                t2 = 1280;
            }

            //bushes redraw
            if (b1 <= -1268)
            {
                b1 = 1280;
            }

            if (b2 <= -1268)
            {
                b2 = 1280;
            }

            //platform redraw
            if (p1 <= -1268)
            {
                p1 = 1280;
            }

            if (p2 <= -1268)
            {
                p2 = 1280;
            }


            //movement speed, back layers are slower; adjust to preference
            if (right)
            {
                cb1 -= 2;
                cb2 -= 2;

                cf1 -= 3;
                cf2 -= 3;

                hb1 -= 5;
                hb2 -= 5;

                hf1 -= 6;
                hf2 -= 6;

                t1 -= 8;
                t2 -= 8;

                b1 -= 9;
                b2 -= 9;

                p1 -= 11;
                p2 -= 11;
            }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveBG();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            playerPictureBox.Image = Properties.Resources.blooIdle;
            timer.Stop();
            switch (encounterCount % 5)
            {
                case 0:
                    Random rand1 = new Random();
                    int qqq1 = rand1.Next(0, 5);
                    switch (qqq1)
                    {
                        case 0:
                            currentEncounter = new Knight("knightt");
                            break;
                        case 1:
                            currentEncounter = new Wizard("gaanddaaalfff");
                            break;
                        case 2:
                            currentEncounter = new Rogue("miroguel");
                            break;
                        case 3:
                            currentEncounter = new Archer("legolas");
                            break;
                        case 4:
                            currentEncounter = new Priest("rafaella");
                            break;
                    }
                    break;
                case 4:
                    Random rand2 = new Random();
                    int qqq2 = rand2.Next(0, 2);
                    switch (qqq2)
                    {
                        case 0:
                            currentEncounter = new Shopkeeper();
                            break;
                        case 1:
                            currentEncounter = new MasterGooway();
                            break;
                    }
                    break;
                default:
                    Random rand3 = new Random();
                    int qqq3 = rand3.Next(0, 11);
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
                    break;
            }
            currentEncounter = new Knight("qweqwe");
            for(int i = 0; i < currentEncounter.Interactions.Length; i++)
            {
                Button button = new Button();

                button.Text = currentEncounter.Interactions[i];


                switch (i)
                {
                    case 0:
                        button.Click += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction1(Player));
                        break;
                    case 1:
                        button.Click += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction2(Player));
                        break;
                    case 2:
                        button.Click += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction3(Player));
                        break;
                    case 3:
                        button.Click += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction4(Player));
                        break;
                    case 4:
                        button.Click += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction5(Player));
                        break;
                    case 5:
                        button.Click += (buttonSender, eventArgs) => HandleButtonClick(buttonSender, eventArgs, () => currentEncounter.EventAction6(Player));
                        break;

                }

               

                

                flowLayoutPanel1.Controls.Add(button);
            }

            label1.Text = currentEncounter.Name;
            dialogueTextBox.Text = currentEncounter.EncounterDialogue;
            charactersPictureBox.Image = Image.FromFile(Path.Combine(directory, "assets", currentEncounter.picImage));
            encounterCount++;
        }


        private void HandleButtonClick(object sender, EventArgs e, Action eventAction)
        {
            eventAction?.Invoke();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            dialogueTextBox.Text = "";
            flowLayoutPanel1.Controls.Clear();
            charactersPictureBox.Image = null;
            playerPictureBox.Image = Properties.Resources.blooBouncing;
            timer.Start();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
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
            e.Graphics.DrawImage(layerTrees, t1, 0, 1280, 720);
            e.Graphics.DrawImage(layerTrees, t2, 0, 1280, 720);
            e.Graphics.DrawImage(layerBush, b1, 0, 1280, 720);
            e.Graphics.DrawImage(layerBush, b2, 0, 1280, 720);
            e.Graphics.DrawImage(layer6, p1, 0, 1280, 720);
            e.Graphics.DrawImage(layer6, p2, 0, 1280, 720);
        }
    }
}
