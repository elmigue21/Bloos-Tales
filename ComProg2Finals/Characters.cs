using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public class Character
    {
        public string Name { get; set; }
        public double Health { get; set; }
        public double Accuracy { get; set; }
        public double AttackDamage { get; set; }
        public double Speed{ get; set; }
        public List<Skill> CharSkills { get; set; }
        public double Rizz{ get; set; }
        public string Image { get; set; }
        public double Defense { get; set; }
        public List<StatusEffect> CharStatEffects { get; set; }
        public Character Opposition { get; set; }
        public double CritChance { get; set; }
        public double CritDamage { get; set; }
        public List<Items> PlayerItems { get; set; }
        Form1 battleForm = Form1.Instance;
        public double Multiplier { get; set; }
        public bool isBlocking { get; set; }
        public bool hasTurn { get; set; }
        public string elementType { get; set; }
        public Character(string name)
        {
            
            Name = name;
            Multiplier = 1;
            CritDamage = 1.5;
            hasTurn = true;
            isBlocking = false;
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
        public void DamageCharac(double dmgValue, Character user)
        {
            //MessageBox.Show("multiplier sa formula: "+ user.Multiplier.ToString());
            if (user.Opposition.isBlocking)
            {
                MessageBox.Show($"{user.Opposition.Name} was unscathed!");
                user.Opposition.isBlocking = false;
            }
            else
            {
                double totalDamage = ((user.AttackDamage * dmgValue) / user.Opposition.Defense) * user.Multiplier;

                Random random = new Random();
                int randomNumber = random.Next(0, 101);
                if (randomNumber <= user.CritChance)
                {
                    MessageBox.Show("CRIT!");
                    totalDamage *= user.CritDamage;
                }
                MessageBox.Show( user.Name+ " dealt " + totalDamage + " damage to " + user.Opposition.Name);
                user.Opposition.Health -= totalDamage;
            }
            battleForm.updateLabels();
        }
        public void ElementDamageCharac(double dmgValue, Character user, string dmgType)
        {
            switch (dmgType)
            {
                case "Fire":
                    switch (user.Opposition.elementType)
                    {
                        case "Wind":
                            dmgValue *= 2;
                            MessageBox.Show("its super effective");
                            break;
                        case "Water":
                            dmgValue /= 2;
                            MessageBox.Show("it wasnt very effective");
                            break;
                    }
                    break;
                case "Water":
                    switch (user.Opposition.elementType)
                    {
                        case "Fire":
                            dmgValue *= 2;
                            MessageBox.Show("its super effective");
                            break;
                        case "Earth":
                            dmgValue /= 2;
                            MessageBox.Show("it wasnt very effective");
                            break;
                    }
                    break;
                case "Wind":
                    switch (user.Opposition.elementType)
                    {
                        case "Earth":
                            dmgValue *= 2;
                            MessageBox.Show("its super effective");
                            break;
                        case "Fire":
                            dmgValue /= 2;
                            MessageBox.Show("it wasnt very effective");
                            break;
                    }
                    break;
                case "Earth":
                    switch (user.Opposition.elementType)
                    {
                        case "Water":
                            dmgValue *= 2;
                            MessageBox.Show("its super effective");
                            break;
                        case "Wind":
                            dmgValue /= 2;
                            MessageBox.Show("it wasnt very effective");
                            break;
                    }
                    break;
            }
            DamageCharac(dmgValue, user);
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
            AttackDamage = 20;
            Speed = 10;
            CharSkills = new List<Skill> { new Tackle(), new Goo(), new Bounce()};
            Rizz = 20;
            Image = "blooIdle.gif";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            Coins = 100;
            Lives = 3;
            CritChance = 0;
            PlayerItems = new List<Items> { };
            elementType = "Fire";

        }
    }

    public class Knight : Character
    {
        public Knight(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 20;
            Speed = 10;
            CharSkills = new List<Skill> { new Slash(),new Block(), new ShieldBash()};
            Rizz = 5;
            Image = "knight.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 100;
        }

    }
    public class Wizard : Character
    {
        public string wizardType;
        public Wizard(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 1;
            Speed = 10;
            CharSkills = new List<Skill> { new Fireball(), new RockHurl(), new WindSlice(), new WaterBlast() };
            Rizz = 5;
            Image = "wiz.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
        }


    }
    public class FireWizard : Wizard
    {
        public FireWizard(string name): base(name)
        {
            Image = "firewizard.png";
            elementType = "Fire";
        }
    }
    public class WaterWizard : Wizard
    {
        public WaterWizard(string name) : base(name)
        {
            Image = "waterwizard.png";
            elementType = "Water";
        }
    }
    public class WindWizard : Wizard
    {
        public WindWizard(string name) : base(name)
        {
            Image = "windwizard.png";
            elementType = "Wind";
        }
    }
    public class EarthWizard : Wizard
    {
        public EarthWizard(string name) : base(name)
        {
            Image = "earthwizard.png";
            elementType = "Earth";
        }
    }

    public class Priest: Character
    {
        public Priest(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 1;
            Speed = 10;
            CharSkills = new List<Skill> { new Heal(), new Smite(), new Baptize()};
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
            AttackDamage = 1;
            Speed = 10;
            CharSkills = new List<Skill> { new Stealth(), new Poison(), new Dagger()};
            Rizz = 5;
            Image = "rogue.png";
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
            AttackDamage = 1;
            Speed = 10;
            CharSkills = new List<Skill> { new Lock(), new Volley(), new Shoot()};
            Rizz = 5;
            Image = "archer.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
        }

    }
    public class HostileChest : Character
    {
        public HostileChest(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 1;
            Speed = 10;
            CharSkills = new List<Skill> { new Chomp(), new Haul()};
            Rizz = 5;
            Image = "evilchest.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
        }

    }

}
