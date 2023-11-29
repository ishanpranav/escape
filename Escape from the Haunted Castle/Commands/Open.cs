using haunted_castle.Commands.Variables_and_References;

namespace haunted_castle.Commands
{
    public class Open
    {
        // Declarations
        static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, bool ComputerRoom, string[] objects)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            for (int i = 0; i < objects.Length; i++)
                objects[i] = objects[i].ToLower();

            if ((opt1 == "op" || opt1 == "o" || opt1 == "open" || opt1 == "unlock") && (opt2 == string.Empty || opt2 == "container"))
                c.Print("\n You do not know what to open.^");

            if (opt1 == "op" || opt1 == "o" || opt1 == "open" || opt1 == "punch" || opt1 == "kick" || opt1 == "zap" || opt1 == "break" || opt1 == "destroy" || opt1 == "use" || opt1 == "unlock")
                foreach (string obj in objects)
                {
                    if (obj == "door" && opt2 == "door")
                        Open_Methods.door();
                    else if (obj == "apple" && opt2 == "apple")
                        c.Print("\n Your attempts to open the apple without biting it are unsuccessful.^");
                    else if (obj == "door2" && opt2 == "door")
                        Open_Methods.door2();
                    else if (obj == "kettle" && opt2 == "kettle")
                        c.Print("\n It is already open.^");
                    else if (obj == "doorway" && opt2 == "doorway")
                        c.Print("\n It is already open.^");
                    else if (obj == "window" && opt2 == "window")
                    {
                        c.Print("\n Did you really think it would be that easy?^");
                        Program.pregunta = 3;
                    }
                    else if (obj == "secret" && (opt2 == "secret" || opt2 == "door"))
                        Open_Methods.secret_door();
                    else if (obj == "oak" && (opt2 == "tree" || opt2 == "oak") && opt1 != "op" && opt1 != "open" && opt1 != "o" && opt1 != "use")
                        c.Print("\n The startled bird flutters out of the tree and then back down again.^");
                    else if (obj == "doors" && (opt2 == "doors" || opt2 == "door"))
                        Open_Methods.doors();
                    else if (obj == "case" && (opt2 == "display" || opt2 == "case"))
                    {
                        if (Program.caseOpen)
                            c.Print("\n It is already open.^");
                        else
                            c.Print("\n It does not budge.^");
                    }
                    else if (obj == "gate" && (opt2 == "gate" || opt2 == "limestone"))
                        c.Print("\n It does not budge.^");
                    else if (obj == "desk" && opt2 == "desk")
                        c.Print("\n There is nothing inside.^");
                    else if (obj == "e" && (opt2 == "e" || opt2 == "east"))
                        Open_Methods.e();
                    else if (obj == "s" && (opt2 == "s" || opt2 == "south"))
                        Open_Methods.SouthNorthWest("south");
                    else if (obj == "n" && (opt2 == "n" || opt2 == "north"))
                        Open_Methods.SouthNorthWest("north");
                    else if (obj == "w" && (opt2 == "w" || opt2 == "west"))
                        Open_Methods.SouthNorthWest("west");
                    else if (obj == "k" && (opt2 == "k" || opt2 == "kitchen"))
                        Storyline.PartXV();
                    else if (obj == "l" && (opt2 == "l" || opt2 == "library"))
                        Open_Methods.l();
                    else if (obj == "x" && (opt2 == "x" || opt2 == "wooden" || opt2 == "door"))
                        Open_Methods.x();
                    else if (obj == "y" && (opt2 == "y" || opt2 == "wooden" || opt2 == "door"))
                        Open_Methods.y();
                    else if (obj == "l" && (opt2 == "door" || opt2 == "doors"))
                        c.Print("\n You cannot open both of them at once.^");
                    else if (obj == "n" && (opt2 == "door" || opt2 == "doors"))
                        c.Print("\n You cannot open all of them at once.^");
                    else if (obj == "purple" && (opt2 == "strange" || opt2 == "blue"))
                        Read_Methods.strange_purple();
                    else if (obj == "bars" && (opt2 == "bars" || opt2 == "bar"))
                        c.Print("\n They do not budge.^");
                    else if (obj == "drive" && opt2 == "drive")
                        c.Print("\n It is jammed.^");
                    else if (obj == "drawbridge" && (opt2 == "drawbridge" || opt2 == "bridge"))
                        Open_Methods.drawbridge();
                }

            if (opt1 == "op" || opt1 == "o" || opt1 == "open")
                switch (opt2)
                {
                    case "bag":
                    case "leather":
                        Open_Methods.bag(ComputerRoom);
                        break;

                    case "box":
                        Open_Methods.box();
                        break;

                    case "crate":
                        Open_Methods.crate();
                        break;

                    case "manual":
                        c.Print("\n Good idea.^");
                        break;

                    case "":
                    case "book":
                        c.Print("\n You do not know what to read.^");
                        break;

                    case "newspaper":
                    case "paper":
                    case "news":
                        Read_Methods.newspaper();
                        break;

                    default:
                        foreach (string obj in objects)
                        {
                            if (obj == "chest" && opt2 == "chest")
                                Open_Methods.chest();
                            if (obj == "map" && opt2 == "map")
                                c.Print("\n The map is already displayed on the wall.^");
                            else if (obj == "sink" && opt2 == "sink")
                                Use_Methods.sinkToWash();
                            else if (obj == "telescope" && opt2 == "telescope")
                                Use_Methods.telescope();
                            else if (obj == "stove" && opt2 == "stove")
                                Use_Methods.stoveToCook();
                            else if (obj == "computer" && (opt2 == "computer" || opt2 == "cpu" || opt2 == "pc"))
                                Use_Methods.computer();
                            else if (obj == "cookbook" && (opt2 == "cookbook" || opt2 == "cook"))
                                Read_Methods.cookbook();
                            else if (obj == "spellbook" && (opt2 == "spell" || opt2 == "spellbook"))
                                Read_Methods.spellbook();
                            else if (obj == "coffin" && (opt2 == "coffin" || opt2 == "black"))
                                Open_Methods.coffin();
                            else if (obj == "poetry" && (opt2 == "poetry" || opt2 == "poem"))
                                Read_Methods.poetry();
                            else if (obj == "calendar" && opt2 == "calendar")
                                Read_Methods.calendar();
                        }
                        break;
                }
        }
    }
}
