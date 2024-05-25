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
        // public string picImage { get; set; }
        public virtual void Perform(Bloo bloo)
        {
            MessageBox.Show($"Events");
        }
    }
    public class Chest : Events
    {
        public Chest()
        {
            Name = "Chest";
            picImage = "chest.png";
            EncounterDialogue = "Bloo stumbles upon a chest!";
            Interactions = new string[] { "Open", "Skip" };
        }
        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("bloo opens the chest");
            Random random = new Random();
            randomNumber = random.Next(100);

            if (randomNumber <= lifePotChance)
            {
                if (bloo.Lives < 5)
                {
                    bloo.Lives += 1;
                }
                MessageBox.Show("You found a Life Potion!");
                form2.runNextEncounter();
            }
            else if (randomNumber <= lifePotChance + rizzChance)
            {
                bloo.Rizz += gainedRizz;
                MessageBox.Show("You gained some Rizz!");
                form2.runNextEncounter();
            }
            else if (randomNumber <= lifePotChance + rizzChance + coinChance)
            {
                bloo.Coins += 50;
                MessageBox.Show("You found some coins!");
                form2.runNextEncounter();
            }
            else
            {
                    // fight chest logic
                    Form2 form2 = Form2.Instance;
                    Form1 form1 = Form1.GetInstance();
                    form1.Enemy = new HostileChest("CHESTY");
                    form1.Enemy.Opposition = bloo;
                    form1.Player = bloo;
                    form1.Player.Opposition = form1.Enemy;
                    form1.Show();
               // MessageBox.Show("You won all loot!");
            }

        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("bloo ignores the chest");
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
        public Cave()
        {
            Name = "Cave";
            picImage = "cave.png";
            EncounterDialogue = "I MINE ALL DAY";
            Interactions = new string[] { "Enter", "Ignore"};
        }

        public override void EventAction1(Bloo bloo)
        {
            Random random = new Random();
            randomNumber = random.Next(1, totalChances + 1);
            // Check which outcome occurs based on the random number
            if (randomNumber <= loseLifeChance)
            {
                bloo.Lives--;
                MessageBox.Show("You lost 1 life!");
            }
            else if (randomNumber <= loseLifeChance + debuffChance)
            {
                // insert debuff logic
                Random rand = new Random();
                int chance = rand.Next(0, 4);
                switch (chance)
                {
                    case 0:
                        bloo.Health -= 20;
                        MessageBox.Show("You hit your head inside the cave. Health reduced by 20.");
                        break;
                    case 1:
                        bloo.AttackDamage -= 20;
                        MessageBox.Show("You cut your hand inside the cave. Attack Damage reduced by 20.");
                        break;
                    case 2:
                        bloo.Coins -= 20;
                        MessageBox.Show("A man inside the cave mugged you. Lost 20 coins");
                        break;
                    case 3:
                        bloo.Rizz -= 20;
                        MessageBox.Show("The cave scared you. Rizz reduced by 20.");
                        break;
                }
                MessageBox.Show("You got a debuff!");
            }
            else if (randomNumber <= loseLifeChance + debuffChance + coinChance)
            {
                bloo.Coins += 50;
                MessageBox.Show("You found some coins!");
            }
            else if (randomNumber <= loseLifeChance + debuffChance + coinChance + rizzChance)
            {
                bloo.Rizz += gainedRizz;
                MessageBox.Show("You found a Rizz!");
            }
            else if (randomNumber <= totalChances)
            {
                StrangeGem strangegem = new StrangeGem();
                strangegem.Acquired(bloo);
                MessageBox.Show("You found a Rare Gem!");
            }
            else
            {
                MessageBox.Show("You explored the cave and found nothing.");
            }
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Bloo got scared of the dark…");
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
        public SwordInStone()
        {
            Name = "SwordInStone";
            picImage = "swordinstone.png";
            EncounterDialogue = "I AM THE CHOSEN ONE";
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
                MessageBox.Show("Bloo was shocked as he pulled the sword effortlessly.");
                }
            else
            {
                MessageBox.Show("Bloo tried his best to pull the sword, but in his dismay, he wasn’t the chosen one.");
            }
            form2.runNextEncounter();
        }
                
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Bloo wasn’t interested in a mere sword…");
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
        public Bonfire()
        {
            Name = "Bonfire";
            picImage = "bonfire.png";
            EncounterDialogue = "Bloo stumbles upon a BONfire";
            Interactions = new string[] { "Obtain", "Ignore" };
        }

        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("Praise the sun!");
            if (bloo.Lives < 5)
            {
                MessageBox.Show("You feel rested. Lives increased");
                bloo.Lives += 1;
            }
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Bloo ignores a game reference…");
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {

        }
    }
    public class MysteriousMan : Events
    {
        int rand;
        public MysteriousMan()
        {
            Name = "Mysterious man";
            picImage = "mysteriousman.png";
            EncounterDialogue = "SHHHHHH";
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
                    MessageBox.Show("Bloo took the blue pill, health reduced by 25%");
                    bloo.Health -= bloo.Health * .25;
                    break;
                case 1:
                    MessageBox.Show("Bloo took the blue pill, bloo's accuracy reduced by 25%");
                    bloo.Accuracy -= 25;
                    break;
                case 2:
                    MessageBox.Show("Bloo took the blue pill, bloo's coin gain reduced");
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
                    MessageBox.Show("Bloo took the red pill, bloo's attack damage increased by 20");
                    bloo.AttackDamage += 20;
                    break;
                case 1:
                    MessageBox.Show("Bloo took the red pill, bloo's crit chance increased by 25");
                    bloo.CritChance += 25;
                    break;
                case 2:
                    MessageBox.Show("Bloo took the red pill, bloos rizz gain increased");
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
        public Jester()
        {
            Name = "Jester";
            picImage = "jester.png";
            EncounterDialogue = "KWAK";
            Interactions = new string[] { "Talk", "Ignore" };
        }
        public override void EventAction1(Bloo bloo)
        {
            // add mystery box logic
            MessageBox.Show("I have a little mystery box for you giggles. What's inside? What’s inside? Oh, the excitement! Well, that’s the fun part, isn’t it? It could be a delightful surprise... or a dreadful shock!” *giggles louder");
            bloo.Coins -= bloo.Coins * .75;
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Bloo dislikes clowns. He thinks they are scary and weird…");
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {
            // insert random item (mystery box) logic here
        }
    }
    public class Seer : Events
    {
        public Seer()
        {
            Name = "Seer";
            picImage = "seer.png";
            EncounterDialogue = "O.O";
            Interactions = new string[] { "Talk", "Ignore" };   
        }
        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show($"Seer");
            Random random = new Random();
            int rand = random.Next(0, 4);
            //rand = 0;
            switch (rand)
            {
                case 0:
                    int bossCount = form2.encounterCount / 5;
                    bloo.Rizz -= bloo.Rizz * .3;
                    MessageBox.Show($"next encounter is {form2.bossFights[bossCount]}");
                    // messagebox.show next enemy
                    break;
                case 1:
                    bloo.Coins -= 150;
                        bloo.PlayerItems.Add(new SeerBuff(rand));
                    MessageBox.Show("buffed, coins - 150, final boss +30% atk dmg");
                    // add status effect final boss 30% atk dmg boost for bloo
                    break;
                case 2:
                    bloo.Coins -= 100;
                        bloo.PlayerItems.Add(new SeerBuff(rand));
                    MessageBox.Show("buffed, coins - 100, next boss +15% atk dmg");
                    // add status effect next boss 15% atk dmg boost for bloo
                    break;
                case 3:
                    bloo.Coins -= 50;
                        bloo.PlayerItems.Add(new SeerBuff(rand));
                    MessageBox.Show("buffed, coins - 50, next boss has lowered accuracy");
                    // add status effect, lower accuracy of next boss
                    break;
                case 4:
                    bloo.Coins -= 50;
                        bloo.PlayerItems.Add(new SeerBuff(rand));
                    MessageBox.Show("buffed, coins - 50, +20 def on next fight");
                    // add status effect, +20 def for bloo on next boss 
                    break;
            }
            form2.runNextEncounter();
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Bloo ignores seer");
            form2.runNextEncounter();
        }
        public override void Perform(Bloo bloo)
        {
            /*
            MessageBox.Show($"Seer");
            Random random = new Random();
            int rand = random.Next(0, 4);
            switch (rand)
            {
                case 0:
                    bloo.Rizz -= bloo.Rizz * .3;
                    // messagebox.show next enemy
                    break;
                case 1:
                    bloo.Coins -= 150;
                    // add status effect final boss 30% atk dmg boost for bloo
                    break;
                case 2:
                    bloo.Coins -= 100;
                    // add status effect next boss 15% atk dmg boost for bloo
                    break;
                case 3:
                    bloo.Coins -= 50;
                    // add status effect, lower accuracy of next boss
                    break;
                case 4:
                    bloo.Coins -= 50;
                    // add status effect, +20 def for bloo on next boss 
                    break;
            }
            */
        }
    }
    public class WishingWell : Events
    {
        int choice;
        int multiplier = 1;
        public WishingWell()
        {
            Name = "Wishing well";
            this.picImage = "wishingwell.png";
            Interactions = new string[] { "Make Wish", "Ignore" };
            EncounterDialogue = "WISHING WASHING";
            Interactions = new string[] { "Wish", "Ignore" };
            //this.multiplier = 1;
        }

        public override void EventAction1(Bloo bloo)
        {
            bloo.Coins -= 2 * multiplier;
            MessageBox.Show($"Threw {2 * multiplier} coins in the wishing well!");
            Random random = new Random();
            int randomNumber = random.Next(100);
            if (randomNumber >= 1 && randomNumber <= 25)
            {
                // insert random mystery potion buff logic here
                MessageBox.Show("Gained random mystery potion buff");
            }
            else if (randomNumber >= 26 && randomNumber <= 30)
            {

                HolyWater holywater = new HolyWater();
                holywater.Acquired(bloo);
                MessageBox.Show("Holy Water Acquired!");
            }
            else
            {
                MessageBox.Show($"Nothing Happened");
            }
            multiplier++;
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Bloo got sad…");
            form2.runNextEncounter();
        }
      
    }
    public class King : Events
    {
        public King()
        {
            Name = "KING";
            picImage = "king.png";
            EncounterDialogue = "What manner of odd creature are you… Say, my kingdom has come to ruins, would you mind making a trade to this daring king?";
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
                        MessageBox.Show("gained 500 coins but next 3 items are not claimable");
                        // add status effect that items are not claimable logic here

                        break;
                    case 1:
                        bloo.Rizz += 50;
                        bloo.Lives = 1;
                        MessageBox.Show("gained 50 rizz, lost lives");
                        break;
                    case 2:
                        bloo.Lives = 5;
                        bloo.Coins -= bloo.Coins * .75;
                        bloo.Rizz -= bloo.Rizz * .75;
                        MessageBox.Show("gained 5 lives, lost 75% coins and 75% rizz");
                        break;
                }
            form2.runNextEncounter();
        }
            public override void EventAction2(Bloo bloo)
            {
                MessageBox.Show("Bloo declines");
            form2.runNextEncounter();
        }


            int choice;

    }
    public class GobletEvent : Events
    {
        public GobletEvent()
        {
            Name = "Goblet";
            picImage = "goblet.png";
            EncounterDialogue = "GOBLET";
            Interactions = new string[] { "Put", "Ignore" };
        }
        int choice;

        public override void EventAction1(Bloo bloo)
        {

                    //bloo.Coins += 50;
                    //MessageBox.Show("Bloo felt wealthy!");

                    Random random = new Random();
                    int randomNumber = random.Next(100);
                    if (randomNumber <= 15)
                    {
                        // insert wizard free pass item logic here
                        Goblet goblet = new Goblet();
                        goblet.Acquired(bloo);
                        MessageBox.Show("The goblet of fire burst into flames! But nothing happened?...");
                    }
                    else if(randomNumber > 15 && randomNumber <= 65)
                    {
                            bloo.Coins += 50;
                            MessageBox.Show("Bloo felt wealthy!");
                    }
                    else
                    {
                        MessageBox.Show($"Nothing happened.");
                    }
            form2.runNextEncounter();

        }   

        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Bloo ignored a movie reference…");
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {

        }
    }
    public class AppleTree : Events
    {
        public AppleTree()
        {
            Name = "Apple Tree";
            picImage = "appletree.png";
            EncounterDialogue = "GRAVITY";
            Interactions = new string[] { "Tackle", "Climb" };
        }
        int choice;

        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("Bloo, with all his might, tackled the tree.");
            MessageBox.Show("An apple fell from the tree.");
            // add plus rizz
            form2.runNextEncounter();
        }

        public override void EventAction2(Bloo bloo)
        {

                    Random random = new Random();
                    int randomNumber = random.Next(100);
                    if (randomNumber <= 25)
                    {
                        MessageBox.Show("Bloo fell down…");
                    }
                    else
                    {
                        MessageBox.Show("Bloo noticed something shiny!");
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
        public MasterGooway()
        {
            picImage = "mastergooway.png";
            //Interactions = new string[] { "Buy", "Skip"};
            EncounterDialogue = "Gooway I am";
            skillshop = new List<Skill> {new Bounce(), new Split(), new Mog(), new ElementBook() };
        }
        int choice;

        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("Use your skills for good, dragon war– oops, wrong student… May that help you in your journey, young one.");
            choice = 2;
            switch (choice)
            {
                case 0:
                    bloo.CharSkills.Add(new Split());
                    MessageBox.Show("Split");
                    break;
                case 1:
                    MessageBox.Show("Element Book");
                    bloo.CharSkills.Add(new ElementBook());
                    break;
                case 2:
                    MessageBox.Show("Mog");
                    bloo.CharSkills.Add(new Mog());
                    break;
                case 3:
                    MessageBox.Show("Bounce");
                    bloo.CharSkills.Add(new Bounce());
                    break;
            }
        }
        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Perhaps you are not ready to learn my ways, young one.");
            form2.runNextEncounter();
        }

        public override void Perform(Bloo bloo)
        {

        }
    }
    public class Shopkeeper: Events
    {
        public List<Items> itemshop;
        public Shopkeeper()
        {
            picImage = "wishingwell.png";
            EncounterDialogue = "SHOPPEEDOOPEE";
            itemshop = new List<Items> { new LifePotion(), new MysteryPotion(), new HardHelmet(), new SpikedHelmet() };

            //Interactions = new string[] { "Buy", "Skip" };    
        }
        int choice;
        public override void EventAction1(Bloo bloo)
        {
            MessageBox.Show("That all pal? If ya ever need more help, I’m just around the corner!");
        }

        public override void EventAction2(Bloo bloo)
        {
            MessageBox.Show("Aight pal, if ya ever found ya self in a sticky situation, I’m just a bounce away.");
            form2.runNextEncounter();
        }
        public override void Perform(Bloo bloo)
        {
            choice = 0;

            switch (choice)
            {
                case 0:
                    MessageBox.Show("Life Potion");
                    LifePotion lifepotion = new LifePotion();
                    lifepotion.Acquired(bloo);
                    break;
                case 1:
                    MessageBox.Show("Mystery Potion");
                    MysteryPotion mysterypotion = new MysteryPotion();
                    mysterypotion.Acquired(bloo);
                    break;
                case 2:
                    MessageBox.Show("Hard Helmet");
                    HardHelmet hardHelmet = new HardHelmet();
                    hardHelmet.Acquired(bloo);
                    break;
                case 3:
                    MessageBox.Show("Spiked Helmet");
                    SpikedHelmet spikedHelmet = new SpikedHelmet();
                    spikedHelmet.Acquired(bloo);
                    break;
            }
           
        }
    }
}
