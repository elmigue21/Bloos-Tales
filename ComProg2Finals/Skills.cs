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

        public virtual void Perform()
        {
            MessageBox.Show($"{Name} skill performed.");
        }
    }

    public class Damage : Skill
    {
        public Damage(string name) : base(name)
        {
        }

        public override void Perform()
        {
            MessageBox.Show($"Dealt damage using {Name}!");
        }
    }
    public class Heal : Skill
    {
        public Heal(string name) : base(name)
        {
        }

        public override void Perform()
        {
            MessageBox.Show($"Using {Name} to heal.");
        }
    }
    public class Block : Skill
    {
        public Block(string name) : base(name)
        {
        }

        public override void Perform()
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class Slash : Skill
    {
        public Slash(string name) : base(name)
        {
        }

        public override void Perform()
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class ShieldBash : Skill
    {
        public ShieldBash(string name) : base(name)
        {
        }

        public override void Perform()
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class Fireball : Skill
    {
        public Fireball(string name) : base(name)
        {
        }

        public override void Perform()
        {
            MessageBox.Show($"Used {Name}");
        }
    }
}
