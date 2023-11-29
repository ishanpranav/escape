// East.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

namespace HauntedCastle.Commands
{
    public class East
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string MazeRoom = "0", string block = "")
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if (opt1 == "e" || opt1 == "east" || opt1 == "right" || opt1 == "starboard" || opt1 == "sb" || opt1 == "b" || ((opt1 == "go" || opt1 == "walk" || opt1 == "run") && (opt2 == "e" || opt2 == "east" || opt2 == "right" || opt2 == "starboard" || opt2 == "sb" || opt2 == "b")))
            {
                switch (MazeRoom)
                {
                    case "D7":
                        Storyline.PC();
                        return;
                    default:
                        if ((opt1 == "sb" || opt1 == "b" || opt1 == "starboard" || (((opt1 == "go") || opt1 == "run" || opt1 == "walk") && (opt1 == "sb" || opt1 == "sb" || opt1 == "starboard"))) && block != string.Empty && Program.ROOM.StartsWith("D") && Program.ROOM != "D1")
                        {
                            c.Print("\n " + block + "^");
                            return;
                        }
                        else
                        {
                            break;
                        }
                }
            }

            if (opt1 == "e" || opt1 == "east" || opt1 == "right" || ((opt1 == "go" || opt1 == "walk" || opt1 == "run") && (opt2 == "e" || opt2 == "east" || opt2 == "right")))
            {
                switch (MazeRoom)
                {
                    case "Z":
                        if (Program.mazes[Program.mazeIdx] == 'e')
                        {
                            Program.mazeIdx++;
                        }

                        FileSystem.TRAVELTO();
                        break;
                    case "Q1":
                        if (Program.mazes[0] == 'e')
                        {
                            Storyline.Z();
                        }
                        else
                        {
                            FileSystem.TRAVELTO();
                        }

                        break;
                    case "J2":
                        Storyline.E6();
                        break;
                    case "E2":
                    case "E3":
                        Storyline.E2();
                        break;
                    case "E6":
                        Storyline.E4();
                        break;
                    case "E4":
                        Storyline.E5();
                        break;
                    case "E5":
                        Storyline.J1();
                        break;
                    case "TROLLB":
                        Storyline.PartXXIV();
                        break;
                    case "STOR":
                        Storyline.PartII();
                        break;
                    case "B3":
                        Storyline.B1();
                        break;
                    case "B1":
                        Storyline.DeltaOut();
                        break;
                    case "R24":
                        Storyline.A1();
                        break;
                    case "R8":
                        if (!Program.pyAwake && Program.pyMoved)
                        {
                            c.Print("\n You tiptoe past the sleeping snake,\n now so well fed and in such a deep slumber that it does not notice your escape.");
                            c.Pause();
                            Storyline.R24();
                        }
                        else if (Program.pyAwake)
                        {
                            Storyline.SnakeBite();
                            c.Print("^");
                        }
                        else
                        {
                            c.Print("\n As you move towards the snake, your loud footsteps cause it to stir.^");
                            Storyline.WakeUpSnake();
                            c.Print("^");
                        }

                        break;
                    case "R3":
                        Storyline.R8();
                        break;
                    case "EP":
                        Storyline.PartXXXII();
                        break;
                    case "R2":
                        Storyline.R7();
                        break;
                    case "SR":
                        OpenMethods.e();
                        break;
                    case "SOP3":
                        Storyline.PartXXXIII();
                        break;
                    case "SOP2":
                        Storyline.SOP3();
                        break;
                    case "SOP":
                        Storyline.SOP2();
                        break;
                    case "BWB":
                        Storyline.PrisonCell2(Program.firstprisoncell);
                        Storyline.PartVI(Program.firstprisoncell);
                        break;
                    case "SNOW_COVERED_LN":
                        c.Print("\n You are on an island and can only go down into the water.^");
                        break;
                    case "COURT":
                        Storyline.PartXXXIV();
                        break;
                    case "OAKFOREST":
                        Storyline.PartXXXIII();
                        break;
                    case "M1":
                        Storyline.MA();
                        break;
                    case "MA":
                        Storyline.MB();
                        break;
                    case "MB":
                        Storyline.MC();
                        break;
                    case "MC":
                        Score.Addition(Score.K_MoatDone);
                        Storyline.PartXXVIII();
                        break;
                    case "M2":
                    case "M3":
                    case "U2":
                    case "FIN":
                        FileSystem.TRAVELTO();
                        break;
                    case "S":
                        Storyline.PartVII(false);
                        break;
                    default:
                        if (block != string.Empty)
                        {
                            c.Print(string.Format("\n {0}^", block));
                        }
                        else
                        {
                            c.Print("\n You cannot go east from here.^");
                        }

                        break;
                }
            }
        }
    }
}
