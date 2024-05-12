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

        public Skill()
        {
        }

        public virtual void Perform(Character target)
        {
            MessageBox.Show($"{Name} skill performed.");

        }
    }

    // BLOO SKILLS
    public class Tackle : Skill
    {
        public Tackle()
        {
            this.Name = "Tackle";
        }

        public override void Perform(Character target)
        {        
            double damageValue = -25;
            MessageBox.Show($"Used {Name} and dealt {damageValue} damage!");
            target.UpdateHealth(damageValue, target);
        }
    }
    public class Goo : Skill
    {
        public Goo()
        {
            this.Name = "Goo";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
            target.CharStatEffects.Add(new DmgPerTurn("Goo", 10, 2));
        }
    }







    


    // KNIGHT SKILLS


    public class Block : Skill
    {
        public Block()
        {
            this.Name = "Block";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
            target.UpdateHealth(-50, target);
        }
    }
    public class Slash : Skill
    {
        public Slash()
        {
            this.Name = "Slash";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
            target.Health -= 50;

        }
    }
    public class ShieldBash : Skill
    {
        public ShieldBash()
        {
            this.Name = "ShieldBash";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }

    // WIZARD SKILLs
    public class Fireball : Skill
    {
        public Fireball()
        {
            this.Name = "Fireball";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
            target.CharStatEffects.Add(new DmgPerTurn("Burn", 10, 5));
        }
    }
    public class RockHurl : Skill
    {
        public RockHurl()
        {
            this.Name = "Rock Hurl";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class WindSlice : Skill
    {
        public WindSlice()
        {
            this.Name = "Wind Slice";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class WaterBlast : Skill
    {
        public WaterBlast()
        {
            this.Name = "Water Blast";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }


    // PRIEST SKILLS
    public class Heal : Skill
    {
        public Heal()
        {
            this.Name = "Heal";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
            target.CharStatEffects.Add(new HealPerTurn("Heal", 10, 2));
        }
    }
    public class Smite : Skill
    {
        public Smite()
        {
            this.Name = "Smite";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class Baptize : Skill
    {
        public Baptize()
        {
            this.Name = "Baptize";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }


    // ROGUE SKILLS
    public class Stealth : Skill
    {
        public Stealth()
        {
            this.Name = "Stealth";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class Poison : Skill
    {
        public Poison()
        {
            this.Name = "Poison";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class Dagger : Skill
    {
        public Dagger()
        {
            this.Name = "Dagger";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }

    // ARCHER SKILLS
    public class Lock : Skill
    {
        public Lock()
        {
            this.Name = "Lock";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }

    public class Volley: Skill
    {
        public Volley()
        {
            this.Name = "Volley";
        }

        public override async void Perform(Character target)
        {
            Random random = new Random();
            int randomNumber = random.Next(2, 6);
            MessageBox.Show($"Used {Name} and shoots {randomNumber} times!");

            for (int i = 0; i < randomNumber; i++)
            {
                //MessageBox.Show("hit " + i);
                target.UpdateHealth(-10, target);
                await Task.Delay(500);
            }
        }
    }
    public class Shoot: Skill
    {
        public Shoot()
        {
            this.Name = "Shoot";
        }

        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
            target.UpdateHealth(-5, target);
        }
    }




    // MEMA SKILLS
    public class Empty : Skill
    {
        public Empty()
        {
            this.Name = "";
        }
        public override void Perform(Character target)
        {
        }
    }
    public class HealingPrayers : Skill
    {
        public HealingPrayers()
        {
            this.Name = "Healing Prayers";
        }
        public override void Perform(Character target)
        {
            MessageBox.Show($"Used {Name}");
        }
    }
    public class Recovery : Skill
    {
        public Recovery()
        {
            this.Name = "Recovery";
        }

        public override void Perform(Character target)
        {
            double healValue = 50;
            MessageBox.Show($"Used {Name} and recovered {healValue} health!");
            //target.Health += healValue;
            target.UpdateHealth(-50, target);
        }
    }
}
