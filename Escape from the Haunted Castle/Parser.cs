// Parser.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using HauntedCastle.Commands;

namespace HauntedCastle
{
    public static class InventoryItems
    {
        public static string Bag = " a leather bag";
        public static string BagWater = Bag + " (contains water)";
        public static string BagTea = Bag + " (contains tea)";
        public static string BagGold = Bag + " (full)";
        public static string Seeds = " seeds";
        public static string Apple = " an apple";
        public static string Match = " a match";
        public static string MatchUsed = Match + " (used)";
        public static string MatchLit = Match + " (lit)";
        public static string Candle = " a candle";
        public static string CandleLit = Candle + " (lit)";
        public static string Key = " a key";
        public static string Silver = "   silver";
        public static string Recipe = " a recipe";
        public static string RecipePaper = Recipe + " (used as paper)";
        public static string RecipePaperUsed = Recipe + " (used as a permit)";
        public static string RecipePaperApproved = "permit (approved)";
        public static string Feather = " a feather";
        public static string FeatherPen = Feather + " (used as a pen)";
        public static string Blackberry = " a blackberry";
        public static string BlackberryInk = Blackberry + " (used as ink)";
        public static string Shield = " a shield";
        public static string Box = " a box";
        public static string BoxRaft = Box + " (used as a raft)";
        public static string Crate = " a crate";
        public static string CrateRaft = Crate + " (used as a raft)";
        public static string FloppyDisk = " a floppy disk";
        public static string Flute = " a flute";
        public static string Monocle = " a monocle";
        public static string MonocleLens = " a monocle (used as a lens)";
        public static string Newspaper = " a newspaper";
    }

    public static class Parser
    {
        private static readonly GUI.Display c = new GUI.Display();

        public static List<string> verbs = new List<string>() { "jump", "put", "sit", "player", "win", "y=mx+b", "submit", "unlock", "you", "zap", "kick", "punch", "clear", "xyzzy", "teleport", "die", "why", "answer", "cook", "wash", "rinse", "clean", "spit", "salivate", "swallow", "drool", "play", "shuffle", "break", "destroy", "climb", "pick", "caps", "setcaps", "diagnose", "health", "state", "stats", "diagnostic", "down", "go", "climb", "run", "walk", "drink", "chug", "drop", "roll", "stop", "east", "eat", "munch", "bite", "look", "examine", "inspect", "restart", "erase", "exit", "quit", "info", "about", "credits", "ver", "version", "inv", "items", "inventory", "light", "burn", "north", "open", "read", "save", "restore", "say", "yell", "shout", "whisper", "chant", "south", "take", "get", "hold", "grab", "obtain", "collect", "remove", "pluck", "up", "use", "turn", "west", "help", "peck", "load", "op", "sip", "learn", "again", "repeat", "who", "what", "when", "where", "how", "life", "sing", "status", "hum", "shield", "reset", "sleep", "rest", "ln", "ls", "le", "lw", "ld", "lu", "blow", "whistle", "yes", "sure", "ok", "okay", "yea", "yeah", "yep", "no", "maybe", "nay", "nea", "spill", "listen", "hear", "talk", "ask", "smell", "sniff", "taste", "touch", "feel", "abra", "abrakadabra", "abracadabra", "hocus", "pocus", "presto", "alakazam", "please", "wait", "redo", "undo", "equip", "be", "am", "are", "is", "throw", "left", "right", "continue", "give", "offer", "show", "rub", "enter", "leave", "in", "out", "think", "oops", "cls", "back", "forward", "starboard", "sb", "aft", "port", "spin", "and", "then", "on", "at", "in", "off", "out", "it", "them", "that", "this", "everything", "thing", "item", "object", "stuff", "wear", "do", "odysseus", "odyssey", "ulysseys", "fix", "pour", "toss", "hello", "custom_key_help", "hiscores", "hi-scores", "score", "scores", "hiscore", "hi-score", "echo", "find", "bless", "gesundheit", "tickle", "watch" };

        public static void Run(string SpecificRoom, string DirectionalRoom, string LookNorth, string LookSouth, string LookEast, string LookWest, string LookUp, string LookDown, string BlockNorth, string BlockSouth, string BlockEast, string BlockWest, string[] Objects, string BlockUpDown = "")
        {
            bool ComputerRoom = SpecificRoom == "COMPUTER_ROOM";
            bool WizardsQuarters = SpecificRoom == "WIZ";
            bool Library = SpecificRoom == "LIB";
            bool ViperRoom = SpecificRoom == "PY";

            Methods.WhatDoYouDo();

            List<string> opt = null;

            while (true)
            {
                Program.Previous = opt;

                opt = new List<string>();

                c.StyleInput(true);

                string full = c.ReadLine(0, false, true);

                if (full.Contains("player") && !full.Contains("hello") && !full.Contains("talk") && !full.Contains("say") && !full.Contains("ask") && !full.Contains("whisper") && !full.Contains("chant") && !full.Contains("yell") && !full.Contains("shout"))
                {
                    c.Print("\n To interact with another player, try talking to them.^");
                    continue;
                }

                try
                {
                    foreach (string s in full.Split(' '))
                    {
                        opt.Add(s);
                    }
                }
                catch { }

                if (opt[0] == "?")
                {
                    opt[0] = "help";
                }

                opt = Methods.FixInput(opt);

                if (Say.CheckSpells(opt[0] + " " + opt[1] + " " + opt[2] + " " + opt[3] + " " + opt[4] + " " + opt[5], SpecificRoom))
                {
                    continue;
                }
                else if (Methods.YesNoCondition(opt[0]) && Program.pregunta > 0)
                {
                    switch (Program.pregunta)
                    {
                        case 1:
                            c.Print("\n No, you do not.^");
                            break;
                        case 2:
                        case 4:
                            c.Print("\n You have transformed into a zombie!^");
                            break;
                        case 3:
                            if (Methods.YesCondition(opt[0]))
                            {
                                c.Print("\n How did you know?\n You have won!");
                                c.Pause();
                                Methods.GameOver(true, false);
                            }
                            else if (Methods.NoCondition(opt[0]))
                            {
                                c.Print("\n Good.^");
                            }

                            break;
                    }

                    Program.pregunta = 0;
                }
                else if (!verbs.Contains(opt[0].ToLower()) && opt[0].Length > 1)
                {
                    c.Print("\n You do not know how to do that.^");
                    continue;
                }
                else if (opt[0] != "y=mx+b")
                {
                    Program.pregunta = 0;
                }

                if ((opt[0] == "again" || opt[0] == "repeat" || opt[0] == "g" || opt[0] == "redo") && Program.Previous == null)
                {
                    c.Print("\n You do not know what to repeat.^");
                }
                else if (opt[0] == "again" || opt[0] == "repeat" || opt[0] == "g" || opt[0] == "redo")
                {
                    opt = Methods.FixInput(Program.Previous);

                    string str = "";

                    foreach (string s in Program.Previous)
                    {
                        str += s + " ";
                    }

                    c.Print("\n Repeating (" + str.Trim() + "):\n", ConsoleColor.Gray);

                    if (!verbs.Contains(opt[0].ToLower()) && opt[0].Length > 1)
                    {
                        c.Print("\n You do not know how to do that.^");
                    }

                    if (opt[0] == "again" || opt[0] == "repeat" || opt[0] == "g" || opt[0] == "redo")
                    {
                        c.Print("\n You do not remember what to repeat.^");
                    }
                }

                if (verbs.Contains(opt[0]))
                {
                    if (!Program.drankWater && !Program.State[0])
                    {
                        c.Print("\n You are slowly dying of thirst.^");

                        Methods.SetPermanentHealth(Program.PermanentHealth - 2);
                    }

                    if (Program.minutes > 0 && Program.minutes < 4)
                    {
                        c.Print("\n The ship continues towards home.^");
                        Program.minutes++;
                    }

                    if (Program.minutes == 4)
                    {
                        Program.minutes = 5;

                        c.Print("\n You see a familiar landmass in the distance: you have reached your home island.");
                        c.Pause();

                        Storyline.E2();
                    }

                    if (Program.ROOM == "FIN")
                    {
                        c.Print("\n The magic staff is glowing vibrantly.^");
                    }
                }

                // Examine and Clear must be first!

                Examine.Run(opt[0], opt[1], LookNorth, LookSouth, LookEast, LookWest, LookUp, LookDown, Objects);
                Clear.Run(opt[0], opt[1]);

                _ = Diagnose.Run(opt[0], opt[1]);
                Drink.Run(opt[0], opt[1], Objects);
                Drop.Run(opt[0], opt[1], SpecificRoom, Objects);
                Eat.Run(opt[0], opt[1], Objects);
                Exit.Run(opt[0], opt[1]);
                Info.Run(opt[0], opt[1]);
                Light.Run(opt[0], opt[1], opt[2], opt[3], Objects);
                Open.Run(opt[0], opt[1], ComputerRoom, Objects);
                Read.Run(opt[0], opt[1], Objects);
                Say.Run(opt[0], Library, WizardsQuarters, ViperRoom, opt);
                Take.Run(opt[0], opt[1], Objects);
                Use.Run(opt[0], opt[1], opt[2], opt[3], opt[4], Objects);
                Inventory.Run(opt[0], opt[1]);

                North.Run(opt[0], opt[1], DirectionalRoom, BlockNorth);
                South.Run(opt[0], opt[1], DirectionalRoom, BlockSouth);
                East.Run(opt[0], opt[1], DirectionalRoom, BlockEast);
                West.Run(opt[0], opt[1], DirectionalRoom, BlockWest);
                Up.Run(opt[0], opt[1], DirectionalRoom, BlockUpDown);
                Down.Run(opt[0], opt[1], DirectionalRoom, BlockUpDown);

                Save.Run(opt[0], opt[1]);
            }
        }
    }
}
