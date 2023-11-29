// BattleSimulator.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using HauntedCastle.Commands;

namespace HauntedCastle
{
    internal class BattleSimulator
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();
        private static readonly int lns = 7;

        public static bool StartBattle(int index, string[] attacks, string Location, string myEnemy = "")
        {
            string Enemy = myEnemy.ToUpper();

            // Declarations
            double hp = Program.PermanentHealth;

            c.Print("\n");
            double ehp = index == -1 ? 100 : 110 + ((index + 1) * 10);

            if (index == 0)
            {
                Enemy = "THE GHOST";
            }
            else if (index == 1)
            {
                Enemy = "THE SUIT OF ARMOR";
            }
            else if (index == 2)
            {
                Enemy = "THE GOBLIN";
            }
            else if (index == 3)
            {
                Enemy = "THE SKELETON KING";
            }

            while (hp > 0 && ehp > 0)
            {
                DiagnosticSummary ds = Diagnose.Run("h", "", false);
                ds.Health = (int)Math.Round(hp);

                WRITESOME(Enemy, Location, index, hp, ehp);

                ConsoleKeyInfo key;
                int idx = 1;

                WRITEALL(idx, true, ds);

                key = new ConsoleKeyInfo();

                while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Spacebar && key.Key != ConsoleKey.X)
                {
                    key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        if (idx > 1)
                        {
                            idx--;
                        }

                        WRITEALL(idx, false, ds);
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        if (Program.Inventory[6] == 1)
                        {
                            if (idx < 7)
                            {
                                idx++;
                            }
                            else if (idx == 7)
                            {
                                idx = 1;
                            }
                        }
                        else
                        {
                            if (idx < 6)
                            {
                                idx++;
                            }
                            else if (idx == 6)
                            {
                                idx = 1;
                            }
                        }

                        WRITEALL(idx, false, ds);
                    }
                    else if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
                    {
                        idx = 1;

                        WRITEALL(idx, false, ds);
                    }
                    else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                    {
                        idx = 2;

                        WRITEALL(idx, false, ds);
                    }
                    else if (key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.NumPad3)
                    {
                        idx = 3;

                        WRITEALL(idx, false, ds);
                    }
                    else if (key.Key == ConsoleKey.D4 || key.Key == ConsoleKey.NumPad4)
                    {
                        idx = 4;

                        WRITEALL(idx, false, ds);
                    }
                    else if (key.Key == ConsoleKey.D5 || key.Key == ConsoleKey.NumPad5)
                    {
                        idx = 5;

                        WRITEALL(idx, false, ds);
                    }
                    else if (key.Key == ConsoleKey.D6 || key.Key == ConsoleKey.NumPad6)
                    {
                        idx = 6;

                        WRITEALL(idx, false, ds);
                    }
                    else if ((key.Key == ConsoleKey.D7 || key.Key == ConsoleKey.NumPad7) && Program.Inventory[6] == 1)
                    {
                        idx = 7;

                        WRITEALL(idx, false, ds);
                    }
                }

                int hps = 0;
                int ehps = 0;
                int enemyAttack = Program.rnd.Next(attacks.Length);

                if (idx == 1)
                {
                    ehps = ds.Health / 5;

                    c.Print(string.Format("\n USING HEALTH ({0}/100): You punch {1} with your hands.", c.FormatScore(ds.Health), Enemy), ConsoleColor.Red);
                }
                else if (idx == 2)
                {
                    ehps = ds.Skill / 5;

                    c.Print(string.Format("\n USING SKILL ({0}/100): You kick {1}.", c.FormatScore(ds.Skill), Enemy), ConsoleColor.Yellow);
                }
                else if (idx == 3)
                {
                    ehps = ds.Magic / 2;

                    c.Print(string.Format("\n USING MAGIC ({0}/100): You zap {1} with your magic staff.", c.FormatScore(ds.Magic), Enemy), ConsoleColor.Magenta);
                }
                else if (idx == 4)
                {
                    if (Program.ateBread)
                    {
                        ehps = 1000;

                        c.Print(string.Format("\n USING HYGIENE ({0}/100): You attack {1} with\n your terrible-smelling breath.", c.FormatScore(ds.Hygiene), Enemy), ConsoleColor.Green);
                    }
                    else if (Program.spit)
                    {
                        ehps = 15;

                        c.Print(string.Format("\n USING HYGIENE ({0}/100): You attack {1} with your bad breath!", c.FormatScore(ds.Hygiene), Enemy), ConsoleColor.Green);
                    }
                    else
                    {
                        ehps = 0;

                        c.Print(string.Format("\n USING HYGIENE ({0}/100): You breathe on {1}.", c.FormatScore(ds.Hygiene), Enemy), ConsoleColor.Green);
                    }
                }
                else if (idx == 5)
                {
                    ehps = 8;

                    c.Print(string.Format("\n You burn {0} with your candle.", Enemy), ConsoleColor.White);
                }
                else if (idx == 6)
                {
                    _ = Commands.Diagnose.Run("h", "");

                    c.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write("\n PRESS [X] TO CONTINUE...");

                    bool x = false;
                    while (!x)
                    {
                        char m = char.ToLower(Console.ReadKey(true).KeyChar);
                        x = m == 'x' || m == '5' || m == '8';
                    }

                    c.Print("\n\n");
                }
                else if (idx == 7 && Program.Inventory[6] == 1)
                {
                    ehps = ds.Protection / 5;

                    c.Print(string.Format("\n USING PROTECTION ({0}/100): You use your shield to protect you from harm\n while simultaneously attacking {1}.", c.FormatScore(ds.Protection), Enemy), ConsoleColor.Cyan);
                    ehp -= ehps;

                    c.Print("\n\n " + Enemy + " strikes back, but your shield protects you from the blow.", ConsoleColor.White);

                    ehp = Math.Round(ehp);
                    Program.Inventory[6]--;

                    c.Print("\n\n Your shield shatters from the impact and disappears.", ConsoleColor.White);
                    c.Pause();

                    WRITESOME(Enemy, Location, index, hp, ehp);
                }

                if (idx != 7 && idx != 6)
                {
                    ehp -= ehps;

                    if (index == -1)
                    {
                        hps = 7;
                    }
                    else
                    {
                        if (enemyAttack < 2)
                        {
                            hps = 7;
                        }

                        if (enemyAttack == 0 && Program.rnd.Next(3) == 0)
                        {
                            Program.State[2] = true;
                        }

                        if (enemyAttack == 2 && Program.rnd.Next(3) == 0)
                        {
                            Program.State[3] = true;
                        }
                    }

                    if (hps > ehps)
                    {
                        c.Print("\n\n Your attack is ineffective.", ConsoleColor.White);
                    }
                    else if (ehps == hps)
                    {
                        c.Print("\n\n Your attack is moderately effective.", ConsoleColor.White);
                    }
                    else if (ehps == 1000)
                    {
                        c.Print("\n\n Your attack is devastatingly effective.", ConsoleColor.White);
                    }
                    else
                    {
                        c.Print("\n\n Your attack is very effective.", ConsoleColor.White);
                    }

                    hp -= hps;

                    c.Print(string.Format("\n\n {0} {1}", Enemy, attacks[enemyAttack]), ConsoleColor.White);

                    ehp = Math.Round(ehp);
                    hp = Math.Round(hp);

                    c.Pause();
                }
            }

            if (hp <= 0)
            {
                c.Print("\n You are slain!", ConsoleColor.White);

                c.ForegroundColor = ConsoleColor.Cyan;

                Console.Write("\n\n PRESS [Z] TO CONTINUE...");

                bool x = false;
                char m;

                while (!x)
                {
                    m = char.ToLower(Console.ReadKey(true).KeyChar);

                    x = m == 'z' || m == '5';
                }

                c.Print("\n\n");

                Methods.GameOver(false);
                return false;
            }
            else
            {
                int gold;
                if (index == -1)
                {
                    gold = 5;
                }
                else
                {
                    gold = (index + 1) * 20;
                    Score.Addition(Score.Y_Battle);
                    Program.Ghosts[index] = true;
                }

                if (Convert.ToInt32(Math.Round(50 + (0.1 * hp))) > hp)
                {
                    Methods.SetPermanentHealth(Convert.ToInt32(Math.Round(70 + (0.1 * hp))));
                }
                else
                {
                    Methods.SetPermanentHealth(Convert.ToInt32(hp));
                }

                Program.Inventory[0] += gold;

                FileSystem.SaveData();

                c.Print(string.Format("\n You win the battle.\n {0} disappears with a loud bang and leaves\n behind {1} gold coins, which you keep.^", Enemy, gold));
                c.Print("\n After a short rest, much of your health is replenished.");

                c.ForegroundColor = ConsoleColor.Cyan;

                Console.Write("\n\n PRESS [Z] TO CONTINUE...");

                bool x = false;
                char m;

                while (!x)
                {
                    m = char.ToLower(Console.ReadKey(true).KeyChar);

                    x = m == 'z' || m == '5';
                }

                c.Print("\n\n");

                c.Clear(true);
                return true;
            }
        }

        private static void WRITESOME(string Enemy, string Location, int index, double hp, double ehp)
        {
            c.Clear(true, ConsoleColor.DarkRed);
            c.Print("\n ");
            c.Print(string.Format("   {0}: ", Location), ConsoleColor.Gray);
            c.Print("Battle", ConsoleColor.White);
            c.DrawLine(83, ConsoleColor.Gray);

            c.Print(string.Format("\n {0}'s HEALTH: {1}/{2}", Program.name, c.FormatScore((int)hp), 100), ConsoleColor.Red);

            if (index == -1)
            {
                c.Print(string.Format("\n\n {0}'s HEALTH: {1}/{2}", Enemy, c.FormatScore((int)ehp), 100), ConsoleColor.Red);
            }
            else
            {
                c.Print(string.Format("\n\n {0}'s HEALTH: {1}/{2}", Enemy, c.FormatScore((int)ehp), 110 + ((index + 1) * 10)), ConsoleColor.Red);
            }
        }

        private static void WRITEALL(int ACTIVEINDEX, bool FIRST, Commands.DiagnosticSummary ds)
        {
            if (!FIRST)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = lns;

                for (int i = 0; i < lns; i++)
                {
                    c.Print("\n");
                }

                Console.CursorLeft = 0;
                Console.CursorTop = lns;
            }

            c.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("\n\n\n Please choose an attack.");

            if (ACTIVEINDEX == 1)
            {
                c.StyleOption(string.Format("> 1. PUNCH\tHEALTH\t\t({0}/100)", c.FormatScore(ds.Health)), true);
            }
            else
            {
                c.StyleOption(string.Format("  1. PUNCH\tHEALTH\t\t({0}/100)", c.FormatScore(ds.Health)));
            }

            if (ACTIVEINDEX == 2)
            {
                c.StyleOption(string.Format("> 2. KICK\tSKILL\t\t({0}/100)", c.FormatScore(ds.Skill)), true);
            }
            else
            {
                c.StyleOption(string.Format("  2. KICK\tSKILL\t\t({0}/100)", c.FormatScore(ds.Skill)));
            }

            if (ACTIVEINDEX == 3)
            {
                c.StyleOption(string.Format("> 3. ZAP\tMAGIC\t\t({0}/100)", c.FormatScore(ds.Magic)), true);
            }
            else
            {
                c.StyleOption(string.Format("  3. ZAP\tMAGIC\t\t({0}/100)", c.FormatScore(ds.Magic)));
            }

            if (ACTIVEINDEX == 4)
            {
                c.StyleOption(string.Format("> 4. BREATHE\tHYGIENE\t\t({0}/100)", c.FormatScore(ds.Hygiene)), true);
            }
            else
            {
                c.StyleOption(string.Format("  4. BREATHE\tHYGIENE\t\t({0}/100)", c.FormatScore(ds.Hygiene)));
            }

            if (ACTIVEINDEX == 5)
            {
                c.StyleOption("> 5. BURN", true);
            }
            else
            {
                c.StyleOption("  5. BURN");
            }

            if (ACTIVEINDEX == 6)
            {
                c.StyleOption("> 6. DIAGNOSE", true);
            }
            else
            {
                c.StyleOption("  6. DIAGNOSE");
            }

            if (ACTIVEINDEX == 7 && Program.Inventory[6] == 1)
            {
                c.StyleOption(string.Format("> 7. SHIELD\tPROTECTION\t({0}/100)", c.FormatScore(ds.Protection)), true);
            }
            else if (Program.Inventory[6] == 1)
            {
                c.StyleOption(string.Format("  7. SHIELD\tPROTECTION\t({0}/100)", c.FormatScore(ds.Protection)));
            }

            c.Print("\n");
            c.DrawLine();
        }
    }
}
