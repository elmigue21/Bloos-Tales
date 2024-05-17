using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

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
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        int lifePotChance = 10;
        int rizzChance = 20;
        int coinChance = 30;

        int gainedRizz = 20;

        int randomNumber;
        public override void Perform(Bloo bloo)
        {
            Random random = new Random();
            randomNumber = random.Next(100);

            if (randomNumber <= lifePotChance)
            {
                if (bloo.Lives < 5) {
                    bloo.Lives += 1;
                        }
                MessageBox.Show("You found a Life Potion!");
            }
            else if (randomNumber <= lifePotChance + rizzChance)
            {
                bloo.Rizz += gainedRizz;
                MessageBox.Show("You gained some Rizz!");
            }
            else if (randomNumber <= lifePotChance + rizzChance + coinChance)
            {
                bloo.Coins += 50;
                MessageBox.Show("You found some coins!");
            }
            else
            {
                // fight chest logic
                MessageBox.Show("You won all loot!");
            }

        }
    }
    public class Cave : Events
    {
        public Cave()
        {
            Name = "Cave";
            picImage = "cave.png";
            EncounterDialogue = "I MINE ALL DAY";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
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
        }
    }
    public class SwordInStone : Events
    {

        public SwordInStone()
        {
            Name = "SwordInStone";
            picImage = "swordinstone.png";
            EncounterDialogue = "I AM THE CHOSEN ONE";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        int pullChance = 5;

        int randomNumber;
        public override void Perform(Bloo bloo)
        {
            Random random = new Random();

            randomNumber = random.Next(100);

            if (randomNumber <= pullChance)
            {
                Excalibur excalibur = new Excalibur();
                excalibur.Acquired(bloo);
                MessageBox.Show("You pulled the excalibur sword");
            }
            else
            {
                MessageBox.Show("The sword wont budge.");
            }

        }
    }
    public class Bonfire : Events
    {
        public Bonfire()
        {
            Name = "Bonfire";
            picImage = "bonfire.png";
            EncounterDialogue = "Bloo stumbles upon a BONfire";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        public override void Perform(Bloo bloo)
        {
            if (bloo.Lives < 5)
            {
                MessageBox.Show("You feel rested. Lives increased");
                bloo.Lives += 1;
            }
        }
    }
    public class MysteriousMan : Events
    {
        public MysteriousMan()
        {
            Name = "Mysterious man";
            picImage = "mysteriousman.png";
            EncounterDialogue = "SHHHHHH";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        int choice;
        public override void Perform(Bloo bloo)
        {
            // 33.3 percent chance eachhhhh
            choice = 0;
            switch (choice) {
                case 0:
                    bloo.Health -= bloo.Health * .25;
                    bloo.AttackDamage += 20;
                    break;
                case 1:
                    bloo.Accuracy -= 25;
                    bloo.CritChance += 25;
                    break;
                case 2:
                    // coin income boost ()
                    // rizz income debuff (mababawasan lahat ng coin income)
                    break;
            }
            MessageBox.Show($"Mysterious Man");
        }
    }
    public class Jester : Events
    {
        public Jester()
        {
            Name = "Jester";
            picImage = "wishingwell.png";
            EncounterDialogue = "KWAK";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        public override void Perform(Bloo bloo)
        {
            bloo.Coins -= bloo.Coins * .75;
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
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        public override void Perform(Bloo bloo)
        {
            MessageBox.Show($"Seer");
            int choice = 0;
            switch (choice)
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
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
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




      





        public override void Perform(Bloo bloo)
        {
            multiplier = 1;
            while (choice != 1)
            {
                choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice) {
                    case 0:
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
                        break;
                    case 1:
                        
                        break;
                }
            }
        }
    }
    public class King : Events
    {
        public King()
        {
            Name = "KING MIGUEL";
            picImage = "king.png";
            EncounterDialogue = "Bloo stumbles upon the greatest king in the world, King Miguel! " +
                "Bloo kneels immediately and devotes his loyalty and pledges his sword and promises to give his life protecting THE ONE TRUE KING, KING MIGUEL! HAIL KING MIGUEL! HAIL!" +
                " MAY HE BE BLESSED AND LONG MAY HE REIGN!";
            Interactions = new string[] { "Kneel", "Bow down", "Praise" };
        }
        int choice;
        public override void Perform(Bloo bloo)
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
            
        }
    }
    public class GobletEvent : Events
    {
        public GobletEvent()
        {
            Name = "Goblet";
            picImage = "goblet.png";
            EncounterDialogue = "GOBLET";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        int choice;
        public override void Perform(Bloo bloo)
        {
            choice = 0;
            switch (choice)
            {
                case 0:
                    bloo.Coins += 50;
                    break;
                case 1:
                    Random random = new Random();
                    int randomNumber = random.Next(100);
                    if (randomNumber <= 5)
                    {
                        // insert wizard free pass item logic here
                        Goblet goblet = new Goblet();
                        goblet.Acquired(bloo);
                        MessageBox.Show("Ignited! Wizard pass gained.");
                    }
                    else
                    {
                        MessageBox.Show($"Nothing happened.");
                    }
                    break;
            }
        }
    }
    public class AppleTree : Events
    {
        public AppleTree()
        {
            Name = "Apple Tree";
            picImage = "appletree.png";
            EncounterDialogue = "GRAVITY";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        int choice;
        public override void Perform(Bloo bloo)
        {
            choice = 1;
            switch (choice)
            {
                case 0:
                    bloo.Rizz += 5;
                    break;
                case 1:
                    Random random = new Random();
                    int randomNumber = random.Next(100);
                    if (randomNumber <= 25)
                    {
                      
                        GoldenArrow goldenArrow = new GoldenArrow();
                        
                        goldenArrow.Acquired(bloo);
                        MessageBox.Show("Golden Arrow acquired!");
                    }
                    else
                    {
                        MessageBox.Show($"{bloo.Name} fell from the tree.");
                    }

                    break;
            }
        }
    }
    public class MasterGooway : Events
    {
        public MasterGooway()
        {
            picImage = "mastergooway.png";
            Interactions = new string[] { "Cook into Turtle soup", "Eat" };
            EncounterDialogue = "Gooway I am";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        int choice;
        public override void Perform(Bloo bloo)
        {
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
    }
    public class Shopkeeper: Events
    {
        public Shopkeeper()
        {
            picImage = "wishingwell.png";
            EncounterDialogue = "SHOPPEEDOOPEE";
            Interactions = new string[] { "Attack", "Rizz", "Ignore" };
        }
        int choice;
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
