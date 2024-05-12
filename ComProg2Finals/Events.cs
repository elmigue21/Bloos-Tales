using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ComProg2Finals
{
    public class Events
    {
        public virtual void Perform(Character target)
        {
            MessageBox.Show($"Events");

        }
    }
    public class Chest : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Chest");
        }
    }
    public class Cave : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Cave");
        }
    }
    public class SwordInStone : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Sword In Stone");
        }
    }
    public class Bonfire : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Bonfire");
        }
    }
    public class MysteriousMan : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Mysterious Man");
        }
    }
    public class Jester : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Jester");
        }
    }
    public class Seer : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Seer");
        }
    }
    public class WishingWell : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Wishing Well");
        }
    }
    public class King : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"King");
        }
    }
    public class Goblet : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Goblet");
        }
    }
    public class AppleTree : Events
    {
        public override void Perform(Character target)
        {
            MessageBox.Show($"Apple Tree");
        }
    }
}
