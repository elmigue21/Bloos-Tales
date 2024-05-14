﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public Form1 battleForm = Form1.Instance;
        public StatusEffect(string name) { 

        }
        public void Remove()
        {

        }
        public virtual void Trigger(Character user)
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
            charac.Health -= dmg;
            MessageBox.Show($"dealt {Name} {dmg} health from {charac.Name}, {intervals} intervals remaining");
            intervals--;
            if (intervals == 0)
            {
                charac.CharStatEffects.Remove(this);
            }
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
            MessageBox.Show($"Healed {healVal} health from {charac.Name}, {intervals} intervals remaining");
            intervals--;
            if (intervals == 0)
            {
                charac.CharStatEffects.Remove(this);
            }
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
            //charac.Multiplier = quadrupleDamage;
            
            
            //MessageBox.Show("multiplier " + charac.Multiplier.ToString());
            
            
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
            /*else
            {
                intervals--;
            }*/
            battleForm.updateLabels();
        }

    }
    public class BounceSkill : StatusEffect
    {
        int intrvl;
        public BounceSkill(string name) : base(name)
        {
            intrvl = 1;
        }

        public override void Trigger(Character user)
        {
            user.isBlocking = true;
            if (intrvl == 0){
                user.isBlocking = false;
                user.CharStatEffects.Remove(this);
                MessageBox.Show("Bloo lands and damages the enemy!");
                user.DamageCharac(15, user);
            }
            else
            {
                MessageBox.Show("Bloo bounces in the air!");
                intrvl--;
            }
        }
    }
    public class HolyWaterHeal : StatusEffect
    {
        public HolyWaterHeal(string name) : base(name)
        {
            
        }

    }
    public class StealthBuff : StatusEffect
    {
        double accuracy;
        double critChance;
        int debuff = 50;
        int buff = 1;
        int intervals;

        public StealthBuff(string name, double accuracy, double crit, int intrvl) : base(name)
        {
            this.accuracy = accuracy - debuff;
            this.critChance = crit + 1;
            intervals = intrvl;
        }
        public override void Trigger(Character charac)
        {
            charac.Accuracy = accuracy;
            charac.CritChance = critChance;


            MessageBox.Show($"{charac} lost {debuff} Accuracy in exchange for {buff}% Critical Chance {intervals} turn");

            intervals--;
            if (intervals == 0)
            {
                charac.CritChance -= 1;
                charac.Accuracy -= buff;
                charac.CharStatEffects.Remove(this);
            }

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
}

}
