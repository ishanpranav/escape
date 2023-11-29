// Computer.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;

namespace HauntedCastle.Minigames
{
    internal class Computer
    {
        private static readonly GUI.Display gui = new GUI.Display();

        public static bool Start()
        {
            gui.DrawScreen();

            gui.PrintScreen("RAZORTEETH PC", 1, ConsoleColor.Cyan);
            gui.PrintScreen("  ###   #####     ####    ###", 4, ConsoleColor.DarkCyan);
            gui.PrintScreen("  #  #  # # #     #   #  #   #", 5, ConsoleColor.DarkCyan);
            gui.PrintScreen("  ###     #       ####   #", 6, ConsoleColor.DarkCyan);
            gui.PrintScreen("  #  #    #       #      #   #", 7, ConsoleColor.DarkCyan);
            gui.PrintScreen("  #  #    #       #       ###", 8, ConsoleColor.DarkCyan);
            gui.PrintScreen("Razorteeth Studios Personal Computer", 10, ConsoleColor.Cyan);
            gui.PrintScreen("Operating System: Razorteeth Doors", 11, ConsoleColor.Cyan);
            gui.PrintScreen(string.Format("{0}, {1}/{2}/{3}", DateTime.Now.DayOfWeek.ToString(), DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year), 17, ConsoleColor.White);
            gui.PrintScreen("PRESS [X] TO LOG ON", 19, ConsoleColor.Yellow);

            char c = char.ToLower(Console.ReadKey(true).KeyChar);

            if (c == 'x')
            {
                while (true)
                {
                    gui.DrawScreen();

                    gui.PrintScreen("LOG ON", 1, ConsoleColor.Cyan);
                    gui.PrintScreen("> PASSWORD", 2, ConsoleColor.Cyan);
                    gui.PrintScreen("Enter the password to log on: ", 4, ConsoleColor.Gray);

                    string pass = gui.ReadLine(45);

                    if (pass.ToLower() == "invalid")
                    {
                        return Tabletop();
                    }
                    else
                    {
                        gui.PrintScreen("Password is invalid.", 6, ConsoleColor.Red);
                        gui.PrintScreen("PRESS [Z] TO EXIT", 18, ConsoleColor.Yellow);
                        gui.PrintScreen("PRESS [X] TO TRY AGAIN", 19, ConsoleColor.Yellow);

                        c = ' ';

                        while (c != 'x')
                        {
                            c = char.ToLower(Console.ReadKey(true).KeyChar);

                            if (c == 'z')
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private static bool Tabletop()
        {
            while (true)
            {
                gui.DrawScreen();

                gui.PrintScreen("TABLETOP", 1, ConsoleColor.Cyan);
                gui.PrintScreen("> BEGIN MENU", 2, ConsoleColor.Cyan);
                gui.PrintScreen("PRESS [Z] TO SEND MESSAGES", 16, ConsoleColor.Yellow);
                gui.PrintScreen("PRESS [X] TO CHECK MESSAGES", 17, ConsoleColor.Yellow);

                if (Program.Inventory[11] == 0)
                {
                    gui.PrintScreen("PRESS [C] TO EJECT DISKETTE", 18, ConsoleColor.Yellow);
                }

                gui.PrintScreen("PRESS [V] TO LOG OFF", 19, ConsoleColor.Yellow);

                char c = char.ToLower(Console.ReadKey(true).KeyChar);

                switch (c)
                {
                    case 'z':
                        string text = string.Empty;

                        gui.DrawScreen();

                        gui.PrintScreen("SEND MESSAGES", 1, ConsoleColor.Cyan);
                        gui.PrintScreen("Send messages to other players on the same computer or server.", 3, ConsoleColor.Cyan);
                        gui.PrintScreen("Enter messages below. Press [ENTER] twice to send.", 4, ConsoleColor.Gray);

                        string line = "y=mx+b";
                        int i = 0;

                        while (line.ToLower() != "" && i < 14)
                        {
                            gui.PrintScreen(Program.name.ToUpper().Trim() + " (" + (i + 1).ToString() + "): ", i + 6, ConsoleColor.White);

                            line = gui.ReadLine(60);

                            if (line.ToLower() != "")
                            {
                                text += Program.name.ToUpper() + ": " + line + Environment.NewLine;
                            }

                            i++;
                        }

                        File.AppendAllText(FileSystem.textfiletxt, Environment.NewLine + text);

                        gui.DrawScreen();

                        gui.PrintScreen("SEND MESSAGES", 1, ConsoleColor.Cyan);
                        gui.PrintScreen("Message was sent successfully.", 3, ConsoleColor.Cyan);
                        gui.PrintScreen("PRESS [C] TO CLOSE", 19, ConsoleColor.Yellow);

                        c = ' ';

                        while (c != 'c')
                        {
                            c = char.ToLower(Console.ReadKey(true).KeyChar);
                        }

                        break;

                    case 'x':
                        gui.DrawScreen();

                        gui.PrintScreen("CHECK MESSAGES", 1, ConsoleColor.Cyan);
                        gui.PrintScreen("Recieve messages from other players on the same computer or server.", 3, ConsoleColor.Cyan);

                        string[] lns = File.ReadAllLines(FileSystem.textfiletxt);

                        lns = lns.Skip(Math.Max(0, lns.Length - 14)).ToArray();

                        for (int j = 0; j < lns.Length; j++)
                        {
                            gui.PrintScreen("  " + lns[j], j + 5, ConsoleColor.White);
                        }

                        gui.PrintScreen("PRESS [C] TO CLOSE", 19, ConsoleColor.Yellow);

                        c = ' ';

                        while (c != 'c')
                        {
                            c = char.ToLower(Console.ReadKey(true).KeyChar);
                        }

                        break;

                    case 'c':
                        if (Program.Inventory[11] == 0)
                        {
                            gui.DrawScreen();

                            gui.PrintScreen("EJECT DISKETTE", 1, ConsoleColor.Green);
                            gui.PrintScreen("Ejecting storage diskette...", 3, ConsoleColor.Green);
                            gui.PrintScreen("Logging off...", 4, ConsoleColor.Green);
                            gui.PrintScreen("PRESS [C] TO CLOSE", 19, ConsoleColor.Yellow);

                            while (true)
                            {
                                c = char.ToLower(Console.ReadKey(true).KeyChar);

                                if (c == 'c')
                                {
                                    return true;
                                }
                            }
                        }

                        break;

                    case 'v':
                        gui.DrawScreen();

                        gui.PrintScreen("LOG OFF", 1, ConsoleColor.Cyan);
                        gui.PrintScreen("Logging off...", 3, ConsoleColor.Green);
                        gui.PrintScreen("PRESS [C] TO CLOSE", 19, ConsoleColor.Yellow);

                        while (true)
                        {
                            c = char.ToLower(Console.ReadKey(true).KeyChar);

                            if (c == 'c')
                            {
                                return false;
                            }
                        }
                }
            }
        }
    }
}
