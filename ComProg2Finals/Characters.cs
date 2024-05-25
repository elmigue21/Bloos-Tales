using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;


namespace ComProg2Finals
{

    public class EncounterClass {
        public string Name { get; set; }
        public string picImage { get; set; }
        public string[] Interactions { get; set; }
        public string EncounterDialogue { get; set; }
        public string befEncounter { get; set; }
        public Form1 battleForm = Form1.GetInstance();
        public Form2 form2 = Form2.Instance;
        private Bloo Player = Form2.Player;
        public Type KeyItem {get;set;}


        public List<Action<Bloo>> EventActions { get; set; }
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
        public List<Action> skillQueue = new List<Action>();
        public int[] skillProbability { get; set; }
        public Character PlayerInstance { get; set; }
        public double DamageTaken { get; set; }
        public Character(string name)
        {
            
            Name = name;
            Multiplier = 1;
            CritDamage = 1.5;
            hasTurn = true;
            isBlocking = false;
            PlayerInstance = Form2.Player;
        }

        public virtual void UseSkill1(Character player)
        {
            //player.skillQueue.Add(() => CharSkills[0].Perform(player));
            CharSkills[0].Perform(player);
        }
        public virtual void UseSkill2(Character player)
        {
           // player.skillQueue.Add(() => CharSkills[1].Perform(player));
            CharSkills[1].Perform(player);
        }
        public virtual void UseSkill3(Character player)
        {
           // player.skillQueue.Add(() => CharSkills[2].Perform(player));
            CharSkills[2].Perform(player);
        }
        public virtual void UseSkill4(Character player)
        {
            //player.skillQueue.Add(() => CharSkills[3].Perform(player));
            CharSkills[3].Perform(player);
        }
        
        public virtual void DamageCharac(double dmgValue, Character user, string skillName)
        {
            MessageBox.Show(user.Name + " used " + skillName);
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
                    bool isCrit = false;
                    int randomNumber = random.Next(0, 101);
                    if (randomNumber <= user.CritChance)
                    {
                        //MessageBox.Show("CRIT!");
                        isCrit = true;
                        totalDamage *= user.CritDamage;
                    }
                    if (!isCrit)
                    {
                        MessageBox.Show(user.Name + " dealt " + totalDamage + " damage to " + user.Opposition.Name);
                    }
                    else
                    {
                        MessageBox.Show(user.Name + " dealt " + totalDamage + " critical damage to " + user.Opposition.Name);
                    }
                    user.Opposition.Health -= totalDamage;
                    
                }
            }
            else
            {
                MessageBox.Show($"{user.Name} tries to attack but misses!");
            }
            battleForm.updateLabels();
        }
        public virtual void LoweringAccuracy(double accuracyValue, Character user)
        {
            double oppAccuracy = user.Opposition.Accuracy;
            oppAccuracy -= accuracyValue;

            if (oppAccuracy >= 40)
            {
                user.Opposition.Accuracy -= accuracyValue;
                MessageBox.Show($"Accuracy of {user.Opposition.Name} became {user.Opposition.Accuracy}");
            }
            else
            {
                user.Opposition.Accuracy = 40;
                MessageBox.Show("Accuracy can't get lower than 40");
            }
        }

            public void ElementDamageCharac(double dmgValue, Character user, string dmgType, string skillName)
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
            DamageCharac(dmgValue, user, skillName);
        }
        /////////////////////////////////
    }
    
    public class Bloo : Character
    {
        public double Coins;
        public double Lives;
        public int coinGainMultiplier;
        public int rizzGainMultiplier;
        public bool canGainCoin;
        public bool canUseRizz;
        public Bloo(string name) : base(name)
        {
            Name = name;
            Health = 50;
            Accuracy = 100;
            AttackDamage = 200;
            Speed = 10;
            CharSkills = new List<Skill> { new Tackle(), new Goo()};
            Rizz = 20;
            picImage = "blooIdle.gif";
            Defense = 40;
            CharStatEffects = new List<StatusEffect> { };
            Coins = 100;
            Lives = 3;
            CritChance = 0;
            PlayerItems = new List<Items> { };
            elementType = "Wind";
            skillProbability = new int[]{ -1,-1,-1,-1};
            coinGainMultiplier = 1;
            rizzGainMultiplier = 1;
            canGainCoin = true;
            canUseRizz = true;
        }
        
        public void GainRizz(double value)
        {
            this.Rizz += value * rizzGainMultiplier;
        }
        public void GainCoin(double value)
        {
            this.Coins += value * coinGainMultiplier;
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
            EncounterDialogue = "I, the honorable knight, shall vanquish this lowly slime!";
            Interactions = new string[] { "Attack", "Rizz"};
            befEncounter = "As Bloo was bouncing his way, a faint sound of clinking metal echoed through the forest…";
            //EventActions.Add(Player => EventAction1(Player));
            //EventActions.Add(Player => EventAction2(Player));
            KeyItem = typeof(Excalibur);
        }
        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("Let us fight to our deaths!");
            form2.EnterBattle();
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("By the gods, this slime is the most beautiful creature next to the princess I have ever seen. I would marry you if I were as gooey as you.");
           // form2.runNextEncounter();
        }
        /*
        public override void EventAction3(Bloo bloo)
        {
            MessageBox.Show("By the heavens! Is that the sword from the stone? The Excalibur?");
            MessageBox.Show("Please, I’m not as worthy as you, humble slime. This honorable knight cannot claim the Excalibur. Use it in your journey and conquer your enemies.");
        }
        */
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
            EncounterDialogue = "OOH! What kind of slime is this? Is it a water type? A fire type? An earth type? Or maybe a wind type?";
            Interactions = new string[] { "Attack", "Rizz"};
            befEncounter = "Bloo bounces his way forward, when suddenly he feels a fearful presence tingling on his gooeyness…";
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
            KeyItem = typeof(Goblet);
        }
        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("It’s big brain time.");
            form2.EnterBattle();
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("From a genius to a genius! Please tell me more about four elementalisms, elucidating the intricacies of earthism, waterism, airism, and fireism, as they intertwine in the grand tapestry of existenceism.");
        }
        public override void EventAction3(Bloo bloo)
        {
            MessageBox.Show("You! Did you put your name on the goblet of fire?! *calmly*");
            MessageBox.Show("Marvelous! What wondrous feats this slime has made, embraced by the goblet’s embrace! A conundrum of magicism and mysterism!");
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
            Health = 50;
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
            EncounterDialogue = "What a cute little creature! But alas, your monstrous nature belies your charm.";
            Interactions = new string[] { "Attack", "Rizz"};
            befEncounter = "As Bloo continued his journey, Bloo began to feel warm… As if he was bouncing through endless purity…";
            KeyItem = typeof(HolyWater);
        }
        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("Your form is an embodiment of evil itself. Fear not, for I shall cleanse thee of its malevolence!");
            form2.EnterBattle();
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("OH MY GOD! Mr. Slime, you are the most adorable thing in the world. I just want to pinch those cheeks!");
        }
        public override void EventAction3(Bloo bloo)
        {
            MessageBox.Show("Divine blessings! This holy water, gifted by thy humble slime, carries the purity of innocence and thy wisdom of unexpected allies. You have my thanks…");
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
            Interactions = new string[] { "Attack", "Rizz"};
            EncounterDialogue = "Man, I’m tired of getting worthless loot…";
            befEncounter = "As the shadows of the forest enveloped Bloo, he noticed a man stalking through the shadows…";
            KeyItem = typeof(StrangeGem);
        }
        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("Let’s see how much gold I can take from this mere slime.");
            form2.EnterBattle();
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("I see… A slime outsmarting me. This is beyond embarrassing, but I admit my inferiority, slime.");
        }
        public override void EventAction3(Bloo bloo)
        {
            MessageBox.Show("...");
            MessageBox.Show("You slime, has made me the richest man in all the land! This is by far one of the rarest gems or might even be the rarest gem!");
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
            Defense = 25;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 33, 33, 33, -1 };
            Interactions = new string[] { "Attack", "Rizz"};
            EncounterDialogue = "In every draw of my bow, fate whispers through the wind, a constant companion to death's embrace.";
            befEncounter = "Bloo felt a slight breeze as he bounces through the grassy fields…";
            KeyItem = typeof(GoldenArrow);
        }
        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("Behold the wind's wrath!");
            form2.EnterBattle();
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Ah, dear slime, your colors dance so vividly. Would you care for a stroll together? I find your company quite... enchanting.");
        }
        public override void EventAction3(Bloo bloo)
        {
            MessageBox.Show("In a sea of dullness, a gleaming arrow is in your hands. May I take a look?");
            MessageBox.Show("By the gods, it's returned to me! This arrow, lost to time's grasp, now rests once more in my hands. With you, old friend, my aim finds its truest mark once again.");
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
        public override void DamageCharac(double dmgValue, Character user, string skillName)
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


    public class Peech : Character
    {
        public Peech(string name) : base(name)
        {
            Name = "Peech";
        }
    }




}
