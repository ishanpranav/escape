// South.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

namespace HauntedCastle.Commands
{
    public class South
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string MazeRoom = "0", string block = "")
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if (opt1 == "s" || opt1 == "south" || opt1 == "a" || opt1 == "aft" || opt1 == "back" || ((opt1 == "go" || opt1 == "walk" || opt1 == "run") && (opt2 == "s" || opt2 == "south" || opt2 == "aft" || opt2 == "back")))
            {
                switch (MazeRoom)
                {
                    case "D2":
                    case "D3":
                        Storyline.D7();
                        return;
                    case "D4":
                        Storyline.D2();
                        return;
                    case "D9":
                        Storyline.D8();
                        break;
                    case "DX":
                        Storyline.D9();
                        break;
                    default:
                        if ((opt1 == "a" || opt1 == "aft" || (((opt1 == "go") || opt1 == "run" || opt1 == "walk") && (opt1 == "aft" || opt1 == "back"))) && block != string.Empty && Program.ROOM.StartsWith("D") && Program.ROOM != "D1")
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

            if (opt1 == "s" || opt1 == "south" || opt1 == "back" || ((opt1 == "go" || opt1 == "walk" || opt1 == "run") && (opt2 == "s" || opt2 == "south")))
            {
                switch (MazeRoom)
                {
                    case "T1":
                        if (Program.ateCake)
                        {
                            Score.Addition(Score.T1);
                            Storyline.T2();
                        }
                        else
                        {
                            c.Print("\n Ouch!\n\n As you try to walk through the doorway, your head hits the wall.\n You appear to be too tall to fit through it.^");
                        }

                        break;
                    case "T2":
                        Score.Addition(Score.T2);
                        Storyline.T3();
                        break;
                    case "T3":
                        Score.Addition(Score.T3);
                        Storyline.T4();
                        break;
                    case "Z":
                        if (Program.mazes[Program.mazeIdx] == 's')
                        {
                            Program.mazeIdx++;
                        }

                        FileSystem.TRAVELTO();
                        break;
                    case "Q1":
                        if (Program.mazes[0] == 's')
                        {
                            Storyline.Z();
                        }
                        else
                        {
                            FileSystem.TRAVELTO();
                        }

                        break;
                    case "E5":
                    case "E6":
                        if (Storyline.sky4 != Storyline.sky && Storyline.sky4 != null)
                        {
                            Storyline.Q1();
                        }
                        else
                        {
                            c.Print("\n It would be unwise to enter the rainforest without guidance.^");
                        }

                        break;
                    case "E4":
                        Storyline.E3();
                        break;
                    case "E3":
                        Storyline.E2();
                        break;
                    case "C3":
                    case "C4":
                        Storyline.C4();
                        break;
                    case "C2":
                        Methods.Checkpoint("Maintenance Hatch", "Haunted Castle: Crawlway");
                        c.Print("\n You step off of the oriental rug and into the uninviting hole.\n\n The rug slowly floats down until it is completely out of sight.");
                        c.Pause();
                        Storyline.C3();
                        break;
                    case "B1":
                        Storyline.DeltaOut();
                        break;
                    case "A2":
                        Storyline.A1();
                        break;
                    case "A1":
                        Program.lockspeed = Program.rnd.Next(4);

                        Methods.Checkpoint("Triangular Opening", "Haunted Castle: Tower of Relics");
                        c.Print("\n You are passing through an enclosed tunnel\n connecting the main castle building to the central tower.");
                        c.Pause();
                        c.Print("\n You reach a triangle-shaped opening.");
                        c.Pause();
                        Storyline.B1();
                        break;
                    case "R6":
                        Storyline.R7();
                        break;
                    case "R7":
                        Storyline.R8();
                        break;
                    case "R2":
                        Storyline.R3();
                        break;
                    case "R1":
                        Storyline.R2();
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
                    case "M1":
                    case "M2":
                    case "M3":
                    case "U2":
                    case "FIN":
                        FileSystem.TRAVELTO();
                        break;
                    case "SHELF":
                    case "L":
                        OpenMethods.secret_door();
                        break;
                    case "SOP3":
                        Score.Addition(Score.O_Passages);
                        Storyline.PartXXXIII();
                        break;
                    case "SOP2":
                        Storyline.SOP3();
                        break;
                    case "SOP":
                        Storyline.SOP2();
                        break;
                    case "SR":
                        OpenMethods.SouthNorthWest("south");
                        break;
                    case "CORRIDOR":
                        OpenMethods.l();
                        break;
                    case "K":
                        Storyline.PartII();
                        break;
                    case "DRAWBRIDGE":
                        Down.Run("d", "", MazeRoom, block);
                        break;
                    case "IS":
                        c.Print("\n You begin to go south, and the north pole fades away.");
                        c.Pause();
                        Storyline.PartXI();
                        break;
                    case "SNOW_COVERED_LN":
                        Storyline.PartXI();
                        break;
                    case "STABLES":
                        Storyline.PartXXXIV();
                        break;
                    case "GAME":
                        Methods.Checkpoint("Hallway", "Haunted Castle");
                        c.Print("\n This is a long hallway extending to the north and south.\n\n The twisting passage confuses you.\n As you try to retrace your steps, you realize that you are hopelessly lost.");
                        c.Pause();
                        c.Print("\n You arrive at the entrance to a wide and open chamber.");
                        c.Pause();
                        Storyline.R1();
                        break;
                    case "OAKFOREST":
                        Storyline.PartXXXI();
                        break;
                    case "COURT":
                        Storyline.PartXXIV();
                        break;
                    default:
                        if (block != string.Empty)
                        {
                            c.Print(string.Format("\n {0}^", block));
                        }
                        else
                        {
                            c.Print("\n You cannot go south from here.^");
                        }

                        break;
                }
            }
        }
    }
}
