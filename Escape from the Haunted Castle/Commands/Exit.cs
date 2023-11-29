// Exit.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace HauntedCastle.Commands
{
    public class Exit
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if (opt1 == "restart" || opt1 == "erase" || opt1 == "reset")
            {
                c.Print("^");

                // Declarations
                string YN = string.Empty;
                string msg = "Are you sure you want to erase your progress?";

                while (!Methods.YesNoCondition(YN))
                {
                    c.StyleAlt(msg);

                    YN = c.ReadLine().ToLower();

                    c.Print("\n");

                    if (Methods.YesCondition(YN))
                    {
                        FileSystem.CheckFolder();

                        if (File.Exists(FileSystem.savefile))
                        {
                            File.Delete(FileSystem.savefile);
                        }

                        c.Print("\n Progress for " + Program.name + " erased.", ConsoleColor.Gray);
                        c.Pause();
                        c.CloseEnvironment();
                    }
                    else if (Methods.NoCondition(YN))
                    {
                        return;
                    }
                    else
                    {
                        msg = "Please answer yes or no:";
                    }
                }
            }

            if (opt1 == "exit" || opt1 == "quit" || opt1 == "q")
            {
                if (opt2 == "save")
                {
                    FileSystem.SaveData();
                    c.CloseEnvironment();
                }
                else if (opt2 == "")
                {
                    string YN = string.Empty;
                    string msg = "Are you sure you want to exit?";

                    c.Print("^");

                    while (!Methods.YesNoCondition(YN))
                    {
                        c.StyleAlt(msg);

                        YN = c.ReadLine().ToLower();

                        c.Print("\n");

                        if (Methods.YesCondition(YN))
                        {
                            FileSystem.SaveData();
                            c.CloseEnvironment();
                        }
                        else if (Methods.NoCondition(YN))
                        {
                            return;
                        }
                        else
                        {
                            msg = "Please answer yes or no:";
                        }
                    }
                }
            }
        }
    }
}
