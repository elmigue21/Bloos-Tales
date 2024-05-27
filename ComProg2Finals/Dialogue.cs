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

        public string CommitEvent1 { get; set; }
        public string CommitEvent2 { get; set; }
        public string CommitEvent3 { get; set; }
        public string CommitEvent4 { get; set; }
        public string CommitEvent5 { get; set; }
        public string CommitEvent6 { get; set; }
        public string CommitEvent7 { get; set; }
        public string CommitEvent8 { get; set; }
        public string CommitEvent9 { get; set; }
        public string CommitEvent10 { get; set; }

        public string RockDialogue { get; set; }
        public string RingDialogue { get; set; }
        public string AmuletDialogue { get; set; }
        public string BehelithDialogue { get; set; }
        public string CologneDialogue { get; set; }
        public string PiggyDialogue { get; set; }
        public string LifeDialogue { get; set; }
        public string RizzBoosterDialogue { get; set; }
        public string HealthBoosterDialogue { get; set; }
        public string DefenseDownDialogue { get; set; }
        public string DuctTapeDialogue { get; set; }
        public string PocketHoleDialogue { get; set; }
        public string OneShotDialogue { get; set; }
        public string HardHelmentDialogue { get; set; }
        public string SpikedHelmetDialogue { get; set; }
        public string ExcaliburDialogue { get; set; }
        public string StrangeGemDialogue { get; set; }
        public string GoldenArrowDialogue { get; set; }
        public string HolyWaterDialogue { get; set; }
        public string GobletDialogue { get; set; }
        public string SplitSkillDialogue { get; set; }
        public string ElementSkillDialogue { get; set; }
        public string MogSkillDialogue { get; set; }
        public string BounceSkillDialogue { get; set; }


        public Dialogue()
        {

        }
    }
    public class ItemsDialogue : Dialogue
    {
        public ItemsDialogue()
        {
            this.RockDialogue = "Bloo obtained a rock!";
            this.RingDialogue = "Bloo obtained the Sacrifice Ring!";
            this.AmuletDialogue = "Bloo obtained the Berserk Amulet!";
            this.BehelithDialogue = "Bloo obtained a rock!";
            this.RockDialogue = "Bloo obtained the Behelith!";
            this.CologneDialogue = "Bloo obtained a cologne!";
            this.PiggyDialogue = "Bloo obtained a Piggy bank!";
            this.LifeDialogue = "Bloo obtained a Life Potion!";
            this.RizzBoosterDialogue = "Bloo obtained a Rizz Booster Potion!";
            this.HealthBoosterDialogue = "Bloo obtained a Health Booster Potion!";
            this.DefenseDownDialogue = "Bloo obtained a Defense Down Potion!";
            this.DuctTapeDialogue = "Bloo obtained a Duct Tape Potion!";
            this.PocketHoleDialogue = "Bloo obtained a Pocket Hole Potion!";
            this.OneShotDialogue = "Bloo obtained a One Shot Potion!";
            this.HardHelmentDialogue = "Bloo obtained a Hard Helmet!";
            this.SpikedHelmetDialogue = "Bloo obtained a Spiked Helmet!";
            this.ExcaliburDialogue = "Bloo obtained the Excalibur!";
            this.StrangeGemDialogue = "Bloo obtained a Strange Gem!";
            this.GoldenArrowDialogue = "Bloo obtained a Golden Arrow!";
            this.HolyWaterDialogue = "Bloo obtained the Holy Water!";
            this.GobletDialogue = "Bloo puts his name on the goblet!";
            this.SplitSkillDialogue = "Bloo obtained the Split Skill!";
            this.ElementSkillDialogue = "Bloo obtained the Element Book!";
            this.MogSkillDialogue = "Bloo obtained the Mog Skill!";
            this.BounceSkillDialogue = "Bloo obtained the Bounce Skill!!";
        }
    }
    public class PrologueDialogue : Dialogue
    {
        public PrologueDialogue()
        {
            this.IntroductionDialogue = "Bloo, a brave little slime embarked on an adventure to find his one true love. Traveling a great distance, he found himself in an unfamiliar place, encountering different people and discovering many new things along the way. Despite the challenge and uncertainties, he followed his path with unwavering determination to where his one true love awaited…";
        }
    }
    public class GoodEndingDialogue : Dialogue
    {
        public GoodEndingDialogue()
        {
            this.CommitEvent1 = "At long last, after hard-fought battles and surpassing many challenges, Bloo has encountered his one true love, Peech.";
            this.CommitEvent2 = "Peech have waited long and Bloo had been tardy for their meeting.";
            this.CommitEvent3 = "Bloo awaited a response from the fair maiden…";
            this.CommitEvent4 = "Peech acknowledges Bloo’s presence…";
            this.CommitEvent5 = "Bloo bounced around in joy as he achieved greatness amidst all the battles and challenges. Now, they’ve lived happily ever after…";
        }
    }
    public class BadEndingDialogue : Dialogue
    {
        public BadEndingDialogue()
        {
            this.CommitEvent1 = "At long last, after hard-fought battles and surpassing many challenges, Bloo has encountered his one true love, Peech.";
            this.CommitEvent2 = "Peech have waited long and Bloo had been tardy for their meeting.";
            this.CommitEvent3 = "Bloo awaited a response from the fair maiden…";
            this.CommitEvent4 = "Peech scorned Bloo’s presence…";
            this.CommitEvent5 = "Bloo hopped in despair, despite all his hard-fought battles, he felt defeated. His beloved, Peech has rejected his heart and never once seen again…";
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
            this.LoseDialogue = "Rage Quits";
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
            this.PassIntroDialogue = "You! Did you put your name on the goblet of fire?! calmly";
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
            this.PassIntroDialogue = "That gem you’re holding… Why does it look familiar…";
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
            this.Option1Dialogue = "Bloo opens the chest!";
            this.CommitEvent1 = "Bloo obtained a life potion!";
            this.CommitEvent2 = "Bloo obtained a pair of sunglasses!";
            this.CommitEvent3 = "Bloo obtained a blobful of coins!";
            this.CommitEvent4 = "The chest transformed into a mimic!";
            this.CommitEvent5 = "Bloo slayed the mimic and was rewarded…";
            this.CommitEvent6 = "The mimic has swallowed Bloo…";
            this.IgnoreDialogue = "Bloo chose to walk past fortune, a pity.";
        }
    }
    public class CaveDialogue : Dialogue
    {
        public CaveDialogue()
        {
            this.EntranceDialogue = "Bloo noticed a dark cave…";
            this.Option1Dialogue = "Bloo bravely enters into the darkness…";
            this.CommitEvent1 = "A piece of rock suddenly falls upon Bloo…";
            this.CommitEvent2 = "Bloo feels uneasy…";
            this.CommitEvent3 = "Bloo found a coin!";
            this.CommitEvent4 = "Bloo is filled with determination!";
            this.CommitEvent5 = "Bloo stepped on something weird…";
            this.CommitEvent6 = "Bloo's health was reduced by 20.";
            this.CommitEvent7 = "Bloo's Attack Damage was reduced by 20.";
            this.CommitEvent8 = "Bloo's Coins was reduced by 20.";
            this.CommitEvent9 = "Bloo's Rizz was reduced by 20.";
            this.CommitEvent10 = "Bloo's found nothing.";
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
            this.CommitEvent1 = "Bloo got an Extra Life!";
            this.IgnoreDialogue = "Bloo ignores a game reference…";
        }
    }
    public class MysteriousManDialogue : Dialogue
    {
        public MysteriousManDialogue()
        {
            this.EntranceDialogue = "An ominous figure appeared…";
            this.CommitEvent1 = "Bloo picked the blue pill and his health was reduced by 25%…";
            this.CommitEvent2 = "Bloo picked the blue pill and his accuracy was reduced by 25%…";
            this.CommitEvent3 = "Bloo picked the blue pill and his coins was reduced…";
            this.CommitEvent4 = "Bloo picked the red pill and his attack increased by 20…";
            this.CommitEvent5 = "Bloo picked the red pill and his critical chance increased by 25…";
            this.CommitEvent6 = "Bloo picked the red pill and his rizz increased…";
            this.IgnoreDialogue = "Bloo’s mom taught him to never talk to strangers…";
        }
    }
    public class JesterDialogue : Dialogue
    {
        public JesterDialogue()
        {
            this.EntranceDialogue = "I have a little mystery box for you giggles. What's inside? What’s inside? Oh, the excitement! Well, that’s the fun part, isn’t it? It could be a delightful surprise... or a dreadful shock! giggles louder";
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
            this.CommitEvent5 = "50 coins for a price of protection.";
            this.CommitEvent4 = "50 coins to make your enemies blind.";
            this.CommitEvent3 = "100 coins for a price of strength on your next encounter.";
            this.CommitEvent2 = "150 coins for a price of pure strength against a powerful enemy.";
            this.CommitEvent1 = "Sneak a peek at your enemy in exchange for your rizz.";
            this.IgnoreDialogue = "Bloo doesn’t want to look into his future…";
        }
    }
    public class WishingWellDialogue : Dialogue
    {
        public WishingWellDialogue()
        {
            this.EntranceDialogue = "They say, throw a coin in the well and your wishes will come through…";
            this.Option1Dialogue = "Bloo threw a coin...";
            this.CommitEvent1 = "Bloo’s wish came true!";
            this.CommitEvent2 = "Bloo got sad…";
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
            this.CommitEvent1 = "Bloo felt wealthy!";
            this.CommitEvent2 = "The goblet of fire burst into flames! But nothing happened?...";
            this.CommitEvent3 = "Nothing happened...";
            this.IgnoreDialogue = "Bloo ignored a movie reference…";
        }
    }
    public class AppleTreeDialogue : Dialogue
    {
        public AppleTreeDialogue()
        {
            this.EntranceDialogue = "Bloo found an apple tree and thought of giving a fruit to her beloved…";
            this.Option1Dialogue = "Bloo, with all his might, tackled the tree.";
            this.CommitEvent1 = "An apple fell down on Bloo’s head…";
            this.Option2Dialogue = "Bloo, having no hands or feet, climbed the tree.";
            this.CommitEvent2 = "Bloo fell down…";
            this.CommitEvent3 = "Bloo noticed something shiny!";
        }
    }
}