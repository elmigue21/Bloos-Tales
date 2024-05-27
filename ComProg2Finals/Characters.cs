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
using System.IO;


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

        public virtual async Task EventAction1(Bloo bloo)
        {

        }
        public virtual async Task EventAction2(Bloo bloo)
        {

        }
        public virtual async Task EventAction3(Bloo bloo)
        {

        }
        public virtual async Task EventAction4(Bloo bloo)
        {

        }
        public virtual async Task EventAction5(Bloo bloo)
        {

        }
        public virtual async Task EventAction6(Bloo bloo)
        {

        }


    }
    public class Character : EncounterClass
    {
        //public string Name { get; set; }
        public double Health { get; set; }
        public double MaxHealth { get; set; }
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
        public double ElementMultiplier = 2;
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
            CharSkills[0].Perform(player);
        }
        public virtual void UseSkill2(Character player)
        {
            CharSkills[1].Perform(player);
        }
        public virtual void UseSkill3(Character player)
        {
            CharSkills[2].Perform(player);
        }
        public virtual void UseSkill4(Character player)
        {
            CharSkills[3].Perform(player);
        }
        public virtual void ChangeRizz(double val)
        {
            if (this.Rizz + val > 100)
            {
                this.Rizz = 100;
            }
            else if (this.Rizz + val < 0)
            {
                this.Rizz = 0;
            }
            else
            {
                this.Rizz += val;
            }
        }
        public virtual void ChangeHealth(double val)
        {
            if (this.Health + val > this.MaxHealth)
            {
                this.Health = this.MaxHealth;
            }
            else if (this.Health + val < 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health += val;
            }
        }

        
        public virtual async Task DamageCharac(double dmgValue, Character user, string skillName)
        {
            battleForm.dialogueTextBox.Text = user.Name + " used " + skillName;
            await Task.Delay(2000);

            if (skillName == "ShieldBash")
            {
                battleForm.dialogueTextBox.Text = user.Name + " stunned " + user.Opposition.Name + "!";
            }
            //string soundFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "swordsound.wav");
           // SoundPlayer player = new SoundPlayer(soundFilePath);
           // player.Play();
            Random accRandom = new Random();
            int accuracyRandom = accRandom.Next(0, 100);
            if (accuracyRandom <= user.Accuracy)
            {
                if (user.Opposition.isBlocking)
                {
                    await Task.Delay(2000);
                    battleForm.dialogueTextBox.Text = $"{user.Opposition.Name} was unscathed!";
                    await Task.Delay(2000);
                    user.Opposition.isBlocking = false;
                }
                else
                {
                    double totalDamage = ((user.AttackDamage * dmgValue) / user.Opposition.Defense + 3) * user.Multiplier;
                    Random random = new Random();
                    bool isCrit = false;
                    int randomNumber = random.Next(0, 101);
                    if (randomNumber <= user.CritChance)
                    {
                        isCrit = true;
                        totalDamage *= user.CritDamage;
                    }
                    if (!isCrit)
                    {
                        await Task.Delay(2000);
                        battleForm.dialogueTextBox.Text = user.Name + " dealt " + totalDamage + " damage to " + user.Opposition.Name;
                        await Task.Delay(2000);
                    }
                    else
                    {
                        await Task.Delay(2000);
                        battleForm.dialogueTextBox.Text = user.Name + " dealt " + totalDamage + " critical damage to " + user.Opposition.Name;
                        await Task.Delay(2000);
                    }
                    user.Opposition.ChangeHealth(-totalDamage);

                    if (user.Opposition.GetType() == typeof(Bloo) && user.Opposition.PlayerItems.Any(item => item.GetType() == typeof(SpikedHelmet))) {
                        
                        double returnedDamage = totalDamage / 2;
                        user.ChangeHealth(-returnedDamage);
                        //MessageBox.Show("Damage dealt to bloo was reflected due to the spiked helmet! returned " + returnedDamage + " damage");
                        await Task.Delay(2000);
                        battleForm.dialogueTextBox.Text = "Damage dealt to bloo was reflected due to the spiked helmet! returned " + returnedDamage + " damage";
                        await Task.Delay(2000);
                    }
                    
                }
            }
            else
            {
                await Task.Delay(2000);
                battleForm.dialogueTextBox.Text = $"{user.Name} tries to attack but misses!";
                await Task.Delay(2000);
            }
            battleForm.updateLabels();
            battleForm.checkWinner();
        }
        public virtual async Task ChangeAccuracy(double val)
        {
            if (this.Accuracy + val  <= 60)
            {
                this.Accuracy = 60;
            }
            else if (this.Accuracy + val >= 100)
            {
                this.Accuracy = 100;
            }
            else
            {
                this.Accuracy += val;
                await Task.Delay(2000);
                battleForm.dialogueTextBox.Text = $"Accuracy of {this.Name} became {this.Accuracy}";
                await Task.Delay(2000);
            }

        }

            public async Task ElementDamageCharac(double dmgValue, Character user, string dmgType, string skillName)
        {
            switch (dmgType)
            {
                case "Fire":
                    switch (user.Opposition.elementType)
                    {
                        case "Wind":
                            dmgValue *= ElementMultiplier;
                            dmgValue *= 2;
                            await Task.Delay(2000);
                            battleForm.dialogueTextBox.Text = "its super effective";
                            await Task.Delay(2000);
                            break;
                        case "Water":
                            dmgValue /= 2;
                            await Task.Delay(2000);
                            battleForm.dialogueTextBox.Text = "it wasnt very effective";
                            await Task.Delay(2000);
                            break;
                    }
                    break;
                case "Water":
                    switch (user.Opposition.elementType)
                    {
                        case "Fire":
                            dmgValue *= ElementMultiplier;
                            dmgValue *= 2;
                            await Task.Delay(2000);
                            battleForm.dialogueTextBox.Text = "its super effective";
                            await Task.Delay(2000);
                            break;
                        case "Earth":
                            dmgValue /= 2;
                            await Task.Delay(2000);
                            battleForm.dialogueTextBox.Text = "it wasnt very effective";
                            await Task.Delay(2000);
                            break;
                    }
                    break;
                case "Wind":
                    switch (user.Opposition.elementType)
                    {
                        case "Earth":
                            dmgValue *= ElementMultiplier;
                            dmgValue *= 2;
                            await Task.Delay(2000);
                            battleForm.dialogueTextBox.Text = "its super effective";
                            await Task.Delay(2000);
                            break;
                        case "Fire":
                            dmgValue /= 2;
                            await Task.Delay(2000);
                            battleForm.dialogueTextBox.Text = "it wasnt very effective";
                            await Task.Delay(2000);
                            break;
                    }
                    break;
                case "Earth":
                    switch (user.Opposition.elementType)
                    {
                        case "Water":
                            dmgValue *= ElementMultiplier;
                            dmgValue *= 2;
                            await Task.Delay(2000);
                            battleForm.dialogueTextBox.Text = "its super effective";
                            await Task.Delay(2000);
                            break;
                        case "Wind":
                            dmgValue /= 2;
                            await Task.Delay(2000);
                            battleForm.dialogueTextBox.Text = "it wasnt very effective";
                            await Task.Delay(2000);
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
        public double discount;
        public bool canGainCoin;
        public bool canUseRizz;
        public bool canGetItem;
        public Bloo(string name) : base(name)
        {
            Name = name;
            Health = 50;
            MaxHealth = 50;
            Accuracy = 100;
            AttackDamage = 999;
            Speed = 10;
            CharSkills = new List<Skill> { new Tackle(), new Goo(), new Bounce()};
            Rizz = 50;
            picImage = "blooIdle.gif";
            Defense = 15;
            CharStatEffects = new List<StatusEffect> { };
            Coins = 500;
            Lives = 3;
            CritChance = 0;
            PlayerItems = new List<Items> { };
            elementType = "Wind";
            skillProbability = new int[]{ -1,-1,-1,-1};
            coinGainMultiplier = 1;
            rizzGainMultiplier = 1;
            canGainCoin = true;
            canUseRizz = true;
            discount = 1;
        }

        public void ChangeCoin(double value)
        {
            if(this.Coins + value <= 0)
            {
                this.Coins = 0;
            }
            else if (this.canGainCoin)
            {
                this.Coins += value;
            }
        }
    }
    public class Knight : Character
    {
        KnightDialogue KnightDiag = new KnightDialogue();
        public Knight(string name) : base(name)
        {
            Name = name;
            Health = 120;
            MaxHealth = 120;
            Accuracy = 100;
            AttackDamage = 15;
            Speed = 10;
            CharSkills = new List<Skill> { new Slash(),new Block(), new ShieldBash()};
            Rizz = 5;
            picImage = "knight.png";
            Defense = 25;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 100;
            skillProbability = new int[] { 33, 33,33, -1};
            EncounterDialogue = KnightDiag.EntranceDialogue;
            Interactions = new string[] { "Attack", "Rizz"};
            befEncounter = KnightDiag.IntroductionDialogue;
            KeyItem = typeof(Excalibur);
        }
        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = KnightDiag.AttackDialogue;
            await Task.Delay(2000);
            form2.EnterBattle();
        }
        public override async Task EventAction2(Bloo bloo)
        {
            if (bloo.Rizz >= 100 && bloo.canUseRizz)
            {  
                form2.dialogueTextBox.Text = KnightDiag.RizzDialogue;
                await Task.Delay(2000);
                form2.runNextEncounter();
            }
            else
            {
                EventAction1(bloo);
            }
        }
    }
    public class Wizard : Character
    {
        WizardDialogue WizardDiag = new WizardDialogue();
        public string wizardType;
        private static Random random = new Random();
        public Wizard(string name) : base(name)
        {
            Name = name;
            Health = 70;
            MaxHealth = 70;
            Accuracy = 100;
            AttackDamage = 35;
            Speed = 10;
            CharSkills = new List<Skill> { new Fireball(), new RockHurl(), new WindSlice(), new WaterBlast() };
            Rizz = 5;
            picImage = "wiz.png";
            Defense = 5;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            EncounterDialogue = WizardDiag.EntranceDialogue;
            Interactions = new string[] { "Attack", "Rizz"};
            befEncounter = WizardDiag.IntroductionDialogue;
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
        public static Wizard CreateRandomWizard()
        {
            int elementType = random.Next(0, 4);

            switch (elementType)
            {
                case 0:
                    return new WaterWizard("Water Wizard");
                case 1:
                    return new EarthWizard("Earth Wizard");
                case 2:
                    return new FireWizard("Fire Wizard");
                case 3:
                    return new WindWizard("Wind Wizard");
                default:
                    throw new Exception("Invalid element type generated.");
            }
        }
        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = WizardDiag.AttackDialogue;
            await Task.Delay(2000);
            form2.EnterBattle();
        }
        public override async Task EventAction2(Bloo bloo)
        {
            if (bloo.Rizz >= 100 && bloo.canUseRizz)
            {
                form2.dialogueTextBox.Text = WizardDiag.RizzDialogue;
                await Task.Delay(2000);
                form2.runNextEncounter();
            }
            else
            {
                EventAction1(bloo);
            }
        }
        public override async Task EventAction3(Bloo bloo)
        {
            form2.dialogueTextBox.Text = WizardDiag.PassIntroDialogue;
            await Task.Delay(2000);
            form2.dialogueTextBox.Text = WizardDiag.PassDialogue;
            await Task.Delay(2000);
        }
    }

    public class FireWizard : Wizard
    {
        public FireWizard(string name): base(name)
        {
            picImage = "wizard_fire.png";
            elementType = "Fire";
        }
    }
    public class WaterWizard : Wizard
    {
        public WaterWizard(string name) : base(name)
        {
            picImage = "wizard_water.png";
            elementType = "Water";
        }
    }
    public class WindWizard : Wizard
    {
        public WindWizard(string name) : base(name)
        {
            picImage = "wizard_wind.png";
            elementType = "Wind";
        }
    }
    public class EarthWizard : Wizard
    {
        public EarthWizard(string name) : base(name)
        {
            picImage = "wizard_earth.png";
            elementType = "Earth";
        }
    }
    public class Priest: Character
    {
        PriestDialogue PriestDiag = new PriestDialogue();
        public bool canRevive;
        public Priest(string name) : base(name)
        {
            Name = name;
            Health = 50;
            MaxHealth = 50;
            Accuracy = 110;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new List<Skill> { new Heal(), new Smite(), new Purify()};
            Rizz = 5;
            picImage = "priest.png";
            Defense = 18;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 33, 33, 33, -1 };
            EncounterDialogue = PriestDiag.EntranceDialogue;
            Interactions = new string[] { "Attack", "Rizz"};
            befEncounter = PriestDiag.IntroductionDialogue;
            KeyItem = typeof(HolyWater);
            canRevive = true;
        }
        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = PriestDiag.AttackDialogue;
            await Task.Delay(2000);
            form2.EnterBattle();
        }
        public override async Task EventAction2(Bloo bloo)
        {
            if (bloo.Rizz == 100 && bloo.canUseRizz)
            {
                form2.dialogueTextBox.Text = PriestDiag.AttackDialogue;
                await Task.Delay(2000);
                form2.runNextEncounter();
            }
            else
            {
                EventAction1(bloo);
            }
        }
        public override async Task EventAction3(Bloo bloo)
        {
            form2.dialogueTextBox.Text = PriestDiag.PassIntroDialogue;
            await Task.Delay(2000);
            form2.dialogueTextBox.Text = PriestDiag.PassDialogue;
            await Task.Delay(2000);
        }
    }
    public class Rogue: Character
    {
        RogueDialogue RogueDiag = new RogueDialogue();
        public Rogue(string name) : base(name)
        {
            Name = name;
            Health = 85;
            MaxHealth = 85;
            Accuracy = 100;
            AttackDamage = 25;
            Speed = 10;
            CharSkills = new List<Skill> { new Stealth(), new Poison(), new Dagger()};
            Rizz = 5;
            picImage = "rogue.png";
            Defense = 16;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 33, 33, 33, -1 };
            Interactions = new string[] { "Attack", "Rizz"};
            EncounterDialogue = RogueDiag.EntranceDialogue;
            befEncounter = RogueDiag.IntroductionDialogue;
            KeyItem = typeof(StrangeGem);
        }
        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = RogueDiag.AttackDialogue;
            await Task.Delay(2000);
            form2.EnterBattle();
        }
        public override async Task EventAction2(Bloo bloo)
        {
            if (bloo.Rizz >= 100 && bloo.canUseRizz)
            {
                form2.dialogueTextBox.Text = RogueDiag.RizzDialogue;
                await Task.Delay(2000);
                form2.runNextEncounter();
            }
            else
            {
                EventAction1(bloo);
            }
        }
        public override async Task EventAction3(Bloo bloo)
        {
            form2.dialogueTextBox.Text = RogueDiag.PassIntroDialogue;
            await Task.Delay(2000);
            form2.dialogueTextBox.Text = RogueDiag.PassDialogue;
            await Task.Delay(2000);
        }

    }
    public class Archer : Character
    {
        ArcherDialogue ArcherDiag = new ArcherDialogue();
        public Archer(string name) : base(name)
        {
            Name = name;
            Health = 80;
            MaxHealth = 80;
            Accuracy = 100;
            AttackDamage = 30;
            Speed = 10;
            CharSkills = new List<Skill> { new Lock(), new Volley(), new Shoot()};
            Rizz = 5;
            picImage = "archer.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 33, 33, 33, -1 };
            Interactions = new string[] { "Attack", "Rizz"};
            EncounterDialogue = ArcherDiag.EntranceDialogue;
            befEncounter = ArcherDiag.IntroductionDialogue;
            KeyItem = typeof(GoldenArrow);
        }
        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ArcherDiag.AttackDialogue;
            await Task.Delay(2000);
            form2.EnterBattle();
        }
        public override async Task EventAction2(Bloo bloo)
        {
            if (bloo.Rizz >= 100 && bloo.canUseRizz)
            {
                form2.dialogueTextBox.Text = ArcherDiag.RizzDialogue;
                await Task.Delay(2000);
                form2.runNextEncounter();
            }
            else
            {
                EventAction1(bloo);
            }
        }
        public override async Task EventAction3(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ArcherDiag.PassIntroDialogue;
            await Task.Delay(2000);
            form2.dialogueTextBox.Text = ArcherDiag.PassDialogue;
            await Task.Delay(2000);
        }
    }
    public class HostileChest : Character
    {
        ChestyDialogue ChestyDiag = new ChestyDialogue();
        public HostileChest(string name) : base(name)
        {
            Name = name;
            Health = 100;
            MaxHealth = 100;
            Accuracy = 100;
            AttackDamage = 10;
            Speed = 10;
            CharSkills = new List<Skill> { new Chomp(), new Haul()};
            Rizz = 5;
            picImage = "chesty_mimic.png";
            Defense = 10;
            CharStatEffects = new List<StatusEffect> { };
            CritChance = 0;
            skillProbability = new int[] { 50, 50, -1, -1 };
            EncounterDialogue = "KWAK";
        }
        public override async Task DamageCharac(double dmgValue, Character user, string skillName)
        {
            Random accRandom = new Random();
            int accuracyRandom = accRandom.Next(0, 100);
            if (accuracyRandom <= user.Accuracy)
            {


                if (user.Opposition.isBlocking)
                {
                    await Task.Delay(2000);
                    battleForm.dialogueTextBox.Text = $"{user.Opposition.Name} was unscathed!";
                    await Task.Delay(2000);
                    user.Opposition.isBlocking = false;
                }
                else
                {


                    double totalDamage = ((user.AttackDamage * dmgValue) / user.Opposition.Defense) * user.Multiplier;
                    Random random = new Random();
                    int randomNumber = random.Next(0, 101);
                    if (randomNumber <= user.CritChance)
                    {
                        await Task.Delay(2000);
                        battleForm.dialogueTextBox.Text = "CRIT!";
                        await Task.Delay(2000);
                        totalDamage *= user.CritDamage;
                    }
                    await Task.Delay(2000);
                    battleForm.dialogueTextBox.Text = user.Name + " dealt " + totalDamage + " damage to " + user.Opposition.Name;
                    await Task.Delay(2000);
                    user.Opposition.Health -= totalDamage;
                    Random rand = new Random();
                    int rando = new Random().Next(0, 101);
                    if (rando <= 30)
                    {
                        user.Health -= totalDamage / 2;
                      //  MessageBox.Show(user.Opposition.Name + " reflected the damage!");
                        user.Health -= totalDamage;
                        await Task.Delay(2000);
                        battleForm.dialogueTextBox.Text = user.Opposition.Name + " reflected the damage!";
                        await Task.Delay(2000);
                    }
                }
            }
            else
            {
                await Task.Delay(2000);
                battleForm.dialogueTextBox.Text = $"{user.Name} tries to attack but misses!";
                await Task.Delay(2000);
            }
        
            battleForm.updateLabels();
        }



    }


    public class Peech : Character
    {
        public SoundPlayer musicBG;
        GoodEndingDialogue GoodEndDiag = new GoodEndingDialogue();
        BadEndingDialogue BadEndDiag = new BadEndingDialogue();
        public Peech(string name) : base(name)
        {
            Name = "Peech";
            Interactions = new string[]{"Talk"};
            picImage = "peech_idle.gif";

        }
        public override async Task EventAction1(Bloo bloo)
        {
            if(bloo.Rizz >= 100)
            {
                Stream soundStream = Properties.Resources.Ending;
                musicBG = new SoundPlayer(soundStream);
                musicBG.PlayLooping();
                await Task.Delay(2000);
                form2.dialogueTextBox.Text = GoodEndDiag.CommitEvent1;
                await Task.Delay(5000);
                form2.dialogueTextBox.Text = GoodEndDiag.CommitEvent2;
                await Task.Delay(5000);
                form2.dialogueTextBox.Text = GoodEndDiag.CommitEvent3;
                await Task.Delay(5000);
                form2.dialogueTextBox.Text = GoodEndDiag.CommitEvent4;
                await Task.Delay(5000);
                form2.dialogueTextBox.Text = GoodEndDiag.CommitEvent5;
                await Task.Delay(5000);
            }
            else
            {
                Stream soundStream = Properties.Resources.Ending;
                musicBG = new SoundPlayer(soundStream);
                musicBG.PlayLooping();
                await Task.Delay(2000);
                form2.dialogueTextBox.Text = BadEndDiag.CommitEvent1;
                await Task.Delay(5000);
                form2.dialogueTextBox.Text = BadEndDiag.CommitEvent2;
                await Task.Delay(5000);
                form2.dialogueTextBox.Text = BadEndDiag.CommitEvent3;
                await Task.Delay(5000);
                Stream soundStreams = Properties.Resources.Bad_Ending;
                musicBG = new SoundPlayer(soundStreams);
                musicBG.PlayLooping();
                form2.dialogueTextBox.Text = BadEndDiag.CommitEvent4;
                await Task.Delay(5000);
                form2.dialogueTextBox.Text = BadEndDiag.CommitEvent5;
                await Task.Delay(5000);
            }
        }
    }




}
