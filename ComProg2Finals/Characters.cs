using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComProg2Finals
{
    public class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Accuracy { get; set; }
        public int AttackDamage { get; set; }
        public int Speed{ get; set; }
        public Skill[] CharSkills { get; set; }
        public int Rizz{ get; set; }
        public string Image { get; set; }
        public int Defense { get; set; }
        public List<StatusEffect> CharStatEffects { get; set; }
        public Character Opposition { get; set; }

        public Character(string name)
        {
            
            Name = name;
            /*
            Health = health;
            Accuracy = accuracy;
            AttackDamage = atkdmg;
            Speed = speed;
            CharSkills = skills;
            Rizz = rizz;
        */
        }

        public virtual void UseSkill1(Character target)
        {
            CharSkills[0].Perform(target);
        }
        public virtual void UseSkill2(Character target)
        {
            CharSkills[1].Perform(target);
        }
        public virtual void UseSkill3(Character target)
        {
            CharSkills[2].Perform(target);
        }
        public virtual void UseSkill4(Character target)
        {
            CharSkills[3].Perform(target);
        }
    }
    
    public class Bloo : Character
    {
        public Bloo(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new Skill[] { new Tackle(), new Goo(), new Empty(), new Empty() };
            Rizz = 5;
            Image = "blooIdle.gif";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
        }
    }

    public class Knight : Character
    {
        public Knight(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new Skill[] { new Slash(),new Block(), new ShieldBash(), new Empty() };
            Rizz = 5;
            Image = "knight.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
        }

    }
    public class Wizard : Character
    {
        public Wizard(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new Skill[] { new Fireball(), new RockHurl(), new WindSlice(), new WaterBlast() };
            Rizz = 5;
            Image = "wiz.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
        }

    }
    public class Priest: Character
    {
        public Priest(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new Skill[] { new Heal(), new Smite(), new Baptize(), new Empty() };
            Rizz = 5;
            Image = "priest.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
        }

    }
    public class Rogue: Character
    {
        public Rogue(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new Skill[] { new Stealth(), new Poison(), new Dagger() , new Empty() };
            Rizz = 5;
            Image = "wiz.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
        }

    }
    public class Archer : Character
    {
        public Archer(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new Skill[] { new Lock(), new Volley(), new Shoot(), new Empty() };
            Rizz = 5;
            Image = "archer.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
        }

    }

}
