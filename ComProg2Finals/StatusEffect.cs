using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ComProg2Finals
{
    public class StatusEffect
    {
        public string Name { get; protected set; }
        //public Form1 battleForm = Form1.Instance;
        public Form1 battleForm = Form1.GetInstance();
        public Form2 form2 = Form2.Instance;
        public StatusEffect(string name) {
            battleForm = Form1.GetInstance();
            
        }
        public void Remove()
        {

        }
        public virtual void Trigger(Character user)
        {

        }
        public virtual void Debuff(Character user)
        {
            
        }
    }
    public class DmgPerTurn : StatusEffect
    {
        double dmg;
        int intervals;
        public DmgPerTurn(string name, double damage, int intrvl) : base(name)
        {
            dmg = damage;
            intervals = intrvl;
            Name = name;
        }
        public override void Trigger(Character charac)
        {
            charac.Opposition.Health -= dmg;
            form2.dialogueTextBox.Text = $"{charac.Name} dealt {dmg} health to {charac.Opposition.Name}, {intervals} intervals remaining";
            intervals--;
            if (intervals == 0)
            {
                charac.CharStatEffects.Remove(this);
            }
        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }

    }
    public class HealPerTurn : StatusEffect
    {
        double healVal;
        int intervals;
        public HealPerTurn(string name, double heal, int intrvl) : base(name)
        {
            healVal = heal;
            intervals = intrvl;
        }
        public override void Trigger(Character charac)
        {
            charac.Health += healVal;
            form2.dialogueTextBox.Text = $"Healed {healVal} health from {charac.Name}, {intervals} intervals remaining";
            intervals--;
            if (intervals == 0)
            {
                charac.CharStatEffects.Remove(this);
            }
        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }

    }

    public class QuadrupleDamage : StatusEffect
    {
        double quadrupleDamage;
        int intervals;
        public QuadrupleDamage(string name, double damage) : base(name)
        {
            quadrupleDamage = damage * 4;
            intervals = 1;
        }
        public override void Trigger(Character charac)
        {  
            if (intervals == 0)
            {
                charac.Multiplier /= 4;
                charac.CharStatEffects.Remove(this);

            }
            else
            {
                charac.Multiplier *= 4;
            }
            intervals--;

            battleForm.updateLabels();
        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }

    }
    public class BounceSkill : StatusEffect
    {
        int intrvl;
        public BounceSkill(string name) : base(name)
        {
            intrvl = 1;
            this.Name = "his momentum from bounce to land on the enemy";
        }

        public override void Trigger(Character user)
        {
            if (intrvl == 0) {
                user.CharStatEffects.Remove(this);
                Random random = new Random();
                int rand = random.Next(0,2);
                rand = 0;
                switch (rand) {
                    case 0:
                       // MessageBox.Show("Bloo lands and attacks the enemy");
                user.skillQueue.Add(()=>user.Opposition.DamageCharac(15, user, this.Name)  );
                        //form2.dialogueTextBox.Text = "Bloo lands and attacks the enemy!";
                        
                        break;
                    case 1:
                      //  form2.dialogueTextBox.Text = "Bloo lands and tries to attack the enemy but missed!";
                        break;
                }
            }
            else
            {
                form2.dialogueTextBox.Text = "Bloo bounces in the air!";
                intrvl--;
            }
        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }
    }
    public class HolyWaterHeal : StatusEffect
    {
        double healVal;
        public HolyWaterHeal(string name, double heal) : base(name)
        {
            healVal = heal;
        }
        
        public override void Trigger(Character charac)
        {
            if (charac.Health + healVal > 100)
            {
                charac.Health = 100;
                MessageBox.Show($"{charac.Name}'s health is maxed");
            }
            else
            {
                charac.Health += healVal;
                MessageBox.Show($"Healed {healVal} health from {charac.Name}");
            }
            
        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }

    }
    public class StealthBuff : StatusEffect
    {
        double critChance;
        int debuff = 50;
        int buff = 1;
        int intervals;

        public StealthBuff(string name, double crit, int intrvl) : base(name)
        {
            this.critChance = crit + 1;
            intervals = intrvl;
        }
        public override void Trigger(Character charac)
        {
            charac.CritChance = critChance;
            form2.dialogueTextBox.Text = $"{charac.Name} lost {debuff} Accuracy in exchange for {buff}% Critical Chance {intervals} turn";

            intervals--;
            if (intervals == 0)
            {
                charac.CritChance -= 1;
                charac.Accuracy += debuff;
                charac.CharStatEffects.Remove(this);
            }

        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }

    }
    public class ReflectDamage : StatusEffect
    {
        public ReflectDamage(string name) : base (name)
        {

        }
        public override void Trigger(Character charac)
        {

        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }
    }

    public class AttackBoost : StatusEffect
    {
        public AttackBoost(string name, double multip, Character user) : base (name){
            user.AttackDamage += user.AttackDamage * multip;
        }

    }
    public class DefenseBoost : StatusEffect
    {
        public DefenseBoost(string name, double val, Character user) : base(name)
        {
            battleForm.Player.Defense += val;
        }
    }
    public class MultiHitChance : StatusEffect
    {
        public int multiHitCount;
        public MultiHitChance(string name, Character user) : base(name)
        {
            Random random = new Random();
            multiHitCount = random.Next(4);
        }
        public override void Trigger(Character charac)
        {
            if (charac.skillQueue.Count > 0)
            {
                for (int i = 0; i < multiHitCount; i++)
                {
                    charac.skillQueue.Add(charac.skillQueue[0]);
                }
            }
            charac.CharStatEffects.Remove(this);
        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }
    }
    public class MogRizz : StatusEffect
    {
        int interval;
        public MogRizz(string name) : base(name)
        {
            interval = 5;
        }
        public override void Trigger(Character charac)
        {
            charac.Rizz -= 10;
            if (this.interval <= 0)
            {
                charac.CharStatEffects.Remove(this);
            }
        }
        public override void Debuff(Character user)
        {
            user.CharStatEffects.Remove(this);
        }
    }

}
