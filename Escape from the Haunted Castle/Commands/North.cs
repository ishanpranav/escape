using haunted_castle.Commands.Variables_and_References;

namespace haunted_castle.Commands
{
    public class North
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string MazeRoom = "0", string block = "")
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if ((opt1 == "go" || opt1 == "climb" || opt1 == "walk" || opt1 == "run" || opt1 == "jump") && (opt2 == string.Empty || opt2 == "none" || opt2 == "around" || opt2 == "in" || opt2 == "out") || opt1 == "enter" || opt1 == "leave" || opt1 == "in" || opt1 == "out") // DO NOT COPY to other direction files (South, East, West, Up, Down)
                c.Print("\n Which direction?^");

            if (opt1 == "n" || opt1 == "north" || opt1 == "forward" || opt1 == "forwards" || opt1 == "f" || ((opt1 == "go" || opt1 == "walk" || opt1 == "run") && (opt2 == "n" || opt2 == "north" || opt2 == "forwards" || opt2 == "forward" || opt2 == "f")))
            {
                switch (MazeRoom)
                {
                    case "Z":
                        if (Program.mazes[Program.mazeIdx] == 'n')
                            Program.mazeIdx++;
                        FileSystem.TRAVELTO();
                        break;
                    case "Q1":
                        if (Program.mazes[0] == 'n')
                            Storyline.Z();
                        else
                            FileSystem.TRAVELTO();
                        break;
                    case "E4":
                    case "E5":
                    case "E6":
                        if (Storyline.sky4 != Storyline.sky && Storyline.sky4 != null)
                            Storyline.Q1();
                        else
                            c.Print("\n It would be unwise to enter the rainforest without guidance.^");
                        break;
                    case "E3":
                        Storyline.E4();
                        break;
                    case "E2":
                        Storyline.E3();
                        break;
                    case "D9":
                        Storyline.D10();
                        break;
                    case "D8":
                        Storyline.D9();
                        break;
                    case "D7":
                        Storyline.D2();
                        break;
                    case "D2":
                    case "D3":
                        Storyline.D4();
                        break;
                    case "B2":
                        Storyline.B1();
                        break;
                    case "B1":
                        Storyline.DeltaOut();
                        break;
                    case "A1":
                        Storyline.A2();
                        break;
                    case "R8":
                        Storyline.R7();
                        break;
                    case "R3":
                        Storyline.R2();
                        break;
                    case "R2":
                        Storyline.R1();
                        break;
                    case "R7":
                        Storyline.R6();
                        break;
                    case "SR":
                        Open_Methods.SouthNorthWest("north");
                        break;
                    case "CORRIDOR":
                        Storyline.PartXV();
                        break;
                    case "L":
                        if (!Program.Ghosts[0])
                        {
                            c.Print("\n You step outside the library.\n\n An angry ghost is blocking your path!^");
                            c.Print("\n \"You dare to enter this castle without permission?\n  For this you shall have a taste of my extraordinary magic!\"");
                            c.Pause();
                            BattleSimulator.StartBattle(0, Program.GhostAttacks, "Haunted Castle: Corridor");
                            c.Print("\n You close the door behind you and re-enter the corridor.");
                            c.Pause();
                        }

                        Storyline.PartII();
                        break;
                    case "JC":
                        if (Program.Inventory[9] == 0 && Program.Inventory[10] == 0)
                            c.Print("\n You have not decided whether to take a box or a crate.^");
                        else
                            Storyline.PartXXIII();
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
                    case "DRAWBRIDGE":
                        Storyline.PartXXXIII();
                        break;
                    case "BERRYGROVE":
                        Storyline.PartXXXI();
                        break;
                    case "STABLES":
                        Storyline.PartXXXV();
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
                    case "OAKFOREST":
                    case "U2":
                    case "FIN":
                        FileSystem.TRAVELTO();
                        break;
                    case "SNOW_COVERED_LN":
                        c.Print("\n You are on an island and can only go down into the water.^");
                        break;
                    default:
                        if (block != string.Empty)
                            c.Print(string.Format("\n {0}^", block));
                        else
                            c.Print("\n You cannot go north from here.^");
                        break;
                }
            }
        }
    }
}
