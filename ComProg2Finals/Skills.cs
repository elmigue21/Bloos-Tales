﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComProg2Finals
{
    public class Skill
    {
        //public Form1 battleForm = Form1.Instance;
        public Form1 battleForm = Form1.GetInstance();
        public List<Action> skillsQueue;
        public string Name { get; protected set; }
        public int Price { get; set; }

        public Skill()
        {
            battleForm = Form1.GetInstance();
            //this.skillsQueue = battleForm.skillsQueue;
        }

        public virtual void Perform(Character user)
        {
            MessageBox.Show($"{Name} skill performed.");

        }
        public void Learn(Bloo bloo)
        {
            bloo.CharSkills.Add(this);
            MessageBox.Show("added " + this + " to bloos skills");
        }
    }

    // BLOO SKILLS
    public class Tackle : Skill
    {
        public Tackle()
        {
            this.Name = "Tackle";
        }

        public override void Perform(Character user)
        {
           // MessageBox.Show($"Used {Name}");
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));

        }

    }
    public class Goo : Skill
    {
        public Goo()
        {
            this.Name = "Goo";
        }

        public override void Perform(Character user)
        {
            MessageBox.Show($"Used {Name}");
           // MessageBox.Show("Used " + this.Name);
            // user.Opposition.Accuracy -= 20;
            user.skillQueue.Add(() => user.Opposition.LoweringAccuracy(20, user));

            //user.Opposition.CharStatEffects.Add(new DmgPerTurn("Goo", 10, 2));
        }
    }

    public class Split : Skill
    {
        public Split()
        {
            this.Name = "Split";
            this.Price = 69;
        }

        public override void Perform(Character user)
        {
         //   MessageBox.Show("Used " + this.Name);
            user.isBlocking = true;
            MessageBox.Show("Bloo splits and makes other slimes to soak up damage!");
        }
    }
    public class ElementBook : Skill
    {
        public ElementBook()
        {
            this.Name = "Element Book";
            this.Price = 69;
        }

        public override void Perform(Character user)
        {
            Random random = new Random();
            int rand = random.Next(0, 4);
            switch (user.Opposition.elementType)
            {
                case "Fire":
                    break;
                case "Earth":
                    break;
                case "Wind":
                    break;
                case "Water":
                    break;
                default:
                    break;
            }
            switch (rand)
            {
                case 0:
                    MessageBox.Show("Element Book used, Burn inflicted on " + user.Opposition.Name);
                    user.elementType = "Fire";
                    //battleForm.skillsQueue.Add(() => user.Opposition.CharStatEffects.Add(new DmgPerTurn("Burn", 10, 5)));
                    user.Opposition.CharStatEffects.Add(new DmgPerTurn("Burn", 10, 5));
                    break;
                case 1:
                    MessageBox.Show("Element book used, " + user.Name + " defense raised.");
                    user.elementType = "Earth";
                    user.Defense += 20;
                    break;
                case 2:
                    MessageBox.Show("Element book used, Wind used");
                    user.elementType = "Wind";
                    user.CharStatEffects.Add(new MultiHitChance("WindHit", user));
                    // dagdag ng stat effect na multi hit
                    //user.CharStatEffects.Add(/*multi hit*/);
                    break;
                case 3:
                    MessageBox.Show("Element book used, " + user.Opposition.Name + "'s Accuracy reduced");
                    user.elementType = "Water";
                    //user.Opposition.Accuracy -= 20;
                    user.skillQueue.Add(() => user.Opposition.LoweringAccuracy(20, user));
                    break;
            }
        }
    }
    public class FireElement : Skill
    {
        public FireElement()
        {

        }
    }
    public class WaterElement : Skill
    {
        public WaterElement()
        {

        }
    }
    public class WindElement : Skill
    {
        public WindElement()
        {

        }
    }
    public class EarthElement : Skill
    {
        public EarthElement()
        {

        }
    }
    public class Mog : Skill
    {
        public Mog()
        {
            this.Name = "Mog";
            this.Price = 69;
        }

        public override void Perform(Character user)
        {
            MessageBox.Show("Used " + this.Name);
            // add status effect na nagbabawas  ng rizz per turn
            user.Health -= 50;
            user.Defense -= 5;
            //user.Accuracy -= 10;
            user.skillQueue.Add(() => user.Opposition.LoweringAccuracy(10, user));
            user.Rizz += 100;
        }
    }

    public class Bounce : Skill
    {
        public Bounce()
        {
            this.Name = "Bounce";
            this.Price = 69;
        }

        public override void Perform(Character user)
        {
            MessageBox.Show("Used " + this.Name);
            user.isBlocking = true;

            BounceSkill bounceSkill = new BounceSkill("Bounce");
            user.CharStatEffects.Add(bounceSkill);
            bounceSkill.Trigger(user);
        }
    }
        



    // KNIGHT SKILLS


    public class Block : Skill
    {
        public Block()
        {
            this.Name = "Block";
        }

        public override void Perform(Character user)
        {
            MessageBox.Show($"Used {Name}");
            user.isBlocking = true;
        }
    }
    public class Slash : Skill
    {
        public Slash()
        {
            this.Name = "Slash";
        }

        public override void Perform(Character user)
        {
           // MessageBox.Show($"Used {Name}");
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
           // user.Opposition.DamageCharac(10, user);
            //user.Opposition.Health -= 50;

        }
    }
    public class ShieldBash : Skill
    {
        public ShieldBash()
        {
            this.Name = "ShieldBash";
        }

        public override void Perform(Character user)
        {
            //MessageBox.Show($"Used {Name}");
            user.skillQueue.Add(() => user.Opposition.DamageCharac(0, user, this.Name));
            // chance lang yung stun
            user.Opposition.hasTurn = false;
        }
    }

    // WIZARD SKILLs
    public class Fireball : Skill
    {
        public Fireball()
        {
            this.Name = "Fireball";

        }

        public override void Perform(Character user)
        {
           // MessageBox.Show($"Used {Name}");
            //user.CharStatEffects.Add(new DmgPerTurn("Burn", 10, 5));
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Fire", this.Name));
           // user.Opposition.ElementDamageCharac(20, user, "Fire");
        }
    }
    public class RockHurl : Skill
    {
        public RockHurl()
        {
            this.Name = "Rock Hurl";
        }

        public override void Perform(Character user)
        {
            //MessageBox.Show($"Used {Name}");
            // test

            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Earth", this.Name));
           // user.Opposition.ElementDamageCharac(20, user, "Earth");
        }
    }
    public class WindSlice : Skill
    {
        public WindSlice()
        {
            this.Name = "Wind Slice";
        }

        public override void Perform(Character user)
        {
           // MessageBox.Show($"Used {Name}");
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Wind", this.Name));
           //user.Opposition.ElementDamageCharac(20, user, "Wind");
        }
    }
    public class WaterBlast : Skill
    {
        public WaterBlast()
        {
            this.Name = "Water Blast";
        }

        public override void Perform(Character user)
        {
           // MessageBox.Show($"Used {Name}");
           user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Water", this.Name));
           // user.Opposition.ElementDamageCharac(20, user, "Water");
        }
    }



    // PRIEST SKILLS
    public class Heal : Skill
    {
        public Heal()
        {
            this.Name = "Heal";
        }

        public override void Perform(Character user)
        {
           // MessageBox.Show($"Used {Name}");
            user.CharStatEffects.Add(new HealPerTurn("Heal", 10, 2));
        }
    }
    public class Smite : Skill
    {
        public Smite()
        {
            this.Name = "Smite";
        }

        public override void Perform(Character user)
        {
           // MessageBox.Show($"Used {Name}");

            if (user.Rizz < 50)
            {
                user.skillQueue.Add(() => user.Opposition.DamageCharac(40, user, this.Name));
                //user.Opposition.DamageCharac(40, user);
            }
            else if (user.Rizz < 60)
            {
                user.skillQueue.Add(() => user.Opposition.DamageCharac(20, user, this.Name));
               // user.Opposition.DamageCharac(20, user);
            }
            else
            {
                user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
               // user.Opposition.DamageCharac(10, user);
            }
        }
    }
    public class Baptize : Skill
    {
        public Baptize()
        {
            this.Name = "Baptize";
        }

        public override void Perform(Character user)
        {
         //   MessageBox.Show($"Used {Name}");
            user.Defense -=5;

        }
    }


    // ROGUE SKILLS
    public class Stealth : Skill
    {
        public Stealth()
        {
            this.Name = "Stealth";
        }

        public override void Perform(Character user)
        {
         //   MessageBox.Show($"Used {Name}");

            StealthBuff stealthBuff = new StealthBuff("Stealth Buff", user.Accuracy, user.CritChance, 5);
            user.CharStatEffects.Add(stealthBuff);
            stealthBuff.Trigger(user);
            //user.CharStatEffects.Add(new StealthBuff("Stealth Buff", user.Accuracy, user.CritChance, 5)); // test
        }
    }
    public class Poison : Skill
    {
        public Poison()
        {
            this.Name = "Poison";
        }

        public override void Perform(Character user)
        {
           // MessageBox.Show($"Used {Name}");
            user.CharStatEffects.Add(new DmgPerTurn("Poison", 5, 3)); // test
        }
    }
    public class Dagger : Skill
    {
        public Dagger()
        {
            this.Name = "Dagger";
           
        }

        public override void Perform(Character user)
        {
          //  MessageBox.Show($"Used {Name}");
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
           // user.Opposition.DamageCharac(10, user);
        }
    }

    // ARCHER SKILLS
    public class Lock : Skill
    {
        public Lock()
        {
            this.Name = "Lock";
        }

        public override void Perform(Character user)
        {
            MessageBox.Show($"Used {this.Name} , {user.Name} will deal 4x damage in the next turn");
            QuadrupleDamage quadrupleDamage = new QuadrupleDamage("Quadruple Damage", user.Multiplier);
            user.CharStatEffects.Add(quadrupleDamage);
            //quadrupleDamage.Trigger(user);

        }
    }

    public class Volley: Skill
    {
        public Volley()
        {
            this.Name = "Volley";
        }

        public override async void Perform(Character user)
        {
            Random random = new Random();
            int randomNumber = random.Next(2, 6);
            MessageBox.Show($"Used {Name} and shoots {randomNumber} times!");

            for (int i = 0; i < randomNumber; i++)
            {
                //MessageBox.Show("hit " + i);

               user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
              //  user.Opposition.DamageCharac(10, user);
                await Task.Delay(200);
            }
        }
    }
    public class Shoot: Skill
    {
        public Shoot()
        {
            this.Name = "Shoot";
        }

        public override void Perform(Character user)
        {
            MessageBox.Show($"Used {Name}");
            user.skillQueue.Add(() => user.DamageCharac(5, user, this.Name));
           // user.Opposition.DamageCharac(5, user);
        }
    }

    // EVIL CHEST SKILLS
    public class Chomp : Skill
    {
        public Chomp()
        {
            this.Name = "Chomp";
        }

        public override void Perform(Character user)
        {
            MessageBox.Show($"Used {Name}");
           user.skillQueue.Add(() => user.Opposition.DamageCharac(5, user, this.Name));
           // user.Opposition.DamageCharac(5, user);
        }
    }

    public class Haul : Skill
    {
        public Haul()
        {
            this.Name = "Haul";
        }

        public override void Perform(Character user)
        {
            MessageBox.Show($"Used {Name}");
            if (user.Opposition is Bloo oppositionBloo)
            {
                Random random = new Random();
                int chance = random.Next(100);
                if (chance <= 25)
                {
                    oppositionBloo.Coins += 50;
                  
                    MessageBox.Show($"{user.Name} threw coins at {user.Opposition.Name}!");
                    user.skillQueue.Add(() => user.DamageCharac(5, user, this.Name));
                  //  user.DamageCharac(5, user);
                }
                else{
                    MessageBox.Show($"{user.Name} missed!");
                }
            }


            
        }
    }



    // MEMA SKILLS
    public class Empty : Skill
    {
        public Empty()
        {
            this.Name = "";
        }
        public override void Perform(Character user)
        {
        }
    }
    public class HealingPrayers : Skill
    {
        public HealingPrayers()
        {
            this.Name = "Healing Prayers";
        }
        public override void Perform(Character user)
        {
            MessageBox.Show($"Used {Name}");
        }
    }

  

    public class Recovery : Skill
    {
        public Recovery()
        {
            this.Name = "Recovery";
        }

        public override void Perform(Character user)
        {
            double healValue = 50;
            MessageBox.Show($"Used {Name} and recovered {healValue} health!");
            //target.Health += healValue;
           // user.UpdateHealth(50, user);
        }
    }
}
