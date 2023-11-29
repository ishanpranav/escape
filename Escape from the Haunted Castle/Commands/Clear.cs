// Clear.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using HauntedCastle.Commands.Variables_and_References;

namespace HauntedCastle.Commands
{
    public class Clear
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');

            if ((opt1 == "clear" || opt1 == "cls" || opt1 == "c") && (opt2 == string.Empty || opt2 == "screen" || opt2 == "lines"))
            {
                FileSystem.SaveData();
                FileSystem.TRAVELTO();
            }
            else if (opt1 == "echo")
            {
                if (!Program.echo)
                {
                    Score.Addition(Score.Z_Echo);
                    Program.echo = true;
                }

                c.Print("\n Echo!^");
            }
            else if (opt1 == "submit")
            {
                c.Print("^");

                // Declarations
                string YN = string.Empty;
                string msg = "Are you sure you want to submit your current score?";

                while (!Methods.YesNoCondition(YN))
                {
                    c.StyleAlt(msg);

                    YN = c.ReadLine().ToLower();

                    c.Print("\n");

                    if (Methods.YesCondition(YN))
                    {
                        Methods.RecordScore();
                        c.Print("\n Recorded.^");
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
            else if (opt1 == "sit")
            {
                c.Print("\n Now is not a time for sitting!^");
            }
            else if (opt1 == "hiscores" || opt1 == "hi-scores" || opt1 == "score" || opt1 == "scores" || opt1 == "hiscore" || opt1 == "hi-score")
            {
                _ = Options.HiScores(true, true);
                FileSystem.TRAVELTO();
            }
            else if (opt1 == "custom_key_help")
            {
                c.Print("\n CUSTOM KEY HELP\n\n  To assign the custom key (NumPad7, the digit 7 on a numeric keypad)\n  to an in-game command, locate and open the file below in a\n  text editor or word processor program:\n\n  " + FileSystem.keymapdat + "\n\n  After \"NumPad7=\" type the command to be associated with the key.\n\n  After \"CommandRequiresObject=\" type \"True\" if the command requires\n  an object or \"False\" if the command does not.\n\n  Save the file and test if the operation succeeded\n  by opening the program and pressing the 7 key on the numeric keypad.^", ConsoleColor.Gray);
            }
            else if (opt1 == "win" && (Program.name.ToLower().Contains("admin") || Program.name.ToLower().Contains("ishan")))
            {
                Methods.GameOver(true, false);
            }
            else if (opt1 == "" && opt2 == "")
            {
                switch (Program.rnd.Next(0, 4))
                {
                    case 0:
                    case 1:
                        c.Print("\n What?^");
                        break;
                    case 2:
                        c.Print("\n Sorry?^");
                        break;
                    case 3:
                        c.Print("\n Pardon?^");
                        break;
                }
            }
            else if (opt1 == "who" && opt2 == "am")
            {
                _ = Diagnose.Run("stats", "");
            }
            else if (opt1 == "what" || opt1 == "who" || opt1 == "when" || opt1 == "how" || opt1 == "where" || (opt1 == "why" && opt2 != ""))
            {
                c.Print("\n Figure it out.^");
            }
            else if (opt1 == "learn" || opt1 == "think")
            {
                c.Print("\n An interesting idea...^");
            }
            else if (opt1 == "sing" || opt1 == "hum")
            {
                c.Print("\n You are not very good at that.^");
            }
            else if (opt1 == "undo" || opt1 == "oops")
            {
                c.Print("\n Actions cannot be undone.^", ConsoleColor.Gray);
            }
            else if (opt1 == "give" || opt1 == "offer" || opt1 == "show")
            {
                c.Print("\n To give an item, try to drop it in front of the intended recipient.^");
            }
            else if (Program.ROOM == "D6" && opt1 == "fix" && opt2 == "telescope")
            {
                Use_Methods.monocle();
            }
            else if (opt1 == "wait" || opt1 == "z" || opt1 == "continue")
            {
                c.Print("\n Nothing happens.^");
            }
            else if (opt1 == "listen" || opt2 == "hear")
            {
                Use_Methods.ears();
            }
            else if (opt1 == "smell" || opt2 == "sniff")
            {
                Use_Methods.nose();
            }
            else if ((opt1 == "turn" || opt1 == "spin") && (opt2 == "wheel" || opt2 == "steering"))
            {
                Use_Methods.wheel();
            }
            else if (opt1 == "sleep" || opt1 == "rest")
            {
                if (Program.ROOM.StartsWith("#"))
                {
                    c.Print("\n It would be unwise to sleep here\n while trapped in an unfamiliar place.^");
                }
                else if (Program.ROOM == "R3" || Program.ROOM == "PartIII")
                {
                    c.Print("\n Sleeping on an armchair might cause neck issues.^");
                }
                else if (Program.ROOM != "PartVI" && Program.ROOM != "PartXIX" && Program.ROOM != "A1" && Program.ROOM != "D8" && Program.ROOM != "D9")
                {
                    c.Print("\n There is no bed here to sleep on.^");
                }
                else
                {
                    c.Print("\n You are not tired.^");
                }
            }
            else if ((opt1 == "touch" || opt1 == "feel" || opt1 == "rub") && (opt2 == "oil" || opt2 == "lamp"))
            {
                Use_Methods.lamp();
            }
            else if (opt1 == "die" || ((opt1 == "break" || opt1 == "destroy") && (opt2 == "myself" || opt2 == "self" || opt2 == "me")))
            {
                c.Print("\n You die of death.");
                c.Pause();
                Methods.GameOver(false);
            }
            else if (Program.InventoryCaptions[15] != InventoryItems.MonocleLens && opt1 == "wear" && opt2 == "monocle")
            {
                c.Print("\n You wear the monocle.\n\n The cyclops's perscription is far worse than yours.\n Your head begins to ache, so you take it off.^");
            }
            else if (opt1 == "answer" || (opt1 == "why" && opt2 == "") || opt1 == "life")
            {
                c.Print("\n Forty-two.^");
            }
            else if ((opt1 == "cook") && Program.ROOM == "PartXV")
            {
                Use_Methods.stoveToCook();
            }
            else if (opt1 == "cook")
            {
                c.Print("\n There is nothing here to properly cook with.^");
            }
            else if (opt1 == "wash" && (opt2 == "hands" || opt2 == "hand" || opt2 == "face" || opt2 == "palm" || opt2 == "palms") && (Program.ROOM == "PartXV" || Program.ROOM == "A2"))
            {
                Use_Methods.sinkToWashhands();
            }
            else if ((opt1 == "wash" || opt1 == "rinse" || opt1 == "clean") && (opt2 == "tomatoes" || opt2 == "tomato") && Program.ROOM == "PartXV")
            {
                Use_Methods.sinkToWashtomatoes();
            }
            else if ((opt1 == "wash" || opt1 == "rinse" || opt1 == "clean") && (Program.ROOM == "PartXV" || Program.ROOM == "A2"))
            {
                Use_Methods.sinkToWash();
            }
            else if (opt1 == "wash" || opt1 == "rinse" || opt1 == "clean")
            {
                c.Print("\n There is nothing here to properly wash with.^");
            }
            else if (opt1 == "spit" || opt1 == "salivate" || opt1 == "swallow" || opt1 == "drool")
            {
                Drink_Methods.spit();
            }
            else if (opt1 == "play" && opt2 == string.Empty)
            {
                c.Print("\n You do not know what to " + opt1 + ".^");
            }
            else if (opt1 == "shuffle" && (Program.ROOM == "PartXXXII" || Program.ROOM == "PartIII"))
            {
                c.Print("\n You shuffle the cards.^");
            }
            else if (opt1 == "shuffle" && opt2 == string.Empty)
            {
                c.Print("\n You do the shuffle.^");
            }
            else if (opt1 == "play" && (opt2 == "cards" || opt2 == "card") && (Program.ROOM == "PartXXXII" || Program.ROOM == "PartIII"))
            {
                Use_Methods.cards();
            }
            else if (opt1 == "whistle" && Program.Inventory[8] == 1)
            {
                Use_Methods.flute();
            }
            else if (opt1 == "whistle")
            {
                c.Print("\n Tweee!^");
            }
            else if (opt1 == "blow")
            {
                c.Print("\n You do not know what to " + opt1 + ".^");
            }
            else if ((opt1 == "play" || opt1 == "blow") && (opt2 == "flute" || opt2 == "tune"))
            {
                Use_Methods.flute();
            }
            else if ((opt1 == "break" || opt1 == "destroy") && opt2 == string.Empty)
            {
                c.Print("\n You do not know what to " + opt1 + ".^");
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && (opt2 == "rat" || opt2 == "rats") && ((Program.ROOM != "D1" && (Program.ROOM == "D8" || (Program.ROOM.StartsWith("D") && !Program.ogAsleep && Program.ratsGone))) || (Program.ROOM == "DX" && Program.ogAsleep)))
            {
                c.Print("\n You would rather not go near the rats.^");
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && (opt2 == "snake") && Program.ROOM == "R8")
            {
                if (Program.pyAwake)
                {
                    Storyline.SnakeBite();
                }
                else
                {
                    c.Print("\n You cause the snake to awaken.^");
                    Storyline.WakeUpSnake();
                }

                c.Print("^");
            }
            else if (opt1 == "tickle" && (opt2 == "me" || opt2 == "myself" || opt2 == "self"))
            {
                c.Print("\n Tickle.^");
            }
            else if (opt1 == "tickle" && opt2 == "dragon" && Program.ROOM == "U2" && Program.Inventory[13] == 1)
            {
                Use_Methods.featherToTickle();
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && (opt2 == "were" || opt2 == "werewolf" || opt2 == "wolf") && Program.ROOM == "U1")
            {
                c.Print("\n You attack the werewolf.\n\n It strikes quickly, too fast for you to react.");
                c.Pause();
                Methods.GameOver(false);
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && opt2 == "dragon" && Program.ROOM == "U2")
            {
                c.Print("\n You attack the dragon.");
                c.Pause();
                Storyline.DestroyDragon();
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && opt2 == "bird" && Program.ROOM == "PartXXXV")
            {
                c.Print("\n It is too high for you to reach.^");
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && opt2 == "cyclops" && Program.ROOM == "D8")
            {
                c.Print("\n You attack the cyclops.\n\n It strikes quickly, too fast for you to react.");
                c.Pause();
                Methods.GameOver(false);
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && opt2 == "troll" && Program.ROOM == "E1")
            {
                c.Print("\n You attack the troll.\n\n It strikes quickly, too fast for you to react.");
                c.Pause();
                Methods.GameOver(false);
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && (opt2 == "vampire" || opt2 == "bat") && Program.vampireAwake && !Program.vampireGone && Program.ROOM == "B3")
            {
                c.Print("\n As you move towards the vampire, it lunges forward and bites you.");
                c.Pause();
                Methods.GameOver(false);
            }
            else if (opt1 == "find" && (opt2 == "myself" || opt2 == "self" || opt2 == "me") && Program.ROOM == "T3")
            {
                Score.Addition(Score.Z_FindMe);
                c.Print("\n You have found yourself in a magical place.");
                c.Pause();
                Storyline.T4();
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && ((opt2 == "sphinx" && Program.ROOM == "PartIV") || ((opt2 == "leprechaun" || opt2 == "leper") && Program.ROOM == "Q2")))
            {
                c.Print("\n It screeches with fury.^");
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && (opt2 == "mirror" || opt2 == "talking") && (Program.ROOM == "PartVIII" || Program.ROOM.StartsWith("#")))
            {
                c.Print("\n You break the mirror without realizing that it will bring terrible consequences.\n\n Fortunately, you do not have to suffer the seven years of bad luck.\n\n You die of death.");
                c.Pause();
                Methods.GameOver(false);
            }
            else if ((opt1 == "break" || opt1 == "destroy") && (opt2 == "castle" || opt2 == "wall" || opt2 == "walls" || opt2 == "room" || opt2 == "area"))
            {
                c.Print("\n The walls of the castle are solid and cannot be broken.^");
            }
            else if ((opt1 == "break" || opt1 == "destroy" || opt1 == "kick" || opt1 == "punch" || opt1 == "zap") && (opt2 == "computer" || opt2 == "pc" || opt2 == "cpu") && (Program.ROOM == "PartIX" || Program.ROOM == "PC"))
            {
                if (Program.computerBroken)
                {
                    c.Print("\n It is already broken.^");
                }
                else
                {
                    c.Print("\n You break the computer.^");

                    Program.computerBroken = true;

                    Score.Addition(Score.J);
                }
            }
            else if (opt1 == "shield" && (opt2 == "" || opt2 == "myself" || opt2 == "me" || opt2 == "self"))
            {
                Use.Run("use", "shield", "", "", "", new string[] { });
            }
            else if (opt1 == "zap" && opt2 == "")
            {
                c.Print("\n Zap!^");
            }
            else if (opt1 == "punch" && opt2 == "")
            {
                c.Print("\n Punch.^");
            }
            else if (opt1 == "kick" && opt2 == "")
            {
                c.Print("\n Kick.^");
            }
            else if (opt1 == "zap" && (opt2 == "me" || opt2 == "myself" || opt2 == "self"))
            {
                c.Print("\n Ouch! Ouch! Ouch!^");

                Methods.SetPermanentHealth(Program.PermanentHealth - 18);
            }
            else if (opt1 == "kick" && (opt2 == "me" || opt2 == "myself" || opt2 == "self"))
            {
                c.Print("\n Ouch!^");

                Methods.SetPermanentHealth(Program.PermanentHealth - 9);
            }
            else if (opt1 == "punch" && (opt2 == "me" || opt2 == "myself" || opt2 == "self"))
            {
                c.Print("\n Oof!^");

                Methods.SetPermanentHealth(Program.PermanentHealth - 8);
            }
            else if ((opt1 == "punch" || opt1 == "break" || opt1 == "kick" || opt1 == "destroy" || opt1 == "zap") && (opt2 == "chandelier") && Program.ROOM == "PartIII")
            {
                c.Print("\n It is too high for you to reach.^");
            }
            else if ((opt1 == "punch" || opt1 == "break" || opt1 == "kick" || opt1 == "destroy" || opt1 == "zap") && (opt2 == "chandelier") && Program.ROOM == "PartXI")
            {
                TakeMethods.chandelier();
            }
            else if (opt1 == "climb" && opt2 != "up" && opt2 != "u" && opt2 != "down" && opt2 != "d" && opt2 != string.Empty)
            {
                c.Print("\n Up or down?^");
            }
            else if (opt1 == "pick" && opt2 == "nose")
            {
                c.Print("\n You will not find any gold nuggets in there.^");
            }
            else if (opt1 == "pick" && (opt2 == "lock" || opt2 == "door") && (Program.ROOM == "PartXV" || Program.ROOM == "PartXXIV"))
            {
                c.Print("\n You do not have the expertise.^");
            }
        }
    }
}
