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
}
