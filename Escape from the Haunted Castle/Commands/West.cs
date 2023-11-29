using haunted_castle.Commands.Variables_and_References;

namespace haunted_castle.Commands
{
    public class West
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string MazeRoom = "0", string block = "")
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if (opt1 == "w" || opt1 == "west" || opt1 == "left" || opt1 == "port" || opt1 == "p" || ((opt1 == "go" || opt1 == "walk" || opt1 == "run") && (opt2 == "w" || opt2 == "west" || opt2 == "left" || opt2 == "port" || opt2 == "p")))
                switch (MazeRoom) {
                    case "PC":
                        Storyline.D7();
                        return;
                    default:
                        if ((opt1 == "p" || opt1 == "port" || ((opt1 == "go") || opt1 == "run" || opt1 == "walk") && (opt1 == "p" || opt1 == "port")) && block != string.Empty && Program.ROOM.StartsWith("D") && Program.ROOM != "D1")
                        {
                            c.Print("\n " + block + "^");
                            return;
                        }
                        else break;
                }

            if (opt1 == "w" || opt1 == "west" || opt1 == "left" || ((opt1 == "go" || opt1 == "walk" || opt1 == "run") && (opt2 == "w" || opt2 == "west" || opt2 == "left")))
            {
                switch (MazeRoom)
                {
                    case "U1":
                        Open_Methods.x();
                        break;
                    case "Z":
                        if (Program.mazes[Program.mazeIdx] == 'w')
                            Program.mazeIdx++;
                        FileSystem.TRAVELTO();
                        break;
                    case "Q1":
                        if (Program.mazes[0] == 'w')
                            Storyline.Z();
                        else
                            FileSystem.TRAVELTO();
                        break;
                    case "E2":
                    case "E3":
                        Storyline.E2();
                        break;
                    case "E4":
                        Storyline.E6();
                        break;
                    case "E6":
                        Storyline.J2();
                        break;
                    case "E5":
                        Storyline.E4();
                        break;
                    case "DRAWBRIDGE":
                        Storyline.E1();
                        break;
                    case "CORRIDOR":
                        Storyline.PartI();
                        break;
                    case "C5":
                        c.Print("\n The limestone gate is closed.^");
                        break;
                    case "GAME":
                        Storyline.PartXVIII();
                        break;
                    case "B4":
                        Storyline.B1();
                        break;
                    case "B1":
                        Storyline.DeltaOut();
                        break;
                    case "A1":
                        Storyline.R24();
                        break;
                    case "R24":
                        Storyline.R8();
                        break;
                    case "R8":
                        Storyline.R3();
                        break;
                    case "R7":
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
                    case "J1":
                        Open_Methods.x();
                        break;
                    case "M1":
                    case "M2":
                    case "M3":
                    case "OAKFOREST":
                    case "U2":
                    case "FIN":
                        FileSystem.TRAVELTO();
                        break;
                    case "SR":
                        Open_Methods.SouthNorthWest("west");
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
                    case "P":
                        Storyline.PartXIX();
                        break;
                    case "TR":
                        Storyline.PartXVI();
                        break;
                    case "THRONE":
                    case "PLATFORM":
                        Open_Methods.doors();
                        break;
                    case "D":
                        Open_Methods.door2();
                        break;
                    case "IS":
                        c.Print("\n At the north pole the only direction is south.^");
                        break;
                    case "SNOW_COVERED_LN":
                        c.Print("\n You are on an island and can only go down into the water.^");
                        break;
                    case "BERRYGROVE":
                        Storyline.PartXXXIII();
                        break;
                    case "COURT":
                        Storyline.PartXXXV();
                        break;
                    default:
                        if (block != string.Empty)
                            c.Print(string.Format("\n {0}^", block));
                        else
                            c.Print("\n You cannot go west from here.^");
                        break;
                }
            }
        }
    }
}
