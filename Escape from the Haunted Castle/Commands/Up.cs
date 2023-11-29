namespace haunted_castle.Commands
{
    public class Up
    {
        // Declarations
        static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string MazeRoom = "0", string block = "")
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if (opt1 == "u" || opt1 == "up" || ((opt1 == "jump" || opt1 == "go" || opt1 == "walk" || opt1 == "run" || opt1 == "climb") && opt2 == "u") || ((opt1 == "go" || opt1 == "walk" || opt1 == "run" || opt1 == "climb" || opt1 == "jump") && opt2 == "up"))
            {
                switch (MazeRoom)
                {
                    case "J2":
                        Storyline.J3();
                        break;
                    case "Y2":
                        Storyline.Y3();
                        break;
                    case "Y1":
                        Storyline.Y2();
                        break;
                    case "OAKFOREST":
                        if (Program.beans)
                            Storyline.Y1();
                        else
                            c.Print("\n The oak tree branches are too high for you to climb.^");
                        break;
                    case "DX":
                        Storyline.D4();
                        break;
                    case "D8":
                        Storyline.D7();
                        break;
                    case "D3":
                        Storyline.D6();
                        break;
                    case "D2":
                        Storyline.D3();
                        break;
                    case "D1":
                        Score.Addition(Score.P2_ObtainRope);
                        Storyline.D2();
                        break;
                    case "C1":
                    case "C2":
                        Storyline.C2();
                        break;
                    case "R7A":
                        Storyline.R7();
                        break;
                    case "R2":
                        Storyline.R2A();
                        break;
                    case "THRONE":
                        Storyline.PartX();
                        break;
                    case "L":
                        Storyline.PartXI();
                        break;
                    case "A":
                        Storyline.PrisonCell2(Program.firstprisoncell);
                        Storyline.PartVI(Program.firstprisoncell);
                        break;
                    case "P":
                        Storyline.PartIX();
                        break;
                    case "COMPUTER_ROOM":
                        Storyline.PartVIII();
                        break;
                    case "TR":
                        Storyline.PartV(false);
                        break;
                    case "IS":
                        Storyline.PartXIII();
                        break;
                    case "EP":
                        Storyline.PartXVI();
                        break;
                    case "Z":
                        Storyline.ZT();
                        break;
                    case "T4":
                        Storyline.U1();
                        break;
                    default:
                        if (block == string.Empty)
                            c.Print("\n You cannot go up from here.^");
                        else
                            c.Print(string.Format("\n {0}^", block));
                        break;
                }

            }
        }
    }
}