using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComProg2Finals
{
    
    public class Events : EncounterClass
    {
        public virtual void Perform(Bloo bloo)
        {

        }
    }
    public class Chest : Events
    {
        ChestyDialogue ChestyDiag = new ChestyDialogue();
        public Chest()
        {
            Name = "Chest";
            picImage = "chesty_close.png";
            EncounterDialogue = ChestyDiag.EntranceDialogue;
            Interactions = new string[] { "Open", "Skip" };
        }
        public override void EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ChestyDiag.Option1Dialogue;
            Random random = new Random();
            randomNumber = random.Next(100);

            if (randomNumber <= lifePotChance)
            {
                if (bloo.Lives < 5)
                {
                    bloo.Lives += 1;
                }
                form2.dialogueTextBox.Text = ChestyDiag.CommitEvent1;
                form2.runNextEncounter();
            }
            else if (randomNumber <= lifePotChance + rizzChance)
            {
                bloo.Rizz += gainedRizz;
                form2.dialogueTextBox.Text = ChestyDiag.CommitEvent2;
                form2.runNextEncounter();
            }
            else if (randomNumber <= lifePotChance + rizzChance + coinChance)
            {
                bloo.Coins += 50;
                form2.dialogueTextBox.Text = ChestyDiag.CommitEvent3;
                form2.runNextEncounter();
            }
            else
            {
                    Form2 form2 = Form2.Instance;
                    Form1 form1 = Form1.GetInstance();
                    form1.Enemy = new HostileChest("CHESTY");
                    form1.Enemy.Opposition = bloo;
                    form1.Player = bloo;
                    form1.Player.Opposition = form1.Enemy;
                    form1.Show();
                form2.dialogueTextBox.Text = ChestyDiag.CommitEvent5;
            }

        }
        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ChestyDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }
        int lifePotChance = 10;
        int rizzChance = 20;
        int coinChance = 30;
        int gainedRizz = 20;
        int randomNumber;

    }
    public class Cave : Events
    {
        CaveDialogue CaveDiag = new CaveDialogue();
        public Cave()
        {
            Name = "Cave";
            picImage = "cave.png";
            EncounterDialogue = CaveDiag.EntranceDialogue;
            Interactions = new string[] { "Enter", "Ignore"};
        }

        public override void EventAction1(Bloo bloo)
        {
            Random random = new Random();
            randomNumber = random.Next(1, totalChances + 1);
            if (randomNumber <= loseLifeChance)
            {
                bloo.Lives--;
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent1;
            }
            else if (randomNumber <= loseLifeChance + debuffChance)
            {
                EncounterDialogue = CaveDiag.CommitEvent2;
                Random rand = new Random();
                int chance = rand.Next(0, 4);
                switch (chance)
                {
                    case 0:
                        bloo.Health -= 20;
                        form2.dialogueTextBox.Text = CaveDiag.CommitEvent6;
                        break;
                    case 1:
                        bloo.AttackDamage -= 20;
                        form2.dialogueTextBox.Text = CaveDiag.CommitEvent7;
                        break;
                    case 2:
                        bloo.Coins -= 20;
                        form2.dialogueTextBox.Text = CaveDiag.CommitEvent8;
                        break;
                    case 3:
                        bloo.Rizz -= 20;
                        form2.dialogueTextBox.Text = CaveDiag.CommitEvent9;
                        break;
                }
            }
            else if (randomNumber <= loseLifeChance + debuffChance + coinChance)
            {
                bloo.Coins += 50;
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent3;
            }
            else if (randomNumber <= loseLifeChance + debuffChance + coinChance + rizzChance)
            {
                bloo.Rizz += gainedRizz;
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent4;
            }
            else if (randomNumber <= totalChances)
            {
                StrangeGem strangegem = new StrangeGem();
                strangegem.Acquired(bloo);
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent5;
            }
            else
            {
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent9;
            }
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = CaveDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }

        int totalChances = 800;
        int loseLifeChance = 180;
        int debuffChance = 180;
        int coinChance = 180;
        int rizzChance = 180;
        int gemChance = 80;
        int gainedRizz = 20;
        int randomNumber;
        public override void Perform(Bloo bloo)
        {

        }
    }
    public class SwordInStone : Events
    {
        SwordStoneDialogue SwordStoneDiag = new SwordStoneDialogue();
        public SwordInStone()
        {
            Name = "SwordInStone";
            picImage = "sword_in_stone.png";
            EncounterDialogue = SwordStoneDiag.EntranceDialogue;
            Interactions = new string[] { "Pull", "Ignore" };
        }

        public override void EventAction1(Bloo bloo)
        {
            Random random = new Random();
            randomNumber = random.Next(100);
            if (randomNumber <= pullChance)
            {
                Excalibur excalibur = new Excalibur();
                excalibur.Acquired(bloo);
                form2.dialogueTextBox.Text = SwordStoneDiag.Option1Dialogue;
            }
            else
            {
                form2.dialogueTextBox.Text = SwordStoneDiag.Option2Dialogue;
            }
            form2.runNextEncounter();
        }
                
        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = SwordStoneDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }
        int pullChance = 5;
        int randomNumber;
        public override void Perform(Bloo bloo)
        {

        }
    }
    public class Bonfire : Events
    {
        BonfireDialogue BonFireDiag = new BonfireDialogue();
        public Bonfire()
        {
            Name = "Bonfire";
            picImage = "bonfire.gif";
            EncounterDialogue = BonFireDiag.EntranceDialogue;
            Interactions = new string[] { "Obtain", "Ignore" };
        }

        public override void EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = BonFireDiag.Option1Dialogue;
            if (bloo.Lives < 5)
            {
                form2.dialogueTextBox.Text = BonFireDiag.CommitEvent1;
                bloo.Lives += 1;
            }
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = BonFireDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {

        }
    }
    public class MysteriousMan : Events
    {
        int rand;
        MysteriousManDialogue MysteriousManDiag = new MysteriousManDialogue();
        public MysteriousMan()
        {
            Name = "Mysterious man";
            picImage = "mysterious_man.png";
            EncounterDialogue = MysteriousManDiag.EntranceDialogue;
            Interactions = new string[] { "Blue pill", "Red Pill"};
            Random random = new Random();
            rand = random.Next(0, 2);            
        }
        int choice;       

        public override void EventAction1(Bloo bloo)
        {
            switch (rand)
            {
                case 0:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent1;
                    bloo.Health -= bloo.Health * .25;
                    break;
                case 1:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent2;
                    bloo.Accuracy -= 25;
                    break;
                case 2:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent3;
                    bloo.coinGainMultiplier /= 2;
                    // minus coin income
                    break;
            }
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {
            switch (rand)
            {
                case 0:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent4;
                    bloo.AttackDamage += 20;
                    break;
                case 1:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent5;
                    bloo.CritChance += 25;
                    break;
                case 2:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent6;
                    // buff rizz income
                    bloo.rizzGainMultiplier *= 2;
                    break;
            }
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {

        }
    }
    public class Jester : Events
    {
        JesterDialogue JesterDiag = new JesterDialogue();
        public Jester()
        {
            Name = "Jester";
            picImage = "jester.png";
           // EncounterDialogue = "KWAK";
           // picImage = "wishingwell.png";
            EncounterDialogue = JesterDiag.EntranceDialogue;
            Interactions = new string[] { "Talk", "Ignore" };
        }
        public override void EventAction1(Bloo bloo)
        {
            // add mystery box logic
//            MessageBox.Show("I have a little mystery box for you giggles. What's inside? What’s inside? Oh, the excitement! Well, that’s the fun part, isn’t it? It could be a delightful surprise... or a dreadful shock!” *giggles louder");
            MysteryBox mysterybox = new MysteryBox();
            mysterybox.Acquired(bloo);
            form2.dialogueTextBox.Text = JesterDiag.EntranceDialogue;
            bloo.Coins -= bloo.Coins * .75;
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = JesterDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }

    }
    public class Seer : Events
    {
        SeerDialogue SeerDiag = new SeerDialogue();
        public Seer()
        {
            Name = "Seer";
            picImage = "seer.png";
            EncounterDialogue = SeerDiag.EntranceDialogue;
            Interactions = new string[] { "Talk", "Ignore" };   
        }
        public override void EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = SeerDiag.Option1Dialogue;
            Random random = new Random();
            int rand = random.Next(0, 4);
           // rand = 0;
            switch (rand)
            {
                case 0:
                    int bossCount = form2.encounterCount / 5;
                    bloo.Rizz -= bloo.Rizz * .3;
                    break;
                case 1:
                    bloo.Coins -= 150;
                        bloo.PlayerItems.Add(new SeerBuff(rand));
                    break;
                case 2:
                    bloo.Coins -= 100;
                        bloo.PlayerItems.Add(new SeerBuff(rand));
                    break;
                case 3:
                    bloo.Coins -= 50;
                        bloo.PlayerItems.Add(new SeerBuff(rand));
                    break;
                case 4:
                    bloo.Coins -= 50;
                        bloo.PlayerItems.Add(new SeerBuff(rand));

                    break;
            }
            form2.runNextEncounter();
        }
        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = SeerDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }
    }
    public class WishingWell : Events
    {
        int choice;
        int multiplier = 1;
        WishingWellDialogue WishingWellDiag = new WishingWellDialogue();
        ItemsDialogue ItemsDiag = new ItemsDialogue();
        public WishingWell()
        {
            Name = "Wishing well";
            this.picImage = "wishing_well.png";
            Interactions = new string[] { "Make Wish", "Ignore" };
            EncounterDialogue = WishingWellDiag.EntranceDialogue;
            Interactions = new string[] { "Wish", "Ignore" };
        }

        public override void EventAction1(Bloo bloo)
        {
            bloo.Coins -= 2 * multiplier;
            form2.dialogueTextBox.Text = WishingWellDiag.Option1Dialogue;
            Random random = new Random();
            int randomNumber = random.Next(100);
            if (randomNumber >= 1 && randomNumber <= 25)
            {
                MysteryPotion mysterypotion = new MysteryPotion();
                mysterypotion.Acquired(bloo);
                form2.dialogueTextBox.Text = WishingWellDiag.CommitEvent1;
            }
            else if (randomNumber >= 26 && randomNumber <= 30)
            {

                HolyWater holywater = new HolyWater();
                holywater.Acquired(bloo);
                form2.dialogueTextBox.Text = WishingWellDiag.CommitEvent1;
                form2.dialogueTextBox.Text = ItemsDiag.HolyWaterDialogue;
            }
            else
            {
                form2.dialogueTextBox.Text = WishingWellDiag.CommitEvent2;
            }
            multiplier++;
        }
        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = WishingWellDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }
      
    }
    public class King : Events
    {
        KingDialogue KingDiag = new KingDialogue();
        public King()
        {
            Name = "KING";
            picImage = "king.gif";
            EncounterDialogue = KingDiag.EntranceDialogue;
            Interactions = new string[] { "Accept", "Decline" };
        }
            public override void EventAction1(Bloo bloo)
            {
                Random random = new Random();
                int randomNumber = random.Next(3);

                switch (randomNumber)
                {
                    case 0:
                        bloo.Coins += 500;
                    form2.dialogueTextBox.Text = KingDiag.Option1Dialogue;
                        // add status effect that items are not claimable logic here

                    break;
                    case 1:
                        bloo.Rizz += 50;
                        bloo.Lives = 1;
                    form2.dialogueTextBox.Text = KingDiag.Option2Dialogue;
                        break;
                    case 2:
                        bloo.Lives = 5;
                        bloo.Coins -= bloo.Coins * .75;
                        bloo.Rizz -= bloo.Rizz * .75;
                    form2.dialogueTextBox.Text = KingDiag.Option3Dialogue;
                        break;
                }
            form2.runNextEncounter();
        }
            public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = KingDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }


            int choice;

    }
    public class GobletEvent : Events
    {
        GobletDialogue GobletDiag = new GobletDialogue();
        public GobletEvent()
        {
            Name = "Goblet";
            picImage = "goblet.png";
            EncounterDialogue = GobletDiag.EntranceDialogue;
            Interactions = new string[] { "Put", "Ignore" };
        }
        int choice;

        public override void EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = GobletDiag.Option1Dialogue;
            Random random = new Random();
                    int randomNumber = random.Next(100);
                    if (randomNumber <= 15)
                    {
                        Goblet goblet = new Goblet();
                        goblet.Acquired(bloo);
                form2.dialogueTextBox.Text = GobletDiag.CommitEvent1;
            }
                    else if(randomNumber > 15 && randomNumber <= 65)
                    {
                            bloo.Coins += 50;
                form2.dialogueTextBox.Text = GobletDiag.CommitEvent2;
            }
                    else
            {
                form2.dialogueTextBox.Text = GobletDiag.CommitEvent3;
            }
            form2.runNextEncounter();

        }   

        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = GobletDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {

        }
    }
    public class AppleTree : Events
    {
        AppleTreeDialogue AppleTreeDiag = new AppleTreeDialogue();
        public AppleTree()
        {
            Name = "Apple Tree";
            picImage = "apple_tree.png";
            EncounterDialogue = AppleTreeDiag.EntranceDialogue;
            Interactions = new string[] { "Tackle", "Climb" };
        }
        int choice;

        public override void EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = AppleTreeDiag.Option1Dialogue;
            form2.dialogueTextBox.Text = AppleTreeDiag.CommitEvent1;
            // add plus rizz
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = AppleTreeDiag.Option2Dialogue;

            Random random = new Random();
                    int randomNumber = random.Next(100);
                    if (randomNumber <= 25)
            {
                form2.dialogueTextBox.Text = AppleTreeDiag.CommitEvent2;
            }
                    else
            {
                form2.dialogueTextBox.Text = AppleTreeDiag.CommitEvent3;
                GoldenArrow goldenarrow = new GoldenArrow();
                goldenarrow.Acquired(bloo);
                    }
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {

        }
    }

    public class MasterGooway : Events
    {
            public List<Skill> skillshop;
        MasterGoowayDialogue MasterGoowayDiag = new MasterGoowayDialogue();
        ItemsDialogue ItemsDiag = new ItemsDialogue();
        public MasterGooway()
        {
            picImage = "master_gooway_idle_right.gif";
            EncounterDialogue = MasterGoowayDiag.EntranceDialogue;
            skillshop = new List<Skill> {new Bounce(), new Split(), new Mog(), new ElementBook() };
        }
        int choice;

        public override void EventAction1(Bloo bloo)
        {
            choice = 2;
            switch (choice)
            {
                case 0:
                    bloo.CharSkills.Add(new Split());
                    form2.dialogueTextBox.Text = ItemsDiag.SplitSkillDialogue;
                    break;
                case 1:
                    form2.dialogueTextBox.Text = ItemsDiag.ElementSkillDialogue;
                    bloo.CharSkills.Add(new ElementBook());
                    break;
                case 2:
                    form2.dialogueTextBox.Text = ItemsDiag.MogSkillDialogue;
                    bloo.CharSkills.Add(new Mog());
                    break;
                case 3:
                    form2.dialogueTextBox.Text = ItemsDiag.BounceSkillDialogue;
                    bloo.CharSkills.Add(new Bounce());
                    break;
            }
            form2.dialogueTextBox.Text = MasterGoowayDiag.EntranceDialogue;
        }
        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = MasterGoowayDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {

        }
    }
    public class Shopkeeper: Events
    {
        public List<Items> itemshop;
        ShopkeeperDialogue ShopKeeperDiag = new ShopkeeperDialogue();
        ItemsDialogue ItemsDiag = new ItemsDialogue();
        public Shopkeeper()
        {
            picImage = "shop_keeper_idle.gif";
            EncounterDialogue = ShopKeeperDiag.EntranceDialogue;
            itemshop = new List<Items> { new LifePotion(), new MysteryPotion(), new HardHelmet(), new SpikedHelmet() };  
        }
        int choice;
        public override void EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ShopKeeperDiag.Option1Dialogue;
        }

        public override void EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ShopKeeperDiag.IgnoreDialogue;
            form2.runNextEncounter();
        }
        public override void Perform(Bloo bloo)
        {
            choice = 0;

            switch (choice)
            {
                case 0:
                    form2.dialogueTextBox.Text = ItemsDiag.LifeDialogue;
                    LifePotion lifepotion = new LifePotion();
                    lifepotion.Acquired(bloo);
                    break;
                case 1:
                    MysteryPotion mysterypotion = new MysteryPotion();
                    mysterypotion.Acquired(bloo);
                    break;
                case 2:
                    form2.dialogueTextBox.Text = ItemsDiag.HardHelmentDialogue;
                    HardHelmet hardHelmet = new HardHelmet();
                    hardHelmet.Acquired(bloo);
                    break;
                case 3:
                    form2.dialogueTextBox.Text = ItemsDiag.SpikedHelmetDialogue;
                    SpikedHelmet spikedHelmet = new SpikedHelmet();
                    spikedHelmet.Acquired(bloo);
                    break;
            }
           
        }
    }
}
