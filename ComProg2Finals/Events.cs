using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.IO;
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
        public virtual async Task Perform(Bloo bloo)
        {

        }
    }
    public class Chest : Events
    {
        public SoundPlayer musicBG;
        ChestyDialogue ChestyDiag = new ChestyDialogue();
        public Chest()
        {
            Name = "Chest";
            picImage = "chesty_close.png";
            EncounterDialogue = ChestyDiag.EntranceDialogue;
            Interactions = new string[] { "Open", "Skip" };
        }
        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ChestyDiag.Option1Dialogue;
            await Task.Delay(2000);
            Random random = new Random();
            randomNumber = random.Next(100);

            if (randomNumber <= lifePotChance)
            {
                if (bloo.Lives < 5)
                {
                    bloo.Lives += 1;
                }
                form2.dialogueTextBox.Text = ChestyDiag.CommitEvent1;
                await Task.Delay(2000);
                form2.runNextEncounter();
            }
            else if (randomNumber <= lifePotChance + rizzChance)
            {
                bloo.ChangeRizz(gainedRizz);
                form2.dialogueTextBox.Text = ChestyDiag.CommitEvent2;
                await Task.Delay(2000);
                form2.runNextEncounter();
            }
            else if (randomNumber <= lifePotChance + rizzChance + coinChance)
            {
                bloo.ChangeCoin(50); ;
                form2.dialogueTextBox.Text = ChestyDiag.CommitEvent3;
                await Task.Delay(2000);
                form2.runNextEncounter();
            }
            else
            {
                Stream soundStream = Properties.Resources.Battle;
                musicBG = new SoundPlayer(soundStream);
                musicBG.PlayLooping();
                Form2 form2 = Form2.Instance;
                Form1 form1 = Form1.GetInstance();
                form1.Enemy = new HostileChest("CHESTY");
                form1.Enemy.Opposition = bloo;
                form1.Player = bloo;
                form1.Player.Opposition = form1.Enemy;
                form1.Show();
                form2.dialogueTextBox.Text = ChestyDiag.CommitEvent5;
                await Task.Delay(2000);
            }

        }
        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ChestyDiag.IgnoreDialogue;
            await Task.Delay(2000);
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
            Interactions = new string[] { "Enter", "Ignore" };
        }

        public override async Task EventAction1(Bloo bloo)
        {
            Random random = new Random();
            randomNumber = random.Next(1, totalChances + 1);
            if (randomNumber <= loseLifeChance)
            {
                bloo.Lives--;
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent1;
                await Task.Delay(2000);
            }
            else if (randomNumber <= loseLifeChance + debuffChance)
            {
                EncounterDialogue = CaveDiag.CommitEvent2;
                await Task.Delay(2000);
                Random rand = new Random();
                int chance = rand.Next(0, 4);
                switch (chance)
                {
                    case 0:
                        bloo.ChangeHealth(-20);
                        form2.dialogueTextBox.Text = CaveDiag.CommitEvent6;
                        await Task.Delay(2000);
                        break;
                    case 1:
                        bloo.AttackDamage -= 20;
                        form2.dialogueTextBox.Text = CaveDiag.CommitEvent7;
                        await Task.Delay(2000);
                        break;
                    case 2:
                        bloo.ChangeCoin(-20);
                        form2.dialogueTextBox.Text = CaveDiag.CommitEvent8;
                        await Task.Delay(2000);
                        break;
                    case 3:
                        bloo.ChangeRizz(-20);
                        form2.dialogueTextBox.Text = CaveDiag.CommitEvent9;
                        await Task.Delay(2000);
                        break;
                }
            }
            else if (randomNumber <= loseLifeChance + debuffChance + coinChance)
            {
                bloo.ChangeCoin(50);
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent3;
                await Task.Delay(2000);
            }
            else if (randomNumber <= loseLifeChance + debuffChance + coinChance + rizzChance)
            {
                bloo.Rizz += gainedRizz;
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent4;
                await Task.Delay(2000);
            }
            else if (randomNumber <= totalChances)
            {
                StrangeGem strangegem = new StrangeGem();
                strangegem.Acquired(bloo, form2);
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent5;
                await Task.Delay(2000);
            }
            else
            {
                form2.dialogueTextBox.Text = CaveDiag.CommitEvent10;
                await Task.Delay(2000);
            }
            form2.runNextEncounter();
        }

        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = CaveDiag.IgnoreDialogue;
            await Task.Delay(2000);
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
        public override async Task Perform(Bloo bloo)
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

        public override async Task EventAction1(Bloo bloo)
        {
            Random random = new Random();
            randomNumber = random.Next(100);
            if (randomNumber <= pullChance)
            {
                Excalibur excalibur = new Excalibur();
                excalibur.Acquired(bloo, form2);
                form2.dialogueTextBox.Text = SwordStoneDiag.Option1Dialogue;
                await Task.Delay(2000);
            }
            else
            {
                form2.dialogueTextBox.Text = SwordStoneDiag.Option2Dialogue;
                await Task.Delay(2000);
            }
            form2.runNextEncounter();
        }

        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = SwordStoneDiag.IgnoreDialogue;
            await Task.Delay(2000);
            form2.runNextEncounter();
        }
        int pullChance = 5;
        int randomNumber;
        public override async Task Perform(Bloo bloo)
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

        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = BonFireDiag.Option1Dialogue;
            await Task.Delay(2000);
            if (bloo.Lives < 5)
            {
                form2.dialogueTextBox.Text = BonFireDiag.CommitEvent1;
                await Task.Delay(2000);
                bloo.Lives += 1;
            }
            form2.runNextEncounter();
        }

        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = BonFireDiag.IgnoreDialogue;
            await Task.Delay(2000);
            form2.runNextEncounter();
        }

        public override async Task Perform(Bloo bloo)
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
            Interactions = new string[] { "Blue pill", "Red Pill" };
            Random random = new Random();
            rand = random.Next(0, 2);
        }
        int choice;

        public override async Task EventAction1(Bloo bloo)
        {
            switch (rand)
            {
                case 0:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent1;
                    await Task.Delay(2000);
                    bloo.ChangeHealth(-bloo.Health * .25);
                    break;
                case 1:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent2;
                    await Task.Delay(2000);
                    bloo.ChangeAccuracy(-25);
                    break;
                case 2:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent3;
                    await Task.Delay(2000);
                    bloo.coinGainMultiplier /= 2;
                    // minus coin income
                    break;
            }
            form2.runNextEncounter();
        }

        public override async Task EventAction2(Bloo bloo)
        {
            switch (rand)
            {
                case 0:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent4;
                    await Task.Delay(2000);
                    bloo.AttackDamage += 20;
                    break;
                case 1:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent5;
                    await Task.Delay(2000);
                    bloo.CritChance += 25;
                    break;
                case 2:
                    form2.dialogueTextBox.Text = MysteriousManDiag.CommitEvent6;
                    await Task.Delay(2000);
                    // buff rizz income
                    bloo.rizzGainMultiplier *= 2;
                    break;
            }
            form2.runNextEncounter();
        }

        public override async Task Perform(Bloo bloo)
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
        public override async Task EventAction1(Bloo bloo)
        {
            await Task.Delay(2000);
            MysteryBox mysterybox = new MysteryBox();
            mysterybox.Acquired(bloo, form2);
            bloo.ChangeCoin(-bloo.Coins * .75);
            form2.runNextEncounter();
        }

        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = JesterDiag.IgnoreDialogue;
            await Task.Delay(2000);
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
        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = SeerDiag.Option1Dialogue;
            await Task.Delay(2000);
            Random random = new Random();
            int rand = random.Next(0, 4);
            // rand = 0;
            switch (rand)
            {
                case 0:
                    int bossCount = form2.encounterCount / 5;
                    bloo.ChangeRizz(-bloo.Rizz * .3);
                    form2.dialogueTextBox.Text = SeerDiag.CommitEvent1;
                    await Task.Delay(2000);
                    break;
                case 1:
                    bloo.ChangeCoin(-150);
                    bloo.PlayerItems.Add(new SeerBuff(rand));
                    form2.dialogueTextBox.Text = SeerDiag.CommitEvent2;
                    await Task.Delay(2000);
                    break;
                case 2:
                    bloo.ChangeCoin(-100);
                    bloo.PlayerItems.Add(new SeerBuff(rand));
                    form2.dialogueTextBox.Text = SeerDiag.CommitEvent3;
                    await Task.Delay(2000);
                    break;
                case 3:
                    bloo.ChangeCoin(-50);
                    bloo.PlayerItems.Add(new SeerBuff(rand));
                    form2.dialogueTextBox.Text = SeerDiag.CommitEvent4;
                    await Task.Delay(2000);
                    break;
                case 4:
                    bloo.ChangeCoin(-50);
                    bloo.PlayerItems.Add(new SeerBuff(rand));
                    form2.dialogueTextBox.Text = SeerDiag.CommitEvent5;
                    await Task.Delay(2000);

                    break;
            }
            form2.runNextEncounter();
        }
        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = SeerDiag.IgnoreDialogue;
            await Task.Delay(2000);
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

        public override async Task EventAction1(Bloo bloo)
        {
            double coinCost = 2 * multiplier;
            bloo.ChangeCoin(-coinCost);
            form2.dialogueTextBox.Text = WishingWellDiag.Option1Dialogue;
            await Task.Delay(2000);
            Random random = new Random();
            int randomNumber = random.Next(100);
            if (randomNumber >= 1 && randomNumber <= 25)
            {
                MysteryPotion mysterypotion = new MysteryPotion();
                mysterypotion.Acquired(bloo, form2);
                form2.dialogueTextBox.Text = WishingWellDiag.CommitEvent1;
                await Task.Delay(2000);
            }
            else if (randomNumber >= 26 && randomNumber <= 30)
            {

                HolyWater holywater = new HolyWater();
                holywater.Acquired(bloo, form2);
                form2.dialogueTextBox.Text = WishingWellDiag.CommitEvent1;
                await Task.Delay(2000);
                form2.dialogueTextBox.Text = ItemsDiag.HolyWaterDialogue;
                await Task.Delay(2000);
            }
            else
            {
                form2.dialogueTextBox.Text = WishingWellDiag.CommitEvent2;
                await Task.Delay(2000);
            }
            form2.UpdateStats();
        }
        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = WishingWellDiag.IgnoreDialogue;
            await Task.Delay(2000);
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
        public override async Task EventAction1(Bloo bloo)
        {
            Random random = new Random();
            int randomNumber = random.Next(3);

            switch (randomNumber)
            {
                case 0:
                    bloo.ChangeCoin(500);
                    form2.dialogueTextBox.Text = KingDiag.Option1Dialogue;
                    await Task.Delay(2000);
                    // add status effect that items are not claimable logic here

                    break;
                case 1:
                    bloo.ChangeRizz(50);
                    bloo.Lives = 1;
                    form2.dialogueTextBox.Text = KingDiag.Option2Dialogue;
                    await Task.Delay(2000);
                    break;
                case 2:
                    bloo.Lives = 5;
                    bloo.ChangeCoin(-bloo.Coins * .75);
                    bloo.ChangeRizz(-bloo.Rizz * .75);
                    form2.dialogueTextBox.Text = KingDiag.Option3Dialogue;
                    await Task.Delay(2000);
                    break;
            }
            form2.runNextEncounter();
        }
        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = KingDiag.IgnoreDialogue;
            await Task.Delay(2000);
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

        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = GobletDiag.Option1Dialogue;
            await Task.Delay(2000);
            Random random = new Random();
            int randomNumber = random.Next(100);
            if (randomNumber <= 15)
            {
                form2.dialogueTextBox.Text = GobletDiag.CommitEvent1;
                await Task.Delay(2000);
                Goblet goblet = new Goblet();
                goblet.Acquired(bloo, form2);
            }
            else if (randomNumber > 15 && randomNumber <= 65)
            {
                form2.dialogueTextBox.Text = GobletDiag.CommitEvent2;
                await Task.Delay(2000);
                bloo.ChangeCoin(50);
            }
            else
            {
                form2.dialogueTextBox.Text = GobletDiag.CommitEvent3;
                await Task.Delay(2000);
            }
            form2.runNextEncounter();

        }

        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = GobletDiag.IgnoreDialogue;
            await Task.Delay(2000);
            form2.runNextEncounter();
        }

        public override async Task Perform(Bloo bloo)
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

        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = AppleTreeDiag.Option1Dialogue;
            await Task.Delay(2000);
            form2.dialogueTextBox.Text = AppleTreeDiag.CommitEvent1;
            await Task.Delay(2000);
            bloo.ChangeRizz(10);
            form2.runNextEncounter();
        }

        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = AppleTreeDiag.Option2Dialogue;
            await Task.Delay(2000);

            Random random = new Random();
            int randomNumber = random.Next(100);
            if (randomNumber <= 25)
            {
                form2.dialogueTextBox.Text = AppleTreeDiag.CommitEvent2;
                await Task.Delay(2000);
            }
            else
            {
                form2.dialogueTextBox.Text = AppleTreeDiag.CommitEvent3;
                await Task.Delay(2000);
                GoldenArrow goldenarrow = new GoldenArrow();
                goldenarrow.Acquired(bloo, form2);
            }
            form2.runNextEncounter();
        }

        public override async Task Perform(Bloo bloo)
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
            skillshop = new List<Skill> { new Bounce(), new Split(), new Mog(), new ElementBook() };
        }
        int choice;

        public override async Task EventAction1(Bloo bloo)
        {
            choice = 2;
            switch (choice)
            {
                case 0:
                    bloo.CharSkills.Add(new Split());
                    form2.dialogueTextBox.Text = ItemsDiag.SplitSkillDialogue;
                    await Task.Delay(2000);
                    break;
                case 1:
                    form2.dialogueTextBox.Text = ItemsDiag.ElementSkillDialogue;
                    await Task.Delay(2000);
                    bloo.CharSkills.Add(new ElementBook());
                    break;
                case 2:
                    form2.dialogueTextBox.Text = ItemsDiag.MogSkillDialogue;
                    await Task.Delay(2000);
                    bloo.CharSkills.Add(new Mog());
                    break;
                case 3:
                    form2.dialogueTextBox.Text = ItemsDiag.BounceSkillDialogue;
                    await Task.Delay(2000);
                    bloo.CharSkills.Add(new Bounce());
                    break;
            }
            form2.dialogueTextBox.Text = MasterGoowayDiag.EntranceDialogue;
            await Task.Delay(2000);
        }
        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = MasterGoowayDiag.IgnoreDialogue;
            await Task.Delay(2000);
            form2.runNextEncounter();
        }

        public override async Task Perform(Bloo bloo)
        {

        }
    }
    public class Shopkeeper : Events
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
        public override async Task EventAction1(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ShopKeeperDiag.Option1Dialogue;
            await Task.Delay(2000);
        }

        public override async Task EventAction2(Bloo bloo)
        {
            form2.dialogueTextBox.Text = ShopKeeperDiag.IgnoreDialogue;
            await Task.Delay(2000);
            form2.runNextEncounter();
        }
        public override async Task Perform(Bloo bloo)
        {
            choice = 0;

            switch (choice)
            {
                case 0:
                    form2.dialogueTextBox.Text = ItemsDiag.LifeDialogue;
                    await Task.Delay(2000);
                    LifePotion lifepotion = new LifePotion();
                    lifepotion.Acquired(bloo, form2);
                    break;
                case 1:
                    MysteryPotion mysterypotion = new MysteryPotion();
                    mysterypotion.Acquired(bloo, form2);
                    break;
                case 2:
                    form2.dialogueTextBox.Text = ItemsDiag.HardHelmentDialogue;
                    await Task.Delay(2000);
                    HardHelmet hardHelmet = new HardHelmet();
                    hardHelmet.Acquired(bloo, form2);
                    break;
                case 3:
                    form2.dialogueTextBox.Text = ItemsDiag.SpikedHelmetDialogue;
                    await Task.Delay(2000);
                    SpikedHelmet spikedHelmet = new SpikedHelmet();
                    spikedHelmet.Acquired(bloo, form2);
                    break;
            }

        }
    }
}
