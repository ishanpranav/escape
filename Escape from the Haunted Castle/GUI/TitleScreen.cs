// TitleScreen.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using HauntedCastle.Properties;

namespace HauntedCastle.GUI
{
    internal class TitleScreen
    {
        // Declarations
        private static readonly Display c = new Display();

        public static void Show(bool Standard, bool Win, bool Lose, bool H = true)
        {
            // Declarations

            try
            {
                c.BackgroundColor = ConsoleColor.Black;
                c.ForegroundColor = ConsoleColor.White;
                Console.CursorVisible = false;
                Console.Title = string.Format("Escape from the Haunted Castle [Version {0}]", Convert.ToString(Assembly.GetEntryAssembly().GetName().Version.Major) + "." + Convert.ToString(Assembly.GetEntryAssembly().GetName().Version.Minor));
                Console.WindowWidth = 83;
                Console.WindowHeight = 40;
                Console.BufferWidth = 83;
                Console.BufferHeight = 40;
            }
            catch { }

            c.Clear();

            //for (int i = 0; i < 40; i++)
            //    Console.Write("\n");

            foreach (string line in Resources.ASCII_Art.Split('r'))
            {
                foreach (char ch in line)
                {
                    switch (ch)
                    {
                        case ' ':
                            break;
                        case 'Z':
                            c.ForegroundColor = Lose ? ConsoleColor.White : Win ? ConsoleColor.DarkRed : ConsoleColor.Red;

                            break;
                        case 'z':
                            c.ForegroundColor = Lose ? ConsoleColor.White : Win ? ConsoleColor.DarkRed : ConsoleColor.Red;

                            break;
                        case '(':
                        case 'C':
                            c.ForegroundColor = Lose ? ConsoleColor.Gray : ConsoleColor.Yellow;
                            break;
                        case '~':
                            c.ForegroundColor = Lose ? ConsoleColor.Red : ConsoleColor.Cyan;
                            break;
                        case ',':
                        case '\'':
                            c.ForegroundColor = Lose ? ConsoleColor.DarkGray : ConsoleColor.Green;
                            break;
                        case '*':
                            c.ForegroundColor = Lose ? ConsoleColor.Gray : ConsoleColor.White;
                            break;
                        case 'U':
                            c.ForegroundColor = Win ? ConsoleColor.DarkRed : ConsoleColor.DarkYellow;
                            break;
                        case '1':
                        case '2':
                            c.ForegroundColor = Win ? ConsoleColor.DarkRed : ConsoleColor.DarkYellow;
                            break;
                        case 'T':
                            c.ForegroundColor = Lose ? ConsoleColor.DarkRed : ConsoleColor.DarkCyan;
                            break;
                        case '`':
                            break;
                        default:
                            c.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }

                    if (ch == '`')
                    {
                        Console.Write(" ");
                    }
                    else if (ch == '\'' || ch == ',')
                    {
                        Console.Write("^");
                    }
                    else if (ch == 'S' || ch == '2')
                    {
                        Console.Write("/");
                    }
                    else if (ch == 'U')
                    {
                        Console.Write("_");
                    }
                    else if (ch == '1')
                    {
                        Console.Write("\\");
                    }
                    else if (ch == 'T')
                    {
                        Console.Write("~");
                    }
                    else
                    {
                        Console.Write(ch.ToString());
                    }

                    c.BackgroundColor = ConsoleColor.Black;
                    c.ForegroundColor = ConsoleColor.White;
                }
            }

            // Declarations
            int j = 2;

            if (!Standard && (Win || Lose))
            {
                Console.Write("\n");
            }

            if (Standard)
            {
                c.Print("\n\n");

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                c.CenterText("Escape from the");
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();

            if (Standard)
            {
                for (int i = 0; i < Resources.TitleText.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Black;

                    //if ((j % 2) == 0)
                    switch (Resources.TitleText[i])
                    {
                        case '`':
                            Console.Write(" ");
                            break;
                        case '!':
                            Console.Write("!");
                            break;
                        case ' ':
                            break;
                        case '\n':
                            Console.Write("\n");
                            break;
                        default:
                            Console.Write(Resources.TitleText[i].ToString());
                            j++;
                            break;
                    }
                }
            }
            else if (Win)
            {
                for (int i = 0; i < Program.EndWinScreenLines.Length; i++)
                {
                    if (Program.EndWinScreenLines[i] != ' ' && Program.EndWinScreenLines[i] != '\n')
                    {
                        c.ForegroundColor = ConsoleColor.Cyan;

                        Console.Write("!");
                    }
                    else if (Program.EndWinScreenLines[i] == '\n' || Program.EndWinScreenLines[i] == 'r')
                    {
                        Console.Write("\n");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
            else if (Lose)
            {
                for (int i = 0; i < Program.EndScreenLines.Length; i++)
                {
                    if (Program.EndScreenLines[i] != ' ' && Program.EndScreenLines[i] != '\n')
                    {
                        c.ForegroundColor = ConsoleColor.Red;

                        Console.Write("!");
                    }
                    else if (Program.EndScreenLines[i] == '\n' || Program.EndScreenLines[i] == 'r')
                    {
                        Console.Write("\n");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }

            c.ForegroundColor = Win ? ConsoleColor.Gray : ConsoleColor.Red;

            if (Win && H)
            {
                c.CenterText("\"Victory belongs to the most persevering.\"");
                Console.WriteLine();
                c.CenterText("- Napoleon Bonaparte");
            }
            else if (!H)
            {
                c.CenterText("\"I would prefer even to fail with honor than to win by cheating.\"");
                Console.WriteLine();
                c.CenterText("- Sophocles");
            }
            else if (Lose)
            {
                c.CenterText("\"Failure is simply the opportunity to begin again,");
                Console.WriteLine();
                c.CenterText(" this time more intelligently\" - Henry Ford");
            }

            if (Standard)
            {
                c.StyleHeader("Press any key to begin", true, false);
                //    c.DrawLine(83, ConsoleColor.DarkCyan);
                //    Console.WriteLine();
                //    Console.ForegroundColor = ConsoleColor.Cyan;
                //    c.CenterText("PRESS ANY KEY TO BEGIN");
            }
            else
            {
                c.StyleHeader(string.Format("{1}'s SCORE: {0}/500", c.FormatScore(Program.score), Program.name.ToUpper()), true, false);
                Console.WriteLine();
            }

            if (Standard)
            {
                _ = Console.ReadKey(true);

                c.Clear();

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
                            break;
                        case '`':
                            Console.Write(" ");
                            break;
                        case '\n':
                            break;
                        case ' ':
                            break;
                        default:
                            c.ForegroundColor = ConsoleColor.DarkCyan;

                            Console.Write(Resources.Razorteeth[i].ToString());

                            c.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }

                Console.WriteLine();

                c.ForegroundColor = ConsoleColor.Cyan;

                c.CenterText("Razorteeth Studios");
                Console.Write("\n\n");
                c.CenterText("Escape from the Haunted Castle");
                Console.WriteLine();

                if (Program.FIXED_COLOR)
                {
                    c.CenterText("Deluxe Edition - Version " + Convert.ToString(Assembly.GetEntryAssembly().GetName().Version));
                }
                else
                {
                    c.CenterText("Standard Edition - Version " + Convert.ToString(Assembly.GetEntryAssembly().GetName().Version));
                }

                Console.WriteLine();
                Console.WriteLine();
                c.CenterText("Copyright (c) 2016-" + Program.Year + " Ishan Pranav");
                _ = Console.ReadKey(true);

                c.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
