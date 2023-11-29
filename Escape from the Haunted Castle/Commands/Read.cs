using haunted_castle.Commands.Variables_and_References;

namespace haunted_castle.Commands
{
    public class Read
    {
        // Declarations
        static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string[] books)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            for (int i = 0; i < books.Length; i++)
                books[i] = books[i].ToLower();

            if (opt1 == "read" || opt1 == "r")
                switch (opt2)
                {
                    case "":
                    case "book":
                        c.Print("\n You do not know what to read.^");
                        break;

                    case "writing":
                        c.Print("\n You do not know which writing to read.^");
                        break;

                    case "manual":
                        c.Print("\n Good idea.^");
                        break;

                    case "magic":
                    case "staff":
                        if (Program.ROOM == "FIN")
                            Read_Methods.magic_staff();
                        break;

                    case "newspaper":
                    case "paper":
                    case "news":
                        Read_Methods.newspaper();
                        break;

                    case "palm":
                    case "palms":
                    case "hand":
                    case "hands":
                        Read_Methods.palm();
                        break;

                    case "floppy":
                    case "disk":
                    case "disc":
                    case "diskette":
                        Read_Methods.floppy();
                        break;

                    case "recipe":
                        Read_Methods.recipe();
                        break;

                    default:
                        foreach (string obj in books)
                        {
                            if (obj == "calendar" && opt2 == "calendar")
                                Read_Methods.calendar();
                            else if (obj == "cookbook" && (opt2 == "cookbook" || opt2 == "cook"))
                                Read_Methods.cookbook();
                            else if (obj == "coffin" && (opt2 == "coffin" || opt2 == "black"))
                                Read_Methods.coffin();
                            else if (obj == "ship" && opt2 == "ship")
                                Read_Methods.ship();
                            else if (obj == "spellbook" && (opt2 == "spellbook" || opt2 == "spell"))
                                Read_Methods.spellbook();
                            else if ((obj == "purple" && opt2 == "strange") || (obj == "purple" && opt2 == "blue"))
                                Read_Methods.strange_purple();
                            else if (obj == "fountain" && (opt2 == "fountain" || opt2 == "basin"))
                                Read_Methods.fountain();
                            else if (obj == "poetry" && (opt2 == "poetry" || opt2 == "poem"))
                                Read_Methods.poetry();
                            else if (obj == "cake" && (opt2 == "cake" || opt2 == "purple"))
                                Read_Methods.cake();
                            else if (obj == "sign" && opt2 == "sign")
                                Read_Methods.sign();
                            else if (obj == "map" && opt2 == "map")
                                Read_Methods.map();
                        }
                        break;
                }
        }
    }
}
