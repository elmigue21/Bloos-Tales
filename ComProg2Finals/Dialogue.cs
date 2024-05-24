using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComProg2Finals
{
    public class Dialogue
    {
        public string IntroductionDialogue { get; set; }
        public string EntranceDialogue { get; set; }
        public string AttackDialogue { get; set; } 
        public string RizzDialogue { get; set; }
        public string WinDialogue { get; set; }
        public string LoseDialogue { get; set; }
        public string PassIntroDialogue { get; set; }  
        public string PassDialogue { get; set; }
        public string Option1Dialogue { get; set; }
        public string Option2Dialogue { get; set; }
        public string Option3Dialogue { get; set; }
        public string IgnoreDialogue { get; set; }    


        public Dialogue() 
        {
         
        }
    }
    public class KnightDialogue : Dialogue
    {
        public KnightDialogue()
        {
            this.IntroductionDialogue = "As Bloo was bouncing his way, a faint sound of clinking metal echoed through the forest…";
            this.EntranceDialogue = "I, the honorable knight, shall vanquish this lowly slime!";
            this.AttackDialogue = "Let us fight to our deaths!";
            this.RizzDialogue = "By the gods, this slime is the most beautiful creature next to the princess I have ever seen. I would marry you if I were as gooey as you.";
            this.WinDialogue = "LET’S GOOOOO!";
            this.LoseDialogue = "*Rage Quits*";
            this.PassIntroDialogue = "By the heavens! Is that the sword from the stone? The Excalibur?";
            this.PassDialogue = "Please, I’m not as worthy as you, humble slime. This honorable knight cannot claim the Excalibur. Use it in your journey and conquer your enemies.";

        }
    }
    public class WizardDialogue : Dialogue
    {
        public WizardDialogue()
        {
            this.IntroductionDialogue = "Bloo bounces his way forward, when suddenly he feels a fearful presence tingling on his gooeyness…";
            this.EntranceDialogue = "OOH! What kind of slime is this? Is it a water type? A fire type? An earth type? Or maybe a wind type?";
            this.AttackDialogue = "It’s big brain time.";
            this.RizzDialogue = "From a genius to a genius! Please tell me more about four elementalisms, elucidating the intricacies of earthism, waterism, airism, and fireism, as they intertwine in the grand tapestry of existenceism.";
            this.WinDialogue = "I’m a five-head genius!";
            this.LoseDialogue = "Wa- wa- wait! I’m still calculating the elementalisms of existentialism!";
            this.PassIntroDialogue = "You! Did you put your name on the goblet of fire?! *calmly*";
            this.PassDialogue = "Marvelous! What wondrous feats this slime has made, embraced by the goblet’s embrace! A conundrum of magicism and mysterism!";

        }
    }
    public class PriestDialogue : Dialogue
    {
        public PriestDialogue()
        {
            this.IntroductionDialogue = "As Bloo continued his journey, Bloo began to feel warm… As if he was bouncing through endless purity…";
            this.EntranceDialogue = "What a cute little creature! But alas, your monstrous nature belies your charm.";
            this.AttackDialogue = "Your form is an embodiment of evil itself. Fear not, for I shall cleanse thee of its malevolence!";
            this.RizzDialogue = "OH MY GOD! Mr. Slime, you are the most adorable thing in the world. I just want to pinch those cheeks!";
            this.WinDialogue = "May god forgive thee Mr. Slime.";
            this.LoseDialogue = "Lord… why have you forsaken me…";
            this.PassIntroDialogue = "A holy water by the hands of this little creature?!";
            this.PassDialogue = "Divine blessings! This holy water, gifted by thy humble slime, carries the purity of innocence and thy wisdom of unexpected allies. You have my thanks…";

        }
    }
    public class RogueDialogue : Dialogue
    {
        public RogueDialogue()
        {
            this.IntroductionDialogue = "As the shadows of the forest enveloped Bloo, he noticed a man stalking through the shadows…";
            this.EntranceDialogue = "Man, I’m tired of getting worthless loot…";
            this.AttackDialogue = "Let’s see how much gold I can take from this mere slime.";
            this.RizzDialogue = "I see… A slime outsmarting me. This is beyond embarrassing, but I admit my inferiority, slime.";
            this.WinDialogue = "Git gud, scrub.";
            this.LoseDialogue = "Wow… you shouldn’t be cheating, man.";
            this.PassIntroDialogue = "";
            this.PassDialogue = "You slime, has made me the richest man in all the land! This is by far one of the rarest gems or might even be the rarest gem!";

        }
    }
    public class ArcherDialogue : Dialogue
    {
        public ArcherDialogue()
        {
            this.IntroductionDialogue = "Bloo felt a slight breeze as he bounces through the grassy fields…";
            this.EntranceDialogue = "In every draw of my bow, fate whispers through the wind, a constant companion to death's embrace.";
            this.AttackDialogue = "Behold the wind's wrath!";
            this.RizzDialogue = "Ah, dear slime, your colors dance so vividly. Would you care for a stroll together? I find your company quite... enchanting.";
            this.WinDialogue = "Victory, born of destiny's touch, is mine.";
            this.LoseDialogue = "Dang, role-playing is hard.";
            this.PassIntroDialogue = "In a sea of dullness, a gleaming arrow is in your hands. May I take a look?";
            this.PassDialogue = "By the gods, it's returned to me! This arrow, lost to time's grasp, now rests once more in my hands. With you, old friend, my aim finds its truest mark once again.";

        }
    }
    public class ShopkeeperDialogue : Dialogue
    {
        public ShopkeeperDialogue()
        {
            this.EntranceDialogue = "Howdy, Bloo! The finest wares for ya surviving needs, as usual.";
            this.Option1Dialogue = "That all pal? If ya ever need more help, I’m just around the corner!";
            this.IgnoreDialogue = "Aight pal, if ya ever found ya self in a sticky situation, I’m just a bounce away.";
        }
    }
    public class MasterGoowayDialogue : Dialogue
    {
        public MasterGoowayDialogue()
        {
            this.EntranceDialogue = "Yesterday is gooey, tomorrow is oozy, but today is squishy. That is why we are called slime.";
            this.Option1Dialogue = "Use your skills for good, dragon war– oops, wrong student… May that help you in your journey, young one.";
            this.IgnoreDialogue = "Perhaps you are not ready to learn my ways, young one.";
        }
    }
    public class ChestyDialogue : Dialogue
    {
        public ChestyDialogue()
        {
            this.EntranceDialogue = "Bloo found a chest!";
            this.Option1Dialogue = "";
            this.IgnoreDialogue = "Bloo chose to walk past fortune, a pity.";
        }
    }
    public class CaveDialogue : Dialogue
    {
        public CaveDialogue()
        {
            this.EntranceDialogue = "Bloo noticed a dark cave…";
            this.Option1Dialogue = "Bloo bravely enters into the darkness…";
            this.IgnoreDialogue = "Bloo got scared of the dark…";
        }
    }
    public class SwordStoneDialogue : Dialogue
    {
        public SwordStoneDialogue()
        {
            this.EntranceDialogue = "Bloo stumbled upon a sword from a stone. It says whoever pulls the sword shall be deemed king of this land.";
            this.Option1Dialogue = "Bloo was shocked as he pulled the sword effortlessly.";
            this.Option2Dialogue = "Bloo tried his best to pull the sword, but in his dismay, he wasn’t the chosen one.";
            this.IgnoreDialogue = "Bloo wasn’t interested in a mere sword…";
        }
    }
    public class BonfireDialogue : Dialogue
    {
        public BonfireDialogue()
        {
            this.EntranceDialogue = "A bonfire… Feels familiar…";
            this.Option1Dialogue = "Praise the sun!";
            this.IgnoreDialogue = "Bloo ignores a game reference…";
        }
    }
    public class MysteriousManDialogue : Dialogue
    {
        public MysteriousManDialogue()
        {
            this.EntranceDialogue = "An ominous figure appeared…";
            this.Option1Dialogue = "Bloo picked the blue pill and felt something…";
            this.Option2Dialogue = "Bloo picked the red pill and felt something…";
            this.IgnoreDialogue = "Bloo’s mom taught him to never talk to strangers…";
        }
    }
    public class JesterDialogue : Dialogue
    {
        public JesterDialogue()
        {
            this.EntranceDialogue = "I have a little mystery box for you giggles. What's inside? What’s inside? Oh, the excitement! Well, that’s the fun part, isn’t it? It could be a delightful surprise... or a dreadful shock! *giggles louder*";
            this.Option1Dialogue = "Bloo chose and felt something...";
            this.IgnoreDialogue = "Bloo dislikes clowns. He thinks they are scary and weird…";
        }
    }
    public class SeerDialogue : Dialogue
    {
        public SeerDialogue()
        {
            this.EntranceDialogue = "In your future, I see twists and turns, challenges and triumphs. Care to gaze into my crystal ball and see the future?";
            this.Option1Dialogue = "Bloo gazes into the crystal ball…";
            this.IgnoreDialogue = "Bloo doesn’t want to look into his future…";
        }
    }
    public class WishingWellDialogue : Dialogue
    {
        public WishingWellDialogue()
        {
            this.EntranceDialogue = "They say, throw a coin in the well and your wishes will come through…";
            this.Option1Dialogue = "Bloo threw a coin...";
            this.IgnoreDialogue = "Bloo doesn’t believe in wishes…";
        }
    }
    public class KingDialogue : Dialogue
    {
        public KingDialogue()
        {
            this.EntranceDialogue = "What manner of odd creature are you… Say, my kingdom has come to ruins, would you mind making a trade to this daring king?";
            this.Option1Dialogue = "What a splendid offer! Wealth over your precious items.";
            this.Option2Dialogue = "How bold! You risk your lives for your own charisma.";
            this.Option3Dialogue = "You disappoint me, slime. Here I thought you were a risk taker.";
            this.IgnoreDialogue = "Bloo doesn’t trade, Bloo only takes…";
        }
    }
    public class GobletDialogue : Dialogue
    {
        public GobletDialogue()
        {
            this.EntranceDialogue = "The goblet of fire is calling Bloo..";
            this.Option1Dialogue = "Bloo puts his name on the goblet...";
            this.IgnoreDialogue = "Bloo ignored a movie reference…";
        }
    }
    public class AppleTreeDialogue : Dialogue
    {
        public AppleTreeDialogue()
        {
            this.EntranceDialogue = "Bloo found an apple tree and thought of giving a fruit to her beloved…";
            this.Option1Dialogue = "Bloo, with all his might, tackled the tree.";
            this.Option2Dialogue = "Bloo, having no hands or feet, climbed the tree.x";
        }
    }
}
