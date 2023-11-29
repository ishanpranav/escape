using System;
using System.IO;
using System.Reflection;

namespace haunted_castle.Commands
{
    public class Info
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');

            if ((opt1 == "info" || opt1 == "about" || opt1 == "help" || opt1 == "?" || opt1 == "credits" || opt1 == "ver" || opt1 == "version" || opt1 == "v") && ((opt1 != "about" && (opt2 == "self" || opt2 == "me" || opt2 == "myself")) || (opt2 == string.Empty || (opt1 == "about" && opt2 == "game"))))
            {
                if (!Program.didInfo)
                {
                    Program.didInfo = true;
                    Score.Addition(Score.Z_Info);
                }

                string temp = string.Empty;

                if (Program.FIXED_COLOR)
                    temp = "Deluxe";
                else
                    temp = "Standard";

                c.Print(string.Format("\n ESCAPE FROM THE HAUNTED CASTLE\n\n Copyright (c) 2016-{2} Ishan Pranav\n\n {0} Edition | Version: {1}", temp, Convert.ToString(Assembly.GetEntryAssembly().GetName().Version), Program.Year), ConsoleColor.Gray);
                c.DrawLine(83, ConsoleColor.Gray);
                c.Print("\n INTRODUCTION\n\n  Welcome to Escape from the Haunted Castle, an exciting text-based adventure\n  game set in an ancient castle haunted by ghosts, goblins, and other foul\n  creatures. Take the role of a lost adventurer in search of treasure and\n  ancient artifacts. Make use of your cunning and skill to escape the castle\n  and arrive home safely with as many points as possible.", ConsoleColor.Gray);
                c.DrawLine(83, ConsoleColor.Gray);
           
                DirectoryInfo dir = new DirectoryInfo(FileSystem.root);

                double mem = 0;
                double memLogs = 0;
                double memDats = 0;
                double memExts = 0;
                int num = 0;
                int logs = 0;
                int dats = 0;
                int exts = 0;

                foreach (FileInfo file in dir.GetFiles())
                    switch (file.Extension.ToLower())
                    {
                        case ".hcx":
                            if (file.Name.ToLower() != "savefile")
                                num++;
                            mem += file.Length;
                            break;

                        case ".log":
                        case ".txt":
                        case ".pdf":
                            logs++;
                            memLogs += file.Length;
                            break;

                        case ".dat":
                            dats++;
                            memDats += file.Length;
                            break;

                        case ".dll":
                        case ".hcm":
                        case ".hcp":
                            exts++;
                            memExts += file.Length;
                            break;
                    }

                FileInfo fi = new FileInfo(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName);

                memExts += fi.Length;
                exts++;

                c.Print(string.Format("\n STORAGE\n\n  Saved Games\t\t{0:n0} file(s)\t{1:n2} kb\n  Program Data\t\t{2:n0} file(s)\t{3:n2} kb\n  Documents/Logs\t{4:n0} file(s)\t{5:n2} kb\n  Extensions/Packages\t{6:n0} file(s)\t{7:n2} kb\n\n  Total Storage Used\t{8:n0} file(s)\t{9:n2} kb", num, (mem / 1024), dats, (memDats / 1024), logs, (memLogs / 1024), exts, (memExts / 1024), (num + logs + dats + exts), ((mem + memLogs + memDats + memExts) / 1024)), ConsoleColor.Gray);
                c.DrawLine(83, ConsoleColor.Gray);
                c.Print("\n Please see the game manual for detailed documentation.^", ConsoleColor.Gray);
            }
        }
    }
}
