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
        public double Health { get; set; }
        public double Accuracy { get; set; }
        public double AttackDamage { get; set; }
        public double Speed{ get; set; }
        public Skill[] CharSkills { get; set; }
        public double Rizz{ get; set; }
        public string Image { get; set; }
        public double Defense { get; set; }
        public List<StatusEffect> CharStatEffects { get; set; }
        public Character Opposition { get; set; }
        public double CritChance { get; set; }
        Form1 battleForm = Form1.Instance;
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
        // for this part, gamit kayo ng negative value for 'double value' para maconsider sya bawas and postive value for dagdag//
        public void UpdateHealth(double value, Character target)
        {
            // target.defense is 10
            double attack = value;


            double totalDamage = attack;


            target.Health += totalDamage;
            battleForm.updateLabels();
        }
        public void UpdateAccuracy(double value, Character target)
        {
            target.Accuracy += value;
        }
        public void UpdateAttackDamage(double value, Character target)
        {
            target.AttackDamage += value;
        }
        public void UpdateSpeed(double value, Character target)
        {
            target.Speed += value;
        }
        public void UpdateRizz(double value, Character target)
        {
            target.Rizz += value;
        }
        public void UpdateDefense(double value, Character target)
        {
            target.Defense += value;
        }
        public void UpdateCoin(double value, Bloo bloo)
        {
            bloo.Defense += value;
        }
        public void UpdateLives(double value, Bloo bloo)
        {
            bloo.Lives += value;
        }
        public void UpdateCritChance(double value, Character target)
        {
            target.Defense += value;
        }
        /////////////////////////////////
    }
    
    public class Bloo : Character
    {
        public double Coins;
        public double Lives;
        public Bloo(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new Skill[] { new Tackle(), new Goo()};
            Rizz = 20;
            Image = "blooIdle.gif";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            Coins = 100;
            Lives = 3;
            CritChance = 0;
            
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
            CharSkills = new Skill[] { new Slash(),new Block(), new ShieldBash()};
            Rizz = 5;
            Image = "knight.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
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
            CritChance = 0;
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
            CharSkills = new Skill[] { new Heal(), new Smite(), new Baptize()};
            Rizz = 5;
            Image = "priest.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
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
            CharSkills = new Skill[] { new Stealth(), new Poison(), new Dagger()};
            Rizz = 5;
            Image = "wiz.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
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
            CharSkills = new Skill[] { new Lock(), new Volley(), new Shoot()};
            Rizz = 5;
            Image = "archer.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
        }

    }

}
