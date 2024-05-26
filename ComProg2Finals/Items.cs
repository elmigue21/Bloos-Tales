﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public class Items
    {
        Form1 battleForm = Form1.GetInstance();
        public ItemsDialogue ItemsDiag = new ItemsDialogue();
        public Form2 form2 = new Form2();
        public string Name { get; protected set; }
        public int Price { get; set; }

        public virtual void Acquired(Bloo charac)
        {

        }
        public virtual void Encountered(Bloo charac)
        {
            
        }
        public virtual void Lost(Bloo charac)
        {

        }
        public virtual void BattleAddItem(Bloo charac)
        {
            
        }
    }
    public class Rock : Items
    {
        public Rock()
        {
            this.Name = "Rock";    
        }
        int iter;
        public override void Acquired(Bloo charac)
        {
            iter = 5;
            charac.PlayerItems.Add(this);
            form2.dialogueTextBox.Text = ItemsDiag.RockDialogue;
        }
        public override void Encountered(Bloo charac)
        {
            if(iter == 0)
            {
                Lost(charac);
            }
            else
            {
                iter--;
            }
        }
        public override void Lost(Bloo charac)
        {
            charac.PlayerItems.Remove(this);
        }
        public override void BattleAddItem(Bloo charac)
        {
            charac.CharStatEffects.Add(new HealPerTurn("HEALINGGGG", 1000, 20));
        }
    }
    public class SacrificeRing : Items
    {
        public SacrificeRing()
        {
            this.Name = "Sacrifice Ring";
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.RingDialogue;
            double change = 25;
            charac.Health -= change;
            charac.AttackDamage += change;
            charac.PlayerItems.Add(this);
            //MessageBox.Show($" -{change}% Gold Income, -{change}% Rizz Income");
        }
    }
    public class BerserkAmulet : Items
    {
        public BerserkAmulet()
        {
            this.Name = "Berserk Amulet";
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.AmuletDialogue;
            charac.Accuracy -= charac.Accuracy * .25;
            charac.AttackDamage += charac.AttackDamage * 25;
            charac.PlayerItems.Add(this);
        }
      
    }
    public class Behelith : Items
    {
        public Behelith()
        {
            this.Name = "Behelith";
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.BehelithDialogue;
            if (charac.Lives < 5)
            {
                charac.Lives++;
            }
            charac.Coins += charac.Coins * .30;
            charac.Rizz -= charac.Rizz * .30;
            charac.PlayerItems.Add(this);
        }
    }

    public class Cologne : Items
    {
        public Cologne()
        {
            this.Name = "Cologne";
        }
        int limit = 20;
        int gainedRizz = 0;
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.CologneDialogue;
            charac.PlayerItems.Add(this);         
        }
        public override void Encountered(Bloo charac)
        {
            gainedRizz += 5;

            if (gainedRizz <= limit)
            {
                charac.Rizz += 5;
            }
        }
    }
    public class Piggybank : Items
    {
        public Piggybank()
        {
            this.Name = "Piggybank";
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.PiggyDialogue;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {            
            charac.Coins += 10;
            // Tuloy-tuloy ang +10 until makabili si Bloo (madagdagan yung inventory)
        }


    }
    public class LifePotion : Items
    {
        ItemsDialogue ItemsDiag = new ItemsDialogue();
        public LifePotion()
        {
            this.Name = "Life Potion";
            this.Price = 51;
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.LifeDialogue;

            if (charac.Lives < 5)
            {
                charac.Lives++;
            }
            charac.PlayerItems.Add(this);
            //MessageBox.Show($"Extra Life");
        }
    }
    public class MysteryPotion : Items
    {
        private static Random random = new Random();
        public MysteryPotion()
        {
            this.Name = "Mystery Potion";
            this.Price = 30;
        }
        public override void Acquired(Bloo charac)
        {

            // List of possible potions
            Items selectedPotion;
            int randomIndex = random.Next(6);
            switch (randomIndex)
            {
                case 0:
                    selectedPotion = new RizzBooster();
                    break;
                case 1:
                    selectedPotion = new HealthBoosterPotion();
                    break;
                case 2:
                    selectedPotion = new DefenseDown50percentPotion();
                    break;
                case 3:
                    selectedPotion = new DuctTapePotion();
                    break;
                case 4:
                    selectedPotion = new PocketHolePotion();
                    break;
                case 5:
                    selectedPotion = new OneShotPotion();
                    break;
                default:
                    throw new Exception("Unexpected potion selection.");

            }
            // Apply the effect of the selected potion
            selectedPotion.Acquired(charac);
        }
    }
    public class RizzBooster : Items
    {
        public RizzBooster()
        {
            this.Name = "Rizz Booster";
        }
        int iter;
        double rizzBuff;
        public override void Acquired(Bloo charac)
        {
            iter = 2;
            form2.dialogueTextBox.Text = ItemsDiag.RizzBoosterDialogue;
            rizzBuff = charac.Rizz * .50;
            charac.Rizz += rizzBuff;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        { 
            if (iter == 0)
            {
                Lost(charac);
            }
            else
            {
                iter--;
            }
        }
        public virtual void Lost(Bloo charac)
        {
            charac.Rizz -= rizzBuff;
            charac.PlayerItems.Remove(this);
        }
    }
    public class HealthBoosterPotion : Items
    {
        public HealthBoosterPotion()
        {
            this.Name = "Health Booster Potion";
        }
        int iter;
        double healthBuff;

        public override void Acquired(Bloo charac)
        {
            iter = 2;
            form2.dialogueTextBox.Text = ItemsDiag.HealthBoosterDialogue;
            healthBuff = charac.Health * .50;
            charac.Health += healthBuff;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            if (iter == 0)
            {
                Lost(charac);
            }
            else
            {
                iter--;
            }
        }
        public virtual void Lost(Bloo charac)
        {
            charac.Health -= healthBuff;
            charac.PlayerItems.Remove(this);
        }
    }
    public class DefenseDown50percentPotion : Items
    {
        public DefenseDown50percentPotion()
        {
            this.Name = "Defense Down 50% Potion";
        }
        int iter;
        double defenseDebuff;
        public override void Acquired(Bloo charac)
        {
            iter = 3;
            form2.dialogueTextBox.Text = ItemsDiag.DefenseDownDialogue;
            defenseDebuff = charac.Defense * .50;
            charac.Defense -= defenseDebuff;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            if (iter == 0)
            {
                Lost(charac);
            }
            else
            {
                iter--;
            }
        }
        public override void Lost(Bloo charac)
        {
            charac.Defense += defenseDebuff;
            charac.PlayerItems.Remove(this);
        }
    }
    public class DuctTapePotion : Items
    {
        public DuctTapePotion()
        {
            this.Name = "Duct Tape Potion";
        }

        int iter = 3;
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.DuctTapeDialogue;
            charac.canUseRizz = false;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            if (iter == 0)
            {
                Lost(charac);
            }
            else
            {
                iter--;
            }
        }
        public virtual void Lost(Bloo charac)
        {
            charac.canUseRizz = true;
            charac.PlayerItems.Remove(this);
        }
    }
    public class PocketHolePotion : Items
    {
        public PocketHolePotion()
        {
            this.Name = "Pocket Hole Potion";
        }
        int iter;        
        public override void Acquired(Bloo charac)
        {
            iter = 3;
            form2.dialogueTextBox.Text = ItemsDiag.PocketHoleDialogue;
            charac.canGainCoin = false;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            if (iter == 0)
            {
                Lost(charac);
            }
            else
            {
                iter--;
            }
        }
        public virtual void Lost(Bloo charac)
        {
            charac.canGainCoin = true;
            charac.PlayerItems.Remove(this);
        }
    }
    public class OneShotPotion : Items
    {
        public OneShotPotion()
        {
            this.Name = "One Shot Potion";
        }
        int iter;
        public override void Acquired(Bloo charac)
        {
            iter = 1;
            form2.dialogueTextBox.Text = ItemsDiag.OneShotDialogue;
            charac.AttackDamage = 9999;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            if (iter == 0)
            {
                Lost(charac);
            }
            else
            {
                iter--;
            }
        }
        public virtual void Lost(Bloo charac)
        {
            charac.AttackDamage = 1;
            charac.PlayerItems.Remove(this);
        }
    }
    public class HardHelmet : Items
    {
        public HardHelmet()
        {
            this.Name = "Hard Helmet";
            this.Price = 10;
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.HardHelmentDialogue;
            charac.Defense += 15;
            charac.PlayerItems.Add(this);
            /*
            MessageBox.Show($"Character's damage somehow refected back!");
            if (Character == Priest)
            {
                ReflectDamage = 1;
            }
            else
            {
                ReflectDamage = 5;
            }
            */
        }
        public override void Encountered(Bloo charac)
        {

        }
    }
    public class SpikedHelmet : Items
    {
        public SpikedHelmet()
        {
            this.Name = "Spiked Helmet";
            this.Price = 10;
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.SpikedHelmetDialogue;
            charac.Defense += 5;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {

        }
    }
    public class Excalibur : Items
    {
        public Excalibur()
        {
            this.Name = "Excalibur";
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.ExcaliburDialogue;
            charac.AttackDamage += 50;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {

        }
    }
    public class StrangeGem : Items
    {
        public StrangeGem()
        {
            this.Name = "Strange Gem";
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.StrangeGemDialogue;
            charac.Coins += charac.Coins * .50;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {

        }
    }
    public class GoldenArrow : Items
    {
        public GoldenArrow()
        {
            this.Name = "Golden Arrow";
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.GoldenArrowDialogue;
            charac.CritChance += 20;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {

        }
    }
    public class HolyWater : Items
    {
        public HolyWater()
        {
            this.Name = "Holy Water";
        }
        public override void Acquired(Bloo charac)
        {
            charac.Health += 10;
            form2.dialogueTextBox.Text = ItemsDiag.HolyWaterDialogue;
            charac.PlayerItems.Add(this);
            if (charac.Health < 100)
            {
                charac.Health += 10;
                if (charac.Health > 100)
                {
                    double Excess = charac.Health - 100;
                    charac.Health -= Excess;
                }
            }
        }
        public override void Encountered(Bloo charac)
        {

        }
    }
    public class Goblet : Items
    {
        public Goblet()
        {
            this.Name = "Goblet";
        }
        public override void Acquired(Bloo charac)
        {
            form2.dialogueTextBox.Text = ItemsDiag.GobletDialogue;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {

        }
    }
    
    public class SeerBuff : Items
    {
        SeerDialogue SeerDiag = new SeerDialogue();
        int index;
        public SeerBuff(int ind)
        {
            index = ind;
        }
        public override void BattleAddItem(Bloo charac)
        {
            switch (index)
            {
                case 1:
                    // if final boss, add stat effect
                    break;
                case 2:
                    charac.CharStatEffects.Add(new AttackBoost("Seer buff", 0.15));
                    form2.dialogueTextBox.Text = "Bloo's attack is enhanced!";
                    charac.PlayerItems.Remove(this);
                    break;
                case 3:
                    // add charac.opposition before triggering//
                    charac.Opposition.Accuracy -= 50;
                    form2.dialogueTextBox.Text = "Bloo's enemy can't see straight!";
                    charac.PlayerItems.Remove(this);
                    break;
                case 4:
                    charac.CharStatEffects.Add(new DefenseBoost("Seer buff", 20));
                    form2.dialogueTextBox.Text = "Bloo's defense is enhanced!";
                    charac.PlayerItems.Remove(this);
                    break;
            }
        }
    }
    public class MysteryBox : Items
    {
        private static Random random = new Random();
        public MysteryBox()
        {
            this.Name = "Mystery Box";
        }
        public override void Acquired(Bloo charac)
        {

            // List of possible potions
            Items selectedPotion;
            int randomIndex = random.Next(15);
            switch (randomIndex)
            {
                case 0:
                    selectedPotion = new Rock();
                    break;
                case 1:
                    selectedPotion = new SacrificeRing();
                    break;
                case 2:
                    selectedPotion = new BerserkAmulet();
                    break;
                case 3:
                    selectedPotion = new Behelith();
                    break;
                case 4:
                    selectedPotion = new Cologne();
                    break;
                case 5:
                    selectedPotion = new Piggybank();
                    break;
                case 6:
                    selectedPotion = new LifePotion();
                    break;
                case 7:
                    selectedPotion = new MysteryPotion();
                    break;
                case 8:
                    selectedPotion = new HardHelmet();
                    break;
                case 9:
                    selectedPotion = new SpikedHelmet();
                    break;
                case 10:
                    selectedPotion = new Excalibur();
                    break;
                case 11:
                    selectedPotion = new StrangeGem();
                    break;
                case 12:
                    selectedPotion = new GoldenArrow();
                    break;
                case 13:
                    selectedPotion = new HolyWater();
                    break;
                case 14:
                    selectedPotion = new Goblet();
                    break;
                default:
                    throw new Exception("Unexpected potion selection.");

            }
            // Apply the effect of the selected potion
            selectedPotion.Acquired(charac);
        }
    }


}