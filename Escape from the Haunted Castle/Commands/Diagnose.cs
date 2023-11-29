// Diagnose.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace HauntedCastle.Commands
{
    public class DiagnosticSummary
    {
        public int Health { get; set; }
        public int Protection { get; set; }
        public int Intelligence { get; set; }
        public int Hygiene { get; set; }
        public int Skill { get; set; }
        public int Magic { get; set; }
    }

    public class Diagnose
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static DiagnosticSummary Run(string opt1, string opt2, bool output = true)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');

            if ((opt1 == "diagnose" || opt1 == "health" || opt1 == "state" || opt1 == "stats" || opt1 == "diagnostic" || opt1 == "status" || opt1 == "h" || opt1 == "about") && ((opt1 != "about" && opt2 == string.Empty) || opt2 == "me" || opt2 == "myself" || opt2 == "self"))
            {
                DiagnosticSummary ds = new DiagnosticSummary()
                {
                    Health = Program.PermanentHealth,
                    Intelligence = (Program.score + Score.WinAll) / 5,
                    Hygiene = 20,
                    Skill = 20,
                    Magic = 14
                };

                if (Program.Inventory[6] == 1)
                {
                    ds.Protection += 20;
                }

                if (Program.Revive)
                {
                    ds.Protection += 30;
                }

                if (!Program.State[0])
                {
                    ds.Protection += 10;
                }

                if (!Program.State[1])
                {
                    ds.Protection += 10;
                    ds.Skill += 40;
                }

                if (!Program.State[2])
                {
                    ds.Protection += 10;
                }

                if (!Program.State[3])
                {
                    ds.Protection += 20;
                }

                if (Program.washedTomatoes)
                {
                    ds.Hygiene += 40;
                }

                if (Program.washedHands)
                {
                    ds.Hygiene += 40;
                }

                if (Program.spit)
                {
                    ds.Hygiene -= 20;
                }

                if (Program.readPalm)
                {
                    ds.Skill += 40;
                    ds.Magic += 14;
                }

                if (Program.ateBread)
                {
                    ds.Hygiene = 0;
                }

                if (Program.IsInvisible)
                {
                    ds.Magic += 28;
                }

                if (Program.SpiderRepelling)
                {
                    ds.Magic += 14;
                }

                if (Program.Revive)
                {
                    ds.Magic += 16;
                }

                if (Program.alternate)
                {
                    ds.Magic += 14;
                }

                ds.Hygiene = 100 - ds.Hygiene;

                if (output)
                {
                    c.Print(string.Format("\n     SCORE:          {0}/500", c.FormatScore(Program.score)), ConsoleColor.White);
                    c.Print(string.Format("\n     HEALTH:         {0}/100^", c.FormatScore(ds.Health)), ConsoleColor.Red);
                    c.Print(string.Format("\n     PROTECTION:     {0}/100", c.FormatScore(ds.Protection)), ConsoleColor.Cyan);
                    c.Print(string.Format("\n     INTELLIGENCE:   {0}/100", c.FormatScore(ds.Intelligence)), ConsoleColor.Gray);
                    c.Print(string.Format("\n     HYGIENE:        {0}/100", c.FormatScore(ds.Hygiene)), ConsoleColor.Green);
                    c.Print(string.Format("\n     SKILL:          {0}/100", c.FormatScore(ds.Skill)), ConsoleColor.Yellow);
                    c.Print(string.Format("\n     MAGIC:          {0}/100^r", c.FormatScore(ds.Magic)), ConsoleColor.Magenta);

                    if (Program.State[0])
                    {
                        c.Print("\n     You are tired.", ConsoleColor.Red);
                    }

                    if (Program.State[1])
                    {
                        c.Print("\n     You are hungry.", ConsoleColor.Red);
                    }

                    if (Program.State[2])
                    {
                        c.Print("\n     You are injured.", ConsoleColor.Red);
                    }

                    if (Program.State[3])
                    {
                        c.Print("\n     You are poisoned.", ConsoleColor.Red);
                    }

                    if (!Program.hasEyebrows)
                    {
                        c.Print("\n     You have burnt hair.", ConsoleColor.Red);
                    }

                    if (Program.Revive)
                    {
                        c.Print("\n     You have a lasting self-healing effect.", ConsoleColor.Cyan);
                    }

                    if (Program.SpiderRepelling)
                    {
                        c.Print("\n     You have a lasting spider-repelling effect.", ConsoleColor.Cyan);
                    }

                    if (Program.ateBread)
                    {
                        c.Print("\n     You have bad breath.", ConsoleColor.Green);
                    }

                    if (Program.IsInvisible)
                    {
                        c.Print("\n     You are invisible.", ConsoleColor.Magenta);
                    }

                    if ((Program.score + Score.WinAll) > Program.MAXSCORE)
                    {
                        c.Print("\n     You are a cheater.", ConsoleColor.Red);
                    }

                    c.Print("\n     You have magical powers.^", ConsoleColor.Magenta);
                }

                return ds;
            }

            return null;
        }
    }
}
