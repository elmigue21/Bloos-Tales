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
        public List<Action> skillsQueue;
        public Form2 form2 = Form2.Instance;
        public string Name { get; protected set; }
        public int Price { get; set; }
        public SkillDiag skilldiag = new SkillDiag();
        
        public Skill()
        {
           // form2 = Form2.Instance;
           
            //this.skillsQueue = battleForm.skillsQueue;
        }

        public virtual async Task Perform(Character user)
        {

        }
        public async void Learn(Bloo bloo)
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

        public override async Task Perform(Character user)
        {
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
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
            user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-20));
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ", Enemy's accuracy reduced!"));
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
            user.isBlocking = true;
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ", Bloo's clones will soak up damage taken!"));
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
                    user.elementType = "Fire";
                    user.Opposition.CharStatEffects.Add(new DmgPerTurn("Burn", 10, 5));
                    user.skillQueue.Add(() => skilldiag.Perform(user, this.Name,", inflicted burn on enemey!"));
                    break;
                case 1:
                   // battleForm.dialoguePanel.Visible = true;
                  //  battleForm.dialogueTextBox.Text = "Element book used, " + user.Name + " defense raised.";
                   // await Task.Delay(2000);
                    user.elementType = "Earth";
                    user.Defense += 20;
                    user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ", Bloo's defense increased!"));

                    break;
                case 2:
                   // battleForm.dialoguePanel.Visible = true;
                  //  battleForm.dialogueTextBox.Text = "Element book used, Wind used";
                  //  await Task.Delay(2000);
                    user.elementType = "Wind";
                    user.CharStatEffects.Add(new MultiHitChance("WindHit", user));
                    user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ", Bloo's hit will have a chance to multihit!"));

                    break;
                case 3:
                  //  battleForm.dialoguePanel.Visible = true;
                   // battleForm.dialogueTextBox.Text = "Element book used, " + user.Opposition.Name + "'s Accuracy reduced";
                   // await Task.Delay(2000);
                    user.elementType = "Water";
                    user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-20));
                    user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ", Enemy's accuracy reduced!"));
                    // user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ", Enemy's accuracy reduced!"));
                    break;
            }
           // await Task.Delay(2000);
           // battleForm.dialoguePanel.Visible = false;
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
            // battleForm.dialoguePanel.Visible = true;
            //battleForm.dialogueTextBox.Text = "Bloo used Mog!";
            // add status effect na nagbabawas  ng rizz per turn
            user.ChangeHealth(-50);
            user.Defense -= 5;
            //user.Accuracy -= 10;
            user.skillQueue.Add(() => user.Opposition.ChangeAccuracy(-10));
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ", Enemy's accuracy reduced!"));
            user.ChangeRizz(100);
           // await Task.Delay(2000);
          //  battleForm.dialoguePanel.Visible = false;
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
           // battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Bloo jumps in the air!";
            user.isBlocking = true;

            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ", Bloo jumps high in the air!"));
            BounceSkill bounceSkill = new BounceSkill("Bounce");
            user.CharStatEffects.Add(bounceSkill);

           // await Task.Delay(2000);
            //battleForm.dialoguePanel.Visible = false;
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
            // battleForm.dialoguePanel.Visible = true;
            // battleForm.dialogueTextBox.Text = "Knight used Block!";
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ""));
            user.isBlocking = true;
          //  await Task.Delay(2000);
          //  battleForm.dialoguePanel.Visible = false;
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
          //  battleForm.dialoguePanel.Visible = true;
          //  battleForm.dialogueTextBox.Text = "Knight used Slash!";
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
            // await Task.Delay(2000);
            // battleForm.dialoguePanel.Visible = false;

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
            // battleForm.dialoguePanel.Visible = true;
            // battleForm.dialogueTextBox.Text = "Knight used Shield Bash!";
            user.Opposition.hasTurn = false;
            user.skillQueue.Add(() => user.Opposition.DamageCharac(0, user, this.Name));
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, ""));
            //user.Opposition.hasTurn = false;
            //  user.Opposition.hasTurn = false;
            //  await Task.Delay(2000);
            //  battleForm.dialoguePanel.Visible = false;
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
          //  battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Wizard used Fireball!";
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Fire", this.Name));
            //  await Task.Delay(2000);
            //  battleForm.dialoguePanel.Visible = false;
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

           // battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Wizard used Rock Hurl!";
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Earth", this.Name));
            //  await Task.Delay(2000);
            //  battleForm.dialoguePanel.Visible = false;
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
           // battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Wizard used Wind Slice!";
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Wind", this.Name));
            // await Task.Delay(2000);
            // battleForm.dialoguePanel.Visible = false;
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
          //  battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Wizard used Water Blast!";
            user.skillQueue.Add(() => user.Opposition.ElementDamageCharac(20, user, "Water", this.Name));
            // await Task.Delay(2000);
            //  battleForm.dialoguePanel.Visible = false;
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
           // battleForm.dialoguePanel.Visible = true;
            //battleForm.dialogueTextBox.Text = "Priest used Heal!";
            //user.CharStatEffects.Add(new HealPerTurn("Heal", 10, 2));
            user.skillQueue.Add(() => user.CharStatEffects.Add(new HealPerTurn("Heal", 10, 2)));
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, "Heal for 2 turns!"));
            // await Task.Delay(2000);
            // battleForm.dialoguePanel.Visible = false;
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
            //  battleForm.dialoguePanel.Visible = true;
            // battleForm.dialogueTextBox.Text = "Priest used Smite!";
            MessageBox.Show($"{user.Name} used {this.Name}");

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
            //await Task.Delay(2000);
           // battleForm.dialoguePanel.Visible = false;
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
           // battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Priest used Purify!";
            user.Opposition.Defense -=1;
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, $"{this.Name}'s defense reduced by 1!"));
            // await Task.Delay(2000);
            // battleForm.dialoguePanel.Visible = false;
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
          //  battleForm.dialoguePanel.Visible = true;
          //  battleForm.dialogueTextBox.Text = "Rogue used Stealth!";
            StealthBuff stealthBuff = new StealthBuff("Stealth Buff", user.CritChance, 5);
            user.CharStatEffects.Add(stealthBuff);
            stealthBuff.Trigger(user);
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, $"{this.Name}'s crit chance increased!"));
            //  await Task.Delay(2000);
            // battleForm.dialoguePanel.Visible = false;
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
           // battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Rogue used Stealth!";
            user.CharStatEffects.Add(new DmgPerTurn("Poison", 5, 3));
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, $"inflicted Poison on {user.Opposition.Name}"));
            // await Task.Delay(2000);
            // battleForm.dialoguePanel.Visible = false;
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
           // battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Rogue used Poison!";
            user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
            // await Task.Delay(2000);
            //  battleForm.dialoguePanel.Visible = false;
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
          //  battleForm.dialoguePanel.Visible = true;
           // battleForm.dialogueTextBox.Text = "Archer used Lock!";
            QuadrupleDamage quadrupleDamage = new QuadrupleDamage("Quadruple Damage", user.Multiplier);
            user.CharStatEffects.Add(quadrupleDamage);
            user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, $"{user.Name}'s damage is quadrupled!"));
            //  await Task.Delay(2000);
            //  battleForm.dialoguePanel.Visible = false;

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
          //  battleForm.dialoguePanel.Visible = true;
          //  battleForm.dialogueTextBox.Text = "Archer used Volley!";
            Random random = new Random();
            int randomNumber = random.Next(2, 6);
        //    battleForm.dialogueTextBox.Text = $"Used {Name} and shoots {randomNumber} times!";

            for (int i = 0; i < randomNumber; i++)
            {
               user.skillQueue.Add(() => user.Opposition.DamageCharac(10, user, this.Name));
            }

           // await Task.Delay(2000);
           // battleForm.dialoguePanel.Visible = false;
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
            //battleForm.dialoguePanel.Visible = true;//<=====

           // battleForm.dialogueTextBox.Text = "Archer used Shoot!";
            user.skillQueue.Add(() => user.DamageCharac(5, user, this.Name));

            // await Task.Delay(2000);//<=====
            // battleForm.dialoguePanel.Visible = false;//<====
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
            //  battleForm.dialoguePanel.Visible = true;
            //battleForm.dialogueTextBox.Text = "Mimic used Chomp!";
            user.skillQueue.Add(() => user.Opposition.DamageCharac(5, user, this.Name));
           // await Task.Delay(2000);
          //  battleForm.dialoguePanel.Visible = false;
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
            //battleForm.dialoguePanel.Visible = true;
            // battleForm.dialogueTextBox.Text = "Mimic used Haul!";
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

                    user.skillQueue.Add(() => skilldiag.Perform(user, this.Name, $"but missed!"));
                }
            }
          //  await Task.Delay(2000);
           // battleForm.dialoguePanel.Visible = false;


        }
    }

    public class SkillDiag
    {
        public SkillDiag()
        {
        }
        public void Perform(Character user, string skillName, string addText)
        {
            MessageBox.Show($"{user.Name} used {skillName} {addText}");
        }
    }

}
