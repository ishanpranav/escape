// Storyline.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace HauntedCastle
{
    internal class Storyline
    {
        // Declarations
        public static ConsoleColor inputColor = ConsoleColor.Gray;
        private static readonly GUI.Display c = new GUI.Display();
        private static readonly string stone = "A stone wall blocks your path.";
        private static readonly string ladderUp = "A ladder leads up through an opening in the white stone ceiling.";
        private static readonly string ladderDown = "A ladder leads down through a hole in the concrete floor.";
        private static readonly string lost = "You are lost.";
        private static readonly string open = "Open water.";
        public static readonly string sky = "You look up at the blue sky above you.";
        public static string sky2 = null;
        public static string sky3 = null;
        public static string sky4 = null;

        /// <summary>
        /// Opening
        /// </summary>
        public static void Gen()
        {
            Program.ROOM = "Gen";

            Methods.Checkpoint("Main Deck", "Open Waters: H.S.S. Opportunity");
            c.Print("\n You are standing on the long main deck of your sailing ship.\n\n As you scan the horizon, you realize that it is already " + DateTime.Today.ToString("MMMM d") + ".\n Years have passed since you began your expedition.\n\n You look down at your compass.\n Just a little further north.");
            c.Pause();
            Methods.Checkpoint("Crow's Nest", "Main Deck: Main Mast");
            c.Print("\n A brilliant red banner comes into view. Then another.\n\n The fog begins to clear.");
            c.Pause();
            Methods.Checkpoint("Drawbridge Gatehouse", "Haunted Castle");
            c.Print("\n The drawbridge lowers.\n\n With your compass in one hand and an empty leather bag in the other,\n you take your first step toward the radiant light\n emanating from the castle entrance.");
            c.Pause();
            Methods.Checkpoint("Treasure Room", "Haunted Castle: East Tower");
            c.Print("\n The treasure room is a chamber of unimaginable size and grandeur.\n\n The explorers of the past have already carried away much of the room's gold,\n but none were wise enough to seek the ancient magic staff.");
            c.Print("\n You stuff your leather bag with a handful of coins,\n looking for the staff in every corner of the room.\n\n Buried under the mound of gold, you find it.^");
            c.Print("\n You hear loud footsteps coming from the direction through which you entered.\n The guards will be here soon.\n\n You hastily climb up a ladder.\n\n Having made one random turn after another,\n you find yourself in complete and utter darkness.");

            Methods.SetPermanentHealth(100);
            Program.Inventory[6] = 1;
            Program.degrees = Program.rnd.Next(2, 179);
            Program.comboAnswer[0] = Program.rnd.Next(10, 13); // X = ? 10 to 12
            Program.comboAnswer[1] = Program.rnd.Next(Program.comboAnswer[0] + 1, 31); // Y = ? (X+1) to 30
            Program.comboAnswer[2] = 0;

            while (Program.comboAnswer[2] == Program.comboAnswer[0] || Program.comboAnswer[2] == Program.comboAnswer[1] || Program.comboAnswer[2] == 0)
            {
                Program.comboAnswer[2] = Program.rnd.Next(10, 36); // Z = ? 10 to 35 excluding X and Y
            }

            Methods.GenMazes();
            Methods.GenWord();

            c.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("\n\n PRESS [Z] TO BEGIN...");

            bool x = false;
            char m;

            while (!x)
            {
                m = char.ToLower(Console.ReadKey(true).KeyChar);

                x = m == 'z' || m == '5';
            }

            c.Print("\n\n");

            PartI();
        }

        /// <summary>
        /// Clearing
        /// </summary>
        public static void Q1()
        {
            Program.ROOM = "Q1";

            Methods.Checkpoint("Clearing", "Rainforest");

            c.Print("\n This is a clearing surrounded by a dense rainforest on all sides.^");

            CheckRainbow();

            Parser.Run("", "Q1", "There is a dense rainforest to the north.", "There is a dense rainforest to the south.", "There is a dense rainforest to the east.", "There is a dense rainforest to the west.", sky4, "", "", "", "", "", new string[] { "rainforest" });
        }

        /// <summary>
        /// Maze
        /// </summary>
        public static void Z()
        {
            Program.ROOM = "Z";

            Methods.Checkpoint("Inside of Rainforest", "Rainforest");

            c.Print("\n You are in a dense rainforest of infinite dimension.\n There are trees on all sides and the forest continues in every direction.^");

            CheckRainbow();

            string down = "You look down at the grass.";

            if (Program.mazeIdx == 16)
            {
                Score.Addition(Score.U_JungleDone);
                Storyline.Q2();
            }
            else if (Program.breadcrumbs[Program.mazeIdx])
            {
                c.Print("\n\n There is a trail of breadcrumbs here.^");

                down += "\n There is a trail of breadcrumbs here.^";
            }

            Parser.Run("", "Z", "There are trees to the north.", "There are trees to the south.", "There are trees to the east.", "There are trees to the west.", sky4 + "\n A tree leads up.", down, "", "", "", "", new string[] { "rainforest" });
        }

        public static void ZT()
        {
            Program.ROOM = "ZT";

            Methods.Checkpoint("Top of Tree", "Rainforest: Inside of Rainforest");

            c.Print("\n You are in the branches of a tree.\n\n Although your visibility has improved,\n your ability to navigate the rainforest has not improved.^");

            CheckRainbow();

            string down = "You look down at the grass.\n The tree leads down.";

            if (Program.breadcrumbs[Program.mazeIdx])
            {
                c.Print("\n\n There is a trail of breadcrumbs here.^");

                down += "\n There is a trail of breadcrumbs here.^";
            }

            Parser.Run("", "ZT", "The tree does not continue north.", "The tree does not continue south.", "The tree does not continue east.", "The tree does not continue west.", sky4, down, "", "", "", "", new string[] { "rainforest" });
        }

        /// <summary>
        /// End of Rainbow
        /// </summary>
        public static void Q2()
        {
            Program.ROOM = "Q2";

            Methods.Checkpoint("End of Rainbow", "Rainforest");

            c.Print("\n You have reached the end of the rainbow.\n\n An excited leprechaun sits on the grass.^");

            TalkToLeprechaun();

            c.Print("\n A hole leads down.^");

            string d = "The rainforest is too dense to navigate.";
            Parser.Run("", "Q2", "There are trees to the north.", "There are trees to the south.", "There are trees to the east.", "There are trees to the west.", sky4, "You look down at the grass.\n A hole leads further down.", d, d, d, d, new string[] { "rainforest", "leprechaun", "tunnel" });
        }

        public static void T1()
        {
            Program.ROOM = "T1";

            Methods.Checkpoint("Hole", "Underground");

            c.Print("\n You have fallen down a hole and have tumbled into an underground cave.^");

            if (Program.ateCake)
            {
                c.Print("\n There is an empty table in the center of the room.^");
            }
            else
            {
                c.Print("\n There is a purple cake on a table in the center of the room.^");
            }

            c.Print("\n A tiny doorway leads south.^");

            Parser.Run("T1", "T1", "The north wall is made of solid stone.", "A tiny doorway leads south.", "The east wall is made of solid stone.", "The west wall is made of solid stone.", "You look up at the opening of the hole.\n Light shines in from above.", "", stone, "", stone, stone, new string[] { "cake", "table2", "tunnel", "doorway" }, "The hole is too high for you to reach.");
        }

        public static void T2()
        {
            Program.ROOM = "T2";

            Methods.Checkpoint("Echo Chamber", "Underground");

            c.Print("\n This is hollow chamber at the center of the cave.\n\n A tiny doorway leads south.^");

            Parser.Run("", "T2", "The north wall is made of solid stone.", "A tiny doorway leads south.", "The east wall is made of solid stone.", "The west wall is made of solid stone.", "", "", stone, "", stone, stone, new string[] { "doorway" });
        }

        public static void T3()
        {
            Program.ROOM = "T3";

            Methods.Checkpoint("Magical Place", "Underground");

            c.Print("\n You are in a mysterious magic room.\n\n There is a manual on a desk here.^");

            Parser.Run("", "T3", "The north wall is made of solid stone.", "A tiny doorway leads south.", "The east wall is made of solid stone.", "The west wall is made of solid stone.", "", "", stone, "", stone, stone, new string[] { "desk", "doorway" });
        }

        public static void T4()
        {
            Program.ROOM = "T4";

            Methods.Checkpoint("Basement", "Gingerbread House");

            c.Print("\n You are in the basement of your gingerbread house.\n\n A ladder leads up.^");

            string d = "A wood-paneled wall blocks your path.";
            Parser.Run("", "T4", "The north wall is paneled with wood.", "The south wall is paneled with wood", "The east wall is paneled with wood.", "The west wall is paneled with wood.", "A ladder leads up.", "", d, d, d, d, new string[] { "tunnel", "ladder" }, "The ladder only leads up.");
        }

        public static void U1()
        {
            Program.ROOM = "U1";

            Methods.Checkpoint("Bedroom", "Gingerbread House");

            c.Print("\n There is a terrifying werewolf lying in your bed.\n Take caution: a single bite can kill you.\n\n It gnashes its teeth and growls frighteningly.\n\n A ladder leads down.\n\n To the west, a wooden door marked X leads outside.^");

            string d = "A wood-paneled wall blocks your path.";
            Parser.Run("", "U1", "The north wall is paneled with wood.", "The south wall is paneled with wood", "The east wall is paneled with wood.", "The west wall is paneled with wood.", "", "A ladder leads down.", d, d, d, d, new string[] { "tunnel", "ladder", "werewolf", "x" }, "The ladder only leads down.");
        }

        public static void U2()
        {
            Program.ROOM = "U2";

            Methods.Checkpoint("Pitch Black", "Darkness");

            c.Print("\n The scorched ruins of your once-beautiful homeland surround you.\n The observatory tower has been reduced to rubble.\n Your gingerbread house has turned to ash.\n\n You are facing an immense fire-breathing dragon.^");

            string d = "Nothing.";

            Parser.Run("", "U2", d, d, d, d, d, d, "", "", "", "", new string[] { "dragon" });
        }

        public static void DestroyDragon()
        {
            if (!Program.died)
            {
                Score.Addition(Score.Z_Undying);
            }

            c.Print("\n Realizing that it has been defeated,\n the dragon cowers in fear before flying away.");
            c.Pause();
            FIN();
        }

        public static void TalkToLeprechaun()
        {
            if (Program.Inventory[8] == 1)
            {
                Program.Inventory[8] = 0;
                Score.Addition(Score.W1_Leprechaun);

                c.Print("\n \"So, you've got a werewolf problem?\n\n  Well, I'm Dr. Leper O'Con, certified Magical Creatures Expert.\n  I'll teach you a spell that'll help in exchange for that flute.\"\n\n The leprechaun takes your flute.^");
            }

            c.Print("\n \"When you get back home, chant \"" + Program.word + "\" and you're problem'll be solved!\"^");
        }

        public static void CheckRainbow()
        {
            if (Storyline.sky4 != Storyline.sky && Storyline.sky4 != null)
            {
                c.Print("\n A rainbow glistens above the clouds,\n its wide arc ending somewhere in the rainforest.");
            }
        }

        /// <summary>
        /// Beach
        /// </summary>
        public static void E2()
        {
            Program.ROOM = "E2";
            Program.degrees = 180;

            Methods.Checkpoint("Beach", "Sunny Island");

            c.Print("\n You are standing on a beach on your home island.\n\n There are distant buildings to the north.\n The beach continues to the east and west.^");

            CheckRainbow();

            Parser.Run("", "E2", "There are distant buildings to the north.", open, "The beach continues to the east.", "The beach continues to the west.", sky4, "The depths of the ocean continue downward.\n You would rather not enter.", "", "There is nothing but open water to the south.", "", "", new string[] { }, "You would rather not submerge yourself in the water.");
        }

        /// <summary>
        /// South End
        /// </summary>
        public static void E3()
        {
            Program.ROOM = "E3";

            Methods.Checkpoint("South End", "Road");

            c.Print("\n This is the beginning of yellow road that continues north.\n\n There are beaches to the east and west.^");

            CheckRainbow();

            Parser.Run("", "E3", "The road continues north.", "To the south is the beach.", "To the east is the beach.", "To the west is the beach.", sky4, "You look down at the yellow road.", "", "", "", "", new string[] { });
        }

        /// <summary>
        /// North End
        /// </summary>
        public static void E4()
        {
            Program.ROOM = "E4";

            Methods.Checkpoint("North End", "Road");

            c.Print("\n This is the end of a yellow road that leads back south.\n\n There is a dense rainforest to the north.\n You see your house on the east side and an observatory to the west.^");

            CheckRainbow();

            Parser.Run("", "E4", "There is a dense rainforest to the north.", "The road leads back south.", "You see your house on the east side.", "You see an observatory to the west.", sky4, "You look down at the yellow road.", "", "", "", "", new string[] { "house", "observatory", "rainforest" });
        }

        /// <summary>
        /// Entrance to Home
        /// </summary>
        public static void E5()
        {
            Program.ROOM = "E5";

            Methods.Checkpoint("Entrance to Home", "Gingerbread House");

            c.Print("\n You have reached the entrance to your cozy gingerbread house.\n\n It is surrounded by a dense rainforest to the north and south.\n\n To the east, a wooden door marked X allows access to the interior.\n To the west is the yellow road.^");

            CheckRainbow();

            Parser.Run("", "E5", "There is a dense rainforest to the north.", "There is a dense rainforest to the south.", "To the east, a wooden door marked X allows access to the interior.", "To the west is the yellow road.", sky4, "You look down at the grass.", "", "", "", "", new string[] { "house", "x", "rainforest" });
        }

        /// <summary>
        /// Bedroom
        /// </summary>
        public static void J1()
        {
            Methods.Checkpoint("Bedroom", "Gingerbread House");

            c.Print("\n You enter your house, only to find a terrifying werewolf lying in your bed.\n Take caution: a single bite can kill you.\n\n It gnashes its teeth and growls frighteningly.\n\n A hole leads down.\n\n To the west, a wooden door marked X leads outside.^");

            string d = "A wood-paneled wall blocks your path.";
            Parser.Run("", "J1", "The north wall is paneled with wood.", "The south wall is paneled with wood", "The east wall is paneled with wood.", "The west wall is paneled with wood.", "", "A hole leads down.", d, d, d, d, new string[] { "tunnel", "ladder", "werewolf", "x" }, "The ladder only leads down.");
        }

        /// <summary>
        /// Entrance to Observatory
        /// </summary>
        public static void E6()
        {
            Program.ROOM = "E6";

            Methods.Checkpoint("Entrance to Observatory", "Observatory");

            c.Print("\n You are at the entrance to an observatory.\n\n It is surrounded by a dense rainforest to the north and south.\n\n To the west, a wooden door marked Y allows access to the interior.\n To the east is the yellow road.^");

            CheckRainbow();

            string d = "It would be unwise to enter the rainforest without guidance.";
            Parser.Run("", "E6", "There is a dense rainforest to the north.", "There is a dense rainforest to the south.", "To the east is the yellow road.", "To the west, a wooden door marked Y allows access to the interior.", sky4, "You look down at the grass.", d, d, "", "", new string[] { "observatory", "y", "rainforest" });
        }

        /// <summary>
        /// Spiral Staircase
        /// </summary>
        public static void J2()
        {
            Program.ROOM = "J2";

            Methods.Checkpoint("Bottom of Stairs", "Observatory: Spiral Staircase");

            c.Print("\n You are standing at the base of a twisting spiral staircase.\n\n A wooden door marked Y leads east to the exterior.^");

            Parser.Run("", "J2", "The north wall is made of white stone.", "The south wall is made of white stone.", "A wooden door marked Y leads east to the exterior.", "The west wall is made of white stone.", "", "", stone, stone, "", stone, new string[] { "y", "steps" }, "The stairs only lead up.");
        }

        /// <summary>
        /// Observation Deck
        /// </summary>
        public static void J3()
        {
            Program.ROOM = "J3";

            Methods.Checkpoint("Observation Deck", "Spiral Staircase: Top of Stairs");

            c.Print("\n This is the main observation area.\n Although the building functions as an observatory,\n there is no astronomical equipment of any kind here.\n\n The spiral staircase leads down.^");

            _ = CheckLight(true);
            CheckRainbow();

            string d = "You will fall off of the deck.";
            Parser.Run("", "J3", "The deck does not continue north.", "The deck does not continue south.", "The deck does not continue east.", "The deck does not continue west.", sky4 + "\n A thin ray of sunlight shines onto the floor.", "You look down at the concrete floor,\n onto which a thin ray of sunlight shines.\n\n The spiral staircase leads down.", d, d, d, d, new string[] { "steps", "rainforest" }, "The stairs only lead down.");
        }

        public static bool CheckLight(bool ShowRay)
        {
            if (Program.Inventory[15] == 1 && Program.Inventory[5] == 1)
            {
                if (ShowRay)
                {
                    c.Print("\n A thin ray of sunlight shines onto the floor.");
                }
            }
            else if (Program.Inventory[15] == 1 && Program.Inventory[5] == 0)
            {
                if (Program.InventoryCaptions[5] == InventoryItems.Key)
                {
                    c.Print("\n A thin ray of sunlight hits a silver key and reflects off it.^");
                }
                else if (Program.InventoryCaptions[5] == InventoryItems.Silver)
                {
                    c.Print("\n A thin ray of sunlight hits a lump of silver and reflects off it.^");
                }
            }
            else if (Program.Inventory[15] == 0 && Program.Inventory[5] == 1)
            {
                c.Print("\n Without a shiny material to reflect off of,\n the thin ray of sunlight passes directly through the monocle.^");
            }
            else if (Program.Inventory[15] == 0 && Program.Inventory[5] == 0)
            {
                if (Program.InventoryCaptions[5] == InventoryItems.Key)
                {
                    c.Print("\n A thin ray of sunlight passes through a monocle\n and is reflected off of a silver key.^");
                }
                else if (Program.InventoryCaptions[5] == InventoryItems.Silver)
                {
                    c.Print("\n A thin ray of sunlight passes through a monocle\n and is reflected off of a lump of silver.^");
                }

                sky4 = sky + "\n A rainbow glistens above the clouds,\n its wide arc ending somewhere in the rainforest.";

                c.Print("\n A rainbow glistens above the clouds,\n its wide arc ending somewhere in the rainforest.^");

                return true;
            }

            return false;
        }

        /// <summary>
        /// Infirmary
        /// </summary>
        public static void Rev()
        {
            Methods.Checkpoint("Bedroom", "Infirmary", false);

            c.Print("\n You find yourself in an infirmary bed,\n where you have been revived and nursed back to health.^");

            c.Print("\n A talking mirror rests against the south wall.\n On the west wall is a television.^");
            c.Print("\n Wooden crates are mankind's greatest invention.^");

            string tile = "A tiled wall blocks your path.";

            Parser.Run("WIZ", "REV", "The north wall is tiled.", "The south wall is tiled.\n A talking mirror rests against it.", "The east wall is tiled.", "The west wall is tiled.\n There is a television on it.", "", "", tile, tile, tile, tile, new string[] { "mirror", "counter", "television", "bed" });
        }

        /// <summary>
        /// Storage Room
        /// </summary>
        public static void PartI()
        {
            Program.ROOM = "PartI";

            string d = "It is too dark to see very much around you.";

            if (Program.InventoryCaptions[2] == InventoryItems.CandleLit)
            {
                Methods.Checkpoint("Storage Room", "Haunted Castle");

                c.Print("\n You are sitting in the storage room of an ancient castle.^");
                c.Print("\n A narrow passage leads east.^");

                if (Program.Inventory[2] == 0)
                {
                    c.Print("\n There is a lit candle here.^");

                    Parser.Run("", "0", "", "", "A narrow passage leads east.", "", "", "", stone, stone, "It would be unsafe to explore without taking the candle with you.", stone, new string[] { "window", "match", "candle" });
                }
                else
                {
                    Parser.Run("", "STOR", "", "", "A narrow passage leads east.", "", "", "", stone, stone, "", stone, new string[] { "window", "match", "candle" });
                }
            }
            else
            {
                Methods.Checkpoint("Darkness", "Haunted Castle: Storage Room");

                c.Print("\n You are sitting in the dark storage room of an ancient castle.^");

                Commands.Inventory.Run("i", "");

                c.Print("\n The castle walls are solid, impossible to break or burn.\n There is only one window.\n\n You see a match and an unlit candle.\n\n The room is too dark to navigate.^");

                Parser.Run("", "0", d, d, d, d, d, d, d, d, d, d, new string[] { "window", "match", "candle" });
            }
        }

        public static void Skywalk(string door)
        {
            Methods.Checkpoint("Skywalk", "Haunted Castle: " + Methods.GrammarCaps(door) + " Tower");
            c.Print("\n You are passing through an enclosed bridge that connects\n the main castle building to the " + door.ToLower() + " tower.");

            if (Program.Inventory[6] > 0)
            {
                c.Print("\n\n Your shield has gone missing.");

                Program.Inventory[6] = 0;
            }

            c.Pause();
        }

        /// <summary>
        /// Corridor
        /// </summary>
        public static void PartII()
        {
            Program.ROOM = "PartII";

            Methods.Checkpoint("Corridor", "Haunted Castle");

            c.Print("\n You are at one end of a long corridor.^");
            c.Print("\n On one side, leading north, a wooden door marked K allows access to the kitchen.\n Leading south, another door marked L provides access to the library.\n A narrow passage leads west to the storage room.^");

            Parser.Run("", "CORRIDOR", "A wooden door marked K allows access to the kitchen.", "A wooden door marked L provides access to the library.", "", "A narrow passage leads west to the storage room.", "", "", "", "", stone, "", new string[] { "k", "l" });
        }

        /// <summary>
        /// Library
        /// </summary>
        public static void PartIII()
        {
            Program.ROOM = "PartIII";

            Methods.Checkpoint("Library", "Haunted Castle");
            c.Print("\n You are in an ancient library.\n A crystal chandelier hangs from the ceiling.\n\n There are two armchairs across from a desk.^");
            c.Print("\n A cookbook, a spellbook, and a strange blue book are on top of a desk.\n\n An empty shelf covers the south wall.\n\n A doorway leads north to the corridor.^");

            Parser.Run("LIB", "L", "A doorway leads north to the corridor.", "An empty shelf covers the south wall.", "", "", "You look up at the solid stone ceiling.\n A chandelier hangs from its center.\n An empty shelf leads up.", "", "", "An empty shelf blocks your path.", stone, stone, new string[] { "shelf", "armchairs", "desk", "purple", "cookbook", "spellbook", "chandelier", "doorway", "secret" });
        }

        /// <summary>
        /// Ballroom
        /// </summary>
        public static void PartIV()
        {
            Program.ROOM = "PartIV";

            Methods.Checkpoint("Ballroom", "Haunted Castle");
            c.Print("\n You are in the ballroom.\n\n There are four wooden doors, one on each wall.\n Each is marked with a compass direction: N, S, E, and W.\n\n A sphinx sits in the center of the room.^");

            TalkToSphinx();

            Parser.Run("", "SR", "A wooden door marked N leads to the north tower.", "A wooden door marked S leads to the south tower.", "A wooden door marked E leads to the east tower.", "A wooden door marked W leads to the west tower.", "", "You look down at the dusty hardwood floor.", "", "", "", "", new string[] { "n", "s", "e", "w", "sphinx" });
        }

        public static void TalkToSphinx()
        {
            c.Print("\n \"North, south, east, or west?\n  Which direction is the best?\n  Three of them I like the least:\n  My favorite is the dawning...\"^");
        }

        /// <summary>
        /// Armory
        /// </summary>
        /// <param name="firstEntry"></param>
        public static void PartV(bool firstEntry)
        {
            Program.ROOM = "PartV";

            Methods.Checkpoint("Armory", "Haunted Castle: East Tower");

            if (firstEntry)
            {
                c.Print("\n This is a small armory.\n The door through which you entered has disappeared.\n You take a break to rest, since you have walked a long way.^");
            }
            else
            {
                c.Print("\n This is a small armory.^");
            }

            c.Print("\n A large wooden chest rests against the south wall.\n Across from the chest is a small sign on the north wall next to a wooden ladder.^");

            Parser.Run("", "A", "The north wall is made of solid stone.\n There is a small sign on it.", "The south wall is made of solid stone.\n A large wooden chest rests against it.", "", "", ladderUp, ladderDown, stone, stone, stone, stone, new string[] { "chest", "ladder", "sign" });
        }

        public static void PrisonCell2(bool firstEntry)
        {
            Program.firstprisoncell = firstEntry;

            if (Program.firstprisoncell)
            {
                Methods.Checkpoint("Prison Cell", "Haunted Castle: East Tower");
                c.Print("\n This is your original prison cell.^");
                c.Print("\n There is a small wall-mounted sign next to a wooden ladder.\n There is also a bed behind open wooden bars.");
                c.Pause();
            }
        }

        /// <summary>
        /// Prison Cell
        /// </summary>
        /// <param name="firstEntry"></param>
        public static void PartVI(bool firstEntry)
        {
            Program.ROOM = "PartVI";

            Program.firstprisoncell = firstEntry;

            if (!firstEntry)
            {
                Methods.Checkpoint("Prison Cell", "Haunted Castle: East Tower");
                c.Print("\n This is your original prison cell.^");
                c.Print("\n There is a small wall-mounted sign next to a wooden ladder.\n There is also a bed behind burnt wooden bars.^");

                Parser.Run("", "P", "The north wall is made of solid stone.\n There is a small sign on it.", "", "", "To the east is the cell's tiny bedroom.", ladderUp, ladderDown, stone, stone, stone, "", new string[] { "ladder", "sign", "bed", "bars" });
            }
            else
            {
                Methods.Checkpoint("Tiny Bedroom", "East Tower: Prison Cell");
                c.Print("\n You walk past the bars and lie down on the bed.\n You can finally sleep peacefully.^");
                c.Print("\n You wake up after eight hours of undisturbed sleep,\n feeling healthy and rested.^");
                c.Print("\n You stand up.\n\n The bars are now closed, trapping you in the cell.^");

                Methods.SetPermanentHealth(100);

                Program.State[0] = false;

                Parser.Run("", "", "The north wall is made of solid stone.\n There is a small sign on it.", "", "A ladder and a sign are on the other side of the bars.", "", "A ladder behind the bars leads up through an opening in the stone ceiling.", "A ladder behind the bars leads down through a hole in the concrete floor.", stone, stone, "Wooden bars block your path.", stone, new string[] { "ladder", "sign", "bed", "bars" }, "The ladder is on the other side of the bars.");
            }
        }

        /// <summary>
        /// Treasure Room
        /// </summary>
        /// <param name="firstEntry"></param>
        public static void PartVII(bool firstEntry)
        {
            Program.ROOM = "PartVII";

            Methods.Checkpoint("Treasure Room", "Haunted Castle: East Tower");
            c.Print("\n You are in a room once filled with great tresures.\n\n Inconsiderate theives have left this place almost completely empty.^");

            if (firstEntry)
            {
                Program.firsttreasureroom = false;

                Program.Inventory[0] += 2;

                c.Print("\n A single coin rests upon the ground.\n You keep it.\n\n After admiring the coin for a while,\n you look up and see a goblin wearing a nasty grin.^");
                c.Print("\n He draws his sword and jumps towards you.^");
                c.Print("\n \"Fool!\n\n  Did you really think that nobody was watching when you stole the king's gold?\"");
                c.Pause();
                _ = BattleSimulator.StartBattle(2, Program.SwordAttacks, "Haunted Castle: Treasure Room");
                c.Print("\n You search around and find a dorway leading west.");
                c.Pause();

                FileSystem.SaveData();
                FileSystem.TRAVELTO();
            }

            c.Print("\n There is a small wall-mounted sign next to a wooden ladder.^");

            if (!firstEntry)
            {
                c.Print("\n A doorway leads west.^");
            }

            Parser.Run("", "TR", "The north wall is made of solid stone.\n There is a small sign on it.", "", "", "A doorway leads west.", ladderUp, "You look down at the concrete floor covered in mounds of treasure.", stone, stone, stone, stone, new string[] { "ladder", "sign", "doorway" }, "You have already reached the bottom of the east tower.");
        }

        /// <summary>
        /// Wizard's Quarters
        /// </summary>
        public static void PartVIII()
        {
            Program.ROOM = "PartVIII";

            Methods.Checkpoint("Wizard's Quarters", "Haunted Castle: East Tower");
            c.Print("\n You are in the home of a powerful wizard.^");
            c.Print("\n A talking mirror rests against the south wall and a spellbook sits on a desk.\n There is a small wall-mounted sign next to a wooden ladder.^");

            Parser.Run("WIZ", "WQ", "The north wall is made of solid stone.\n There is a small sign on it.", "The south wall is made of solid stone.\n A talking mirror rests against it.", "", "", "You look up at the white stone ceiling.", ladderDown, stone, stone, stone, stone, new string[] { "ladder", "sign", "mirror", "spellbook", "desk" }, "You have already reached the top of the east tower.");
        }

        /// <summary>
        /// Office
        /// </summary>
        public static void PartIX()
        {
            Program.ROOM = "PartIX";

            Methods.Checkpoint("Office", "Haunted Castle: East Tower");
            c.Print("\n This is a small office.^");
            c.Print("\n A computer sits on top of a desk.^");

            if (Program.Inventory[11] == 0)
            {
                c.Print("\n Inside of the computer's disk drive is a floppy disk.^");
            }

            c.Print("\n There is also small wall-mounted sign next to a wooden ladder.^");

            Parser.Run("COMPUTER_ROOM", "COMPUTER_ROOM", "The north wall is made of solid stone.\n There is a small sign on it.", "", "", "", ladderUp, ladderDown, stone, stone, stone, stone, new string[] { "ladder", "sign", "computer", "desk", "drive", "floppy", "television" });
        }

        /// <summary>
        /// Top of Shelf
        /// </summary>
        public static void PartXI()
        {
            Program.ROOM = "PartXI";

            Methods.Checkpoint("Top of Shelf", "Haunted Castle: Library");
            c.Print("\n You are sitting on top of the library shelf.\n A crystal chandelier hangs from the center of the ceiling.^");

            if (!Program.elf)
            {
                c.Print("\n You find a gold coin here, which you keep.^");

                Program.Inventory[0] += 2;

                c.Print("\n A watchful elf sits on the shelf with you.\n He is wearing a red hat and red suit.\n He stares at you carefully.\n\n You stare back at him, surprised and slightly afraid.^");
                c.Print("\n He turns and opens a secret door behind the shelf.\n He goes south behind the wall, closes the door, and disappears.^");

                Score.Addition(Score.J * 2); // J.Elf

                Program.elf = true;
            }

            string d = "You will fall off of the shelf.";

            Parser.Run("LIB", "SHELF", "The shelf does not continue to the north.", "A secret door leads south behind the shelf.", "The shelf does not continue east.", "The shelf does not continue west.", "You look up at the solid stone ceiling.\n A chandelier hangs from its center.", "The shelf leads down to the main library area.", d, "", d, d, new string[] { "chandelier2", "secret", "elf" }, "You have already reached the top of the shelf.");
        }

        /// <summary>
        /// North Pole
        /// </summary>
        /// <param name="firstEntry"></param>
        public static void PartXII(bool firstEntry)
        {
            Program.ROOM = "PartXII";

            Methods.Checkpoint("Freezing Waters", "North Pole: Arctic Ocean");

            if (firstEntry)
            {
                c.Print("\n The castle library disappears and a vast, cold ocean materializes around you.\n You are treading in the freezing Arctic Ocean,\n at 0 degrees north and 0 degrees east.\n\n A wooden ladder leads up onto shore.\n\n Your compass needle begins to spin.^");
            }
            else
            {
                c.Print("\n A wooden ladder leads up onto shore.^");
            }

            string d = "At the north pole the only direction is south.";

            Parser.Run("", "IS", "You are already at the north pole!", "A magic portal leads south.", d, d, "A wooden ladder leads up onto shore.", "The depths of the freezing ocean continue downward.", "You are already at the north pole!", "", d, d, new string[] { "ladder" });
        }

        /// <summary>
        /// Snow-Covered Lane
        /// </summary>
        public static void PartXIII()
        {
            Program.ROOM = "PartXIII";

            Methods.Checkpoint("Snow-Covered Lane", "North Pole: Snowy Island");
            c.Print("\n You are standing on a snow-covered lane.\n\n A wooden ladder leads down into the water.\n\n There are exits to the south, south, south, and south.^");

            string d = "At the north pole the only direction is south.";

            Parser.Run("", "SNOW_COVERED_LN", "You are already at the north pole!", "A magic portal leads south.", d, d, sky, "A ladder leads down into the depths of the freezing ocean.", "You are already at the north pole!", "", d, d, new string[] { "ladder", "cottage" }, "The ladder only leads down.");
        }

        /// <summary>
        /// Kitchen
        /// </summary>
        public static void PartXV()
        {
            Program.ROOM = "PartXV";

            Methods.Checkpoint("Kitchen", "Haunted Castle");
            c.Print("\n You are in the castle's recently remodeled kitchen.\n\n A calendar is tacked to the north wall.\n Fresh tomatoes are on the counter, next to the stove.\n On the other side of the room is a sink filled with water.^");

            if (Program.Inventory[5] == 0 && Program.InventoryCaptions[5] == InventoryItems.Key)
            {
                c.Print("\n You glimpse a shiny key hanging from a hook next to a large door.^");
            }
            else
            {
                c.Print("\n You see an empty hook next to a large door.^");
            }

            c.Print("\n A doorway leads south to the corridor.^");

            string d = "A tiled wall blocks your path.";

            Parser.Run("", "K", "The north wall is plain and has a calendar tacked to it.", "A doorway leads south to the corridor.", "The east wall is beautifully tiled.", "The west wall is beautifully tiled.", "", "You look down at the floor covered in black and white kitchen tiles.", "A plain wall blocks your path.", "", d, d, new string[] { "door", "sink", "k_sink", "stove", "calendar", "tomatoes", "counter", "doorway", "key", "water", "hook" });
        }

        /// <summary>
        /// Stairs
        /// </summary>
        public static void PartXVI()
        {
            Program.ROOM = "PartXVI";

            Methods.Checkpoint("Top of Staircase", "Haunted Castle: Stairs");
            c.Print("\n You reach a large spiral staircase.\n\n The stairs lead down into great depths unknown.\n A doorway leads east.^");

            Parser.Run("", "S", "", "", "A doorway leads east.", "", "", "The staircase leads down into great depths unknown.", stone, stone, "", stone, new string[] { "steps" }, "The stairs only lead down.");
        }

        /// <summary>
        /// Underwater
        /// </summary>
        public static void PartXVII()
        {
            Program.ROOM = "PartXVII";

            if (Program.belowsealevel)
            {
                c.Print("\n You would rather not be submerged in freezing water again.^");
            }
            else
            {
                Score.Addition(Score.J); // J_GoDown

                Program.belowsealevel = true;

                Methods.Checkpoint("Underwater", "Arctic Ocean: Freezing Waters");
                c.Print("\n You dive down into the depths of the cold ocean.^");
                c.Print("\n You quickly come back up, as there is nothing to see here.");
                Methods.SetPermanentHealth(Program.PermanentHealth - 15);
                c.Pause();
                PartXII(false);
            }
        }

        /// <summary>
        /// Eerie Passage
        /// </summary>
        public static void PartXVIII()
        {
            Program.ROOM = "PartXVIII";

            Methods.Checkpoint("Eerie Passage", "Stairs: Bottom of Staircase");
            c.Print("\n You are at the beginning of an eerie-looking passage at the base of\n the stairs, which lead back up.\n\n A doorway leads east to a bright and welcoming room.^");

            Parser.Run("", "EP", "", "", "A doorway leads east to a bright and welcoming room.", "", "The staircase leads up.", "", stone, "", stone, stone, new string[] { }, "The stairs only lead up.");
        }

        /// <summary>
        /// Behind Wooden Bars
        /// </summary>
        public static void PartXIX()
        {
            Program.ROOM = "PartXIX";

            Methods.Checkpoint("Tiny Bedroom", "East Tower: Prison Cell");
            c.Print("\n There are bars here.\n The ladder and the sign are on the east side of the bars.^");

            Parser.Run("", "BWB", "The north wall is made of solid stone.\n There is a small sign on it.", "", "A ladder and a sign are on the other side of the bars.", "", "A ladder behind the bars leads up through an opening in the stone ceiling.", "A ladder behind the bars leads down through a hole in the concrete floor.", stone, stone, "Wooden bars block your path.", stone, new string[] { "ladder", "sign", "bed", "bars" }, "The ladder is on the east side of the bars.");
        }

        /// <summary>
        /// Throne Room
        /// </summary>
        public static void PartXX()
        {
            Program.ROOM = "PartXX";

            Methods.Checkpoint("Throne Room", "Haunted Castle");

            c.Print("\n You are standing in a large, open room.^");
            c.Print("\n In the center of the room is a grand throne,\n raised above the ground by marble steps.^");
            c.Print("\n Four pillars surround the the throne and support the ceiling.\n\n The room's only exit is through a pair of double doors leading\n west to a circular path, as the limestone gate has closed.\n\n The steps lead up to a platform.^");

            if (!Program.Ghosts[3])
            {
                c.Print("\n You cautiously walk towards them when the doors fling open and a skeleton enters.\n He is obviously the king, as he wears a gold crown upon his head and a red silk\n cape around his neck.^");
                c.Print("\n You quickly hide behind a pillar.\n You are lucky that he does not see you as he sits down on his throne.^");
                c.Print("\n You try to sneak past the king while he looks down, but he catches you easily.\n\n \"Intruder!\"\n\n He draws his sword and attacks as you cower in fear.");
                c.Pause();
                _ = BattleSimulator.StartBattle(3, Program.SwordAttacks, "Haunted Castle: Throne Room");

                FileSystem.SaveData();
                FileSystem.TRAVELTO();
            }

            Parser.Run("", "THRONE", "", "", "The limestone gate is closed.", "A pair of double doors leads west to a circular path.", "", "Steps lead up onto a raised platform.", stone, stone, "The limestone gate blocks your path.", "", new string[] { "doors", "columns", "throne", "steps", "gate" }, "The steps only lead up.");
        }

        /// <summary> Platform </summary>
        public static void PartX()
        {
            Program.ROOM = "PartX";

            Methods.Checkpoint("Platform", "Haunted Castle: Throne Room");
            c.Print("\n You are standing on a platform in a large, open room, facing a grand throne.^");
            c.Print("\n Four pillars surround you and support the ceiling.\n\n Steps lead down to the main throne room.^");

            Parser.Run("", "PLATFORM", "", "", "", "A pair of double doors leads west to a circular path.", "", "Steps lead down to the main throne room.", stone, stone, stone, "", new string[] { "doors", "columns", "throne", "steps" }, "The steps only lead down.");
        }

        /// <summary>
        /// Great Hall
        /// </summary>
        public static void PartXXI()
        {
            Program.ROOM = "PartXXI";

            Methods.Checkpoint("Great Hall", "Haunted Castle");
            c.Print("\n You are in a grand dining hall at the head of a long table, surrounded by fifty\n matching chairs.\n\n A glistening cup of coffee sits on the table.\n It is still hot: it was placed here recently.^");
            c.Print("\n A door, identical to the one in the kitchen,\n leads west, continuing your current circular path.^");

            Parser.Run("", "D", "", "", "", "A door leads west, continuing your current circular path.", "", "", stone, stone, stone, "", new string[] { "table", "coffee", "chairs", "door2" });
        }

        /// <summary>
        /// Janitor's Closet
        /// </summary>
        public static void PartXXII()
        {
            Program.ROOM = "PartXXII";

            Methods.Checkpoint("Utility Closet", "Haunted Castle");
            c.Print("\n You are in a tiny utility closet.\n While trying to reach the exit, you accidentally knock down a crate.\n It falls to the ground with a loud thud.^");
            c.Print("\n Someone enters through the north doorway.\n\n You quickly hide behind a box.\n\n \"I thought I heard something in here.\n  Oh well, I'll just alert the other guards anyway.\"^");
            c.Print("\n You hear loud footsteps.\n They slowly get softer, then fade away completely.^");
            c.Print("\n You only have enough time to take either the box or the crate.\n One might be useful later.\n\n One doorway leads north and another leads east.^");

            Parser.Run("", "JC", "A doorway leads north.", "", "The voice came from the east exit.", "", "", "", "", stone, "You would rather not be captured by the guards.", stone, new string[] { "box", "crate", "doorway" });
        }

        /// <summary> A1 </summary>
        public static void A1()
        {
            Program.ROOM = "A1";

            Methods.Checkpoint("Large Bedroom", "Haunted Castle");
            c.Print("\n You are in a large bedroom, complete with a bed and a small table.\n\n One doorway leads north to a washroom and another leads south.\n A tunnel leads west.^");

            Parser.Run("", "A1", "A doorway leads north to a washroom.", "A doorway leads south.", "", "A tunnel leads west.", "", "", "", "", stone, "", new string[] { "doorway", "bed", "table2", "tunnel" });
        }

        /// <summary> A2 </summary>
        public static void A2()
        {
            Program.ROOM = "A2";

            Methods.Checkpoint("Washroom", "Haunted Castle");
            c.Print("\n You are in a washroom.\n\n There is a small sink filled with water.\n\n To the south is the bedroom.^");

            Parser.Run("", "A2", "", "A doorway leads south to the bedroom.", "", "", "", "", stone, "", stone, stone, new string[] { "doorway", "sink", "water" });
        }

        public static void DeltaOut()
        {
            int prev = Program.lockspeed;

            while (prev == Program.lockspeed)
            {
                Program.lockspeed = Program.rnd.Next(3);
            }

            switch (Program.lockspeed)
            {
                case 0:
                    B2();
                    break;

                case 1:
                    B3();
                    break;

                case 2:
                    B4();
                    break;
            }
        }

        /// <summary> B1 </summary>
        public static void B1()
        {
            Program.ROOM = "B1";

            Methods.Checkpoint("Delta Room", "Haunted Castle: Tower of Relics");
            c.Print("\n You are lost in a triangular room at the intersection of three other rooms.\n\n Your compass needle begins to spin.^");

            Parser.Run("", "B1", lost, lost, lost, lost, "", "", "", "", "", "", new string[] { });
        }

        /// <summary> B2 </summary>
        public static void B2()
        {
            Program.ROOM = "B2";

            Methods.Checkpoint("Bottom of Tower", "Haunted Castle: Tower of Relics");
            c.Print("\n You are at the base of the central tower, three times as tall as the east tower.\n The ceiling extends up for a seemingly infinite distance.\n\n There is a large oriental rug on the floor.\n\n To the north is the delta room.^");

            Parser.Run("", "B2", "A doorway leads north to the delta room.", "", "", "", "The ceiling extends up for a seemingly infinite distance.", "There is a large oriental rug on the floor.", "", stone, stone, stone, new string[] { "doorway", "rug" }, "You see no obvious way to go up or down.");
        }

        /// <summary> B3 </summary>
        public static void B3()
        {
            Program.ROOM = "B3";

            Methods.Checkpoint("Tomb", "Haunted Castle: Tower of Relics");
            c.Print("\n This is a small tomb containing a black coffin.^");

            if (!Program.vampireGone && Program.vampireAwake)
            {
                c.Print("\n The vampire stares at you with a furious expression.\n Take caution: a single bite can kill you.^");
            }

            c.Print("\n To the east is the delta room.^");

            Parser.Run("V", "B3", "", "", "A doorway leads east to the delta room.", "", "", "", stone, stone, "", stone, new string[] { "doorway", "coffin", "vampire" });
        }

        /// <summary> B4 </summary>
        public static void B4()
        {
            Program.ROOM = "B4";

            Methods.Checkpoint("Gallery", "Haunted Castle: Tower of Relics");
            c.Print("\n This is a long art gallery with painted walls.\n\n There is a glass display case in the center of the room.\n An oil lamp rests inside of the display case.\n\n To the west is the delta room.^");

            Parser.Run("", "B4", "The north wall is painted turquoise.", "The south wall is painted bright orange", "The east wall is painted stark white.", "A doorway leads west to the delta room.", "", "", "A turquoise wall blocks your path.", "A bright orange wall blocks your path.", "A stark white wall blocks your path.", "", new string[] { "doorway", "case", "lamp" });
        }

        /// <summary> C1 </summary>
        public static void C1()
        {
            Program.ROOM = "C1";

            Methods.Checkpoint("Top of Oriental Rug", "Tower of Relics: Bottom of Tower");
            c.Print("\n You are riding on the floating oriental rug.\n The ceiling extends up for a seemingly infinite distance.^");

            string d = "You will fall off of the rug.";

            Parser.Run("", "C1", "A doorway below you leads north to the delta room.", "", "", "", "The ceiling extends up for a seemingly infinite distance.", "There is a large oriental rug below you.", "The doorway is too far below you.", d, d, d, new string[] { "doorway", "rug2" }, "The rug floats downwards, then floats back up again.");
        }

        /// <summary> C2 </summary>
        public static void C2()
        {
            Program.ROOM = "C2";

            Methods.Checkpoint("Top of Oriental Rug", "Haunted Castle: Tower of Relics");
            c.Print("\n You are riding on the floating oriental rug.\n The ceiling extends up for a seemingly infinite distance.\n\n There is a small hole to the south.^");

            string d = "You will fall off of the rug.";

            Parser.Run("", "C2", "", "A doorway below you leads north to the delta room.", "", "", "The ceiling extends up for a seemingly infinite distance.", "There is a large oriental rug below you.", "The doorway is too far below you.", "", d, d, new string[] { "doorway", "rug2", "tunnel" }, "The rug floats downwards, then floats back up again.");
        }

        /// <summary> C3 </summary>
        public static void C3()
        {
            Program.ROOM = "C3";

            Methods.Checkpoint("Entrance to Crawlway", "Tower of Relics: Crawlway");
            c.Print("\n This is a narrow maintenance tunnel with a short ceiling.\n\n A small hole leads north and the tunnel continues to the south.^");

            string d = "A steel wall blocks your path.";

            Parser.Run("", "C3", "To the north is a seemingly infinite abyss.\n You no longer have the rug to help you travel down safely.", "The tunnel continues to the south.", "The east wall is made of steel.", "The west wall is made of steel.", "You look up at the short ceiling.", "You look down at the steel floor.", "You no longer have the rug to help you travel there safely.", "", d, d, new string[] { "tunnel" }, "You no longer have the rug to help you travel up and down.");
        }

        /// <summary> C4 </summary>
        public static void C4()
        {
            Program.ROOM = "C4";

            Methods.Checkpoint("Crawlway", "Haunted Castle: Tower of Relics");
            c.Print("\n This is a narrow maintenance tunnel with a short ceiling.\n\n A small hole leads down and the tunnel continues to the south.^");

            string d = "A steel wall blocks your path.";

            Parser.Run("", "C4", "The north wall is made of steel.", "The tunnel continues to the south.", "The east wall is made of steel.", "The west wall is made of steel.", "You look up at the short ceiling.", "You look at the steel floor.\n A small hole leads down.", d, "", d, d, new string[] { "tunnel" }, "The steel ceiling blocks your path.");
        }

        /// <summary> C5 </summary>
        public static void C5()
        {
            Program.ROOM = "C5";

            Methods.Checkpoint("Fountain Room", "Haunted Castle");
            c.Print("\n You are standing in front of a monolithic,\n three-story gate made of Egpytian limestone.\n\n A beautiful fountain spews water into a basin.\n\n The gate leads west to a circular path.\n The hole in the ceiling is too high for you to reach.^");

            Parser.Run("", "C5", "", "", "", "To the west is a monolithic limestone gate.", "You look up at the solid gold ceiling.\n A hole leads up to a maintenance hatch,\n but it is too high for you to reach.", "", stone, stone, stone, "", new string[] { "tunnel", "gate", "fountain", "water" });
        }

        /// <summary>
        /// Series of Passages
        /// </summary>
        public static void PartXXIII()
        {
            Program.ROOM = "PartXXIII";

            Methods.Checkpoint("Magnificent Aisle", "Haunted Castle");
            c.Print("\n You are lost in a magnificent aisle with a ceiling supported by columns.^");

            Parser.Run("", "SOP", lost, lost, lost, lost, "You look up at the stone ceiling\n supported by columns.", "", "", "", "", "", new string[] { "columns" });
        }

        /// <summary>
        /// Series of Passages
        /// </summary>
        public static void SOP2()
        {
            Program.ROOM = "SOP2";

            Methods.Checkpoint("Atrium", "Haunted Castle");
            c.Print("\n You are lost in a bright atrium.\n\n Light shines in from the blue sky above.^");

            Parser.Run("", "SOP2", lost, lost, lost, lost, sky, "", "", "", "", "", new string[] { });
        }

        /// <summary>
        /// Series of Passages
        /// </summary>
        public static void SOP3()
        {
            Program.ROOM = "SOP3";

            Methods.Checkpoint("Regal Chamber", "Haunted Castle");
            c.Print("\n You are lost in a regal chamber.\n There is a marble statue in the center of the room.^");

            Parser.Run("", "SOP3", lost, lost, lost, lost, "", "", "", "", "", "", new string[] { "statue" });
        }

        /// <summary>
        /// Drawbridge Gatehouse
        /// </summary>
        public static void PartXXIV()
        {
            Program.ROOM = "PartXXIV";

            Methods.Checkpoint("Drawbridge Gatehouse", "Haunted Castle");
            c.Print("\n You are inside of the building where the drawbridge is stored.\n\n To the north is the courtyard.^");

            if (Program.InventoryCaptions[7] == InventoryItems.RecipePaperApproved)
            {
                c.Print("\n The drawbridge leads south over the moat.^");
            }
            else
            {
                c.Print("\n The drawbridge, once dropped, leads south.^");
            }

            c.Print("\n A tunnel leads west.^");

            Parser.Run("", "DRAWBRIDGE", "To the north is the courtyard.", "The drawbridge leads south once dropped.", "The east wall is large and made of white brick.", "A tunnel leads west.", "", "You look down at the concrete floor.\n The drawbridge leads further down once dropped.", "", "", "A large, white brick wall blocks your path.", "", new string[] { "drawbridge", "tunnel" });
        }

        /// <summary>
        /// Troll Booth
        /// </summary>
        public static void E1()
        {
            Program.ROOM = "E1";

            Methods.Checkpoint("Troll Booth", "Haunted Castle: Drawbridge Gatehouse");

            c.Print("\n You are facing a small toll booth.\n\n A colossal troll looks at you furiously and unintelligently.\n Take caution: a single strike can kill you.^");

            TalkToTroll();

            c.Print("\n A tunnel leads east to the main drawbridge gatehouse.^");

            string d = "A large, white brick wall blocks your path.";
            Parser.Run("", "TROLLB", "The north wall is large and made of white brick.", "The south wall is large and made of white brick.", "A tunnel leads east to the main drawbridge gatehouse.", "The west wall is large and made of white brick.", "", "You look down at the concrete floor.", d, d, "", d, new string[] { "drawbridge", "tunnel", "troll" });
        }

        public static void TalkToTroll()
        {
            if (Program.InventoryCaptions[7] == InventoryItems.RecipePaperApproved)
            {
                c.Print("\n \"I already open drawbridge.\n  What you want?\"^");
            }
            else if (Program.InventoryCaptions[7] == InventoryItems.RecipePaperUsed)
            {
                c.Print("\n \"Permit good.\n  I open drawbridge.\"\n\n The troll takes your permit,\n then exits east through the tunnel and returns promptly.\n\n \"Here, have newspaper. Good reading on journey.\"\n\n He hands you a newspaper, which you keep.^");

                Program.Inventory[7] = 0;
                Program.Inventory[16] = 1;
                Score.Addition(Score.H_OpenDrawbridge);
                Program.InventoryCaptions[7] = InventoryItems.RecipePaperApproved;
            }
            else
            {
                c.Print("\n \"You want cross drawbridge?\n  I need valid permit.\n\n  What you mean don't have permit?\n  Can't cross without permit!\n  Must pay troll with permit!\"\n\n You realize that you can forge a permit if you can use an item as paper,\n use another item as a pen, and use a third item as ink.^");
            }
        }

        /// <summary>
        /// Deep Waters
        /// </summary>
        public static void PartXXVI()
        {
            Program.ROOM = "PartXXVI";

            Methods.Checkpoint("Deep Waters", "Moat");
            c.Print("\n You are treading in the deep waters of the castle moat.\n\n You cannot to swim across,\n and the curent is gradually carrying you away from shore.\n\n You will need to use something as a raft.^");

            string d = "You cannot swim that far.";

            Parser.Run("", "DROWN", open, open, open, open, sky, "The depths of the moat continue downward.\n You would rather not enter.", d, d, d, d, new string[] { });
        }

        /// <summary>
        /// Inside of Crate
        /// </summary>
        public static void PartXXVII()
        {
            Program.ROOM = "PartXXVII";

            Methods.Checkpoint("Inside of Crate", "Moat: Deep Waters");
            c.Print("\n You are inside of a crate, floating in the deep waters of the castle moat.^");

            Parser.Run("", "M1", open, open, open, open, sky, "The depths of the moat continue downward.\n You would rather not enter.", "", "", "", "", new string[] { "crate2" }, "You would rather not submerge yourself in the water.");
        }

        /// <summary>
        /// Inside of Crate
        /// </summary>
        public static void MA()
        {
            Program.ROOM = "MA";

            Methods.Checkpoint("Inside of Crate", "Moat: Wide Waters");
            c.Print("\n You are inside of a crate, floating in the wide waters of the castle moat.\n\n Far off in the distance is a small ship.^");

            Parser.Run("", "MA", open, open, open, open, sky, "The depths of the moat continue downward.\n You would rather not enter.", "", "", "", "", new string[] { "crate2", "ship2" }, "You would rather not submerge yourself in the water.");
        }

        /// <summary>
        /// Inside of Crate
        /// </summary>
        public static void MB()
        {
            Program.ROOM = "MB";

            Methods.Checkpoint("Inside of Crate", "Moat: Rocky Waters");
            c.Print("\n You are inside of a crate, floating in the rocky waters of the castle moat.\n\n Off in the distance is a little ship.^");

            Parser.Run("", "MB", open, open, open, open, sky, "The depths of the moat continue downward.\n You would rather not enter.", "", "", "", "", new string[] { "crate2", "ship2" }, "You would rather not submerge yourself in the water.");
        }

        /// <summary>
        /// Inside of Crate
        /// </summary>
        public static void MC()
        {
            Program.ROOM = "MC";

            Methods.Checkpoint("Inside of Crate", "Moat: Kelpy Waters");
            c.Print("\n You are inside of a crate, floating in the kelpy waters of the castle moat.\n\n In the distance is a lonely ship.^");

            Parser.Run("", "MC", open, open, open, open, sky, "The depths of the moat continue downward.\n You would rather not enter.", "", "", "", "", new string[] { "crate2", "ship" }, "You would rather not submerge yourself in the water.");
        }

        /// <summary>
        /// Inside of Crate
        /// </summary>
        public static void PartXXVIII()
        {
            Program.ROOM = "PartXXVIII";

            Methods.Checkpoint("Inside of Crate", "Moat: Rigorous Waters");
            c.Print("\n You are inside of a crate, floating in the rigorous waters of the castle moat.\n\n The crate begins to rock violently as it is pushed by the strong current.\n\n A lonely ship sails in the distance, close enough for inspection.\n The open water extends in every direction: in order to cross safely,\n you will need to board the ship.\n\n First, you must get the captain's attention.^");

            Parser.Run("", "M2", open, open, open, open, sky, "The depths of the moat continue downward.\n You would rather not enter.", "", "", "", "", new string[] { "crate3", "ship" }, "You would rather not submerge yourself in the water.");
        }

        /// <summary>
        /// Rigorous Waters
        /// </summary>
        public static void D1()
        {
            Program.ROOM = "D1";

            Methods.Checkpoint("Rigorous Waters", "Moat");
            c.Print("\n You are treading in the rigorous waters of the castle moat.\n\n You will not be able to swim across,\n and the curent is quickly carrying you away from shore.\n\n The ship is now in full view, and a long rope leads up onto the deck.^");

            string d = "You cannot swim that far.";

            Parser.Run("", "D1", open, open, open, open, "A rope leads up onto the deck.", "The depths of the moat continue downward.\n You would rather not enter.", d, d, d, d, new string[] { "rope" }, "You would rather not submerge yourself in the water.");
        }

        public static void D2()
        {
            Program.ROOM = "D2";

            Methods.Checkpoint("Main Deck", "Open Waters: H.S.S. Liberty");
            c.Print("\n You are standing on the long main deck of the ship.^");

            Rats();

            c.Print("\n The deck continues aft and forward.\n A mast extends upwards and the rope leads down.\n You see land to port.^");

            Parser.Run("", "D2", "The deck continues forward.", "The deck continues aft.", open, "There is land to port.", "The main mast extends upwards.\n " + sky2, "The rope leads down into the depths of the moat.\n You would rather not enter.", "", "", "There is nothing but open water to starboard.", "The shores are far off in the distance.", new string[] { "rope2", "mast", "ship" });
        }

        public static void D3()
        {
            Program.ROOM = "D3";

            Methods.Checkpoint("Main Mast", "H.S.S. Liberty: Main Deck");
            c.Print("\n You are hanging from a beam on the main mast of the ship.\n\n It extends upwards and downwards.^");

            Parser.Run("", "D3", "The deck continues forward.", "The deck continues aft.", open, "There is land to port.", "The mast extends upwards.\n " + sky2, "The mast leads down to the ground.", "", "", "There is nothing but open water to starboard.", "The shores are far off in the distance.", new string[] { "mast", "ship" });
        }

        public static void FIN()
        {
            Program.ROOM = "FIN";

            Methods.Checkpoint("Vibrant Glow", "Darkness");

            c.Print("\n Your expedition is complete.^");
            c.Print("\n In the darkness, a swarm of flies surrounds an overturned honey pot.\n After a while, the honey sticks to their feet and wings,\n preventing them from flying away.\n\n  \"What stupid creatures are we!\n   For a short hour's pleasure we have wasted our whole lives!\"^");

            c.Print("\n Your magic staff is glowing vibrantly.^");

            string d = "Nothing.";
            Parser.Run("", "FIN", d, d, d, d, d, d, "", "", "", "", new string[] { });
        }

        public static void D4()
        {
            Program.ROOM = "D4";

            Methods.Checkpoint("Bow", "H.S.S. Liberty");
            c.Print("\n This is the bow, the front of the ship.\n\n A figurehead is fastened to the bowsprit.^");

            Rats();

            c.Print("\n The deck continues aft.\n A hole leads down into the lower compartments of the ship.^");

            Parser.Run("", "D4", open, "The deck continues aft.", open, "There is land to port.", sky2, "A hole leads down into the lower compartments of the ship.", "There is nothing but open water forward.", "", "There is nothing but open water to starboard.", "The shores are far off in the distance.", new string[] { "ship", "figurehead", "tunnel" });
        }

        public static void D8()
        {
            Program.ROOM = "D8";

            Methods.Checkpoint("Captain's Quarters", "Stern: Below Deck");
            c.Print("\n This is the captain's personal cabin.^");

            if (Program.Inventory[15] == 1 || Program.InventoryCaptions[15] == InventoryItems.MonocleLens)
            {
                c.Print("\n A huge, green cyclops sleeps soundly on the bed,\n now undisturbed by the rats.^");
            }
            else if (Program.ogAsleep)
            {
                c.Print("\n A huge, green cyclops wearing a monocle sleeps soundly on the bed,\n now undisturbed by the rats.^");
            }
            else if (!Program.ratsGone)
            {
                c.Print("\n A huge, green, monocle-wearing cyclops is trying to chase away three rats.\n\n \"Arr!\n\n  These confounded rats!\n\n  Will they ever let me sleep in peace?\"\n\n Take caution: a single strike can kill you.^");
            }
            else
            {
                c.Print("\n A huge, green, monocle-wearing cyclops stands before you.\n\n To your dismay, the three rats follow you back into the room.\n\n \"Arr!\n\n  Get those nasty creatures away from me, ye rascal!\n  And shouldn't you be swabbing the deck?\"\n\n Take caution: a single strike can kill you.^");
            }

            c.Print("\n A doorway leads forward to another cabin.\n A hole leads up to the deck.^");

            string d = "A sturdy wall blocks your path.";
            Parser.Run("", "D8", "A doorway leads forward to another cabin.", "There is a sturdy wall aft.", "There is a sturdy wall on the starboard side.", "There is a sturdy wall on the port side.", "A hole leads up to the deck.", "You look down at the wooden floor.", "", d, d, d, new string[] { "bed", "cyclops", "monocle", "tunnel" });
        }

        public static void D9()
        {
            Program.ROOM = "D9";

            Methods.Checkpoint("Cabin", "H.S.S. Liberty: Below Deck");
            c.Print("\n You are in a cabin with a bed.^");

            Rats();

            c.Print("\n One doorway leads aft to the captain's quarters\n and another leads forward to the galley.^");

            string d = "A sturdy wall blocks your path.";
            Parser.Run("", "D9", "A doorway leads forward to the galley.", "A doorway leads aft to the captain's quarters.", "There is a sturdy wall on the starboard side.", "There is a sturdy wall on the port side.", "You look up at the wooden roof above you.", "You look down at the wooden floor.", "", "", d, d, new string[] { "bed" });
        }

        public static void D10()
        {
            Program.ROOM = "DX";

            Methods.Checkpoint("Galley", "Bow: Below Deck");
            c.Print("\n This is the galley, the ship's kitchen.^");

            if (Program.ogAsleep)
            {
                c.Print("\n Three rats are eating some moldy cheese on the counter.^");
            }
            else if (Program.ratsGone)
            {
                c.Print("\n Three rats follow you into the room.\n They begin to nibble on some moldy cheese on the counter.^");
                Program.ogAsleep = true;
                Score.Addition(Score.P4_RatsEatCheese);
            }
            else
            {
                c.Print("\n There is moldy cheese on the counter.^");
            }

            c.Print("\n A doorway leads aft to a cabin and a hole leads up to the deck.^");

            string d = "A sturdy wall blocks your path.";
            Parser.Run("", "DX", "There is a sturdy wall forward.", "A doorway leads aft to a cabin.", "There is a sturdy wall on the starboard side.", "There is a sturdy wall on the port side.", "A hole leads up to the deck.", "You look down at the wooden floor.", d, "", d, d, new string[] { "cheese", "counter" });
        }

        public static void PC()
        {
            Program.ROOM = "PC";

            Methods.Checkpoint("Navigation Room", "Stern: Bridge");
            c.Print("\n You are in the navigation room.\n\n There is a computer on a desk made of oak wood.");

            if (Program.Inventory[11] == 0)
            {
                c.Print("\n Inside of the computer's disk drive is a floppy disk.^");
            }

            Rats();

            c.Print("\n A map is tacked to wall on the starboard side.\n\n A doorway on the port side leads to the main bridge area.^");

            string d = "A sturdy wall blocks your path.";
            Parser.Run("COMPUTER_ROOM", "PC", "There is a sturdy wall forward.", "There is a sturdy wall aft.", "There is a sturdy wall on the starboard side.\n A map is tacked to it.", "The main bridge area is on the port side.", "You look up at the wooden roof above you.", "You look down at the wooden floor.", d, d, d, "", new string[] { "computer", "map", "doorway", "desk", "drive", "floppy" });
        }

        public static void D7()
        {
            Program.ROOM = "D7";

            Methods.Checkpoint("Bridge", "H.S.S. Liberty: Stern");
            c.Print("\n This is the nautical bridge at the stern of the ship, enclosed by sturdy walls.\n\n The steering wheel is proudly displayed in the center of the room.^");

            Rats();

            c.Print("\n The deck continues forward.\n A doorway on the starboard side leads to a navigation room.\n A hole leads down into the lower compartments of the ship.^");

            string d = "A sturdy wall blocks your path.";
            Parser.Run("", "D7", "The deck continues forward.", "There is a sturdy wall aft.", "There is a navigation room on the starboard side.", "There is a sturdy wall to port.", "You look up at the wooden roof above you.", "A hole leads down into the lower compartments of the ship.", "", d, "", d, new string[] { "tunnel", "doorway", "wheel" });
        }

        public static void D6()
        {
            Program.ROOM = "D6";

            Methods.Checkpoint("Crow's Nest", "Main Deck: Main Mast");
            c.Print("\n This is the crow's nest of the ship.\n\n A telescope is stationed here.\n\n The mast leads down.^");

            Parser.Run("", "D6", open, open, open, "There is land to port.", sky2, "The mast leads down.", "The crow's nest does not continue forward.", "The crow's nest does not continue aft.", "There is nothing but open water to starboard.", "The shores are far off in the distance.", new string[] { "mast", "ship", "telescope" });
        }

        public static void Rats()
        {
            if (!Program.ogAsleep && Program.ratsGone)
            {
                c.Print("\n Three rats follow you here.^");
            }
        }

        /// <summary>
        /// Stables
        /// </summary>
        public static void PartXXXI()
        {
            Program.ROOM = "PartXXXI";

            Methods.Checkpoint("Stables", "Haunted Castle: North Plaza");
            c.Print("\n You hear chirping in the distance.\n\n This is a dusty stables building.\n The smell of horses still lingers, despite their absence.^");

            if (Program.Inventory[3] == 0 && Program.InventoryCaptions[3] == InventoryItems.Apple)
            {
                c.Print("\n An uneaten apple lies on the ground next to a feeding trough filled with water.^");
            }
            else
            {
                c.Print("\n There is a feeding trough filled with water here.^");
            }

            c.Print("\n To the north is a small oak forest.\n To the south is a blackberry grove.^");

            string d = "A large, white brick wall blocks your path.";

            Parser.Run("", "STABLES", "To the north is a small oak forest.", "To the south is a blackberry grove.", "The east wall is large and made of white brick.", "The west wall is large and made of white brick.", "You look up at the wooden roof above you.", "You look down at the concrete floor.", "", "", d, d, new string[] { "apple", "water", "trough" });
        }

        /// <summary>
        /// Recreation Room
        /// </summary>
        public static void PartXXXII()
        {
            Program.ROOM = "PartXXXII";

            Methods.Checkpoint("Recreation Room", "Haunted Castle");
            c.Print("\n This is a bright and colorful game room.\n\n There is a television on the east wall.^");
            c.Print("\n One doorway leads west and another leads south.^");

            Parser.Run("", "GAME", "", "A doorway leads south.", "The east wall is painted purple.\n There is a television on it.", "A doorway leads west.", "", "You look down at the colorfully carpeted floor.", stone, "", stone, "", new string[] { "counter", "doorway", "television" });
        }

        /// <summary>
        /// Courtyard
        /// </summary>
        public static void PartXXXIII()
        {
            Program.ROOM = "PartXXXIII";

            Methods.Checkpoint("Courtyard", "Haunted Castle: North Plaza");
            c.Print("\n You hear chirping in the distance.\n\n You are standing in the center of a wide and open courtyard,\n part of the castle's northern plaza.\n\n Light shines in from the blue sky above.\n\n To the south is the drawbridge gatehouse, to the east is a blackberry grove,\n and to the west is a small oak forest.^");

            Parser.Run("", "COURT", "The north wall is large and made of white brick.", "To the south is the drawbridge gatehouse.", "To the east is a blackberry grove.", "To the west is a small oak forest.", sky, "You look down at the concrete floor.", "A large, white brick wall blocks your path.", "", "", "", new string[] { "apple", "water" });
        }

        /// <summary>
        /// Blackberry Grove
        /// </summary>
        public static void PartXXXIV()
        {
            Program.ROOM = "PartXXXIV";

            Methods.Checkpoint("Blackberry Grove", "Haunted Castle: North Plaza");
            c.Print("\n You are in a grove of leafy blackberry bushes.^");

            if (Program.Inventory[12] == 0)
            {
                c.Print("\n A single blackberry hangs from a bush.^");
            }

            c.Print("\n To the west is the courtyard and to the north is the stables building.^");

            string d = "A large, white brick wall blocks your path.";

            Parser.Run("", "BERRYGROVE", "To the north is the stables building.", "The south wall is large and made of white brick.", "The east wall is large and made of white brick.", "To the west is the courtyard.", sky, "You look down at the ground, covered in untrimmed grass.", "", d, d, "", new string[] { "bushes", "blackberry" });
        }

        /// <summary>
        /// Oak Forest
        /// </summary>
        public static void PartXXXV()
        {
            Program.ROOM = "PartXXXV";

            Methods.Checkpoint("Oak Forest", "Haunted Castle");
            c.Print("\n You hear a loud chirping sound.\n\n This is a small forest of oak trees.^");

            if (Program.Inventory[13] == 0 && Program.Inventory[3] == 0 && Program.InventoryCaptions[3] == InventoryItems.Seeds)
            {
                c.Print("\n Sitting on the ground is a feathery bird.^");
            }
            else if (Program.Inventory[13] == 0)
            {
                c.Print("\n Sitting in a tree is a feathery bird.^");
            }
            else if (Program.Inventory[13] == 1)
            {
                c.Print("\n Sitting on the ground is a bird.^");
            }

            if (Program.beans)
            {
                c.Print("\n There is a tall beanstalk here.^");
            }

            c.Print("\n The forest continues in a circular path to the north and to the west.\n To the east is the courtyard and to the south is the stables building.^");

            Parser.Run("", "OAKFOREST", "The forest continues in a circular path to the north.", "To the south is the stables building.", "To the east is the courtyard.", "The forest continues in a circular path to the west.", sky3, "You look down at the untrimmed grass.", "", "", "", "", new string[] { "oak", "bird", "feather", "beanstalk" });
        }

        public static void Y1()
        {
            Program.ROOM = "Y1";

            Methods.Checkpoint("Bottom of Beanstalk", "Oak Forest: Beanstalk");
            c.Print("\n This is the bottom of the beanstalk, surrounded by oak trees.\n\n The beanstalk continues upwards and downwards.^");

            string d = "You will fall off of the beanstalk.";
            Parser.Run("", "Y1", "The beanstalk does not continue north.", "The beanstalk does not continue south.", "The beanstalk does not continue east.", "The beanstalk does not continue west.", "The beanstalk leads up.", "The beanstalk leads down.", d, d, d, d, new string[] { "oak", "beanstalk" });
        }

        public static void Y2()
        {
            Program.ROOM = "Y2";

            Methods.Checkpoint("Beanstalk", "Haunted Castle: Oak Forest");
            c.Print("\n You are now higher than the tops of the oak trees.\n\n The beanstalk continues upwards and downwards.^");

            string d = "You will fall off of the beanstalk.";
            Parser.Run("", "Y2", "The beanstalk does not continue north.", "The beanstalk does not continue south.", "The beanstalk does not continue east.", "The beanstalk does not continue west.", "The beanstalk leads up.", "The beanstalk leads down.", d, d, d, d, new string[] { "oak", "beanstalk" });
        }

        public static void Y3()
        {
            Program.ROOM = "Y3";

            Methods.Checkpoint("Giant's Palace", "Beanstalk: Top of Beanstalk");
            c.Print("\n This is the top of the beanstalk, far higher than the trees.^");

            if (!Program.beanGold)
            {
                Program.beanGold = true;
                Program.Inventory[0] += 192;
                Score.Addition(Score.J * 2);

                c.Print("\n You find three golden eggs here, which you keep.^");
            }

            c.Print("\n The beanstalk continues downwards.^");

            string d = "You will fall off of the beanstalk.";
            Parser.Run("", "Y3", "The beanstalk does not continue north.", "The beanstalk does not continue south.", "The beanstalk does not continue east.", "The beanstalk does not continue west.", sky, "The beanstalk leads down.", d, d, d, d, new string[] { "oak", "beanstalk" });
        }

        /// <summary> Ancient Chamber </summary>
        public static void R1()
        {
            Program.ROOM = "R1";

            Methods.Checkpoint("Ancient Chamber", "Haunted Castle");

            if (Program.pyAwake)
            {
                c.Print("\n You hear a faint hissing sound that is barely audible.^");
            }

            c.Print("\n You are at the entrance to a massive chamber at the heart of the castle.\n\n A doorway leads south.^");

            Parser.Run("", "R1", "", "The doorway leads south.", "", "", "", "", stone, "", stone, stone, new string[] { "doorway" });
        }

        /// <summary> Theater </summary>
        public static void R2()
        {
            Program.ROOM = "R2";

            Methods.Checkpoint("West of Theater", "Ancient Chamber: Theater");

            if (Program.pyAwake)
            {
                c.Print("\n You hear a soft hiss in the distance.^");
            }

            c.Print("\n You are standing in a wide theater.^");
            c.Print("\n There is an elevated stage with steps on one side.\n Tomatoes are littered all over the stage and floor,\n evidence of the theater's low-quality performances during the time of its use.\n\n To north is the chamber entrance and to the south is a living room.\n The theater continues to the east.\n The steps lead up onto the stage.^");

            Parser.Run("", "R2", "A doorway leads north to the chamber entrance.", "A doorway leads south to a living room.", "The theater continues to the east.", "", "Steps lead up onto the stage.", "", "", "", "", stone, new string[] { "doorway", "steps", "tomatoes", "stage" }, "The steps only lead up.");
        }

        /// <summary> Stage </summary>
        public static void R2A()
        {
            Program.ROOM = "R2A";

            Methods.Checkpoint("Stage", "Ancient Chamber: West of Theater");

            if (Program.pyAwake)
            {
                c.Print("\n You hear a faint hissing sound that is barely audible.^");
            }

            c.Print("\n You are standing on the elevated stage of the theater.^");
            c.Print("\n Tomatoes are littered all over the floor.\n\n The steps lead down off of the stage.^");

            string d = "You will fall off of the stage.";

            Parser.Run("", "R2A", "The stage does not continue north.", "The stage does not continue south.", "The stage does not continue east.", stone, "", "Steps lead down off of the stage.", d, d, d, "", new string[] { "doorway", "steps", "tomatoes", "stage" }, "The steps only lead down.");
        }

        /// <summary> Living Room </summary>
        public static void R3()
        {
            Program.ROOM = "R3";

            Methods.Checkpoint("Living Room", "Haunted Castle: Ancient Chamber");

            if (Program.pyAwake)
            {
                c.Print("\n You hear a loud hissing sound.^");
            }

            c.Print("\n This is a small living room.\n\n A porcelain tea kettle sits on a small table surrounded by two armchairs.^");
            c.Print("\n To north is the theater.\n A tunnel leads east.^");

            Parser.Run("T", "R3", "To the north is the theater.", "", "A tunnel leads east.", "", "", "", "", stone, "", stone, new string[] { "doorway", "kettle", "table2", "armchairs", "tunnel", "tea" });
        }

        /// <summary> Lobby </summary>
        public static void R6()
        {
            Program.ROOM = "R6";

            Methods.Checkpoint("Lobby", "Ancient Chamber: Theater");

            if (Program.pyAwake)
            {
                c.Print("\n You hear a faint hissing sound that is barely audible.^");
            }

            c.Print("\n This is a small waiting room, a lobby for the theater.\n\n There are two armchairs here next to a small table.");

            if (Program.Inventory[14] > 2)
            {
                c.Print("^");
            }
            else if (Program.Inventory[14] == 0)
            {
                c.Print("\n On the table is a loaf of garlic bread.^");
            }
            else
            {
                c.Print("\n On the table is a slice of garlic bread.^");
            }

            c.Print("\n A doorway leads south to the inside of the theater.^");

            Parser.Run("", "R6", "", "A doorway leads south to the inside of the theater.", "", "", "", "", stone, "", stone, stone, new string[] { "doorway", "armchairs", "table2", "bread" });
        }

        /// <summary> Front of Theater </summary>
        public static void R7()
        {
            Program.ROOM = "R7";

            Methods.Checkpoint("Theater", "Haunted Castle: Ancient Chamber");

            if (Program.pyAwake)
            {
                c.Print("\n You hear a loud hissing sound.^");
            }

            c.Print("\n You are standing at the front of the wide theater.^");
            c.Print("\n Tomatoes are littered all over the stage and floor.\n\n The theater continues to the north and to the west.\n A tunnel leads south.\n Steps lead down to an orchestra pit.^");

            Parser.Run("", "R7", "The theater continues to the north.", "A tunnel leads south.", "", "The theater continues to the west.", "You look up at the stage.", "Steps lead down to an orchestra pit.", "", "", stone, "", new string[] { "tunnel", "tomatoes", "stage", "steps" }, "The steps only lead down.");
        }

        /// <summary> Orchestra Pit </summary>
        public static void R7A()
        {
            Program.ROOM = "R7A";

            Methods.Checkpoint("Orchestra Pit", "Ancient Chamber: Theater");

            if (Program.pyAwake)
            {
                c.Print("\n You hear a soft hiss in the distance.^");
            }

            c.Print("\n This is a recessed pit where a classical orchestra would have performed long ago.^");

            if (Program.Inventory[8] == 0)
            {
                c.Print("\n A long-forgotten flute rests upon the ground.^");
            }

            c.Print("\n Steps lead up and out of the pit.^");

            Parser.Run("", "R7A", "The pit does not continue north.", "The pit does not continue south.", "The pit does not continue east.", "THe pit does not continue west.", "Steps lead up and out of the pit.", "", stone, stone, stone, stone, new string[] { "tunnel", "stage", "steps", "flute" }, "The steps only lead up.");
        }

        /// <summary> Snake's Lair </summary>
        public static void R8()
        {
            Program.ROOM = "R8";

            Methods.Checkpoint("Snake's Lair", "Haunted Castle: Ancient Chamber");
            c.Print("\n This is a dark, damp pit.^");

            if (Program.pyAwake)
            {
                c.Print("\n A menacing snake glares at you.\n\n \"It is excellent to sssee you again.\n  Finally, I can have sssome lunch.\n\n  Wait, where was I? Oh, yesss - lunch.\n\n  Hmm... do I even like humans?\"^");
            }
            else
            {
                c.Print("\n A long snake covered in menacing patterns\n is coiled up on the ground, fast asleep.^");
            }

            c.Print("\n Tunnels lead north, east, and west.");

            string tunnelAdd = "";

            if (!Program.pyAwake && Program.pyMoved)
            {
                c.Print("\n\n The snake is a very deep slumber,\n so the east tunnel provides an easy exit.");
                tunnelAdd += "\n It provides an unhindered exit.";
            }
            else
            {
                c.Print("\n The snake is blocking the east tunnel.");
                tunnelAdd += "\n It is blocked by the snake.";
            }

            c.Print("^");

            Parser.Run("PY", "R8", "A tunnel leads north to the theater.", "", "A tunnel leads east." + tunnelAdd, "A tunnel leads west to a living room.", "", "", "", stone, "", "", new string[] { "tunnel", "snake" });
        }

        /// <summary> Underground Tunnel </summary>
        public static void R24()
        {
            Program.ROOM = "R24";

            Methods.Checkpoint("Underground Tunnel", "Haunted Castle");
            c.Print("\n You hear a faint hissing sound that is barely audible.^");
            c.Print("\n This is a dark tunnel leading to the east and to the west.^");

            Parser.Run("", "R24", "", "", "The tunnel leads east.", "The tunnel leads west.", "", "", stone, stone, "", "You would rather not return to the snake's lair.", new string[] { "tunnel" });
        }

        public static void WakeUpSnake()
        {
            c.Print("\n It begins to slowly uncoil until it is fully upright.\n The snake seems confused and generally unintelligent,\n but this fails to distract you from the fact that its massive jaws\n and unforgiving fangs are capable of devouring you whole.^");
            c.Print("\n \"What is thisss?\n\n  A tasssty morsssel has brought itssself before me...\n  Sniff... sniff... I sssmell a human...\n  Do I like humans? I don't think they are very tasssty.\n\n  Hmm... I am quite hungry though. I don't have much elssse to eat, do I?\n\n  Wait... what? Where was I?\n  Oh, right, I was about to eat you.\"");

            Program.pyAwake = true;
        }

        public static void SnakeBite()
        {
            c.Print("\n As you move towards the snake, its jaws snap forward and bite you.\n\n The bite is extremely harmful,\n both poisoning you with its venom and giving you a minor injury.");

            if (Program.Revive)
            {
                c.Print("\n\n The spell of reviving takes effect.");
            }
            else
            {
                Methods.SetPermanentHealth(Program.PermanentHealth - 15);
            }

            Program.State[2] = true;
            Program.State[3] = true;
        }
    }
}
