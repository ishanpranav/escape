using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace haunted_castle
{
    class Options
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void About()
        {
            c.Clear();
            c.StyleHeader("About", true, false);

            Commands.Info.Run("info", "");

            bool x = false;
            char m;

            c.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("\n PRESS [X] TO CONTINUE...");

            while (!x)
            {
                m = char.ToLower(Console.ReadKey(true).KeyChar);

                x = (m == 'x' || m == '8' || m == '5');
            }

            c.ForegroundColor = ConsoleColor.White;
        }

        private static void writeScreen(bool ret, string msg, ConsoleColor fg = ConsoleColor.Green, ConsoleColor bg = ConsoleColor.Black, bool lines = true)
        {
            if (ret)
            {
                c.Print(msg, fg, bg);
                
                if (lines)
                    c.DrawLine(83, ConsoleColor.Gray);
            }
        }

        public static string HiScores(bool ret, bool summary = false)
        {
            int limit = 10;

            if (summary)
                limit = 30;

            if (ret)
            {
                c.Clear();
                c.StyleHeader("Hi-Scores", true, false);
            }

            if (File.Exists(FileSystem.scoresdat))
            {
                List<string> lst = new List<string>();
                SimpleEncryption se = new SimpleEncryption();

                try
                {
                    foreach (string line in se.DecryptString(File.ReadAllText(FileSystem.scoresdat)).Split('~'))
                        lst.Add(line);

                    if (lst.Count == 0)
                        writeScreen(ret, "\n There are no Hi-Scores to display.", ConsoleColor.Gray);

                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].Trim() == string.Empty)
                            lst.RemoveAt(i);
                        else if (lst[i].Split(',')[0].Trim() == string.Empty)
                            lst.RemoveAt(i);
                    }

                    List<string> lstOrd = lst.OrderByDescending(s => int.Parse(s.Split(',')[1])).ToList();

                    int num = 1;
                    string spacing, spacing2;
                    string rank = string.Empty;

                    if (lst.Count != 0)
                        writeScreen(ret, "\n  #1\tSCORE: 500     ISHAN P      RANK: EMPEROR", ConsoleColor.Cyan, ConsoleColor.Black, !summary);

                    List<string> names = new List<string>();
                    ConsoleColor cc = ConsoleColor.Gray;

                    for (int i = 0; i < lstOrd.Count(); i++)
                    {
                        spacing = string.Empty;
                        spacing2 = string.Empty;

                        try
                        {
                            for (int j = 0; j < 3 - lstOrd[i].Split(',')[1].Length; j++)
                                spacing += " ";

                            for (int j = 0; j < 8 - lstOrd[i].Split(',')[0].Length; j++)
                                spacing2 += " ";
                        }
                        catch { }

                        int tscore = int.Parse(lstOrd[i].Split(',')[1]);
                        int nextRank = 0;
                        string sNextRank = "#";

                        int[] nRanks = new int[] { 500, 450, 420, 385, 350, 315, 280, 245, 210, 175, 140, 100, 50, 30, 0 };
                        string[] ranks = new string[] { "EMPEROR......", "KING.........", "SENIOR MASTER", "MASTER.......", "JUNIOR MASTER", "PRINCE.......", "GRAND DUKE...", "DUKE.........", "EARL.........", "BARON........", "LORD.........", "KNIGHT.......", "ADVENTURER...", "MERCHANT.....", "NOVICE......." };

                        if (nRanks.Length == ranks.Length)
                            for (int j = 0; j < nRanks.Length; j++)
                                if (tscore >= nRanks[j])
                                {
                                    rank = ranks[j];

                                    if (j > 1)
                                        nextRank = (nRanks[j - 1] - tscore);
                                    else
                                        sNextRank = string.Empty;

                                    break;
                                }

                        rank = rank.Replace('.', ' ');

                        if (sNextRank != string.Empty)
                            sNextRank = "NEXT RANK: " + c.FormatScore(nextRank);

                        if (!names.Contains(lstOrd[i].Split(',')[0].ToUpper()))
                        {
                            if (lstOrd[i].Split(',')[0].ToUpper().Contains("ISHAN") || lstOrd[i].Split(',')[0].ToUpper().Contains("ADMIN"))
                                tscore = Program.MAXSCORE + 1;

                            cc = ConsoleColor.Gray;

                            if (num < limit && tscore <= Program.MAXSCORE)
                            {
                                if (num == 1)
                                {
                                    string scorer = lstOrd[i].Split(',')[0].ToUpper();

                                    while (scorer.Length < 8)
                                        scorer += " ";

                                    cc = ConsoleColor.Yellow;

                                    if (!ret)
                                        return string.Format("CONGRATULATIONS {0}{2}  SCORE: {1}", scorer, lstOrd[i].Split(',')[1], spacing);
                                }
                                else if (num < 5)
                                    cc = ConsoleColor.White;

                                writeScreen(ret, string.Format("\n  #{0}\tSCORE: {2}{3}     {1}{6}     RANK: {4}   {5}", (num + 1).ToString(), lstOrd[i].Split(',')[0].ToUpper(), lstOrd[i].Split(',')[1], spacing, rank, sNextRank, spacing2), cc, ConsoleColor.Black, !summary);
                            }
                            else if (num < limit && tscore > Program.MAXSCORE)
                                num--;
                        }
                        else
                            num--;

                        names.Add(lstOrd[i].Split(',')[0].ToUpper());

                        num++;
                    }
                }
                catch
                {
                    writeScreen(ret, "\n Error: The Hi-Scores file is corrupt!\n\n Please see the game manual for details on troubleshooting errors.\n\n To resolve this issue, try deleting the file below:\n\n " + FileSystem.scoresdat, ConsoleColor.Red);
                }

                if (ret && !summary)
                {
                    bool x = false;
                    char m = ' ';

                    c.ForegroundColor = ConsoleColor.Cyan;

                    Console.Write("\n PRESS [Z] FOR MORE SCORES\n PRESS [X] TO CONTINUE...");

                    while (!x)
                    {
                        m = char.ToLower(Console.ReadKey(true).KeyChar);

                        x = (m == 'x' || m == '8' || m == '5' || m == 'z');
                    }

                    if (m == 'z')
                        HiScores(true, true);

                    c.Print("\n\n");
                }
            }
            else
                writeScreen(ret, "\n There are no scores to display.", ConsoleColor.Gray);

            if (ret && summary)
                c.Pause();

            return string.Empty;
        }
    }
}
