using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ComProg2Finals
{
    public class Events
    {
        public virtual void Perform(Bloo bloo)
        {
            MessageBox.Show($"Events");

        }
    }
    public class Chest : Events
    {
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
            }
            else if (randomNumber <= lifePotChance + rizzChance)
            {
                bloo.Rizz += gainedRizz;
                MessageBox.Show("You found a Rizz!");
            }
            else if (randomNumber <= lifePotChance + rizzChance + coinChance)
            {
                MessageBox.Show("You found some coins!");
            }
            else
            {
                MessageBox.Show("You won all loot!");
            }

        }
    }
    public class Cave : Events
    {
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
                MessageBox.Show("You got a debuff!");
            }
            else if (randomNumber <= loseLifeChance + debuffChance + coinChance)
            {
                // insert coin logic
                MessageBox.Show("You found some coins!");
            }
            else if (randomNumber <= loseLifeChance + debuffChance + coinChance + rizzChance)
            {
                // insert rizz logic
                bloo.Rizz += gainedRizz;
                MessageBox.Show("You found a Rizz!");
            }
            else if (randomNumber <= totalChances)
            {
                // insert rogue free pass
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
        int pullChance = 5;

        int randomNumber;
        public override void Perform(Bloo bloo)
        {
            Random random = new Random();

            randomNumber = random.Next(100);

            if (randomNumber <= pullChance)
            {
                // insert excalibur item logic
                MessageBox.Show("You pulled the excalibur sword");
            }
            else
            {
                MessageBox.Show("weak");
            }

        }
    }
    public class Bonfire : Events
    {
        public override void Perform(Bloo bloo)
        {
            if (bloo.Lives < 5)
            {
                bloo.Lives += 1;
            }
        }
    }
    public class MysteriousMan : Events
    {
        int choice;
        public override void Perform(Bloo bloo)
        {
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
        public override void Perform(Bloo bloo)
        {
            bloo.Coins -= bloo.Coins * .75;
            // insert random item (mystery box) logic here
        }
    }
    public class Seer : Events
    {
        public override void Perform(Bloo bloo)
        {
            MessageBox.Show($"Seer");
        }
    }
    public class WishingWell : Events
    {
        int choice;
        int multiplier;
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
                            // add holy water item (priest free pass here)
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
    public class Goblet : Events
    {
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
        int choice;
        public override void Perform(Bloo bloo)
        {
            choice = 0;
            switch (choice)
            {
                case 0:
                    bloo.Rizz += 5;
                    break;
                case 1:
                    Random random = new Random();
                    int randomNumber = random.Next(100);
                    if (randomNumber <= 24)
                    {
                        // insert archer free pass logic here
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
}
