// FileSystem.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace HauntedCastle
{
    internal class FileSystem
    {
        private const string alpha = "3479ACEGHJKMNPQRATWY34793479TGKM";

        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static string root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Escape from the Haunted Castle\";
        public static string savefile = root + "SAVEFILE.HCX";
        public static string scoresdat = root + "SCORES.DAT";
        public static string playersdat = root + "PLAYERS.DAT";
        public static string savefilexml = root + "SAVEFILE.XML";
        public static string textfiletxt = root + "MESSAGES.TXT";
        public static string ishandll = "ISHAN.DLL";
        public static string keymapdat = root + "KEYMAP.TXT";
        public static SimpleEncryption Encryption = new SimpleEncryption();

        public static void CheckFolder()
        {
            try
            {
                DELETE(savefilexml);

                if (!Directory.Exists(root))
                {
                    _ = Directory.CreateDirectory(root);
                }

                if (!File.Exists(scoresdat))
                {
                    File.WriteAllText(scoresdat, string.Empty);
                }

                if (!File.Exists(keymapdat))
                {
                    File.WriteAllText(keymapdat, "# Escape from the Haunted Castle Custom Key Mapping File" + Environment.NewLine + "NumPad7=custom_key_help" + Environment.NewLine + "CommandRequiresObject=False");
                }

                if (!File.Exists(playersdat))
                {
                    File.WriteAllText(playersdat, string.Empty);
                }

                if (!File.Exists(root + "CASTLE.DAT"))
                {
                    File.WriteAllText(root + "CASTLE.DAT", Properties.Resources.ASCII_Art);
                }

                if (!File.Exists(root + "RTLOGO.DAT"))
                {
                    File.WriteAllText(root + "RTLOGO.DAT", Properties.Resources.Razorteeth);
                }

                if (!File.Exists(root + "TITLE.DAT"))
                {
                    File.WriteAllText(root + "TITLE.DAT", Properties.Resources.TitleText);
                }

                if (!File.Exists(root + "README.TXT"))
                {
                    File.WriteAllText(root + "README.TXT", Properties.Resources.README);
                }

                if (File.Exists(ishandll))
                {
                    if (!File.Exists(root + ishandll))
                    {
                        File.Copy(ishandll, root + ishandll);
                    }
                }
                else
                {
                    c.Clear();
                    c.StyleHeader("Error", true, false);
                    c.Print("\n Required files are missing!\n\n Please contact the publisher for assistance.", ConsoleColor.Red);
                    c.Pause();
                    c.CloseEnvironment();
                }

                List<string> lines = new List<string>();
                lines.AddRange(File.ReadAllLines(playersdat));
                lines = lines.Distinct().ToList<string>();
                lines.Sort();
                File.WriteAllLines(playersdat, lines);

                if (!File.Exists(textfiletxt))
                {
                    File.WriteAllText(textfiletxt, string.Empty);
                }

                if (File.Exists(root + ".HCX"))
                {
                    File.Delete(root + ".HCX");
                }
            }
            catch
            {
                c.Clear();
                c.StyleHeader("Error", true, false);
                c.Print("\n Required files are inaccessible!\n\n Please contact the publisher for assistance.", ConsoleColor.Red);
                c.Pause();
                c.CloseEnvironment();
            }
        }

        public static void DELETE(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                else if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                }
            }
            catch { }
        }

        public static void EraseData()
        {
            DELETE(playersdat);
            DELETE(savefile);
            DELETE(scoresdat);
            DELETE(textfiletxt);
            DELETE(keymapdat);
            DELETE(ishandll);

            foreach (FileInfo f in new DirectoryInfo(root).GetFiles())
            {
                if (f.Extension.ToLower() == ".hcx" || f.Extension.ToLower() == ".log")
                {
                    DELETE(f.FullName);
                }
            }
        }

        public static void SaveData()
        {
            try
            {
                savefile = root + Program.name.ToUpper() + ".HCX";
            }
            catch { }

            DELETE(root + "SAVEFILE.HCX");

            CheckFolder();

            // Declarations
            XmlTextWriter w = new XmlTextWriter(savefilexml, Encoding.UTF8) { Formatting = Formatting.None };

            w.WriteStartElement("HCX"); // a-
            WriteVariable(w, "REV", Program.Revive);
            WriteVariable(w, "SPR", Program.SpiderRepelling);
            WriteVariable(w, "UND", Program.belowsealevel);
            WriteVariable(w, "ELF", Program.elf);
            WriteVariable(w, "TR1", Program.firsttreasureroom);
            WriteVariable(w, "PCD", Program.computerDropped);
            WriteVariable(w, "PCB", Program.computerBroken);
            WriteVariable(w, "INV", Program.IsInvisible);
            WriteVariable(w, "LIB", Program.libraryUNLOCKED);
            WriteVariable(w, "PYA", Program.pyAwake);
            WriteVariable(w, "PYM", Program.pyMoved);
            WriteVariable(w, "VMA", Program.vampireAwake);
            WriteVariable(w, "VMM", Program.vampireGone);
            WriteVariable(w, "RUB", Program.lampUsed);
            WriteVariable(w, "GDC", Program.caseOpen);
            WriteVariable(w, "SPB", Program.bookUNLOCKED);
            WriteVariable(w, "EYE", Program.hasEyebrows);
            WriteVariable(w, "WAT", Program.drankWater);
            WriteVariable(w, "PR1", Program.firstprisoncell);
            WriteVariable(w, "EBR", Program.ateBread);
            WriteVariable(w, "ECK", Program.ateCake);
            WriteVariable(w, "PHP", Program.PermanentHealth);
            WriteVariable(w, "LEM", Program.degrees);
            WriteVariable(w, "LCK", Program.lockspeed);
            WriteVariable(w, "PAN", Program.PannedForGoldTimes);
            WriteVariable(w, "WTM", Program.washedTomatoes);
            WriteVariable(w, "WHD", Program.washedHands);
            WriteVariable(w, "SPT", Program.spit);
            WriteVariable(w, "PLM", Program.readPalm);
            WriteVariable(w, "ALT", Program.alternate);
            WriteVariable(w, "RAT", Program.ratsGone);
            WriteVariable(w, "MAP", Program.mapRead);
            WriteVariable(w, "TEL", Program.useTel);
            WriteVariable(w, "OGA", Program.ogAsleep);
            WriteVariable(w, "MIN", Program.minutes);
            WriteVariable(w, "BNS", Program.beans);
            WriteVariable(w, "BNG", Program.beanGold);
            WriteVariable(w, "MZI", Program.mazeIdx);
            WriteVariable(w, "WOR", Program.word);
            WriteVariable(w, "INF", Program.didInfo);
            WriteVariable(w, "EXO", Program.echo);
            WriteVariable(w, "DED", Program.died);
            WriteVariable(w, "GSN", Program.gsn);

            WriteGroup(w, "INI", Array.ConvertAll<int, object>(Program.Inventory, x => x));
            WriteGroup(w, "INC", Array.ConvertAll<string, object>(Program.InventoryCaptions, x => x));
            WriteGroup(w, "STX", Array.ConvertAll<bool, object>(Program.State, x => x));
            WriteGroup(w, "GPX", Array.ConvertAll<bool, object>(Program.Ghosts, x => x));
            WriteGroup(w, "MAZ", Array.ConvertAll<char, object>(Program.mazes, x => x));
            WriteGroup(w, "MZ2", Array.ConvertAll<bool, object>(Program.breadcrumbs, x => x));
            WriteGroup(w, "CBX", Array.ConvertAll<int, object>(Program.comboAnswer, x => x));

            WriteVariable(w, "XXR", Program.ROOM.ToString());
            WriteVariable(w, "XXS", Program.score.ToString());
            WriteVariable(w, "XXN", Program.name.ToString());
            w.WriteEndElement(); // -a
            w.Close();

            string full = string.Empty;

            foreach (string line in File.ReadAllLines(savefilexml))
            {
                full += line;
            }

            File.WriteAllText(savefile, Encryption.EncryptString(full));
            DELETE(savefilexml);
        }

        public static void LoadData()
        {
            CheckFolder();

            int ph = 100;

            if (File.Exists(savefile))
            {
                // Declarations
                XmlDocument reader = new XmlDocument();

                try
                {
                    string full = string.Empty;

                    foreach (string line in File.ReadAllLines(savefile))
                    {
                        full += line;
                    }

                    File.WriteAllText(savefilexml, Encryption.DecryptString(full));

                    reader.Load(savefilexml);

                    Program.Revive = Convert.ToBoolean(ReadVariable(reader, "REV").ToString().ToLower());
                    Program.SpiderRepelling = Convert.ToBoolean(ReadVariable(reader, "SPR").ToString().ToLower());
                    Program.belowsealevel = Convert.ToBoolean(ReadVariable(reader, "UND").ToString().ToLower());
                    Program.elf = Convert.ToBoolean(ReadVariable(reader, "ELF").ToString().ToLower());
                    Program.firsttreasureroom = Convert.ToBoolean(ReadVariable(reader, "TR1").ToString().ToLower());
                    Program.computerDropped = Convert.ToBoolean(ReadVariable(reader, "PCD").ToString().ToLower());
                    Program.pyAwake = Convert.ToBoolean(ReadVariable(reader, "PYA").ToString().ToLower());
                    Program.pyMoved = Convert.ToBoolean(ReadVariable(reader, "PYM").ToString().ToLower());
                    Program.vampireAwake = Convert.ToBoolean(ReadVariable(reader, "VMA").ToString().ToLower());
                    Program.vampireGone = Convert.ToBoolean(ReadVariable(reader, "VMM").ToString().ToLower());
                    Program.lampUsed = Convert.ToBoolean(ReadVariable(reader, "RUB").ToString().ToLower());
                    Program.caseOpen = Convert.ToBoolean(ReadVariable(reader, "GDC").ToString().ToLower());
                    Program.computerBroken = Convert.ToBoolean(ReadVariable(reader, "PCB").ToString().ToLower());
                    Program.IsInvisible = Convert.ToBoolean(ReadVariable(reader, "INV").ToString().ToLower());
                    Program.libraryUNLOCKED = Convert.ToBoolean(ReadVariable(reader, "LIB").ToString().ToLower());
                    Program.bookUNLOCKED = Convert.ToBoolean(ReadVariable(reader, "SPB").ToString().ToLower());
                    Program.hasEyebrows = Convert.ToBoolean(ReadVariable(reader, "EYE").ToString().ToLower());
                    Program.ateBread = Convert.ToBoolean(ReadVariable(reader, "EBR").ToString().ToLower());
                    Program.ratsGone = Convert.ToBoolean(ReadVariable(reader, "RAT").ToString().ToLower());
                    Program.mapRead = Convert.ToBoolean(ReadVariable(reader, "MAP").ToString().ToLower());
                    Program.ogAsleep = Convert.ToBoolean(ReadVariable(reader, "OGA").ToString().ToLower());
                    Program.useTel = Convert.ToBoolean(ReadVariable(reader, "TEL").ToString().ToLower());
                    Program.minutes = Convert.ToInt32(ReadVariable(reader, "MIN").ToString().ToLower());
                    Program.beans = Convert.ToBoolean(ReadVariable(reader, "BNS").ToString().ToLower());
                    Program.beanGold = Convert.ToBoolean(ReadVariable(reader, "BNG").ToString().ToLower());
                    Program.drankWater = Convert.ToBoolean(ReadVariable(reader, "WAT").ToString().ToLower());
                    Program.firstprisoncell = Convert.ToBoolean(ReadVariable(reader, "PR1").ToString().ToLower());

                    ph = Convert.ToInt32(ReadVariable(reader, "PHP").ToString().ToLower());

                    Program.degrees = Convert.ToInt32(ReadVariable(reader, "LEM").ToString().ToLower());

                    Program.name = ReadVariable(reader, "XXN").ToString();
                    Program.washedTomatoes = Convert.ToBoolean(ReadVariable(reader, "WTM").ToString().ToLower());
                    Program.washedHands = Convert.ToBoolean(ReadVariable(reader, "WHD").ToString().ToLower());
                    Program.spit = Convert.ToBoolean(ReadVariable(reader, "SPT").ToString().ToLower());
                    Program.readPalm = Convert.ToBoolean(ReadVariable(reader, "PLM").ToString().ToLower());
                    Program.alternate = Convert.ToBoolean(ReadVariable(reader, "ALT").ToString().ToLower());

                    try
                    {
                        Program.mazeIdx = Convert.ToInt32(ReadVariable(reader, "MZI").ToString().ToLower());
                        Program.ateCake = Convert.ToBoolean(ReadVariable(reader, "ECK").ToString().ToLower());
                        Program.didInfo = Convert.ToBoolean(ReadVariable(reader, "INF").ToString().ToLower());
                        Program.echo = Convert.ToBoolean(ReadVariable(reader, "EXO").ToString().ToLower());
                        Program.died = Convert.ToBoolean(ReadVariable(reader, "DED").ToString().ToLower());
                        Program.gsn = Convert.ToBoolean(ReadVariable(reader, "GSN").ToString().ToLower());
                    }
                    catch
                    {
                        Program.mazeIdx = 1;
                        Program.ateCake = false;
                        Program.didInfo = false;
                        Program.echo = false;
                        Program.died = false;
                        Program.gsn = false;
                    }

                    try
                    {
                        Program.word = ReadVariable(reader, "WOR").ToString();
                    }
                    catch
                    {
                        Methods.GenWord();
                    }

                    if (string.IsNullOrWhiteSpace(Program.word))
                    {
                        Methods.GenWord();
                    }

                    if (!Parser.verbs.Contains(Program.word))
                    {
                        Parser.verbs.Add(Program.word);
                    }

                    Program.lockspeed = Convert.ToInt32(ReadVariable(reader, "LCK").ToString().ToLower());
                    Program.PannedForGoldTimes = Convert.ToInt32(ReadVariable(reader, "PAN").ToString().ToLower());
                    Program.score = Convert.ToInt32(ReadVariable(reader, "XXS").ToString().ToLower());

                    Program.Inventory = Array.ConvertAll(ReadGroup(reader, "INI"), x => Convert.ToInt32(x));
                    Program.InventoryCaptions = Array.ConvertAll(ReadGroup(reader, "INC"), x => x.ToString());
                    Program.mazes = Array.ConvertAll(ReadGroup(reader, "MAZ"), x => char.Parse(x.ToString()));
                    Program.State = Array.ConvertAll(ReadGroup(reader, "STX"), x => Convert.ToBoolean(x));
                    Program.Ghosts = Array.ConvertAll(ReadGroup(reader, "GPX"), x => Convert.ToBoolean(x));
                    Program.breadcrumbs = Array.ConvertAll(ReadGroup(reader, "MZ2"), x => Convert.ToBoolean(x));
                    Program.comboAnswer = Array.ConvertAll(ReadGroup(reader, "CBX"), x => Convert.ToInt32(x));

                    if (Program.mazes.Length != 17 || Program.breadcrumbs.Length != 17 || Program.mazes.Contains('*') || Program.mazes == null || Program.breadcrumbs == null)
                    {
                        Methods.GenMazes();
                    }

                    if (Program.comboAnswer.Length != 3)
                    {
                        try
                        {
                            Program.comboAnswer = new int[]
                            {
                                Convert.ToInt32(ReadVariable(reader, "CB0").ToString().ToLower()),
                                Convert.ToInt32(ReadVariable(reader, "CB1").ToString().ToLower()),
                                Convert.ToInt32(ReadVariable(reader, "CB2").ToString().ToLower())
                            };
                        }
                        catch
                        {
                            Program.comboAnswer = new int[] { 10, 31, 16 };
                        }
                    }

                    if (Program.State.Length != 4 && Program.Ghosts.Length != 4)
                    {
                        try
                        {
                            Program.Ghosts = new bool[]
                            {
                                Convert.ToBoolean(ReadVariable(reader, "GP0").ToString().ToLower()),
                                Convert.ToBoolean(ReadVariable(reader, "GP1").ToString().ToLower()),
                                Convert.ToBoolean(ReadVariable(reader, "GP2").ToString().ToLower()),
                                Convert.ToBoolean(ReadVariable(reader, "GP3").ToString().ToLower())
                            };

                            Program.State = new bool[]
                            {
                                Convert.ToBoolean(ReadVariable(reader, "ST0").ToString().ToLower()),
                                Convert.ToBoolean(ReadVariable(reader, "ST1").ToString().ToLower()),
                                Convert.ToBoolean(ReadVariable(reader, "ST2").ToString().ToLower()),
                                Convert.ToBoolean(ReadVariable(reader, "ST3").ToString().ToLower())
                            };
                        }
                        catch
                        {
                            Program.Ghosts = new bool[] { false, false, false, false };
                            Program.State = new bool[] { true, true, false, false };
                        }
                    }

                    if (Program.InventoryCaptions.Length == 16 || Program.Inventory.Length == 16)
                    {
                        List<string> inc = new List<string>();
                        List<int> ini = new List<int>();

                        inc.AddRange(Program.InventoryCaptions);
                        inc.Add(InventoryItems.Newspaper);

                        ini.AddRange(Program.Inventory);
                        ini.Add(0);

                        Program.InventoryCaptions = inc.ToArray();
                        Program.Inventory = ini.ToArray();
                    }

                    Storyline.sky2 = Program.mapRead
                        ? "You look at the dark sky above you.\n Staring up at the heavens, you become aware of your terrible vision.\n You will not be able to use your naked eye to study the stars."
                        : Storyline.sky;

                    Storyline.sky3 = Program.beans ? Storyline.sky + "\n A tall beanstalk leads up." : Storyline.sky;

                    Storyline.sky4 = Program.Inventory[5] == 0 && Program.Inventory[15] == 0 && Program.degrees == 180
                        ? Storyline.sky + "\n A rainbow glistens above the clouds,\n its wide arc ending somewhere in the rainforest."
                        : Storyline.sky;
                }
                catch
                {
                    c.Clear();
                    c.StyleHeader("Error", true, false);
                    c.Print("\n The save file is incompatible with the current version.\n\n Please see the game manual for details on troubleshooting errors.", ConsoleColor.Red);
                    _ = Console.ReadKey(false);
                    c.CloseEnvironment();
                }

                Console.Title = string.Format("Escape from the Haunted Castle [Version {0}]", Convert.ToString(Assembly.GetEntryAssembly().GetName().Version.Major) + "." + Convert.ToString(Assembly.GetEntryAssembly().GetName().Version.Minor));

                Program.ROOM = ReadVariable(reader, "XXR").ToString();

                try
                {
                    savefile = root + Program.name.ToUpper() + ".HCX";
                }
                catch { }

                try
                {
                    if (File.Exists(FileSystem.playersdat))
                    {
                        foreach (string line in File.ReadAllLines(FileSystem.playersdat))
                        {
                            if (line != "" && File.Exists(FileSystem.root + line.ToUpper() + ".hcx") && !Program.GhostPlayers.Keys.Contains(line))
                            {
                                XmlDocument rdr = new XmlDocument();

                                string f = string.Empty;

                                foreach (string ln in File.ReadAllLines(FileSystem.root + line.ToUpper() + ".hcx"))
                                {
                                    f += ln;
                                }

                                File.WriteAllText(FileSystem.root + line.ToUpper() + ".xml", Encryption.DecryptString(f));

                                rdr.Load(FileSystem.root + line.ToUpper() + ".xml");

                                string n = ReadVariable(rdr, "XXN").ToString();
                                string r = ReadVariable(rdr, "XXR").ToString();

                                if (!string.IsNullOrWhiteSpace(n) && !string.IsNullOrWhiteSpace(r))
                                {
                                    Program.GhostPlayers.Add(n, r);
                                }

                                DELETE(FileSystem.root + line.ToUpper() + ".xml");
                            }
                        }
                    }
                }
                catch { }

                Program.setup = true;
            }
            else
            {
                SaveData();
            }

            Methods.SetPermanentHealth(ph);
            DELETE(savefilexml);
        }

        public static void TRAVELTO()
        {
            c.ForegroundColor = Storyline.inputColor;

            c.Clear();

            if (Program.ROOM.StartsWith("#"))
            {
                Storyline.Rev();
            }
            else
            {
                switch (Program.ROOM.ToLower())
                {
                    case "gen":
                        Storyline.Gen();
                        break;
                    case "parti":
                        Storyline.PartI();
                        break;
                    case "partii":
                        Storyline.PartII();
                        break;
                    case "partiii":
                        Storyline.PartIII();
                        break;
                    case "partiv":
                        Storyline.PartIV();
                        break;
                    case "partv":
                        Storyline.PartV(false);
                        break;
                    case "partvi":
                        Storyline.PartVI(Program.firstprisoncell);
                        break;
                    case "partvii":
                        Storyline.PartVII(Program.firsttreasureroom);
                        break;
                    case "partviii":
                        Storyline.PartVIII();
                        break;
                    case "partix":
                        Storyline.PartIX();
                        break;
                    case "partxi":
                        Storyline.PartXI();
                        break;
                    case "partxii":
                        Storyline.PartXII(false);
                        break;
                    case "partxiii":
                        Storyline.PartXIII();
                        break;
                    case "partxv":
                        Storyline.PartXV();
                        break;
                    case "partxvi":
                        Storyline.PartXVI();
                        break;
                    case "partxvii":
                        Storyline.PartXVII();
                        break;
                    case "partxviii":
                        Storyline.PartXVIII();
                        break;
                    case "partxix":
                        Storyline.PartXIX();
                        break;
                    case "partxx":
                        Storyline.PartXX();
                        break;
                    case "partxxi":
                        Storyline.PartXXI();
                        break;
                    case "partxxii":
                        Storyline.PartXXII();
                        break;
                    case "partxxiii":
                        Storyline.PartXXIII();
                        break;
                    case "partxxiv":
                        Storyline.PartXXIV();
                        break;
                    case "partxxv":
                        break;
                    case "partxxvi":
                        Storyline.PartXXVI();
                        break;
                    case "partxxvii":
                        Storyline.PartXXVII();
                        break;
                    case "partxxviii":
                        Storyline.PartXXVIII();
                        break;
                    case "partxxxi":
                        Storyline.PartXXXI();
                        break;
                    case "partxxxii":
                        Storyline.PartXXXII();
                        break;
                    case "partxxxiii":
                        Storyline.PartXXXIII();
                        break;
                    case "partxxxiv":
                        Storyline.PartXXXIV();
                        break;
                    case "partxxxv":
                        Storyline.PartXXXV();
                        break;
                    case "sop2":
                        Storyline.SOP2();
                        break;
                    case "sop3":
                        Storyline.SOP3();
                        break;
                    case "partx":
                        Storyline.PartX();
                        break;
                    case "r1":
                        Storyline.R1();
                        break;
                    case "r2":
                        Storyline.R2();
                        break;
                    case "r3":
                        Storyline.R3();
                        break;
                    case "r6":
                        Storyline.R6();
                        break;
                    case "r7":
                        Storyline.R7();
                        break;
                    case "r8":
                        Storyline.R8();
                        break;
                    case "r24":
                        Storyline.R24();
                        break;
                    case "r2a":
                        Storyline.R2A();
                        break;
                    case "r7a":
                        Storyline.R7A();
                        break;
                    case "a1":
                        Storyline.A1();
                        break;
                    case "a2":
                        Storyline.A2();
                        break;
                    case "b1":
                        Storyline.B1();
                        break;
                    case "b2":
                        Storyline.B2();
                        break;
                    case "b3":
                        Storyline.B3();
                        break;
                    case "b4":
                        Storyline.B4();
                        break;
                    case "c1":
                        Storyline.C1();
                        break;
                    case "c2":
                        Storyline.C2();
                        break;
                    case "c3":
                        Storyline.C3();
                        break;
                    case "c4":
                        Storyline.C4();
                        break;
                    case "c5":
                        Storyline.C5();
                        break;
                    case "ma":
                        Storyline.MA();
                        break;
                    case "mb":
                        Storyline.MB();
                        break;
                    case "mc":
                        Storyline.MC();
                        break;
                    case "d1":
                        Storyline.D1();
                        break;
                    case "d2":
                        Storyline.D2();
                        break;
                    case "d3":
                        Storyline.D3();
                        break;
                    case "d4":
                        Storyline.D4();
                        break;
                    case "pc":
                        Storyline.PC();
                        break;
                    case "d7":
                        Storyline.D7();
                        break;
                    case "d6":
                        Storyline.D6();
                        break;
                    case "dx":
                        Storyline.D10();
                        break;
                    case "d8":
                        Storyline.D8();
                        break;
                    case "d9":
                        Storyline.D9();
                        break;
                    case "e1":
                        Storyline.E1();
                        break;
                    case "e2":
                        Storyline.E2();
                        break;
                    case "e3":
                        Storyline.E3();
                        break;
                    case "e4":
                        Storyline.E4();
                        break;
                    case "e5":
                        Storyline.E5();
                        break;
                    case "e6":
                        Storyline.E6();
                        break;
                    case "j1":
                        Storyline.J1();
                        break;
                    case "j2":
                        Storyline.J2();
                        break;
                    case "j3":
                        Storyline.J3();
                        break;
                    case "q1":
                        Storyline.Q1();
                        break;
                    case "q2":
                        Storyline.Q2();
                        break;
                    case "t1":
                        Storyline.T1();
                        break;
                    case "t2":
                        Storyline.T2();
                        break;
                    case "t3":
                        Storyline.T3();
                        break;
                    case "t4":
                        Storyline.T4();
                        break;
                    case "u1":
                        Storyline.U1();
                        break;
                    case "u2":
                        Storyline.U2();
                        break;
                    case "fin":
                        Storyline.FIN();
                        break;
                    case "y1":
                        Storyline.Y1();
                        break;
                    case "y2":
                        Storyline.Y2();
                        break;
                    case "y3":
                        Storyline.Y3();
                        break;
                    case "z":
                        Storyline.Z();
                        break;
                    case "zt":
                        Storyline.ZT();
                        break;
                }
            }
        }

        private static void WriteVariable(XmlTextWriter writer, string name, object value)
        {
            if (value == null)
            {
                value = string.Empty;
            }

            writer.WriteStartElement("A"); // c- // var
            writer.WriteStartElement("B"); // d- // nam
            writer.WriteString(name);
            writer.WriteEndElement(); // -d
            writer.WriteStartElement("C"); // d- // val
            writer.WriteString(value.ToString());
            writer.WriteEndElement(); // -d
            writer.WriteEndElement(); // -c
        }

        private static void WriteGroup(XmlTextWriter writer, string name, object[] values)
        {
            writer.WriteStartElement("D"); // grp
            writer.WriteStartElement("B"); // nam
            writer.WriteString(name);
            writer.WriteEndElement();

            for (int i = 0; i < values.Length; i++)
            {
                writer.WriteStartElement("C"); // val
                writer.WriteString(values[i].ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        private static object ReadVariable(XmlDocument reader, string name)
        {
            try
            {
                return reader.SelectSingleNode("HCX/A/C[../B='" + name + "']").InnerText;
            }
            catch
            {
                return string.Empty;
            }
        }

        private static object[] ReadGroup(XmlDocument reader, string name)
        {
            List<object> temp = new List<object>();

            try
            {
                foreach (XmlNode x in reader.SelectNodes("HCX/D/C[../B='" + name + "']"))
                {
                    temp.Add(x.InnerText);
                }

                return temp.ToArray();
            }
            catch
            {
                return new object[] { };
            }
        }
    }
}
