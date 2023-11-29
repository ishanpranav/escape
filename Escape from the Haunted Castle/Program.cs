using System;
using System.Collections.Generic;
using System.IO;

namespace haunted_castle
{
    public class Program
    {
        // Declarations
        public const int MAXSCORE = 500;
        const int NumItems = 17;
        public static string x = string.Empty;
        public static string Year = "2020";
        public static bool FIXED_COLOR = true;
        public static bool FIXED_CAPS = false;
        public static bool washedTomatoes = false;
        public static bool washedHands = false;
        public static bool readPalm = false;
        public static bool spit = false;
        public static bool alternate = false;
        public static bool ratsGone = false;
        public static bool setup = false;
        public static bool Revive = false;
        public static bool SpiderRepelling = false;
        public static bool belowsealevel = false;
        public static bool elf = false;
        public static bool pyAwake = false;
        public static bool pyMoved = false;
        public static bool vampireGone = false;
        public static bool vampireAwake = false;
        public static bool beans = false;
        public static bool beanGold = false;
        public static bool ateBread = false;
        public static bool ateCake = false;
        public static bool useTel = false;
        public static bool mapRead = false;
        public static bool ogAsleep = false;
        public static bool caseOpen = false;
        public static bool lampUsed = false;
        public static bool died = false;
        public static bool firsttreasureroom = true;
        public static bool computerDropped = false;
        public static bool computerBroken = false;
        public static bool IsInvisible = false;
        public static bool libraryUNLOCKED = false;
        public static bool bookUNLOCKED = false;
        public static bool hasEyebrows = true;
        public static bool drankWater = false;
        public static bool firstprisoncell = true;
        public static bool echo = false;
        public static bool didInfo = false;
        public static bool gsn = false;
        public static bool[] State = new bool[4] { true, true, false, false };
        public static bool[] Ghosts = new bool[4] { false, false, false, false };
        public static ConsoleColor color = ConsoleColor.Green;
        static GUI.Display c = new GUI.Display();
        public static int PermanentHealth = 100;
        public static int pregunta = 0;
        public static int degrees = 45;
        public static int lockspeed = 0;
        public static int PannedForGoldTimes = 0;
        public static int score = 0;
        public static int poemAnswer = 0;
        public static int minutes = 0;
        public static int mazeIdx = 1;
        public static int[] Inventory = new int[NumItems] { 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static int[] comboAnswer = new int[3];
        public static char[] mazes = new char[17] { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*' };
        public static bool[] breadcrumbs = new bool[17];
        public static Random rnd = new Random();
        public static List<string> Previous = null;
        // March 18, 2016
        public static string name = "savefile";
        public static string ROOM = string.Empty;
        public static string word = string.Empty;
        public static string[] combo = new string[3] { "00", "00", "00" };
        public static string[] GhostAttacks = new string[] { "throws a great ball of flame at you.", "summons a volley of arrows.", "releases a cloud of poison to slowly weaken you." };
        public static string[] SpiderAttacks = new string[] { "kicks with its leg.", "kicks sharply with its leg.", "bites you. The poison weakens you slowly." };
        public static string[] SwordAttacks = new string[] { "strikes with its sword.", "lunges forward and attacks.", "sharply attacks with its sword." };
        public static string[] SleepingStatements = new string[] { "lies unconscious on the ground", "lies unconscious on the floor", "is lying unconscious on the ground", "is lying unconscious on the floor", "rests unconscious on the ground", "rests unconscious on the floor", "is resting unconscious on the ground", "is resting unconscious on the floor", "lies on the ground, unconscious", "lies on the floor, unconscious", "is lying on the ground, unconscious", "is lying on the floor, unconscious", "rests on the ground, unconscious", "rests on the floor, unconscious", "is resting on the ground, unconscious", "is resting on the floor, unconscious" };
        public static string[] InventoryCaptions = new string[NumItems] { "", InventoryItems.Match, InventoryItems.Candle, InventoryItems.Apple, InventoryItems.BagGold, InventoryItems.Key, InventoryItems.Shield, InventoryItems.Recipe, InventoryItems.Flute, InventoryItems.Box, InventoryItems.Crate, InventoryItems.FloppyDisk, InventoryItems.Blackberry, InventoryItems.Feather, "", InventoryItems.Monocle, InventoryItems.Newspaper };
        public static Dictionary<string, string> GhostPlayers = new Dictionary<string, string>();
        public static string EndScreenLines =
            (
                "   ##    ##    ########    ##    ##        #######    ########    ########    ##\n" +
                "    ##  ##     ##    ##    ##    ##        ##    ##      ##       ##          ##\n" +
                "      ##       ##    ##    ##    ##        ##    ##      ##       ########    ##\n" +
                "      ##       ##    ##    ##    ##        ##    ##      ##       ##            \n" +
                "      ##       ########    ########        #######    ########    ########    ##\n\n"
            );
        public static string EndWinScreenLines =
            (
                "   ##    ##    ########    ##    ##        ##    ##    ########    ###   ##    ##\n" +
                "    ##  ##     ##    ##    ##    ##        ##    ##       ##       ####  ##    ##\n" +
                "      ##       ##    ##    ##    ##        ## ## ##       ##       ## ## ##    ##\n" +
                "      ##       ##    ##    ##    ##        ## ## ##       ##       ##  ####      \n" +
                "      ##       ########    ########        ###  ###    ########    ##   ###    ##\n\n"
           );
        private static int lns = 10;

        public static void Main(string[] args)
        {
            if (File.Exists(FileSystem.ishandll))
                SignatureCheck.Run();
            else
            {
                c.Clear();
                c.StyleHeader("Error", true, false);
                c.Print("\n The program cannot run due to a software issue!\n\n Please contact the publisher for assistance.", ConsoleColor.Red);
                c.Pause();
                c.CloseEnvironment();
            }

            // START Important Code

            /*~~~~~~~~~~~~~~~~~~~~*\
            |  __________________  |
            | |                  | |
            | |     WARNING!     | |
            | |   Do not edit!   | |
            | |  Important code  | |
            | |__________________| |
            |                      |
            \*~~~~~~~~~~~~~~~~~~~~*/

            FileSystem.CheckFolder();

            CheckArguments(args, false);
            CheckArguments(Environment.GetCommandLineArgs(), false);

            try
            {
                CheckArguments(AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData, true);
            }
            catch { }

            Console.CancelKeyPress += Console_CancelKeyPress;

            c.LoadEnvironment();

            if (FIXED_CAPS)
                fn();
            else
                Welcome();

            // END Important Code
        }

        static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            c.Clear();
            c.Print("\n\n Saving game...", ConsoleColor.Gray);
            FileSystem.SaveData();
            c.Print("\n Preparing to exit...", ConsoleColor.Gray);
            c.CloseEnvironment();
        }

        static void Welcome(bool skipTitle = false)
        {
            // Declarations
            bool opt1LOOP = false;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            int index = 1;

            if (!skipTitle)
                GUI.TitleScreen.Show(true, false, false);

            opt1LOOP = false;

            string scores = Options.HiScores(false);

            c.ForegroundColor = ConsoleColor.White;
            
            c.Clear();
            Console.WriteLine();
            PROCESSLINE("+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@~");
            PROCESSLINE("|                                                                               |");
            PROCESSLINE("|                        ESCAPE FROM THE HAUNTED CASTLE                         |");
            PROCESSLINE("|                                                                               |");
            PROCESSLINE("|         Escape from the Haunted Castle is an exciting text adventure!         |");
            PROCESSLINE("|                                                                               |");
            PROCESSLINE("|                      Copyright (c) 2016-" + Year + " Ishan Pranav                     |");

            if (scores != string.Empty)
            {
                lns = 12;

                PROCESSLINE("|                                                                               |");

                c.ForegroundColor = ConsoleColor.White;
                Console.Write(" ");
                Console.Write("\u2551");
                Console.Write("                      ");
                Console.Write(scores);
                Console.Write("                     ");
                Console.Write("\u2551");
                Console.WriteLine();
            }

            PROCESSLINE("|                                                                               |");
            PROCESSLINE("*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@/");

            while (!opt1LOOP)
            {
                WRITEALL(index, true);

                key = new ConsoleKeyInfo();

                while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Spacebar && key.Key != ConsoleKey.X)
                {
                    key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (index > 1)
                            index--;

                        WRITEALL(index);
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (index < 4)
                            index++;
                        else if (index == 4)
                            index = 1;

                        WRITEALL(index);
                    }
                    else if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                    {
                        index = 1;

                        WRITEALL(index);
                    }
                    else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                    {
                        index = 2;

                        WRITEALL(index);
                    }
                    else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
                    {
                        index = 3;

                        WRITEALL(index);
                    }
                    else if (key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.NumPad4)
                    {
                        index = 4;

                        WRITEALL(index);
                    }
                }

                if (index == 1)
                    opt1LOOP = true;
                else if (index == 2)
                {
                    Options.About();
                    Welcome(true);
                }
                else if (index == 3)
                {
                    Options.HiScores(true);
                    Welcome(true);
                }
                else if (index == 4)
                {
                    FileSystem.SaveData();
                    c.CloseEnvironment();
                }
            }

            fn();
        }

        private static void fn()
        {
            if (!FIXED_CAPS)
                c.Clear();

            try
            {
                FileSystem.savefile = FileSystem.root + Methods.PlayerSelect().ToLower() + ".hcx";
            
                FileSystem.LoadData();
                FileSystem.TRAVELTO();
                return;
            }
            catch
            {
                FileSystem.savefile = FileSystem.root + "SAVEFILE.HCX";
            }
            
            if (!setup)
            {
                string opt1 = string.Empty;
                string opt2 = string.Empty;
                string yn = string.Empty;
                bool err1 = false;
                bool err2 = false;
                bool namesure = false;

                name = "savefile";

                c.Clear();
                c.StyleHeader("New Player", true, false);
                c.Print("\n");

                while (!namesure)
                {
                    while (name.ToLower() == "savefile" || name == null || name == string.Empty || err1 || err2)
                    {
                        err1 = false;
                        err2 = false;
                        yn = string.Empty;

                        c.StyleAlt("What is your nickname?");
                        c.Print("________", ConsoleColor.White);

                        Console.CursorLeft -= 8;

                        name = c.ReadLine(8).Trim();

                        foreach (char x in name)
                            if (!char.IsLetter(x) && x != ' ')
                                err1 = true;

                        if (err1)
                            c.Print("\n\n Nickname may only contain letters.^", ConsoleColor.Red);

                        if (name.Length == 0)
                            err2 = true;

                        if (File.Exists(FileSystem.root + name + ".hcx"))
                        {
                            c.Print("\n\n Nickname is already in use.^", ConsoleColor.Red);

                            err1 = true;
                        }

                        if (name.ToLower().Contains("ishan") || name.ToLower().Contains("admin"))
                        {
                            c.Print("\n\n Nickname is reserved.^", ConsoleColor.Cyan);

                            c.StyleAlt("Enter Security Key:");

                            string k = string.Empty;

                            if (c.ReadLine().ToLower() != "012004")
                            {
                                name = string.Empty;
                                c.Print("\n\n Security Key is invalid.^", ConsoleColor.Cyan);
                            }
                        }
                    }

                    string msg = name.ToUpper().Trim() + ", are you sure?";

                    while (!Methods.YesNoCondition(yn) && yn.Trim() != name.ToLower())
                    {
                        c.StyleAlt(msg);

                        yn = c.ReadLine().ToLower();

                        name = name.ToUpper().Trim();

                        if (Methods.YesCondition(yn) || yn.Trim() == name.ToLower())
                            namesure = true;
                        else if (Methods.NoCondition(yn))
                            name = string.Empty;
                        else
                            msg = "Please answer yes or no:";
                    }
                }

                File.AppendAllText(FileSystem.playersdat, name.ToLower() + "\r\n");

                if (!FIXED_CAPS)
                    c.Clear();

                c.ForegroundColor = ConsoleColor.White;

                setup = true;

                if (!FIXED_CAPS)
                    c.Clear();
            }

            c.Print("\n");

            Storyline.Gen();
        }

        private static void PROCESSLINE(string LINE)
        {
            c.BackgroundColor = ConsoleColor.Black;
            c.ForegroundColor = ConsoleColor.White;

            Console.Write(" ");

            foreach (char ch in LINE)
            {
                if (ch == '@')
                    Console.Write("\u2550");
                else if (ch == '+')
                    Console.Write("\u2554");
                else if (ch == '~')
                    Console.Write("\u2557");
                else if (ch == '*')
                    Console.Write("\u255a");
                else if (ch == '/')
                    Console.Write("\u255d");
                else if (ch == '/')
                    Console.Write("\u255d");
                else if (ch == '|')
                    Console.Write("\u2551");
                else
                {
                    c.ForegroundColor = ConsoleColor.Gray;

                    Console.Write(ch.ToString());

                    c.ForegroundColor = ConsoleColor.White;
                }
            }

            c.ForegroundColor = ConsoleColor.Gray;
            c.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine();
        }

        private static void WRITEALL(int ACTIVEINDEX, bool FIRST = false)
        {
            if (!FIRST)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = lns;

                for (int i = 0; i < lns; i++)
                    c.Print("\n");

                Console.CursorLeft = 0;
                Console.CursorTop = lns;
            }

            c.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n Please choose an option.");

            c.ForegroundColor = ConsoleColor.White;

            if (ACTIVEINDEX == 1)
                c.StyleOption("> 1. START", true);
            else
                c.StyleOption("  1. START");

            if (ACTIVEINDEX == 2)
                c.StyleOption("> 2. ABOUT", true);
            else
                c.StyleOption("  2. ABOUT");

            if (ACTIVEINDEX == 3)
                c.StyleOption("> 3. HI-SCORES", true);
            else
                c.StyleOption("  3. HI-SCORES");

            if (ACTIVEINDEX == 4)
                c.StyleOption("> 4. QUIT", true);
            else
                c.StyleOption("  4. QUIT");

            c.ForegroundColor = ConsoleColor.White;

            c.Print("\n");
        }

        private static void CheckArguments(string[] Arguments, bool IsClickOnce)
        {
            // Declarations
            int minIndex = 1;

            if (IsClickOnce)
                minIndex = 0;

            if (Arguments.Length > minIndex)
            {
                if (File.Exists(Arguments[minIndex]))
                {
                    c.LoadEnvironment();

                    FileSystem.savefile = Arguments[minIndex];

                    FileSystem.LoadData();
                    FileSystem.TRAVELTO();
                }
                else if (Arguments[minIndex].ToLower() == "nointerface" || Arguments[minIndex].ToLower() == "standard")
                {
                    FIXED_CAPS = true;
                    FIXED_COLOR = false;
                }
            }
        }
    }
}
