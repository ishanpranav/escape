// Display.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;

namespace HauntedCastle.GUI
{
    public class Display
    {
        public ConsoleColor ForegroundColor
        {
            get
            {
                return Program.FIXED_COLOR ? ConsoleColor.Gray : Console.ForegroundColor;
            }
            set
            {
                Console.ForegroundColor = Program.FIXED_COLOR ? value : ConsoleColor.Gray;
            }
        }

        public ConsoleColor BackgroundColor
        {
            get
            {
                return Program.FIXED_COLOR ? ConsoleColor.Black : Console.BackgroundColor;
            }
            set
            {
                Console.BackgroundColor = Program.FIXED_COLOR ? value : ConsoleColor.Black;
            }
        }

        public void LoadEnvironment()
        {
            try
            {
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.White;
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.CursorVisible = false;
                Console.Title = string.Format("Escape from the Haunted Castle (Version {0})", Convert.ToString(Assembly.GetEntryAssembly().GetName().Version.Major) + "." + Convert.ToString(Assembly.GetEntryAssembly().GetName().Version.Minor));

                Console.CursorSize = 100;
                Console.WindowWidth = 83;
                Console.WindowHeight = 40;
                Console.BufferWidth = 83;
                Console.BufferHeight = 40;
            }
            catch { }

            if (!Program.FIXED_CAPS)
            {
                Clear();
            }
        }

        public void CloseEnvironment()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorVisible = true;
            Console.CursorSize = 25;
            Console.WindowWidth = 90;
            Console.WindowHeight = 30;
            Console.BufferWidth = 90;
            Console.BufferHeight = 30;

            Clear();
            Environment.Exit(0);
        }

        public void DrawScreen()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;

            Clear(true, ConsoleColor.DarkMagenta);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine(" (..............................................................................)".Replace('.', '\u2500').Replace('(', '\u250C').Replace(')', '\u2510'));

            for (int i = 0; i < 21; i++)
            {
                Console.WriteLine(" \u2502                                                                              \u2502");
            }

            Console.WriteLine(" L............................................................................../".Replace('.', '\u2500').Replace('L', '\u2514').Replace('/', '\u2518'));
        }

        public void PrintScreen(string Message, int Line, ConsoleColor Color)
        {
            ConsoleColor origColor = Console.ForegroundColor;

            Console.ForegroundColor = Color;

            Console.SetCursorPosition(4, Line + 9);
            Console.Write(Message);

            Console.ForegroundColor = origColor;
        }

        public void Print(string Message, ConsoleColor TextColor = ConsoleColor.Green, ConsoleColor HighlightColor = ConsoleColor.Black)
        {
            // Declarations
            _ = ForegroundColor;
            _ = BackgroundColor;

            if (TextColor == ConsoleColor.Green)
            {
                TextColor = Program.color;

                if (Program.FIXED_CAPS || Console.CapsLock)
                {
                    Message = Message.ToUpper();
                }
            }

            BackgroundColor = HighlightColor;
            ForegroundColor = TextColor;

            MiniPrint(Message, TextColor == ConsoleColor.Green);

            if (Program.ROOM == "T2" && TextColor == ConsoleColor.Green && !string.IsNullOrWhiteSpace(Message.Replace("^", "")))
            {
                MiniPrint(Message, TextColor == ConsoleColor.Green);
            }

            if (!Program.FIXED_COLOR && TextColor == ConsoleColor.Green && !string.IsNullOrWhiteSpace(Message))
            {
                System.Threading.Thread.Sleep(400);
            }
        }
        private void MiniPrint(string Message, bool IsPrint)
        {
            if (Message.Contains("^"))
            {
                for (int i = 0; i < Message.Split('^').Length - 1; i++)
                {
                    Console.Write(Message.Split('^')[i]);
                    Print("\n");

                    if (!Program.FIXED_COLOR && IsPrint && !string.IsNullOrWhiteSpace(Message))
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            else
            {
                Console.Write(Message);
            }
        }

        public void Pause()
        {
            bool x = false;
            char m;

            ForegroundColor = ConsoleColor.Cyan;

            Console.Write("\n\n PRESS [X] TO CONTINUE...");

            while (!x)
            {
                m = char.ToLower(Console.ReadKey(true).KeyChar);

                x = m == 'x' || m == '8' || m == '5';
            }

            Print("\n\n");
        }

        public void Clear(bool StatusBar = false, ConsoleColor BarColor = ConsoleColor.DarkBlue)
        {
            Console.Clear();

            if (StatusBar)
            {
                ForegroundColor = ConsoleColor.Cyan;
                BackgroundColor = BarColor;

                Console.Write(" ♦ ");

                string n = Program.name.ToUpper();

                while (n.Length != 9)
                {
                    n += " ";
                }

                Print("Escape from the Haunted Castle | Ishan Pranav | " + n, ConsoleColor.White, BarColor);

                if (Console.CapsLock)
                {
                    Print(" (A) ", ConsoleColor.Yellow, BarColor);
                }
                else
                {
                    Print("     ", ConsoleColor.White, BarColor);
                }

                Print("[?] [F11] ", ConsoleColor.White, BarColor);
                Print("[Ctrl+C]", ConsoleColor.Red, BarColor);

                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }
        }

        public void CenterText(string Text)
        {
            for (int i = 0; i < ((83 - Text.Length) / 2); i++)
            {
                Console.Write(" ");
            }

            Console.Write(Text);
        }

        public void DrawLine(int LengthInCharacters = 83, ConsoleColor LineColor = ConsoleColor.White)
        {
            if (Program.FIXED_COLOR)
            {
                if (LengthInCharacters == 83 && 83 != Console.WindowWidth)
                {
                    LengthInCharacters = Console.WindowWidth;
                }

                ForegroundColor = LineColor;

                Console.WriteLine();

                for (int i = 0; i < LengthInCharacters; i++)
                {
                    Console.Write("_");
                }
            }
            else
            {
                Console.WriteLine("\n");
            }
        }

        public void StyleOption(string Label, bool Active = false)
        {
            Print("\n\n\t");

            ForegroundColor = Active ? ConsoleColor.DarkCyan : ConsoleColor.Cyan;

            foreach (char ch in Label)
            {
                Console.Write(ch.ToString());
            }
        }

        public void StyleInput(bool Command = false)
        {
            ForegroundColor = ConsoleColor.Cyan;

            if (Command)
            {
                ForegroundColor = ConsoleColor.Cyan;

                Console.Write(string.Format("\n SCORE: {0}/{1} >", FormatScore(Program.score), Program.MAXSCORE));
            }
            else
            {
                Console.Write("\n >");
            }

            ForegroundColor = ConsoleColor.White;
        }

        public string FormatScore(int Score)
        {
            switch (Score.ToString().Length)
            {
                case 0:
                    return "000";

                case 1:
                    return "00" + Score.ToString();

                case 2:
                    return "0" + Score.ToString();

                default:
                    return Score.ToString();
            }
        }

        public void StyleAlt(string Message)
        {
            ForegroundColor = ConsoleColor.White;

            if (Program.FIXED_COLOR)
            {
                for (int i = 0; i < 83; i++)
                {
                    Console.Write("_");
                }
            }

            Print("\n " + Message, ConsoleColor.White);
            DrawLine();
            Print("\n");
            Console.CursorLeft = Message.Length + 2;
            Console.CursorTop -= 3;
        }

        public string ReadLine(int MaxChars = 0, bool NoCursor = false, bool Parser = false)
        {
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            string text = string.Empty;
            string cur = "♦";
            ConsoleColor cursorColor = ConsoleColor.White;

            Console.CursorVisible = true;

            ForegroundColor = cursorColor;

            if (NoCursor)
            {
                Console.CursorLeft++;
            }
            else
            {
                Console.Write(cur);
            }

            ForegroundColor = ConsoleColor.White;

            Console.CursorLeft--;
            while (key.Key != ConsoleKey.Enter)
            {
                bool preset = false;
                key = Console.ReadKey(true);

                if (Console.CursorLeft >= 81 || key.Key == ConsoleKey.Enter || (MaxChars != 0 && text.Length >= MaxChars && key.Key != ConsoleKey.Backspace))
                {
                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.CursorLeft++;

                        Console.Write("\b \b");
                    }

                    continue;
                }

                if (Console.NumberLock && Parser)
                {
                    string mask = string.Empty;

                    switch (key.Key)
                    {
                        case ConsoleKey.NumPad7:
                            try
                            {
                                FileSystem.CheckFolder();
                                string[] hk = File.ReadAllLines(FileSystem.keymapdat);

                                if (hk[1].Split('=')[0].ToLower() == "numpad7")
                                {
                                    mask = hk[1].Split('=')[1].ToLower();

                                    if (hk[2].Split('=')[0].ToLower() == "commandrequiresobject")
                                    {
                                        preset = Convert.ToBoolean(hk[2].Split('=')[1].ToLower());

                                        if (hk[0].ToLower() == "custom_key_help")
                                        {
                                            preset = false;
                                            mask = "custom_key_help";
                                            FileSystem.DELETE(FileSystem.keymapdat);
                                        }
                                    }
                                    else
                                    {
                                        preset = false;
                                        mask = "custom_key_help";
                                        FileSystem.DELETE(FileSystem.keymapdat);
                                    }
                                }
                                else
                                {
                                    preset = false;
                                    mask = "custom_key_help";
                                    FileSystem.DELETE(FileSystem.keymapdat);
                                }
                            }
                            catch
                            {
                                preset = false;
                                mask = "custom_key_help";
                                FileSystem.DELETE(FileSystem.keymapdat);
                            }

                            break;
                        case ConsoleKey.NumPad0:
                            mask = "take inventory";
                            break;
                        case ConsoleKey.Add:
                            mask = "take the ";
                            preset = true;
                            break;
                        case ConsoleKey.Subtract:
                            mask = "drop the ";
                            preset = true;
                            break;
                        case ConsoleKey.NumPad1:
                            mask = "zap the ";
                            preset = true;
                            break;
                        case ConsoleKey.Divide:
                            mask = "look at the ";
                            preset = true;
                            break;
                        case ConsoleKey.Multiply:
                            mask = "use the ";
                            preset = true;
                            break;
                        case ConsoleKey.NumPad5:
                            mask = "look around";
                            break;
                        case ConsoleKey.Decimal:
                            mask = "diagnose myself";
                            break;
                        case ConsoleKey.NumPad2:
                            mask = "go south";
                            break;
                        case ConsoleKey.NumPad3:
                            mask = "climb down";
                            break;
                        case ConsoleKey.NumPad4:
                            mask = "go west";
                            break;
                        case ConsoleKey.NumPad6:
                            mask = "go east";
                            break;
                        case ConsoleKey.NumPad8:
                            mask = "go north";
                            break;
                        case ConsoleKey.NumPad9:
                            mask = "climb up";
                            break;
                    }

                    if (mask != string.Empty)
                    {
                        if (Console.CapsLock)
                        {
                            mask = mask.ToUpper();
                        }

                        if (preset)
                        {
                            Console.Write(mask);
                        }
                        else
                        {
                            Console.WriteLine(mask);
                        }

                        text = mask;
                    }

                    if (mask != string.Empty && !preset)
                    {
                        return text;
                    }
                }

                if (!preset)
                {
                    char vk;
                    if (key.Key == ConsoleKey.Enter)
                    {
                        vk = '^';
                    }
                    else if (key.Key == ConsoleKey.Backspace)
                    {
                        vk = ' ';
                    }
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        text = "~";
                        break;
                    }
                    else if ((char.IsLetterOrDigit(key.KeyChar) || char.IsPunctuation(key.KeyChar) || char.IsSymbol(key.KeyChar) || char.IsSeparator(key.KeyChar) || char.IsDigit(key.KeyChar)) && key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.UpArrow && key.Key != ConsoleKey.DownArrow && key.Key != ConsoleKey.RightArrow && key.Key != ConsoleKey.LeftArrow && key.Key != ConsoleKey.Escape && key.KeyChar != '~')
                    {
                        vk = key.KeyChar;
                    }
                    else
                    {
                        continue;
                    }

                    if (key.Key == ConsoleKey.Backspace && text.Length > 0)
                    {
                        text = text.Substring(0, text.Length - 1);

                        Console.Write("\b \b");

                        ForegroundColor = cursorColor;

                        if (NoCursor)
                        {
                            Console.CursorLeft++;
                        }
                        else
                        {
                            Console.Write(cur);
                        }

                        ForegroundColor = ConsoleColor.White;

                        Console.CursorLeft++;

                        Console.Write("\b \b");

                        Console.CursorLeft--;
                    }
                    else if (key.Key != ConsoleKey.Backspace && vk != '^')
                    {
                        Console.Write(vk);

                        ForegroundColor = cursorColor;

                        if (NoCursor)
                        {
                            Console.CursorLeft++;
                        }
                        else
                        {
                            Console.Write(cur);
                        }

                        ForegroundColor = ConsoleColor.White;

                        Console.CursorLeft--;

                        text += vk;
                    }
                }
            }

            if (text == "~")
            {
                Print("\b\n\n Did you really think it would be that easy?^");
                Program.pregunta = 3;
                return "y=mx+b";
            }

            Console.CursorVisible = false;

            Print("\n");

            return text;
        }

        public void StyleHeader(string Message, bool DrawLines = true, bool space = true)
        {
            if (space)
            {
                for (int i = 0; i < 5; i++)
                {
                    Print("\n");
                }
            }

            if (DrawLines)
            {
                DrawLine();
            }

            ForegroundColor = ConsoleColor.Cyan;

            Console.Write("\n");
            CenterText(Message.ToUpper());

            ForegroundColor = ConsoleColor.White;

            if (DrawLines)
            {
                DrawLine();
            }
        }
    }
}
