﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace ComProg2Finals
{

    public class EncounterClass {
        public string Name { get; set; }
        public string picImage { get; set; }
        public string[] Interactions { get; set; }
        public string EncounterDialogue { get; set; }
        public Form1 battleForm = Form1.GetInstance();
        public Form2 form2 = Form2.Instance;
        // public Action<Bloo>[] EncounterActions{ get; set; }

        public virtual void EventAction1(Bloo bloo)
        {

        }
        public virtual void EventAction2(Bloo bloo)
        {

        }
        public virtual void EventAction3(Bloo bloo)
        {

        }
        public virtual void EventAction4(Bloo bloo)
        {

        }
        public virtual void EventAction5(Bloo bloo)
        {

        }
        public virtual void EventAction6(Bloo bloo)
        {

        }


    }
    public class Character : EncounterClass
    {
        //public string Name { get; set; }
        public double Health { get; set; }
        public double Accuracy { get; set; }
        public double AttackDamage { get; set; }
        public double Speed{ get; set; }
        public List<Skill> CharSkills { get; set; }
        public double Rizz{ get; set; }
        //public string Image { get; set; }
        public double Defense { get; set; }
        public List<StatusEffect> CharStatEffects { get; set; }
        public Character Opposition { get; set; }
        public double CritChance { get; set; }
        public double CritDamage { get; set; }
        public List<Items> PlayerItems { get; set; }
       // public Form1 battleForm = Form1.Instance;
       // public Form2 form2 = Form2.Instance;
        public double Multiplier { get; set; }
        public bool isBlocking { get; set; }
        public bool hasTurn { get; set; }
        public string elementType { get; set; }
        public Skill skillQueued { get; set; }
        public int[] skillProbability { get; set; }
        public Character PlayerInstance { get; set; }
        public Character(string name)
        {
            
            Name = name;
            Multiplier = 1;
            CritDamage = 1.5;
            hasTurn = true;
            isBlocking = false;
            PlayerInstance = Form2.Player;
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
        
        public virtual void DamageCharac(double dmgValue, Character user)
        {
            //string soundFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "swordsound.wav");
           // SoundPlayer player = new SoundPlayer(soundFilePath);
           // player.Play();
            Random accRandom = new Random();
            int accuracyRandom = accRandom.Next(0, 100);
            if (accuracyRandom <= user.Accuracy)
            {




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
                    MessageBox.Show(user.Name + " dealt " + totalDamage + " damage to " + user.Opposition.Name);
                    user.Opposition.Health -= totalDamage;
                }

            }
            else
            {
                MessageBox.Show($"{user.Name} tries to attack but misses!");
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
            AttackDamage = 999;
            Speed = 10;
            CharSkills = new List<Skill> { new Tackle(), new Goo(), new Bounce()};
            Rizz = 20;
            picImage = "blooIdle.gif";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            Coins = 100;
            Lives = 3;
            CritChance = 0;
            PlayerItems = new List<Items> { };
            elementType = "Wind";
            skillProbability = new int[]{ -1,-1,-1,-1};

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
            CharSkills = new List<Skill> { new Slash(),new Block(), new ShieldBash()};
            Rizz = 5;
            picImage = "knight.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 100;
            skillProbability = new int[] { 33, 33,33, -1};
            EncounterDialogue = "Who goes there";
            Interactions = new string[] { "Attack", "Rizz", "Ignore"};
        }
        public override void EventAction1(Bloo bloo)
        {
            form2.EnterBattle();
            //form2.runNextEncounter();
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show(bloo.Name +" uses Rizz");
        }
        public override void EventAction3(Bloo bloo)
        {
            MessageBox.Show( bloo.Name+" ignores");
            form2.runNextEncounter();
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
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new List<Skill> { new Fireball(), new RockHurl(), new WindSlice(), new WaterBlast() };
            Rizz = 5;
            picImage = "wiz.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            EncounterDialogue = "MAGIICCCCC";
            Interactions = new string[] { "Attack", "Rizz", "Ignore","VANISH" };
            switch (PlayerInstance.elementType)
            {
                case "Fire":
                    skillProbability = new int[] { 10, 10, 10, 70 };
                    break;
                case "Earth":
                    skillProbability = new int[] { 10, 10, 70, 10 };
                    break;
                case "Wind":
                    skillProbability = new int[] { 70, 0, 10, 10 };
                    break;
                case "Water":
                    skillProbability = new int[] { 10, 70, 10, 70 };
                    break;
                default:
                    skillProbability = new int[] { 25, 25, 25, 25 };
                    break;
            }


        }
        public override void EventAction1(Bloo bloo)
        {
            form2.EnterBattle();
        }


    }
    public class FireWizard : Wizard
    {
        public FireWizard(string name): base(name)
        {
            picImage = "firewizard.png";
            elementType = "Fire";
        }
    }
    public class WaterWizard : Wizard
    {
        public WaterWizard(string name) : base(name)
        {
            picImage = "waterwizard.png";
            elementType = "Water";
        }
    }
    public class WindWizard : Wizard
    {
        public WindWizard(string name) : base(name)
        {
            picImage = "windwizard.png";
            elementType = "Wind";
        }
    }
    public class EarthWizard : Wizard
    {
        public EarthWizard(string name) : base(name)
        {
            picImage = "earthwizard.png";
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
            picImage = "priest.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 33, 33, 33, -1 };
            EncounterDialogue = "Healing prayers for you!";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
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
            CharSkills = new List<Skill> { new Stealth(), new Poison(), new Dagger()};
            Rizz = 5;
            picImage = "rogue.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 25, 25, 25, 25 };
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
            EncounterDialogue = "ROGUEEEE";
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
            CharSkills = new List<Skill> { new Lock(), new Volley(), new Shoot()};
            Rizz = 5;
            picImage = "archer.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 33, 33, 33, -1 };
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
            EncounterDialogue = "LEGOLAS DIFF";
        }

    }
    public class HostileChest : Character
    {
        public HostileChest(string name) : base(name)
        {
            Name = name;
            Health = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new List<Skill> { new Chomp(), new Haul()};
            Rizz = 5;
            picImage = "evilchest.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 50, 50, -1, -1 };
            EncounterDialogue = "KWAK";
        }

        public override void DamageCharac(double dmgValue, Character user)
        {
            //MessageBox.Show("multiplier sa formula: "+ user.Multiplier.ToString());
            Random accRandom = new Random();
            int accuracyRandom = accRandom.Next(0, 100);
            if (accuracyRandom <= user.Accuracy)
            {


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
                    MessageBox.Show(user.Name + " dealt " + totalDamage + " damage to " + user.Opposition.Name);
                    user.Opposition.Health -= totalDamage;
                    Random rand = new Random();
                    int rando = new Random().Next(0, 101);
                    if (rando <= 100)
                    {
                        user.Health -= totalDamage;
                        MessageBox.Show(user.Opposition.Name + " reflected the damage!");
                    }
                }
            }
            else
            {
                MessageBox.Show($"{user.Name} tries to attack but misses!");
            }
        
            battleForm.updateLabels();
        }

    }






}
