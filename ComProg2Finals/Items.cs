using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public class Items
    {
        public virtual void Acquired(Bloo charac)
        {
            MessageBox.Show($"Items");

        }
        public virtual void Encountered(Bloo charac)
        {
            
        }
        public virtual void Lost(Bloo charac)
        {
            MessageBox.Show("item lost");
        }
        public virtual void BattleAddItem(Bloo charac)
        {
            
        }
    }
    public class Rock : Items
    {
        int iter;
        public override void Acquired(Bloo charac)
        {
            iter = 5;
            MessageBox.Show($"bloo acquired rock, It does nothing");
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {

            if(iter == 0)
            {
                Lost(charac);
            }
            else
            {
                MessageBox.Show("ITER--");
                iter--;
            }
            MessageBox.Show(charac.AttackDamage.ToString());
        }

        public override void Lost(Bloo charac)
        {
            MessageBox.Show("You lost your rock, it did nothing.");
            charac.PlayerItems.Remove(this);
        }
        public override void BattleAddItem(Bloo charac)
        {
            charac.CharStatEffects.Add(new HealPerTurn("HEALINGGGG", 1000, 20));
        }
    }
    public class SacrificeRing : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained the Sacrifice Ring!");
            double change = 25;
            charac.Health -= change;
            charac.AttackDamage += change;
            charac.PlayerItems.Add(this);
            //MessageBox.Show($" -{change}% Gold Income, -{change}% Rizz Income");

        }

    }
    public class BerserkAmulet : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained the Berserk Amulet!");
            double change = 25;
            charac.Accuracy -= charac.Accuracy * (change / 100);
            charac.AttackDamage += charac.AttackDamage * (change / 100);
            charac.PlayerItems.Add(this);
            //MessageBox.Show($" -{change}% Accuracy, +{change}% Double Damage");

        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

    }
    public class Behelith : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained the Behelith");
            double change = 30;
            if (charac.Lives < 5)
            {
                charac.Lives++;
            }
            charac.Coins += charac.Coins * (change / 100);
            charac.Rizz -= charac.Rizz * (change / 100);
            charac.PlayerItems.Add(this);
            //MessageBox.Show($"One life, +{change}% Gold Income, -{change}% Rizz Income");
        }

        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }

    public class Cologne : Items
    {
        int limit = 20;
        int gainedRizz = 0;
        public override void Acquired(Bloo charac)
        { 
            MessageBox.Show($"Bloo obtained a Cologne!"); 
            charac.PlayerItems.Add(this);         
        }
        public override void Encountered(Bloo charac)
        {
            gainedRizz += 5;

            if (gainedRizz <= limit)
            {
                charac.Rizz += 5;
                MessageBox.Show(charac.Rizz.ToString());
            }
        }
    }
    public class Piggybank : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained a Piggy bank!");
            
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            
            charac.Coins += 10;
            MessageBox.Show("+10 Bonus");
            MessageBox.Show(charac.Coins.ToString());
            // Tuloy-tuloy ang +10 until makabili si Bloo (madagdagan yung inventory)
        }


    }
    public class LifePotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained a Life Potion!");

            if(charac.Lives < 5)
            {
                charac.Lives++;
            }
            charac.PlayerItems.Add(this);
            //MessageBox.Show($"Extra Life");
        }

    }
    public class MysteryPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Mystery Potion");
            charac.PlayerItems.Add(this);

        }
      
    }
    public class RizzBooster : Items
    {
        int iter;
        double rizzBuff;
        public override void Acquired(Bloo charac)
        {
            iter = 2;
            MessageBox.Show($"Bloo obtained a Rizz Booster Potion!");
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
            MessageBox.Show(charac.Rizz.ToString());
        }
        public virtual void Lost(Bloo charac)
        {
            MessageBox.Show("RizzBooster lost");
            charac.Rizz -= rizzBuff;
            charac.PlayerItems.Remove(this);
            MessageBox.Show("From lost: " + charac.Rizz.ToString());

        }


    }
    public class HealthBoosterPotion : Items
    {
        int iter;
        double healthBuff;

        public override void Acquired(Bloo charac)
        {
            iter = 2;
            MessageBox.Show($"Bloo obtained a Health Booster Potion");
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
            MessageBox.Show(charac.Health.ToString());
        }
        public virtual void Lost(Bloo charac)
        {
            MessageBox.Show("Health Booster lost");
            charac.Health -= healthBuff;
            charac.PlayerItems.Remove(this);
            MessageBox.Show("From Lost - Health: " + charac.Health.ToString());

        }
    }
    public class DefenseDown50percentPotion : Items
    {
        int iter;
        double defenseDebuff;
        public override void Acquired(Bloo charac)
        {
            iter = 3;
            MessageBox.Show($"Bloo obtained a Defense Down 50% Potion");
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
            MessageBox.Show(charac.Defense.ToString());
        }
        public virtual void Lost(Bloo charac)
        {
            MessageBox.Show("Defense Down lost");
            charac.Defense += defenseDebuff;
            charac.PlayerItems.Remove(this);
            MessageBox.Show("From Lost - Defense: " + charac.Defense.ToString());

        }

    }
    public class DuctTapePotion : Items
    {
        int iter = 3;
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Duct Tape Potion, can’t use rizz");
            //
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
            MessageBox.Show("Duct Tape Potion lost");
            charac.PlayerItems.Remove(this);
        }

    }
    public class PocketHolePotion : Items
    {
        int iter;
        
        public override void Acquired(Bloo charac)
        {
            iter = 2;
            MessageBox.Show($"Bloo obtained a Pocket Hole, can't use money");
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
            MessageBox.Show(charac.Coins.ToString());
        }
        public virtual void Lost(Bloo charac)
        {
            MessageBox.Show("Pocket Hole Potion lost");
            charac.PlayerItems.Remove(this);
        

        }

    }
    public class OneShotPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"One Shot Potion");
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

    }
    public class HardHelmet : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Hard Helmet");
            charac.Defense += 15;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

    }
    public class SpikedHelmet : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Spiked Helmet");
            charac.Defense += 5;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class Excalibur : Items
    {
        public override void Acquired(Bloo charac)
        {
            charac.AttackDamage += 50;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

    }
    public class StrangeGem : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Strange Gem");
            charac.Coins += charac.Coins * .50;
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

    }
    public class GoldenArrow : Items
    {
        public override void Acquired(Bloo charac)
        {
            charac.CritChance += 20;
            charac.PlayerItems.Add(this);
            MessageBox.Show($"{charac.Name}'s crit chance is now {charac.CritChance}");
        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

    }
    public class HolyWater : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Holy Water");
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

    }
    public class Goblet : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Goblet");
            charac.PlayerItems.Add(this);
        }
        public override void Encountered(Bloo charac)
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

    }
}