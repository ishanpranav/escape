// Read.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

namespace HauntedCastle.Commands
{
    public class Read
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string[] books)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            for (int i = 0; i < books.Length; i++)
            {
                books[i] = books[i].ToLower();
            }

            if (opt1 == "read" || opt1 == "r")
            {
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
                        {
                            ReadMethods.magic_staff();
                        }

                        break;

                    case "newspaper":
                    case "paper":
                    case "news":
                        ReadMethods.newspaper();
                        break;

                    case "palm":
                    case "palms":
                    case "hand":
                    case "hands":
                        ReadMethods.palm();
                        break;

                    case "floppy":
                    case "disk":
                    case "disc":
                    case "diskette":
                        ReadMethods.floppy();
                        break;

                    case "recipe":
                        ReadMethods.recipe();
                        break;

                    default:
                        foreach (string obj in books)
                        {
                            if (obj == "calendar" && opt2 == "calendar")
                            {
                                ReadMethods.calendar();
                            }
                            else if (obj == "cookbook" && (opt2 == "cookbook" || opt2 == "cook"))
                            {
                                ReadMethods.cookbook();
                            }
                            else if (obj == "coffin" && (opt2 == "coffin" || opt2 == "black"))
                            {
                                ReadMethods.coffin();
                            }
                            else if (obj == "ship" && opt2 == "ship")
                            {
                                ReadMethods.ship();
                            }
                            else if (obj == "spellbook" && (opt2 == "spellbook" || opt2 == "spell"))
                            {
                                ReadMethods.spellbook();
                            }
                            else if ((obj == "purple" && opt2 == "strange") || (obj == "purple" && opt2 == "blue"))
                            {
                                ReadMethods.strange_purple();
                            }
                            else if (obj == "fountain" && (opt2 == "fountain" || opt2 == "basin"))
                            {
                                ReadMethods.fountain();
                            }
                            else if (obj == "poetry" && (opt2 == "poetry" || opt2 == "poem"))
                            {
                                ReadMethods.poetry();
                            }
                            else if (obj == "cake" && (opt2 == "cake" || opt2 == "purple"))
                            {
                                ReadMethods.cake();
                            }
                            else if (obj == "sign" && opt2 == "sign")
                            {
                                ReadMethods.sign();
                            }
                            else if (obj == "map" && opt2 == "map")
                            {
                                ReadMethods.map();
                            }
                        }

                        break;
                }
            }
        }
    }
}
