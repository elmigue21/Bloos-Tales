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
            charac.AttackDamage += 50;
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
            charac.AttackDamage -= 50;
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
            charac.Health -= 50;
            charac.AttackDamage += 50;
            MessageBox.Show($"Sacrifice Ring");
            charac.PlayerItems.Add(this);

        }
    }
    public class BerserkAmulet : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Berserk Amulet");
            charac.Accuracy -= charac.Accuracy * .25;
            charac.AttackDamage += charac.AttackDamage * .25;
            charac.PlayerItems.Add(this);
        }
    }
    public class Behelith : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Behelith");
            charac.PlayerItems.Add(this);
        }
    }
    public class Cologne : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Cologne");
            charac.Rizz += 20;
            charac.PlayerItems.Add(this);
        }
    }
    public class Piggybank : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Piggy bank");
            charac.PlayerItems.Add(this);
        }
    }
    public class LifePotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Life Potion");

            if(charac.Lives < 5)
            {
                charac.Lives++;
            }
            charac.PlayerItems.Add(this);
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
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Rizz Booster");
            charac.PlayerItems.Add(this);
        }
    }
    public class HealthBoosterPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Health Booster Potion");
            charac.PlayerItems.Add(this);
        }
    }
    public class DefenseDown50percentPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Defense Down 50% Potion");
            charac.PlayerItems.Add(this);
        }
    }
    public class DuctTapePotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Duct Tape Potion, can’t use rizz");
            charac.PlayerItems.Add(this);
        }
    }
    public class PocketHolePotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Pocket Hole Potion, can’t use money");
            charac.PlayerItems.Add(this);
        }
    }
    public class OneShotPotion : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"One Shot Potion");
            charac.PlayerItems.Add(this);
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
    }
    public class SpikedHelmet : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Spiked Helmet");
            charac.Defense += 5;
            charac.PlayerItems.Add(this);
        }
    }
    public class Excalibur : Items
    {
        public override void Acquired(Bloo charac)
        {
            charac.AttackDamage += 50;
            charac.PlayerItems.Add(this);
        }
    }
    public class StrangeGem : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Strange Gem");
            charac.PlayerItems.Add(this);
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
    }
    public class HolyWater : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Holy Water");
            charac.PlayerItems.Add(this);
        }
    }
    public class Goblet : Items
    {
        public override void Acquired(Bloo charac)
        {
            MessageBox.Show($"Goblet");
            charac.PlayerItems.Add(this);
        }
    }
}