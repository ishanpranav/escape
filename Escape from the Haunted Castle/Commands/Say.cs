// Say.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace HauntedCastle.Commands
{
    public class Say
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, bool Library, bool WizardsQuarters, bool ViperRoom, List<string> full)
        {
            // Declarations
            List<string> origFull = full;
            string opt2 = string.Empty;

            opt1 = opt1.ToLower().Replace("^", string.Empty);

            try
            {
                foreach (string opt in origFull)
                {
                    opt2 += opt.Replace("\"", string.Empty).Replace("^", string.Empty) + " ";
                }

                opt2 = opt2.Remove(0, opt1.Length).Trim();
            }
            catch
            {
                opt2 = string.Empty;
            }

            if (opt1 == "talk" || opt1 == "ask" || opt1 == "hello")
            {
                opt1 = "\"";
                opt2 = "hello " + opt2;
            }

            if ((opt1 == "say" || opt1 == "whisper" || opt1 == "chant" || opt1 == "\"") && opt2 == string.Empty)
            {
                c.Print("\n You do not know what to say.^");
                return;
            }

            if (opt1 == "say" || opt1 == "yell" || opt1 == "shout" || opt1 == "whisper" || opt1 == "chant" || opt1 == "\"")
            {
                if ((opt1 == "yell" || opt1 == "shout") && opt2 == string.Empty)
                {
                    if (Library)
                    {
                        c.Print("\n It is very rude to shout in a library.^");
                    }
                    else
                    {
                        c.Print("\n Nobody answers.^");
                    }

                    if (!Program.pyAwake && ViperRoom)
                    {
                        c.Print("\n You cause the snake to awaken.^");
                        Storyline.WakeUpSnake();
                        c.Print("^");
                    }
                    else if (Program.ROOM == "D1")
                    {
                        c.Print("\n You shout at the top of your lungs,\n alerting the ship's captain of your presence.\n\n The ship gradually approaches and finally reaches you.^");
                        c.Print("\n You quickly jump out of the crate and it floats away.");
                        c.Pause();
                        Storyline.D1();
                    }
                    else if (opt2 != string.Empty)
                    {
                        c.Print(string.Format("\n You shout \"{0}\" to nobody in particular.^", opt2));
                    }
                }
                else if (opt2 == "nothing")
                {
                    if (Library)
                    {
                        c.Print("\n You are silent, as you should be in a library.^");
                    }
                    else if (ViperRoom)
                    {
                        c.Print("\n You are slient, hoping not to awaken the sleeping snake.");
                    }
                    else
                    {
                        c.Print("\n You are silent.^");
                    }
                }

                if (WizardsQuarters)
                {
                    if (opt2.ToLower().Contains("fairest") || opt2.ToLower().Contains("pretty") || opt2.ToLower().Contains("beautiful") || opt2.ToLower().Contains("prettiest") || opt2.ToLower().Contains("mirror"))
                    {
                        c.Print("\n \"So says this mirror on the wall,\n  Snow White is the fairest of them all...\n\n  I mean, other than me, of course.\"^");
                    }
                    else
                    {
                        c.Print("\n \"Hello!\n\n  Have you heard of these new inventions?\n  They're called crates.\n\n  They say that the crate is the greatest invention\n  of our time.\"^");
                    }
                }
                else if (Program.ROOM == "B3" && Program.vampireAwake && !Program.vampireGone)
                {
                    c.Print(string.Format("\n You say \"{0}\" to the vampire.\n It does not reply but gives you a hostile stare.^", opt2));
                }
                else if (Program.ROOM == "D8")
                {
                    if (Program.ogAsleep)
                    {
                        c.Print("\n You do not want to wake up the cyclops.^");
                    }
                    else if (opt2.ToLower().Contains("ulysseys") || opt2.ToLower().Contains("odysseus") || opt2.ToLower().Contains("odyssey"))
                    {
                        c.Print("\n \"So you are a friend of Odysseus?\n\n  Speak not a word of that villain!\n  For countless years I have searched for him!\n\n  It was he who blinded me - the scoundrel Odysseus.\n  First I got eye surgery, and now I have to wear a monocle!\n  Do you have any idea how painful eye surgery is?\n\n  Walk the plank at once, you who befriends my enemy!\"");
                        c.Pause();
                        Methods.Checkpoint("Plank", "H.S.S. Liberty: Main Deck");
                        c.Print("\n You are standing on a plank extending from the long main deck of the ship.^");
                        c.Print("\n The cylcops forces you to walk the plank,\n and you fall into the ocean.\n\n You drown.");
                        c.Pause();
                        Methods.GameOver(false);
                    }
                    else
                    {
                        c.Print("\n \"Stop chattering and get to work, matey!\n  Help me get these rats away from here so I can sleep!\n\n  Where are they?\n  Where?\n  Hey, get back here, nasty rats!\n\n  Oh, I wouldn't be in this situation if that wicked man\n  hadn't blinded me!\n  I had to get eye surgery 'cause of him!\"^");
                    }
                }
                else if (Program.ROOM == "E1")
                {
                    Storyline.TalkToTroll();
                }
                else if (ViperRoom)
                {
                    if (Program.pyAwake)
                    {
                        if (opt2.ToLower().Contains("hello") || opt2.ToLower().Contains("snake"))
                        {
                            c.Print("\n \"Hello! Nice to meet you.\n  Have you seen my lunch by any chance?\n  Oh yesss, I forgot that you are the main course.\n\n  Perhaps I was a bit rude earlier.\n  Did I offend you? No? Excellent.\n\n  Oh, by the way, have you ssseen my lunch?\"^");
                        }
                        else
                        {
                            c.Print("\n \"What is thisss noise?\n\n  Aha... The human can ssspeak!\n  I wonder why it hasn't sssaid hello.\"^");
                        }
                    }
                    else
                    {
                        c.Print("\n You cause the snake to awaken.^");
                        Storyline.WakeUpSnake();
                        c.Print("^");
                    }
                }
                else if (Program.ROOM == "R3")
                {
                    c.Print("\n \"Hello! I am the Living Room.\n\n  Nice to meet you.\n\n  Have you ever heard of a crate?\n  I was told that the crate is humanity's greatest invention.\"^");
                }
                else if (Program.ROOM == "PartIV")
                {
                    Storyline.TalkToSphinx();
                }
                else if (Program.ROOM == "Q2")
                {
                    Storyline.TalkToLeprechaun();
                }
                else if (Program.ROOM == "U1")
                {
                    c.Print("\n The werewolf growls back at you.^");
                }
                else if (opt2.Contains("player"))
                {
                    if ((Program.GhostPlayers.Count - 1) > 0)
                    {
                        foreach (string player in Program.GhostPlayers.Keys)
                        {
                            if (Program.GhostPlayers[player].ToLower() == Program.ROOM.ToLower() && player.ToLower() != Program.name.ToLower() && opt2.Contains(player.ToLower()))
                            {
                                c.Print("\n Player " + player.ToUpper() + " awakens and menacingly approaches you with a magic staff,\n not unlike your own.");
                                c.Pause();

                                if (BattleSimulator.StartBattle(-1, new string[] { "punches you with their hands.", "kicks you.", "zaps you with their magic staff.", "attacks you with their bad breath.", "burns you with their candle.", "uses their shield while attacking you." }, "Player " + player.ToUpper(), player.ToUpper()))
                                {
                                    _ = Program.GhostPlayers.Remove(player);
                                }

                                FileSystem.SaveData();
                                FileSystem.TRAVELTO();
                                break;
                            }
                        }
                    }
                }
                else if (Library && opt2 != "nothing")
                {
                    c.Print("\n It is rude to speak in a library.^");
                }
                else if (opt2.Contains("hello"))
                {
                    c.Print("\n Nobody answers.^");
                }
                else if (opt2 != "nothing" && opt2 != string.Empty)
                {
                    c.Print(string.Format("\n You say \"{0}\" to nobody in particular.^", opt2));
                }
            }
        }

        public static bool CheckSpells(string Message, string SpecificRoom)
        {
            if (Message.ToLower().Contains("alakazam") && SpecificRoom != "LIB")
            {
                SayMethods.SpellOfInvisibility();
            }
            else if (Message.ToLower().Contains("alakazam"))
            {
                c.Print("\n It is rude to speak in a library.^");
            }
            else if (Message.ToLower().Contains(Program.word) && Program.Inventory[8] == 0 && Program.degrees == 180 && Program.ROOM != "U1")
            {
                c.Print("\n You have not reached home yet.^");
            }
            else if ((Message.ToLower().Contains(Program.word) || Message.ToLower().Contains("please")) && Program.Inventory[8] == 0 && Program.degrees == 180 && Program.ROOM == "U1")
            {
                SayMethods.FinalSpell();
            }
            else if (Message.ToLower().Contains("gesundheit") || (Message.ToLower().Contains("bless") && Program.ROOM != "FIN"))
            {
                c.Print("\n Nothing happens.^");
            }
            else if (Message.ToLower().Contains("gesundheit") || (Message.ToLower().Contains("bless") && Program.ROOM == "FIN"))
            {
                SayMethods.Gesundheit();
            }
            else if (Message.ToLower().Contains("hocus") || Message.ToLower().Contains("pocus"))
            {
                c.Print("\n Nothing happens.^");
            }
            else if (Message.ToLower().Contains("presto"))
            {
                SayMethods.SpellOfSpiderRepelling();
            }
            else if (Message.ToLower().Contains("abracadabra"))
            {
                c.Print("\n You invoke the spell of reviving!^");

                SayMethods.SpellOfReviving();
            }
            else if (Message.ToLower().Contains("open") && Message.ToLower().Contains("sesame"))
            {
                SayMethods.OpenGlassCase();
            }
            else if (Message.ToLower().Contains("ishan"))
            {
                SayMethods.Ishan();
            }
            else if (Message.ToLower().Contains("xyzzy"))
            {
                if (Program.alternate)
                {
                    c.Print("\n Nothing happens.^");
                }
                else
                {
                    Methods.Checkpoint("Astroid Belt", "Alternate Universe");
                    c.Print("\n You are floating through an astroid belt in a strange alternate universe.\n Rocks and debris are coming towards you from all directions...");
                    c.Pause();
                    c.Print("\n Actually, none of that was true.\n\n Nothing happens.");
                    c.Pause();

                    Program.alternate = true;

                    FileSystem.TRAVELTO();
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
