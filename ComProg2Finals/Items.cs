using System;
using System.Collections.Generic;
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
        public virtual void Encountered()
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
        public override void Acquired(Bloo charac)
        {
           // MessageBox.Show($"Bloo obtained a rock!");
            MessageBox.Show($"It does nothing");
            charac.PlayerItems.Add(this);
        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }

        public override void Lost(Bloo charac)
        {
            MessageBox.Show("You lost your rock, it did nothing.");
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
            double change = 50;
            charac.Health -= change;
            charac.AttackDamage += change;
            charac.PlayerItems.Add(this);
            //MessageBox.Show($" -{change}% Gold Income, -{change}% Rizz Income");

        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
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
        public override void Encountered()
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
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class Cologne : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained a Cologne!");
            charac.Rizz += 20;
            charac.PlayerItems.Add(this);
            //MessageBox.Show($"+20 Permanent Rizz");
        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class Piggybank : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained a Piggy bank!");
            charac.Coins += 10;
            charac.PlayerItems.Add(this);
            //MessageBox.Show($"+10 Coins");
        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
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
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class MysteryPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Mystery Potion");
            charac.PlayerItems.Add(this);

        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class RizzBooster : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained a Rizz Booster Potion!");
            double change = 20;
            charac.Rizz += charac.Rizz * (change / 100);
            charac.PlayerItems.Add(this);
            //MessageBox.Show($"+{change}% Permanent Rizz");
        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class HealthBoosterPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained a Health Booster Potion");
            double change = 20;
            charac.Health += charac.Health * (change / 100);
            charac.PlayerItems.Add(this);
            //MessageBox.Show($"+{change}% Health");
        }
    }
    public class DefenseDown50percentPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Bloo obtained a Defense Down 50% Potion");
            double change = 50;
            charac.Defense += charac.Defense * (change / 100);
            charac.PlayerItems.Add(this);
            //MessageBox.Show($"+{change}% Defense");
        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class DuctTapePotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Duct Tape Potion, can’t use rizz");
            charac.PlayerItems.Add(this);
        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class PocketHolePotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Pocket Hole Potion, can’t use money");
            charac.PlayerItems.Add(this);
        }
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
    public class OneShotPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"One Shot Potion");
            charac.PlayerItems.Add(this);
        }
        public override void Encountered()
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
        public override void Encountered()
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
        public override void Encountered()
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
        public override void Encountered()
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
        public override void Encountered()
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
        public override void Encountered()
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
        public override void Encountered()
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
        public override void Encountered()
        {
            MessageBox.Show("Rock item encounter method triggered.");
        }
    }
}