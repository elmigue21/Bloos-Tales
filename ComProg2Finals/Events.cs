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

    }
}
