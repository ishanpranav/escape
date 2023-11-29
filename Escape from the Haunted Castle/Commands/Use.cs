// Use.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using HauntedCastle.Commands.Variables_and_References;

namespace HauntedCastle.Commands
{
    public class Use
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string opt3, string opt4, string opt5, string[] appliances)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');
            opt3 = opt3.ToLower().Replace('^', ' ');
            opt4 = opt4.ToLower().Replace('^', ' ');
            opt5 = opt5.ToLower().Replace('^', ' ');

            for (int i = 0; i < appliances.Length; i++)
            {
                appliances[i] = appliances[i].ToLower();
            }

            if (opt1 == "use" || opt1 == "equip")
            {
                switch (opt2)
                {
                    case "addscore":
                        if (Program.name.ToLower().Contains("admin") || Program.name.ToLower().Contains("ishan"))
                        {
                            try
                            {
                                SimpleEncryption se = new SimpleEncryption();

                                string x = se.DecryptString(System.IO.File.ReadAllText(FileSystem.scoresdat));

                                x += opt3 + "," + c.FormatScore(System.Convert.ToInt32(opt4)) + "~";

                                System.IO.File.WriteAllText(FileSystem.scoresdat, se.EncryptString(x));

                                c.Print("\n Done.^");
                            }
                            catch
                            {
                                c.Print("\n Error.^", System.ConsoleColor.Red);
                            }
                        }

                        break;

                    case "nose":
                        Use_Methods.nose();
                        break;

                    case "ear":
                    case "ears":
                        Use_Methods.ears();
                        break;

                    case "eyes":
                    case "eye":
                        switch (opt3)
                        {
                            case "":
                            case "to":
                                switch (opt4)
                                {
                                    case "":
                                        Clear.Run("cls", "");
                                        break;

                                    case "look":
                                    case "examine":
                                    case "inspect":
                                    case "l":
                                    case "x":
                                        c.Print("\n To use your eyes, try to look at, examine, or inspect an object.^");
                                        break;
                                }

                                break;
                        }

                        break;

                    case "brain":
                    case "brains":
                        c.Print("\n An interesting idea...^");
                        break;

                    case "manual":
                        c.Print("\n Good idea.^");
                        break;

                    case "":
                        c.Print("\n You do not know what to " + opt1 + ".^");
                        break;

                    case "staff":
                    case "magic":
                        if (Program.ROOM == "FIN")
                        {
                            ReadMethods.magic_staff();
                        }
                        else
                        {
                            c.Print("\n To use the magic staff, try to say an incantation or zap an object.^");
                        }

                        break;

                    case "compass":
                        c.Print("\n To use the compass, try to go north, south, east, or west.^");
                        break;

                    case "shield":
                        if (Program.Inventory[6] > 0)
                        {
                            c.Print("\n There is no enemy here to use your shield against.^");
                        }
                        else
                        {
                            c.Print("\n You do not have that.^");
                        }

                        break;

                    case "fist":
                    case "fists":
                    case "hands":
                    case "hand":
                    case "palm":
                    case "palms":
                        c.Print("\n To use your fists, try to punch an object.^");
                        break;

                    case "match":
                        switch (opt3)
                        {
                            case "":
                            case "to":
                                switch (opt4)
                                {
                                    case "":
                                        Light_Methods.match();
                                        break;

                                    case "light":
                                        switch (opt5)
                                        {
                                            case "candle":
                                                Light_Methods.candleWithMatch();
                                                break;
                                            case "hair":
                                            case "hairs":
                                                if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed)
                                                {
                                                    c.Print("\n It has already been used.^");
                                                }
                                                else
                                                {
                                                    c.Print("\n You would rather not waste it.^");
                                                }

                                                break;
                                        }

                                        break;
                                }

                                break;
                        }

                        break;

                    case "candle":
                        switch (opt3)
                        {
                            case "":
                            case "to":
                                switch (opt4)
                                {
                                    case "":
                                        c.Print("\n You do not know what to do with it.^");
                                        break;

                                    case "light":
                                        switch (opt5)
                                        {
                                            case "hair":
                                            case "hairs":
                                                Light_Methods.eyebrowsWithCandle();
                                                break;
                                        }

                                        break;
                                }

                                break;
                        }

                        break;

                    case "box":
                        if (Program.Inventory[9] == 1 || Program.ROOM == "PartXXII")
                        {
                            Use_Methods.box();
                        }

                        break;

                    case "key":
                        if (Program.ROOM == "PartXV")
                        {
                            OpenMethods.door();
                        }

                        break;

                    case "flute":
                        if (Program.Inventory[8] == 1 || Program.ROOM == "R7A")
                        {
                            Use_Methods.flute();
                        }

                        break;

                    case "crate":
                        if (Program.Inventory[10] == 1 || Program.ROOM == "PartXXII")
                        {
                            Use_Methods.crate();
                        }

                        break;

                    case "floppy":
                    case "disk":
                    case "disc":
                    case "diskette":
                        if (Program.Inventory[11] == 1)
                        {
                            c.Print("\n It is useless.^");
                        }
                        else if (Program.ROOM == "PartVIII" || Program.ROOM == "PC")
                        {
                            Methods.WriteCaption("It is inside of the computer's floppy disk drive.");
                        }

                        break;

                    case "monocle":
                        Use_Methods.monocle();
                        break;

                    case "recipe":
                        if (Program.Inventory[7] == 1 && Program.ROOM == "PartXV")
                        {
                            Use_Methods.stoveToCook();
                        }
                        else if (Program.Inventory[7] == 1)
                        {
                            if (opt3 == "paper")
                            {
                                Use_Methods.recipeAsPaper();
                            }
                            else if (opt3 == "as" || (opt3 == "for" && opt3 != "to"))
                            {
                                if (opt4 == "")
                                {
                                    c.Print("\n You do not know what to use it as.^");
                                }
                                else if (opt4 == "paper")
                                {
                                    Use_Methods.recipeAsPaper();
                                }
                            }
                            else
                            {
                                c.Print("\n You do not know what to use it as.^");
                            }
                        }
                        else
                        {
                            c.Print("\n You do not have that.^");
                        }

                        break;

                    case "blackberry":
                    case "black":
                    case "berry":
                        if (Program.Inventory[12] == 1)
                        {
                            if (opt3 == "ink")
                            {
                                Use_Methods.blackberryAsInk();
                            }
                            else if (opt3 == "as" || (opt3 == "for" && opt3 != "to"))
                            {
                                if (opt4 == "")
                                {
                                    c.Print("\n You do not know what to use it as.^");
                                }
                                else if (opt4 == "ink")
                                {
                                    Use_Methods.blackberryAsInk();
                                }
                            }
                            else
                            {
                                c.Print("\n You do not know what to use it as.^");
                            }
                        }
                        else
                        {
                            c.Print("\n You do not have that.^");
                        }

                        break;

                    case "feather":
                        if (Program.Inventory[13] == 1)
                        {
                            if (opt3 == "pen")
                            {
                                Use_Methods.featherAsPen();
                            }
                            else if (opt3 == "as" || (opt3 == "for" && opt3 != "to"))
                            {
                                if (opt4 == "")
                                {
                                    if (Program.degrees == 180)
                                    {
                                        c.Print("\n You do not know what to do with it.^");
                                    }
                                    else
                                    {
                                        c.Print("\n You do not know what to use it as.^");
                                    }
                                }
                                else if (opt4 == "pen")
                                {
                                    Use_Methods.featherAsPen();
                                }
                            }
                            else if (opt3 == "to" && opt4 == "tickle")
                            {
                                Use_Methods.featherToTickle();
                            }
                            else
                            {
                                if (Program.degrees == 180)
                                {
                                    c.Print("\n You do not know what to do with it.^");
                                }
                                else
                                {
                                    c.Print("\n You do not know what to use it as.^");
                                }
                            }
                        }
                        else
                        {
                            c.Print("\n You do not have that.^");
                        }

                        break;

                    default:
                        foreach (string obj in appliances)
                        {
                            if (obj == "stove" && opt2 == "stove")
                            {
                                switch (opt3)
                                {
                                    case "":
                                    case "to":
                                        switch (opt4)
                                        {
                                            case "":
                                            case "cook":
                                                Use_Methods.stoveToCook();
                                                break;
                                        }

                                        break;
                                }
                            }
                            else if (obj == "sink" && opt2 == "sink")
                            {
                                switch (opt3)
                                {
                                    case "":
                                    case "to":
                                        switch (opt4)
                                        {
                                            case "":
                                            case "wash":
                                                switch (opt5)
                                                {
                                                    case "":
                                                        Use_Methods.sinkToWash();
                                                        break;

                                                    case "face":
                                                    case "hands":
                                                    case "palms":
                                                    case "hand":
                                                    case "palm":
                                                        Use_Methods.sinkToWashhands();
                                                        break;

                                                    case "tomatoes":
                                                    case "tomato":
                                                        if (Program.ROOM == "PartXV")
                                                        {
                                                            Use_Methods.sinkToWashtomatoes();
                                                        }
                                                        else
                                                        {
                                                            c.Print("\n You do not have that.^");
                                                        }

                                                        break;
                                                }

                                                break;

                                            case "get":
                                            case "obtain":
                                            case "take":
                                                switch (opt5)
                                                {
                                                    case "water":
                                                        TakeMethods.water();
                                                        break;
                                                }

                                                break;
                                        }

                                        break;
                                }
                            }
                            else if ((obj == "chandelier" || obj == "chandelier2") && opt2 == "chandelier")
                            {
                                c.Print("\n The chandelier has no bulbs or candles.^");
                            }
                            else if (obj == "cards" && (opt2 == "cards" || opt2 == "card" || opt2 == "deck"))
                            {
                                switch (opt3)
                                {
                                    case "":
                                    case "to":
                                        switch (opt4)
                                        {
                                            case "":
                                            case "play":
                                                Use_Methods.cards();
                                                break;

                                            case "shuffle":
                                                Clear.Run("shuffle", "cards");
                                                break;
                                        }

                                        break;

                                    default:
                                        Use_Methods.cards();
                                        break;
                                }
                            }
                            else if (obj == "bed" && opt2 == "bed")
                            {
                                Clear.Run("rest", "");
                            }
                            else if (obj == "computer" && (opt2 == "computer" || opt2 == "cpu" || opt2 == "pc"))
                            {
                                Use_Methods.computer();
                            }
                            else if (obj == "television" && (opt2 == "television" || opt2 == "tv" || opt2 == "tele"))
                            {
                                Use_Methods.television();
                            }
                            else if (obj == "lamp" && (opt2 == "lamp" || opt2 == "oil"))
                            {
                                Use_Methods.lamp();
                            }
                            else if (obj == "crate2" && opt2 == "crate")
                            {
                                c.Print("\n You are inside of it.^");
                            }
                            else if (obj == "telescope" && opt2 == "telescope")
                            {
                                Use_Methods.telescope();
                            }
                            else if (obj == "mirror" && (opt2 == "mirror" || opt2 == "talking"))
                            {
                                Examine.Run("l", "mirror", "", "", "", "", "", "", new string[] { "mirror" });
                            }
                            else if (obj == "poetry" && (opt2 == "poetry" || opt2 == "poem"))
                            {
                                ReadMethods.poetry();
                            }
                            else if (obj == "spellbook" && (opt2 == "spell" || opt2 == "spellbook"))
                            {
                                ReadMethods.spellbook();
                            }
                            else if (obj == "cookbook" && (opt2 == "cook" || opt2 == "cookbook"))
                            {
                                ReadMethods.cookbook();
                            }
                            else if (obj == "rope" && opt2 == "rope")
                            {
                                Up.Run("u", "", "D1");
                            }
                            else if (obj == "rope2" && opt2 == "rope")
                            {
                                Down.Run("d", "", "D2");
                            }
                            else if (obj == "fountain" && (opt2 == "fountain" || opt2 == "basin"))
                            {
                                c.Print("\n It is already on.^");
                            }
                            else if (obj == "purple" && (opt2 == "strange" || opt2 == "purple"))
                            {
                                ReadMethods.strange_purple();
                            }
                            else if (obj == "rug" && (opt2 == "oriental" || opt2 == "rug"))
                            {
                                Use_Methods.rug();
                            }
                            else if (obj == "rug2" && (opt2 == "oriental" || opt2 == "rug"))
                            {
                                c.Print("\n You are on top of it.^");
                            }
                            else if (obj == "box-crate" && ((opt2 == "box" && (Program.Inventory[9] == 1 || Program.ROOM == "PartXXII")) || (opt2 == "crate" && (Program.Inventory[10] == 1 || Program.ROOM == "PartXXII"))))
                            {
                                c.Print("\n You have nothing to use it for here.^");
                            }
                            else if (obj == "wheel" && (opt2 == "wheel" || opt2 == "steering"))
                            {
                                Use_Methods.wheel();
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
