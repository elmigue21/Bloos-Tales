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

        public virtual async Task Perform(Character user)
        {

        }
        public async void Learn(Bloo bloo)
        {
            bloo.CharSkills.Add(this);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "added " + this.Name + " to bloos skills";
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }

    // BLOO SKILLS
    public class Tackle : Skill
    {
        public Tackle()
        {
            this.Name = "Tackle";
        }

        public override async Task Perform(Character user)
        {
            // await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Bloo used Tackle!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
            //  form2.dialogueTextBox.Text = $"Used {Name}";
        }

    }
    public class Goo : Skill
    {
        public Goo()
        {
            this.Name = "Goo";
        }

        public override async Task Perform(Character user)
        {
            //   form2.dialogueTextBox.Text = "Used " + this.Name;
            // await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Bloo used Goo!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-20));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;

        }
    }

    public class Split : Skill
    {
        public Split()
        {
            this.Name = "Split";
            this.Price = 69;
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Bloo splits and makes other slimes to soak up damage!";
            await Task.Delay(2000);
            user.isBlocking = true;
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class ElementBook : Skill
    {
        public ElementBook()
        {
            this.Name = "Element Book";
            this.Price = 69;
        }

        public override async Task Perform(Character user)
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
                    await Task.Delay(2000);
                    battleForm.dialoguePanel.Visible = true;
                    battleForm.dialogueTextBox.Text = "Element Book used, Burn inflicted on " + user.Opposition.Name;
                    await Task.Delay(2000);
                    user.elementType = "Fire";
                    user.Opposition.CharStatEffects.Add(new DmgPerTurn("Burn", 10, 5));
                    
                    break;
                case 1:
                    await Task.Delay(2000);
                    battleForm.dialoguePanel.Visible = true;
                    battleForm.dialogueTextBox.Text = "Element book used, " + user.Name + " defense raised.";
                    await Task.Delay(2000);
                    user.elementType = "Earth";
                    user.Defense += 20;
                    
                    break;
                case 2:
                    await Task.Delay(2000);
                    battleForm.dialoguePanel.Visible = true;
                    battleForm.dialogueTextBox.Text = "Element book used, Wind used";
                    await Task.Delay(2000);
                    user.elementType = "Wind";
                    user.CharStatEffects.Add(new MultiHitChance("WindHit", user));
                    
                    break;
                case 3:
                    await Task.Delay(2000);
                    battleForm.dialoguePanel.Visible = true;
                    battleForm.dialogueTextBox.Text = "Element book used, " + user.Opposition.Name + "'s Accuracy reduced";
                    await Task.Delay(2000);
                    user.elementType = "Water";
                    user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-20));
                    
                    break;
            }
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class Mog : Skill
    {
        public Mog()
        {
            this.Name = "Mog";
            this.Price = 69;
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Bloo used Mog!";
            await Task.Delay(2000);
            
            // add status effect na nagbabawas  ng rizz per turn
            user.ChangeHealth(-50);
            user.Defense -= 5;
            //user.Accuracy -= 10;
            user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-10));
            user.ChangeRizz(100);
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }

    public class Bounce : Skill
    {
        public Bounce()
        {
            this.Name = "Bounce";
            this.Price = 69;
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Bloo jumps in the air!";
            await Task.Delay(2000);
            user.isBlocking = true;
            

            BounceSkill bounceSkill = new BounceSkill("Bounce");
            user.CharStatEffects.Add(bounceSkill);
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
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

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Knight used Block!";
            await Task.Delay(2000);
            user.isBlocking = true;
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class Slash : Skill
    {
        public Slash()
        {
            this.Name = "Slash";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Knight used Slash!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;

        }
    }
    public class ShieldBash : Skill
    {
        public ShieldBash()
        {
            this.Name = "ShieldBash";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Knight used Shield Bash!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.DamageCharac(0, user, this.Name));
            user.Opposition.hasTurn = false;
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }

    // WIZARD SKILLs
    public class Fireball : Skill
    {
        public Fireball()
        {
            this.Name = "Fireball";

        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Wizard used Fireball!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Fire", this.Name));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class RockHurl : Skill
    {
        public RockHurl()
        {
            this.Name = "Rock Hurl";
        }

        public override async Task Perform(Character user)
        {
            //MessageBox.Show($"Used {Name}");
            // test

            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Wizard used Rock Hurl!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Earth", this.Name));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class WindSlice : Skill
    {
        public WindSlice()
        {
            this.Name = "Wind Slice";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Wizard used Wind Slice!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Wind", this.Name));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class WaterBlast : Skill
    {
        public WaterBlast()
        {
            this.Name = "Water Blast";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Wizard used Water Blast!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Water", this.Name));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }



    // PRIEST SKILLS
    public class Heal : Skill
    {
        public Heal()
        {
            this.Name = "Heal";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Priest used Heal!";
            await Task.Delay(2000);
            user.CharStatEffects.Add(new HealPerTurn("Heal", 10, 2));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class Smite : Skill
    {
        public Smite()
        {
            this.Name = "Smite";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Priest used Smite!";
            await Task.Delay(2000);
            
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
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class Purify : Skill
    {
        public Purify()
        {
            this.Name = "Purify";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Priest used Purify!";
            await Task.Delay(2000);
            user.Defense -=1;
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }


    // ROGUE SKILLS
    public class Stealth : Skill
    {
        public Stealth()
        {
            this.Name = "Stealth";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Rogue used Stealth!";
            await Task.Delay(2000);
            StealthBuff stealthBuff = new StealthBuff("Stealth Buff", user.CritChance, 5);
            user.CharStatEffects.Add(stealthBuff);
            stealthBuff.Trigger(user);
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class Poison : Skill
    {
        public Poison()
        {
            this.Name = "Poison";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Rogue used Stealth!";
            await Task.Delay(2000);
            user.CharStatEffects.Add(new DmgPerTurn("Poison", 5, 3));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class Dagger : Skill
    {
        public Dagger()
        {
            this.Name = "Dagger";
           
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Rogue used Poison!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }

    // ARCHER SKILLS
    public class Lock : Skill
    {
        public Lock()
        {
            this.Name = "Lock";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Rogue used Lock!";
            await Task.Delay(2000);
            QuadrupleDamage quadrupleDamage = new QuadrupleDamage("Quadruple Damage", user.Multiplier);
            user.CharStatEffects.Add(quadrupleDamage);
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;

        }
    }

    public class Volley: Skill
    {
        public Volley()
        {
            this.Name = "Volley";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Archer used Volley!";
            await Task.Delay(2000);
            Random random = new Random();
            int randomNumber = random.Next(2, 6);
            battleForm.dialogueTextBox.Text = $"Used {Name} and shoots {randomNumber} times!";

            for (int i = 0; i < randomNumber; i++)
            {
               user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
            }

            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }
    public class Shoot: Skill
    {
        public Shoot()
        {
            this.Name = "Shoot";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;//<=====

            battleForm.dialogueTextBox.Text = "Archer used Shoot!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.DamageCharac(5, user, this.Name));
            
            await Task.Delay(2000);//<=====
            battleForm.dialoguePanel.Visible = false;//<====
        }
    }

    // EVIL CHEST SKILLS
    public class Chomp : Skill
    {
        public Chomp()
        {
            this.Name = "Chomp";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Mimic used Chomp!";
            await Task.Delay(2000);
            user.skillQueue.Add(() => user.Opposition.DamageCharac(5, user, this.Name));
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;
        }
    }

    public class Haul : Skill
    {
        public Haul()
        {
            this.Name = "Haul";
        }

        public override async Task Perform(Character user)
        {
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = true;
            battleForm.dialogueTextBox.Text = "Mimic used Haul!";
            await Task.Delay(2000);
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
                    
                    battleForm.dialogueTextBox.Text = $"{user.Name} missed!";
                }
            }
            await Task.Delay(2000);
            battleForm.dialoguePanel.Visible = false;


        }
    }

}
