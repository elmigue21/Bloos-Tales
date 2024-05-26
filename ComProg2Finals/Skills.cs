using System;
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
        public Form2 form2 = Form2.Instance;
        public string Name { get; protected set; }
        public int Price { get; set; }

        public Skill()
        {
            battleForm = Form1.GetInstance();
            form2 = Form2.Instance;
            //this.skillsQueue = battleForm.skillsQueue;
        }

        public virtual void Perform(Character user)
        {
          //  form2.dialogueTextBox.Text = $"{Name} skill performed.";

        }
        public void Learn(Bloo bloo)
        {
            bloo.CharSkills.Add(this);
            //form2.dialogueTextBox.Text = "added " + this.Name + " to bloos skills";
        }
    }

    // BLOO SKILLS
    public class Tackle : Skill
    {
        public Tackle()
        {
            this.Name = "Tackle";
        }

        public override async void Perform(Character user)
        {
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));

            form2.dialogueTextBox.Text = $"{user.Name} Used {Name}!";
           
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
         //   form2.dialogueTextBox.Text = "Used " + this.Name;
            user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-20));

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
            user.isBlocking = true;
            form2.dialogueTextBox.Text = "Bloo splits and makes other slimes to soak up damage!";
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
                    form2.dialogueTextBox.Text = "Element Book used, Burn inflicted on " + user.Opposition.Name;
                    user.elementType = "Fire";
                    user.Opposition.CharStatEffects.Add(new DmgPerTurn("Burn", 10, 5));
                    break;
                case 1:
                    form2.dialogueTextBox.Text = "Element book used, " + user.Name + " defense raised.";
                    user.elementType = "Earth";
                    user.Defense += 20;
                    break;
                case 2:
                    form2.dialogueTextBox.Text = "Element book used, Wind used";
                    user.elementType = "Wind";
                    user.CharStatEffects.Add(new MultiHitChance("WindHit", user));
                    break;
                case 3:
                    form2.dialogueTextBox.Text = "Element book used, " + user.Opposition.Name + "'s Accuracy reduced";
                    user.elementType = "Water";
                    user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-20));
                    break;
            }
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
            form2.dialogueTextBox.Text = "Used " + this.Name;
            // add status effect na nagbabawas  ng rizz per turn
            user.ChangeHealth(-50);
            user.Defense -= 5;
            //user.Accuracy -= 10;
            user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-10));
            user.ChangeRizz(100);
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
            MessageBox.Show("bloo jumps!");
           // form2.dialogueTextBox.Text = "Used " + this.Name;
            user.isBlocking = true;

            BounceSkill bounceSkill = new BounceSkill("Bounce");
            user.CharStatEffects.Add(bounceSkill);
            //bounceSkill.Trigger(user);
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
            form2.dialogueTextBox.Text = $"Used {Name}";
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
            form2.dialogueTextBox.Text = $"Used {Name}";
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));

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
            user.skillQueue.Add(() => user.Opposition.DamageCharac(5, user, this.Name));
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
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Fire", this.Name));
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
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Wind", this.Name));
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
           user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Water", this.Name));
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
            if (user.Rizz < 50)
            {
                user.skillQueue.Add(() => user.Opposition.DamageCharac(40, user, this.Name));
            }
            else if (user.Rizz < 60)
            {
                user.skillQueue.Add(() => user.Opposition.DamageCharac(20, user, this.Name));
            }
            else
            {
                user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
            }
        }
    }
    public class Purify : Skill
    {
        public Purify()
        {
            this.Name = "Purify";
        }

        public override void Perform(Character user)
        {
            user.Opposition.Defense -=1;

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
            StealthBuff stealthBuff = new StealthBuff("Stealth Buff", user.CritChance, 5);
            user.CharStatEffects.Add(stealthBuff);
            stealthBuff.Trigger(user);
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
            user.CharStatEffects.Add(new DmgPerTurn("Poison", 5, 3));
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
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
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
            form2.dialogueTextBox.Text = $"Used {this.Name} , {user.Name} will deal 4x damage in the next turn";
            QuadrupleDamage quadrupleDamage = new QuadrupleDamage("Quadruple Damage", user.Multiplier);
            user.CharStatEffects.Add(quadrupleDamage);

        }
    }

    public class Volley: Skill
    {
        public Volley()
        {
            this.Name = "Volley";
        }

        public override void Perform(Character user)
        {
            Random random = new Random();
            int randomNumber = random.Next(2, 6);
            form2.dialogueTextBox.Text = $"Used {Name} and shoots {randomNumber} times!";

            for (int i = 0; i < randomNumber; i++)
            {
               user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
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
            user.skillQueue.Add(() => user.DamageCharac(5, user, this.Name));
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
           user.skillQueue.Add(() => user.Opposition.DamageCharac(5, user, this.Name));
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
            if (user.Opposition is Bloo oppositionBloo)
            {
                Random random = new Random();
                int chance = random.Next(100);
                if (chance <= 25)
                {
                    oppositionBloo.ChangeCoin(50);
                    user.skillQueue.Add(() => user.DamageCharac(5, user, this.Name));
                }
                else{
                    form2.dialogueTextBox.Text = $"{user.Name} missed!";
                }
            }


            
        }
    }

}
