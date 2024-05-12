using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public class Items
    {
        public virtual void Perform(Character target)
        {
            MessageBox.Show($"Items");

        }
    }
    public class Rock : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Rock");
        }
    }
    public class SacrificeRing : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Sacrifice Ring");
        }
    }
    public class BerserkAmulet : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Berserk Amulet");
        }
    }
    public class Behelith : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Behelith");
        }
    }
    public class Cologne : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Cologne ");
        }
    }
    public class Piggybank : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Piggy bank");
        }
    }
    public class LifePotion : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Life Potion");
        }
    }
    public class RizzBooster : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Rizz Booster");
        }
    }
    public class HealthBoostePotion : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Health Booster Potion");
        }
    }
    public class DefenseDown50percentPotion : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Defense Down 50% Potion");
        }
    }
    public class DuctTapePotion : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Duct Tape Potion, can’t use rizz");
        }
    }
    public class PocketHolePotion : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Pocket Hole Potion, can’t use money");
        }
    }
    public class OneShotPotion : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"One Shot Potion");
        }
    }
    public class HardHelmet : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Hard Helmet");
        }
    }
    public class SpikedHelmet : Items
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Spiked Helmet");
        }
    }
}