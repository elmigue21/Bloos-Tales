using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ComProg2Finals
{
    public class StatusEffect
    {
        public string Name { get; protected set; }
        public StatusEffect(string name) { 

        }
        public void Remove()
        {

        }
        public virtual void Trigger(Character target)
        {

        }
    }
    public class DmgPerTurn : StatusEffect
    {
        double dmg;
        int intervals;
        public DmgPerTurn(string name, double damage, int intrvl) : base(name)
        {
            dmg = damage;
            intervals = intrvl;
            Name = name;
        }
        public override void Trigger(Character target)
        {
            target.Health -= dmg;
            MessageBox.Show($"dealt {Name} {dmg} health from {target.Name}, {intervals} intervals remaining");
            intervals--;
            if (intervals == 0)
            {
                target.CharStatEffects.Remove(this);
            }
        }

    }
    public class HealPerTurn : StatusEffect
    {
        double healVal;
        int intervals;
        public HealPerTurn(string name, double heal, int intrvl) : base(name)
        {
            healVal = heal;
            intervals = intrvl;
        }
        public override void Trigger(Character target)
        {
            target.Health += healVal;
            MessageBox.Show($"Healed {healVal} health from {target}, {intervals} intervals remaining");
            intervals--;
            if (intervals == 0)
            {
                target.CharStatEffects.Remove(this);
            }
        }

    }

}
