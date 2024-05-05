using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public class Skill
    {
        public string Name { get; protected set; }

        public Skill(string name)
        {
            Name = name;
        }

        public virtual void Perform(Character target)
        {
            MessageBox.Show($"{Name} skill performed.");

        }
    }

    public class Damage : Skill
    {
        public Damage(string name, int dmg) : base(name)
        {
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Dealt damage using {Name}!");
        }
    }
    public class Heal : Skill
    {
        int healVal;
        public Heal(string name, int heal) : base(name)
        {
            healVal = heal;
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Using {Name} to heal.");
           // MessageBox.Show(healVal.ToString());
            target.Health += healVal;
        }
    }
    public class Block : Skill
    {
        public Block(string name) : base(name)
        {
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class Slash : Skill
    {
        int dmg;
        public Slash(string name, int damage) : base(name)
        {
            dmg = damage;
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
            target.Health -= dmg;

        }
    }
    public class ShieldBash : Skill
    {
        public ShieldBash(string name) : base(name)
        {
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class Fireball : Skill
    {
        public Fireball(string name) : base(name)
        {
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
}
