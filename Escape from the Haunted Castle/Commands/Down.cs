// Down.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

namespace HauntedCastle.Commands
{
    public class Down
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string MazeRoom = "0", string block = "")
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if (opt1 == "d" || opt1 == "down" || ((opt1 == "go" || opt1 == "walk" || opt1 == "run" || opt1 == "climb" || opt1 == "jump") && (opt2 == "d" || opt2 == "down")))
            {
                switch (MazeRoom)
                {
                    case "J1":
                        c.Print("\n It would be unwise to explore further while there is a werewolf in your house.^");
                        break;
                    case "U1":
                        Storyline.T4();
                        break;
                    case "J3":
                        Storyline.J2();
                        break;
                    case "Y1":
                        Storyline.PartXXXV();
                        break;
                    case "":
                        Storyline.Y1();
                        break;
                    case "Y3":
                        Storyline.Y2();
                        break;
                    case "D7":
                        Storyline.D8();
                        break;
                    case "D4":
                        Storyline.D10();
                        break;
                    case "D6":
                        Storyline.D3();
                        break;
                    case "D3":
                        Storyline.D2();
                        break;
                    case "D2":
                        c.Print("\n You would rather not climb back down into the water.^");
                        break;
                    case "C4":
                        c.Print("\n You fall through the hole in the crawlway and enter a vibrant room.");
                        c.Pause();
                        Storyline.C5();
                        break;
                    case "R7":
                        Storyline.R7A();
                        break;
                    case "R2A":
                        Storyline.R2();
                        break;
                    case "PLATFORM":
                        Storyline.PartXX();
                        break;
                    case "Y2":
                        Storyline.Y1();
                        break;
                    case "A":
                        if (Program.State[0])
                        {
                            c.Print("\n You are too tired to climb all the way down there.^");
                        }
                        else
                        {
                            Storyline.PartVII(Program.firsttreasureroom);
                        }

                        break;
                    case "P":
                        Storyline.PartV(false);
                        break;
                    case "COMPUTER_ROOM":
                        Storyline.PrisonCell2(Program.firstprisoncell);
                        Storyline.PartVI(Program.firstprisoncell);
                        break;
                    case "WQ":
                        Storyline.PartIX();
                        break;
                    case "S":
                        Storyline.PartXVIII();
                        break;
                    case "DRAWBRIDGE":
                        if (Program.InventoryCaptions[7] == InventoryItems.RecipePaperApproved)
                        {
                            c.Print("\n You begin to cross the drawbridge, when it splits in two and collapses.\n The drawbridge sinks into the moat, taking you with it.");
                            c.Pause();
                            Storyline.PartXXVI();
                        }
                        else
                        {
                            c.Print("\n Ouch!\n\n You walk directly into the drawbridge and hit it with full force.\n You are now dazed and have a minor injury.^");

                            Methods.SetPermanentHealth(Program.PermanentHealth - 10);
                            Program.State[2] = true;
                        }

                        break;
                    case "DROWN":
                        c.Print("\n You submerge yourself in the water.\n You frantically try to reach the surface, but you have already gone too deep.");
                        c.Pause();

                        Methods.GameOver(false);
                        break;
                    case "IS":
                        Storyline.PartXVII();
                        break;
                    case "SHELF":
                        Storyline.PartIII();
                        break;
                    case "SNOW_COVERED_LN":
                        Storyline.PartXII(false);
                        break;
                    case "Q2":
                        Storyline.T1();
                        break;
                    case "ZT":
                        Storyline.Z();
                        break;
                    default:
                        if (block != string.Empty)
                        {
                            c.Print(string.Format("\n {0}^", block));
                        }
                        else
                        {
                            c.Print("\n You cannot go down from here.^");
                        }

                        break;
                }
            }
        }
    }
}
