// ReadMethods.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace HauntedCastle.Commands
{
    public class ReadMethods
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void magic_staff()
        {
            if (Program.ROOM == "FIN")
            {
                c.Print("\n There is an inscription that you never noticed.\n\n It reads:\n\n \"CONGRATULATIONS, " + Program.name.Trim().ToUpper() + "!\n\n  By obtaining this most ancient magic staff,\n  you have achieved a victory like no other.\n\n  Your admirable cunning and unmatched skill\n  have led you this glorious achievement.\n\n  May you proudly boast of your feat.\"^");
                c.Print("\n You look over your belongings and status,\n amazed at what you have achieved on your journey.");

                c.Pause();
                Commands.Inventory.Run("i", "");
                c.Pause();
                _ = Commands.Diagnose.Run("h", "");

                c.ForegroundColor = ConsoleColor.Cyan;

                Console.Write("\n\n PRESS [Z] TO FINISH...");

                bool x = false;
                char m;

                while (!x)
                {
                    m = char.ToLower(Console.ReadKey(true).KeyChar);

                    x = m == 'z' || m == '5';
                }

                c.Print("\n\n");

                Methods.GameOver(true);
            }
        }

        public static void cookbook()
        {
            if (Program.Inventory[7] == 1)
            {
                c.Print("\n You do not need to look through the cookbook again\n since you already have a recipe.^");
            }
            else
            {
                Program.Inventory[7] = 1;

                Score.Addition(Score.B2_ObtainRecipe);

                c.Print("\n As you look through the cookbook, a loose page falls out.\n It is a recipe for tomato soup.\n\n You keep it.^");
            }
        }

        public static void spellbook()
        {
            // Declarations
            string spell = string.Empty;

            c.Print("\n You look through the book for a specific spell.^");

            c.StyleAlt("Enter a spell:");

            try
            {
                spell = c.ReadLine().ToLower();
            }
            catch { }

            c.Print("\n");

            if ((spell.Contains("invisibility") || spell.Contains("invisible") || spell.Contains("alakazam")) && Program.bookUNLOCKED)
            {
                c.Print("\n The page reads:\n\n \"Chapter I. SPELL of INVISIBILITY\n\n  Invisibility is the power to make oneself unable to be seen.\n  To invoke it, chant \'alakazam\'\n\n  This spell transports its caster to the unseen world.\"^");
            }
            else if (spell.Contains("hurt") || spell.Contains("injury"))
            {
                c.Print("\n The page reads:\n\n \"Chapter II. ELIXIR of INJURY\n\n  The cure for injury is water.\"^");
            }
            else if (spell.Contains("poison") || spell.Contains("cure") || spell.Contains("antidote") || spell.Contains("snake"))
            {
                c.Print("\n The page reads:\n\n \"Chapter III. ELIXIR of ANTIDOTE\n\n  The antidote for poisoning is tea.\"^");
            }
            else if (spell.Contains("spider") || spell.Contains("repel") || spell.Contains("presto"))
            {
                c.Print("\n The page reads:\n\n \"Chapter IV. SPELL of SPIDER REPELLING\n\n  This spell repels all spiders.\n  To invoke it, chant \'presto\'\"^");
            }
            else if (spell.Contains("open") || spell.Contains("sesame") || spell.Contains("opening"))
            {
                c.Print("\n The page reads:\n\n \"Chapter V. SPELL of OPENING\n\n  This spell can open some locks.\n  To invoke it, chant \'open sesame\'\"^");
            }
            else if (spell.Contains("revive") || spell.Contains("reviving") || spell.Contains("heal") || spell.Contains("life") || spell.Contains("invincibility") || spell.Contains("immortality") || spell.Contains("invincible") || spell.Contains("immortal") || spell.Contains("abra"))
            {
                c.Print("\n The page reads:\n\n \"Chapter VI. SPELL of REVIVING\n\n  The revive spell maintains maxium health.\n  To invoke it, chant \'abracadabra\'\"^");
            }
            else if (spell.Contains("fly") || spell.Contains("flight") || spell.Contains("teleport") || spell.Contains("travel") || spell.Contains("xyzzy"))
            {
                c.Print("\n The page has been torn out.^");
            }
            else if (spell.Contains("ulysseys") || spell.Contains("odysseus") || spell.Contains("odyssey") || spell.Contains("cyclops"))
            {
                c.Print("\n The page reads:\n\n \"Chapter VII. PHRASE of CYCLOPS REPELLING\n\n  This phrase can make a cyclops cower in fear.\n  To invoke it, shout \'Odysseus\'\"^");
            }
            else if (spell.Contains("mirror") || spell.Contains("fairest") || spell.Contains("beautiful") || spell.Contains("prettiest") || spell.Contains("pretty"))
            {
                c.Print("\n The page reads:\n\n \"Chapter X. PHRASE of MIRRORS\n\n  This phrase can be used to ask a talking magic mirror\n who the fairest of them all is.\n  To invoke it, begin your conversation by saying \'Mirror, mirror...\'\"^");
            }
            else if (spell.Contains("hello"))
            {
                c.Print("\n The page reads:\n\n \"Chapter XI. PHRASE of GREETING\n\n  This phrase can be used to greet someone.\n  To invoke it, begin your conversation by saying \'Hello...\'\"^");
            }
            else if (spell.Contains("nothing") || spell.Contains("silence"))
            {
                c.Print("\n The page reads:\n\n \"Chapter XII. SILENCE\n\n  Silence is best used in libraries.\n  To invoke it, say nothing.\"^");
            }
            else if (spell.Contains("bless") || spell.Contains("gesundheit"))
            {
                c.Print("\n The page reads:\n\n \"Chapter XII. SPELL of GOOD HEALTH\n\n  A wish for another's good health must be expressed after a sneeze.\n  To invoke it, say \'gesundheit\' or \'bless you\'\"^");
            }
            else if (spell == "")
            {
                c.Print("\n You did not specify which spell to look for.^");
            }
            else
            {
                c.Print("\n There is no such spell in the book.^");
            }
        }

        public static void ship()
        {
            c.Print("\n A huge, 57 m long sailing ship with masts reaching 16 m tall.\n\n The side of the ship reads:\n\n  \"H.S.S. LIBERTY\"^");
        }

        public static void strange_purple()
        {
            if (Program.bookUNLOCKED)
            {
                c.Print("\n A single word is written in the otherwise blank book:");
                c.Print("\n\n \"INVISIBILITY\"^");
            }
            else
            {
                if (Program.lockspeed == 3)
                {
                    c.Print("\n A small combination lock keeps the book shut.\n It is permanently stuck.^");
                }
                else
                {
                    // Declarations
                    bool invalidFormat = false;

                    if (Program.combo.Length != 3)
                    {
                        Program.combo = new string[] { "00", "00", "00" };
                    }

                    c.Print("\n A small combination lock keeps the book shut.\n It requires three 2-digit numbers to unlock.^");

                    c.StyleAlt("Enter a combination (3 2-digit numbers split by spaces):");

                    c.Print("__ __ __", ConsoleColor.Gray);

                    Console.CursorLeft -= 8;

                    try
                    {
                        Program.combo = c.ReadLine(8, true).Split(' ', ',', '-', '/');
                    }
                    catch { }

                    c.Print("\n");

                    if (Program.combo.Length != 3)
                    {
                        invalidFormat = true;
                    }

                    foreach (string num in Program.combo)
                    {
                        invalidFormat = num.Length != 2;

                        try
                        {
                            _ = Convert.ToInt32(num);
                        }
                        catch
                        {
                            invalidFormat = true;
                        }
                    }

                    if (invalidFormat)
                    {
                        c.Print("\n Hmm... That will not work!\n\n The lock requires three 2-digit numbers to unlock.^");
                    }
                    else
                    {
                        if (Program.combo[0] == Program.comboAnswer[0].ToString() && Program.combo[1] == Program.comboAnswer[1].ToString() && Program.combo[2] == Program.comboAnswer[2].ToString())
                        {
                            c.Print("\n The lock opens.^");

                            Program.bookUNLOCKED = true;

                            Score.Addition(Score.C_ReadStrangePurple);

                            strange_purple();
                        }
                        else
                        {
                            c.Print("\n The lock does not open.");
                            c.Print("\n Your incorrect attempt makes it slightly tighter.^");
                        }
                    }
                }
            }
        }

        public static void palm()
        {
            Program.readPalm = true;

            c.Print("\n You read your palm.^");
            c.Print("\n Your head line is deep: you have clear and focused thinking.");
            c.Print("\n Your line of life runs close to your thumb: you are often tired.");
            c.Print("\n Your line of life is deep: you have vitality.");
            c.Print("\n Your line of destiny is deep: you are strongly controlled by fate.");
            c.Print("\n Your line of health is missing: you have little to no health problems.");
            c.Print("\n Your money line crosses your line of destiny: you will find wealth through luck.^");
        }

        public static void coffin()
        {
            c.Print("\n A black, hexagonal coffin.^");

            if (Program.vampireAwake && Program.vampireGone)
            {
                c.Print("\n There is an engraving on the bottom of the coffin.\n\n It reads:\n\n \"OPEN SESAME\"^");
            }
            else if (Program.vampireAwake)
            {
                c.Print("\n There is writing inside, but the vampire is standing on top of it.^");
            }
            else
            {
                c.Print("\n It is closed.^");
            }
        }

        public static void fountain()
        {
            c.Print("\n A beautiful fountain depicting a majestic horse\n galloping through a river of foaming water.\n The basin is wide and round, with engraved lettering.\n\n It reads:\n\n \"Make a Wish\"^");
        }

        public static void cake()
        {
            if (Program.ateCake)
            {
                c.Print("\n The cake is already finished.^");
            }
            else
            {
                c.Print("\n A mysterious purple cake with writing on it.\n\n It reads:\n\n \"Happy Birthday!\"^");
            }
        }

        public static void sign()
        {
            c.Print("\n A small, bronze, wall-mounted sign.^");
            c.Print("\n It reads:\n\n \"EAST TOWER:\n  Floor 5: Wizard's Quarters\n  Floor 4: Office\n  Floor 3: Prison Cell\n  Floor 2: Armory\n  Floor 1: Treasure Room.\"^");
        }

        public static void calendar()
        {
            c.Print("\n An annual calendar.\n It is fastened to the north wall by a tack.^");
            c.Print(string.Format("\n The date {0}/{1}/{2} is circled.\n\n A caption reads:\n\n \"My Birthday!\"^", Program.comboAnswer[0], Program.comboAnswer[1], Program.comboAnswer[2]));
        }

        public static void floppy()
        {
            if (Program.Inventory[11] == 1)
            {
                c.Print("\n Scribbled in black ink is a single word:\n\n \"USELESS\"^");
            }
            else if (Program.ROOM == "PC" || Program.ROOM == "PartIX")
            {
                c.Print("\n It is inside of the computer's floppy disk drive.^");
            }
            else
            {
                c.Print("\n You do not have that.^");
            }
        }

        public static void recipe()
        {
            if (Program.Inventory[7] == 1 || Program.ROOM == "PartIII")
            {
                c.Print("\n It reads:\n\n \"Ingredients: Tomatoes.\n\n  Directions: Cook.\"^");
            }
            else if (Program.ROOM == "PartIII")
            {
                cookbook();
            }
        }

        public static void poetry()
        {
            c.Print("\n You open the book of poetry to a random page.^");

            string myAnswer = string.Empty;
            string[] poems = new string[]
            {
                "I'm not friendly to goats\n  But I let them cross moats\n  As collector of tolls\n  I am one of the...",
                "Her home's always growing\n  Because she loves sewing\n  With eight eyes to guide her\n  She's known as the...",
                "Pointy ears make me keen\n  You'll be heard and be seen\n  By the spy on your shelf\n  The watchful little..."
            };

            string[] poemAnswers = new string[]
            {
                "trolls",
                "spider",
                "elf"
            };

            Program.poemAnswer = Program.rnd.Next(poemAnswers.Length);

            c.Print(string.Format("\n The page reads:\n\n \"{0}\"^", poems[Program.poemAnswer]));

            c.StyleAlt("Enter the next word in the poem:");

            try
            {
                myAnswer = c.ReadLine(20).ToLower();
            }
            catch { }

            c.Print("\n");

            if (myAnswer == poemAnswers[Program.poemAnswer])
            {
                c.Print("\n A blinding light engulfs the room.\n\n You are rapidly transported through space and time to continue your journey.");
                c.Pause();
                Program.ROOM = Program.ROOM.Replace("#", "");
                FileSystem.TRAVELTO();
            }
            else
            {
                c.Print("\n Nothing happens.^");
            }
        }

        public static void newspaper()
        {
            if (Program.Inventory[16] == 1)
            {
                c.Print("\n You flip through the newspaper and skim over the most interesting articles.\n\n Page A1 reads:\n\n \"THE HAUNTED HERALD\n\n  Volume XVI, Issue 12.\n  " + DateTime.Now.DayOfWeek.ToString() + ", " + DateTime.Today.ToString("MMMM d") + "\n\n  KINGDOM's PRECIOUS MAGIC STAFF STOLEN\"");
                c.Pause();
                c.Print("\n Page A2 reads:\n\n \"NEWS: HISTORY's GREATEST HEIST\n\n  The magic staff, an ancient artifact and a symbol of the Kingdom's rich\n  culture was stolen early this morning. Royal reports have confirmed that\n  the thief was a moderately-intelligent human explorer named " + Program.name + ".\n  Authorities are desperately searching...\"");
                c.Pause();
                c.Print("\n Page B3 reads:\n\n \"BUSINESS: GOLD PRICES PLUMMET\n\n  Lawmakers have repealed the Anti-Dwarf Mining Act, which prohibits\n  dwarves from mining precious metals. The bill is a result of a recent\n  initiative to reduce the expense of unemployment compensation,\n  which has skyrocketed with the growth of the dwarf populaton in the\n  last decade. Seven entrepreneurial dwarves quickly responded to the\n  news, which was published in yesterday\'s issue, by forming a mining\n  company that single-handedly caused gold prices to decrease by over\n  eighty percent...\"");
                c.Pause();
                c.Print("\n Page B4 reads:\n\n \"TECHNOLOGY: RAZORTEETH ANNOUNCES LATEST TECH REVOLUTION\n\n  Razorteeth Studios announced the upcoming release of its latest\n  ground-breaking technology. Someone familiar with the product compared\n  its design to the innovative brilliance of wooden crates....\"");
                c.Pause();
                c.Print("\n Page B9 reads:\n\n \"MARKETS: MINING CAUSES MARKET CRISIS\n\n  Inflation of precious metals has caused prices of otherwise useless\n  items to increase exponentially...\"");
                c.Pause();
                c.Print("\n One of the advertisements on the back cover catches your eye.\n\n The page reads:\n\n \"Dr. LEPER O'CON's PEST CONTROL\n\n  Need help expelling an annoying magical creature?\n  Look no further than Dr. Leper O'Con, certified Magical Creatures Expert.\n  Find me at the end of any rainbow!\"^");
            }
            else
            {
                c.Print("\n You do not have that.^");
            }
        }

        public static void map()
        {
            if (!Program.mapRead)
            {
                Score.Addition(Score.P3_ReadMap);
            }

            Program.mapRead = true;

            Storyline.sky2 = "You look at the dark sky above you.\n Staring up at the heavens, you become aware of your terrible vision.\n You will not be able to use your naked eye to study the stars.";

            c.Print("\n A large, yellowed map, fastened to the wall by four tacks.^");
            c.Print("\n It is very complicated, but you understand that you must look up at the sky,\n using the positions of the stars to guide your journey.^");
        }
    }
}
