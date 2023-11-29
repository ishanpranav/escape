// Methods.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using HauntedCastle.Properties;

namespace HauntedCastle
{
    internal class Methods
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void WhatDoYouDo(bool space = false)
        {
            c.StyleHeader("What do you do?", true, space);
            c.Print("\n   * Enter \"EXIT\" or \"Q\" to quit Escape from the Haunted Castle.", ConsoleColor.Gray);
            c.Print("\n   * Enter \"CLEAR\" or \"C\" to clear the screen.", ConsoleColor.Gray);
            c.Print("\n   * Enter \"SAVE\" to manually save your progress.", ConsoleColor.Gray);
            c.Print("\n   * Enter \"DIAGNOSE\" or \"H\" to see your health and state.", ConsoleColor.Gray);
            c.Print("\n   * Enter \"INVENTORY\" or \"I\" to see your inventory.", ConsoleColor.Gray);
            c.Print("^");
        }

        public static void SetPermanentHealth(int Health)
        {
            if (Health < 85 && (Health < Program.PermanentHealth) && Program.Revive)
            {
                c.Print("\n The spell of reviving takes effect.^");

                Health += 5;
            }

            Program.PermanentHealth = Health <= 100 ? Health : 100;

            if (Program.PermanentHealth <= 0)
            {
                c.Print("\n You die of injury.");
                c.Pause();
                GameOver(false);
            }
        }

        public static void Checkpoint(string GameArea, string Location, bool ShowPlayers = true)
        {
            c.Clear(true);

            for (int i = 0; i < Console.WindowHeight / 4; i++)
            {
                c.Print("\n");
            }

            c.ForegroundColor = ConsoleColor.Gray;
            c.CenterText("Loading... Please wait.");

            FileSystem.SaveData();

            c.Clear(true);
            c.Print("\n ");
            c.Print(string.Format("   {0}: ", Location), ConsoleColor.Gray);
            c.Print(GameArea, ConsoleColor.White);
            c.DrawLine(83, ConsoleColor.Gray);

            if (ShowPlayers && (Program.GhostPlayers.Count - 1) > 0)
            {
                foreach (string player in Program.GhostPlayers.Keys)
                {
                    if (Program.GhostPlayers[player].ToLower() == Program.ROOM.ToLower() && player.ToLower() != Program.name.ToLower())
                    {
                        c.Print(string.Format("\n Player {0} {1}.\n", player.ToUpper(), Program.SleepingStatements[Program.rnd.Next(Program.SleepingStatements.Length)]));
                        break;
                    }
                }
            }

            if (ShowPlayers)
            {
                if (Program.State[3] && Program.PermanentHealth > 30 && !Program.Revive)
                {
                    c.Print("\n You are slowly dying of poisoning.");

                    SetPermanentHealth(Program.PermanentHealth - 2);
                }
            }
        }

        public static void GenMazes()
        {
            char prev = '*';

            Program.mazeIdx = 1;
            Program.mazes = new char[17] { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' };
            Program.breadcrumbs = new bool[17];

            for (int i = 0; i < Program.mazes.Length; i++)
            {
                while (Program.mazes[i] == prev || Program.mazes[i] == '*')
                {
                    Program.mazes[i] = (new char[] { 'n', 's', 'e', 'w' })[Program.rnd.Next(4)];
                }

                if (Program.mazes[i] == 'n')
                {
                    prev = 's';
                }
                else if (Program.mazes[i] == 's')
                {
                    prev = 'n';
                }
                else if (Program.mazes[i] == 'e')
                {
                    prev = 'w';
                }
                else if (Program.mazes[i] == 'w')
                {
                    prev = 'e';
                }

                Program.breadcrumbs[i] = false;
            }
        }

        public static void GenWord()
        {
            string con = "bdghjklmqrtvw";
            string an = "eiouy";

            Program.word = con[Program.rnd.Next(con.Length)].ToString() + an[Program.rnd.Next(an.Length)].ToString() + con[Program.rnd.Next(con.Length)].ToString() + an[Program.rnd.Next(an.Length)].ToString() + con[Program.rnd.Next(con.Length)].ToString();

            Parser.verbs.Add(Program.word);
        }

        private static void WRITEALL(int ACTIVEINDEX, bool FIRST = false)
        {
            if (!FIRST)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 6;

                for (int i = 0; i < 6; i++)
                {
                    c.Print("\n");
                }

                Console.CursorLeft = 0;
                Console.CursorTop = 6;
            }

            List<string> lines = new List<string>();

            foreach (string line in File.ReadAllLines(FileSystem.playersdat))
            {
                if (line != "" && File.Exists(FileSystem.root + line.ToUpper() + ".hcx") && !lines.Contains(line))
                {
                    lines.Add(line);
                }
            }

            c.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n Please choose an existing player or create a new one.");

            c.ForegroundColor = ConsoleColor.White;

            if (ACTIVEINDEX == 1)
            {
                c.Print("\n\n\t>> NEW PLAYER", ConsoleColor.White);
            }
            else
            {
                c.Print("\n\n\t > NEW PLAYER", ConsoleColor.Gray);
            }

            for (int i = 0; i < lines.Count; i++)
            {
                if (ACTIVEINDEX == (i + 2))
                {
                    c.StyleOption(">> " + lines[i].ToUpper(), true);
                }
                else
                {
                    c.StyleOption(" > " + lines[i].ToUpper());
                }
            }

            c.ForegroundColor = ConsoleColor.White;

            c.Print("\n");
        }

        public static string PlayerSelect()
        {
            c.Clear();
            c.StyleHeader("Select Player", true, false);
            c.Print("\n");

            ConsoleKeyInfo key;
            int index = 1;
            List<string> lines = new List<string>();

            foreach (string line in File.ReadAllLines(FileSystem.playersdat))
            {
                if (line != "" && File.Exists(FileSystem.root + line.ToUpper() + ".hcx") && !lines.Contains(line))
                {
                    lines.Add(line);
                }
            }

            while (true)
            {
                WRITEALL(index, true);

                key = new ConsoleKeyInfo();

                while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Spacebar && key.Key != ConsoleKey.X)
                {
                    key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.NumPad8 || key.Key == ConsoleKey.NumPad9)
                    {
                        if (index > 1)
                        {
                            index--;
                        }

                        WRITEALL(index);
                    }
                    else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.NumPad3)
                    {
                        if (index < (lines.Count + 1))
                        {
                            index++;
                        }
                        else if (index == (lines.Count + 1))
                        {
                            index = 1;
                        }

                        WRITEALL(index);
                    }
                }

                for (int i = 0; i < (lines.Count + 2); i++)
                {
                    if (index == (i + 2))
                    {
                        return lines[i];
                    }
                }

                if (index == 1)
                {
                    return null;
                }
            }
        }

        public static List<string> FixInput(List<string> input_start)
        {
            // Declarations
            List<string> input = new List<string>();
            bool notEmpty = false;
            int minVal = 6;

            foreach (string word in input_start)
            {
                input.Add(word.ToLower());
            }

            while (input.Count < minVal)
            {
                input.Add(string.Empty);
            }

            foreach (string word in input)
            {
                if (word != string.Empty)
                {
                    notEmpty = true;
                }
            }

            if (notEmpty)
            {
                while (input[0] == string.Empty)
                {
                    input.RemoveAt(0);
                }
            }

            while (input.Count < minVal)
            {
                input.Add(string.Empty);
            }

            for (int i = 0; i < input.Count; i++)
            {
                input[i] = input[i].Replace(".", "").Replace(",", "").Replace("!", "").Replace("?", "").Replace(":", "");
            }

            if (input[0] == "you" || (input[0] == "i" && input[1] != string.Empty))
            {
                input.RemoveAt(0);
            }

            for (int i = 1; i < input.Count - 1; i++)
            {
                try
                {
                    if (input[i] == "an" || input[i] == "a" || input[i] == "the" || input[i] == "my" || input[i] == "those" || input[i] == "that" || input[i] == "these" || input[i] == "this" || input[i] == "all" || input[i] == "every" || input[i] == "each" || input[i] == "some")
                    {
                        input.RemoveAt(i);
                    }

                    if (input[0] == "munch" && input[i] == "on")
                    {
                        input[0] = "eat";
                    }

                    if (input[0] == "look" && input[i] == "at")
                    {
                        input[0] = "examine";
                    }

                    if (input[0] == "look" && input[i] == "in")
                    {
                        input[0] = "inspect";
                    }

                    if (input[0] == "turn" && input[i] == "on")
                    {
                        input[0] = "use";
                    }

                    if (input[0] == "put" && input[i] == "on")
                    {
                        input[0] = "use";
                    }

                    if (input[0] == "put" && (input[i] == "down" || input[i] == "d"))
                    {
                        input[0] = "drop";
                        input[i] = "it";
                    }

                    if (input[0] == "take" && input[i] == "off")
                    {
                        input[0] = "remove";
                    }

                    if (input[0] == "pick" && (input[i] == "up" || input[i] == "u"))
                    {
                        input[0] = "take";
                        input[i] = "it";
                    }

                    if (input[0] == "take" && input[i] == "out")
                    {
                        input[0] = "remove";
                    }
                }
                catch { }
            }

            for (int i = 1; i < input.Count - 1; i++)
            {
                try
                {
                    if (input[i] == "on" || input[i] == "at" || input[i] == "in" || input[i] == "off" || input[i] == "out" || input[i] == "it" || input[i] == "" || input[i] == "them" || input[i] == "that" || input[i] == "this" || input[i] == "everything" || input[i] == "thing" || input[i] == "item" || input[i] == "object" || input[i] == "stuff")
                    {
                        input.RemoveAt(i);
                    }
                }
                catch { }
            }

            while (input.Count < minVal)
            {
                input.Add(string.Empty);
            }

            if (input.Contains("and") || input.Contains("then"))
            {
                c.Print("\n Multiple actions cannot be performed at the same time.^", ConsoleColor.Gray);

                input = new List<string>() { "y", "=", "m", "x", "+", "b" };
            }

            return input;
        }

        public static void RecordScore()
        {
            SimpleEncryption se = new SimpleEncryption();

            if (Program.score > Program.MAXSCORE)
            {
                Program.score = Program.MAXSCORE;
            }

            if (Program.score != 0 && Program.name != "" && !Program.name.ToLower().Contains("ishan") && !Program.name.ToLower().Contains("admin"))
            {
                string x = se.DecryptString(File.ReadAllText(FileSystem.scoresdat));

                x += Program.name + "," + c.FormatScore(Program.score) + "~";

                File.WriteAllText(FileSystem.scoresdat, se.EncryptString(x));
            }

            FileSystem.SaveData();
        }

        public static void GameOver(bool YouHaveWon, bool H = true)
        {
            RecordScore();

            FileSystem.SaveData();

            if (YouHaveWon)
            {
                FileSystem.CheckFolder();

                if (File.Exists(FileSystem.savefile))
                {
                    File.Delete(FileSystem.savefile);
                }

                GUI.TitleScreen.Show(false, true, false, H);

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("\n\n");

                c.CenterText("PRESS ANY KEY TO FINISH");

                Console.WriteLine("\n\n");

                _ = Console.ReadKey(true);

                _ = Options.HiScores(true);

                Credits();
            }
            else
            {
                // int k = Program.score;
                int g = (int)Math.Floor((double)(Program.Inventory[0] / 2));

                SetPermanentHealth(100);

                Program.Inventory[0] -= g;
                Program.died = true;

                FileSystem.SaveData();

                GUI.TitleScreen.Show(false, false, true);

                Console.WriteLine("\n\n");

                c.CenterText("PRESS ANY KEY TO REVIVE");

                Console.WriteLine("\n\n");

                _ = Console.ReadKey(true);

                // Revival Point
                c.Clear(true);
                Checkpoint("Entrance to Infirmary", "Infirmary", false);

                c.Print("\n You have been revived!");

                FileSystem.SaveData();

                c.Pause();

                Program.ROOM = "#" + Program.ROOM;
                FileSystem.TRAVELTO();
            }
        }

        public static void Credits()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();

            for (int i = 0; i < Console.WindowHeight; i++)
            {
                Console.WriteLine();
            }

            string[] names = new string[]
            {
                "Ishan Pranav",
                "Ishan Pranav",
                "Ishan Pranav",
                "Mira Pranav",
                "Mira Pranav",
                "Napoleon Bonaparte",
                "Henry Ford",
                "Sophocles"
            };

            string[] titles = new string[]
            {
                "writer",
                "artist",
                "programmer",
                "editor",
                "thanks",
                "quotes",
                "quotes",
                "quotes"
            };

            string last = string.Empty;

            for (int i = 0; i < names.Length; i++)
            {
                if (last != titles[i])
                {
                    Console.WriteLine();
                    Console.WriteLine();

                    c.CenterText(titles[i].ToUpper());

                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine();

                c.CenterText(names[i]);

                Console.WriteLine();
                Console.WriteLine();

                Thread.Sleep(1000);

                last = titles[i];
            }

            Thread.Sleep(1000);

            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < Resources.Razorteeth.Length; i++)
            {
                switch (Resources.Razorteeth[i])
                {
                    case 'a':
                        for (int k = 0; k < 24; k++)
                        {
                            Console.Write(" ");
                        }

                        break;
                    case 'r':
                        Console.Write("\n");
                        Thread.Sleep(250);
                        break;
                    case '`':
                        Console.Write(" ");
                        break;
                    case '\n':
                        break;
                    case ' ':
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.DarkCyan;

                        Console.Write(Resources.Razorteeth[i].ToString());

                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }

            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            c.CenterText("Escape from the Haunted Castle");

            Console.WriteLine();
            Thread.Sleep(1000);
            Console.WriteLine();

            c.CenterText("Copyright (c) 2016-" + Program.Year + " Ishan Pranav");

            for (int i = 0; i < 14; i++)
            {
                Console.WriteLine();
                Thread.Sleep(1000);
            }

            _ = Console.ReadKey(true);
            Environment.Exit(0);
        }

        public static string GrammarCaps(string s)
        {
            // Declarations
            string str = ((s + " ")[0].ToString().ToUpper() + s.Remove(0, 1)).ToString();

            if (str == "Op" || str == "O")
            {
                str = "Open";
            }
            else if (str == "X")
            {
                str = "Examine";
            }
            else if (str == "L")
            {
                str = "Look";
            }
            else if (str == "\'")
            {
                str = "Say";
            }

            return str;
        }

        public static void WriteCaption(string str)
        {
            c.Print(string.Format("\n {0}^", str.Replace('@', '\n')));
        }

        public static bool YesNoCondition(string Input)
        {
            return YesCondition(Input) || NoCondition(Input);
        }

        public static bool YesCondition(string Input)
        {
            return Input == "y" || Input == "yes" || Input == "sure" || Input == "ok" || Input == "okay" || Input == "yea" || Input == "yeah" || Input == "yep";
        }

        public static bool NoCondition(string Input)
        {
            return Input == "n" || Input == "no" || Input == "maybe" || Input == "nay" || Input == "nea";
        }
    }
}
