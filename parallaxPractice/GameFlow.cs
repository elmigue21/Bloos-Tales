using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parallaxPractice
{
    public partial class GameFlow : Form
    {
        public GameFlow()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        Image layer1 = Properties.Resources._00Sky;
        Image layer2 = Properties.Resources._01cloudsBack;
        Image layer3 = Properties.Resources._02cloudsFront;
        Image layer4 = Properties.Resources._03hillsBack;
        Image layer5 = Properties.Resources._04hillsFront;
        Image layerTrees = Properties.Resources.trees;
        Image layerBush = Properties.Resources.bushes;
        Image layer6 = Properties.Resources._05platform;

        int s1 = 0, s2 = 1277, cb1 = 0, cb2 = 1277, cf1 = 0, cf2 = 1277, hb1 = 0, hb2 = 1277, hf1 = 0, hf2 = 1277, p1 = 0, p2 = 1277, t1=0, t2=1277, b1=0, b2=1277;

        

        Image imgChar = null;
        int dialogue_count, event_dialogue_count = 0;
        int count= 0;
        bool fightClicked, rizzClicked= false;
        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Stop();
            characters.Visible = false;
            dialogue_box.Visible = false;
            fight_btn.Visible = false;
            rizz_btn.Visible = false;
        }
        bool right, hold = true;

        void walk()
        {
            timer2.Stop();
            scroll_panel.Visible = false;
            fight_btn.Visible = false;
            rizz_btn.Visible = false;
            characters.Visible=false;
            dialogue_box.Visible = false;
            right = true;
            hold = false;
            player.Image = Properties.Resources.blooBouncing;
            timer2.Start();
        }
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
                hb2-=5;

                hf1 -= 6;
                hf2-=6;

                t1 -= 8;
                t2 -= 8;

                b1 -= 9;
                b2 -= 9;

                p1 -= 11;
                p2-=11;
            }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveBG();
        }
        private void fight_btn_Click(object sender, EventArgs e)
        {
            fightClicked = true;
            dialogue_count++;
            fight_btn.Visible = false;
            rizz_btn.Visible = false;
            scroll_panel_Click(this, new EventArgs());
        }
        private void rizz_btn_Click(object sender, EventArgs e)
        {
            rizzClicked = true;
            dialogue_count++;
            fight_btn.Visible = false;
            rizz_btn.Visible = false;
            scroll_panel_Click(this, new EventArgs());
        }
        private void scroll_panel_Click(object sender, EventArgs e)
        {
            if (imgChar == null)
            {
                walk();
            }
            if (fightClicked == true || rizzClicked == true)
            {
                event_dialogue_count++;
            }
            else
            {
                dialogue_count++;
            }
            switch (count)
            {
                case 0:
                    paladin();
                    break;
                case 1:
                    wizard();
                    break;
            }
            

        }
        void wizard()
        {
            imgChar = Properties.Resources.wizard;
                switch (dialogue_count)
                {
                    case 1:
                        dialogue_box.Text = "Hello Wizard 1 " + dialogue_count;
                        break;
                    case 2:
                        dialogue_box.Text = "What would you do";
                        fight_btn.Visible = true;
                        rizz_btn.Visible = true;
                        
                        break;
                    case 3:
                    if (fightClicked == true)
                        {
                            switch (event_dialogue_count)
                            {
                            case 1:
                            dialogue_box.Text = "Wizard Fight";
                            break;

                            case 2:
                                dialogue_count = 0;
                                event_dialogue_count= 0;
                                count = 0;
                                imgChar = null;
                                fightClicked = false;
                                scroll_panel_Click(this, new EventArgs());
                                break;
                            }
                        }
                    else if (rizzClicked == true) {
                        switch (event_dialogue_count)
                        {
                            case 1:
                                dialogue_box.Text = "Rizz Wizard";
                                break;

                            case 2:
                                dialogue_count = 0;
                                event_dialogue_count = 0;
                                count = 0;
                                imgChar = null;
                                rizzClicked = false;
                                scroll_panel_Click(this, new EventArgs());
                                break;
                        }
                    }
                    else{
                        dialogue_count = 2;
                    }
                    break;

                }
        }
        void paladin()
        {
            imgChar = Properties.Resources.paladin;
            switch (dialogue_count)
            {
                case 1:
                    dialogue_box.Text = "Hello Paladin 1 " + dialogue_count;
                    break;
                case 2:
                    dialogue_box.Text = "What would you do";
                    fight_btn.Visible = true;
                    rizz_btn.Visible = true;

                    break;
                case 3:
                    if (fightClicked == true)
                    {
                        switch (event_dialogue_count)
                        {
                            case 1:
                                dialogue_box.Text = "Paladin Fight";
                                break;

                            case 2:
                                dialogue_count = 0;
                                event_dialogue_count = 0;
                                count = 1;
                                imgChar = null;
                                fightClicked = false;
                                scroll_panel_Click(this, new EventArgs());
                                break;
                        }
                    }
                    else if (rizzClicked == true)
                    {
                        switch (event_dialogue_count)
                        {
                            case 1:
                                dialogue_box.Text = "Rizz Paladin";
                                break;

                            case 2:
                                dialogue_count = 0;
                                event_dialogue_count = 0;
                                count = 1;
                                imgChar = null;
                                rizzClicked = false;
                                scroll_panel_Click(this, new EventArgs());
                                break;
                        }
                    }
                    else
                    {
                        dialogue_count = 2;
                    }
                    break;

            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            characters.Image = imgChar;
            dialogue_box.Visible = true;
            characters.Visible = true;
            scroll_panel.Visible = true;
            right = false;
            hold = true;
            player.Image = Properties.Resources.blooIdle;
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
