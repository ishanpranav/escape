// Take.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using HauntedCastle.Commands.Variables_and_References;

namespace HauntedCastle.Commands
{
    public class Take
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string[] objects)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i] = objects[i].ToLower();
            }

            if (opt1 == "take" || opt1 == "obtain" || opt1 == "collect" || opt1 == "get" || opt1 == "hold" || opt1 == "grab" || opt1 == "t")
            {
                switch (opt2)
                {
                    case "":
                        string text = opt1;

                        if (opt1 == "t")
                        {
                            text = "take";
                        }

                        c.Print("\n You do not know what to " + text + ".^");
                        break;

                    case "seeds":
                    case "seed":
                    case "appleseeds":
                    case "appleseed":
                        if (Program.Inventory[3] == 1 && Program.InventoryCaptions[3] == InventoryItems.Apple)
                        {
                            c.Print("\n They are inside of the apple.^");
                        }

                        break;

                    case "manual":
                    case "magic":
                    case "staff":
                    case "compass":
                    case "bag":
                    case "leather":
                        c.Print("\n You already have that.^");
                        break;

                    case "caution":
                        c.Print("\n Good idea.^");
                        break;

                    case "pose":
                        if (opt1 == "t")
                        {
                            c.Print("\n You do the T-pose.^");
                        }

                        break;

                    case "inventory":
                        Inventory.Run("i", string.Empty);
                        break;

                    case "diagnostic":
                        _ = Diagnose.Run("stats", string.Empty);
                        break;

                    case "recipe":
                        if (Program.ROOM == "PartIII" && Program.Inventory[7] == 0)
                        {
                            c.Print("\n The cookbook is closed.^");
                        }
                        else if (Program.Inventory[7] == 1)
                        {
                            c.Print("\n You already have that.^");
                        }

                        break;

                    case "rat":
                    case "rats":
                        if ((Program.ROOM != "D1" && (Program.ROOM == "D8" || (Program.ROOM.StartsWith("D") && !Program.ogAsleep && Program.ratsGone))) || (Program.ROOM == "DX" && Program.ogAsleep))
                        {
                            c.Print("\n You would rather not touch the rats.^");
                        }

                        break;

                    case "gold":
                    case "golden":
                    case "coin":
                    case "dust":
                    case "egg":
                    case "eggs":
                    case "coins":
                    case "ring":
                    case "pair":
                    case "rings":
                    case "bracelet":
                    case "goblet":
                    case "tiara":
                    case "scarab":
                    case "spoon":
                    case "ingot":
                        if (Program.Inventory[0] > 0)
                        {
                            c.Print("\n You already have that.^");
                        }

                        break;

                    case "newspaper":
                    case "news":
                    case "paper":
                        if (Program.Inventory[16] == 1)
                        {
                            c.Print("\n You already have that.^");
                        }

                        break;

                    case "crumbs":
                    case "breadcrumbs":
                    case "crumb":
                    case "breadcrumb":
                    case "handful":
                        if (Program.ateBread)
                        {
                            c.Print("\n You already have more than enough.^");
                        }

                        break;

                    case "key":
                    case "silver":
                        if (Program.ROOM == "PartXV" && Program.InventoryCaptions[5] == InventoryItems.Key)
                        {
                            TakeMethods.ITEM(5);
                        }
                        else if (Program.ROOM == "J3" && Program.Inventory[5] == 0)
                        {
                            c.Print("\n The hot metal burns your hand.^");

                            Methods.SetPermanentHealth(Program.PermanentHealth - 5);
                        }

                        break;

                    case "monocle":
                    case "lens":
                        if (Program.ROOM == "D8")
                        {
                            TakeMethods.monocle();
                        }
                        else if (Program.ROOM == "J3" && Program.Inventory[15] == 0)
                        {
                            c.Print("\n The hot glass burns your hand.^");

                            Methods.SetPermanentHealth(Program.PermanentHealth - 5);
                        }

                        break;

                    case "candle":
                        if (Program.Inventory[2] == 0 && Program.ROOM == "PartI")
                        {
                            Score.Addition(Score.A2_ObtainCandle);
                            Program.Inventory[2] = 1;

                            c.Print("\n Taken.^");

                            if (Program.InventoryCaptions[2] == InventoryItems.CandleLit)
                            {
                                c.Print("\n With the candle now in hand, your vision improves.");
                                c.Pause();

                                Storyline.PartI();
                            }
                        }
                        else
                        {
                            c.Print("\n You already have that.^");
                        }

                        break;

                    default:
                        foreach (string obj in objects)
                        {
                            if (obj == "match" && opt2 == "match")
                            {
                                TakeMethods.ITEM(1);
                            }
                            else if (obj == "water" && opt2 == "water")
                            {
                                TakeMethods.water();
                            }
                            else if (obj == "lamp" && (opt2 == "lamp" || opt2 == "oil"))
                            {
                                Use_Methods.lamp();
                            }
                            else if (obj == "rope" && opt2 == "rope")
                            {
                                c.Print("\n You grab onto the rope and climb up onto the deck.");
                                c.Pause();
                                Up.Run("u", "", "D1");
                            }
                            else if (obj == "rope2" && opt2 == "rope")
                            {
                                c.Print("\n The rope is tied down securely.^");
                            }
                            else if (obj == "cake" && (opt2 == "cake" || opt2 == "purple"))
                            {
                                c.Print("\n It is too heavy to lift.^");
                            }
                            else if (obj == "telescope" && opt2 == "telescope")
                            {
                                c.Print("\n That would be stealing!^");
                            }
                            else if (obj == "vampire" && (opt2 == "vampire" || opt2 == "bat") && Program.vampireAwake && !Program.vampireGone)
                            {
                                c.Print("\n As you move towards the vampire, it lunges forward and bites you.");
                                c.Pause();
                                Methods.GameOver(false);
                            }
                            else if (obj == "troll" && opt2 == "troll")
                            {
                                c.Print("\n As you move towards the troll, it strikes.\n\n You die before you can even react.");
                                c.Pause();
                                Methods.GameOver(false);
                            }
                            else if (obj == "werewolf" && (opt2 == "werewolf" || opt2 == "were" || opt2 == "wolf"))
                            {
                                c.Print("\n As you move towards the werewolf, it strikes.\n\n You die before you can even react.");
                                c.Pause();
                                Methods.GameOver(false);
                            }
                            else if ((obj == "sphinx" && opt2 == "sphinx") || (obj == "leprechaun" && (opt2 == "leprechaun" || opt2 == "leper")))
                            {
                                c.Print("\n It screeches with fury.^");
                            }
                            else if (obj == "stove" && opt2 == "soup")
                            {
                                Eat_Methods.soup();
                            }
                            else if (obj == "steps" && (opt2 == "stairs" || opt2 == "steps" || opt2 == "staircase"))
                            {
                                c.Print("\n Which direction?^");
                            }
                            else if (obj == "kettle" && opt2 == "kettle")
                            {
                                c.Print("\n It is too heavy for you to lift.\n Perhaps you could take the tea instead.^");
                            }
                            else if (obj == "tea" && opt2 == "tea")
                            {
                                TakeMethods.tea();
                            }
                            else if (obj == "cheese" && (opt2 == "moldy" || opt2 == "cheese"))
                            {
                                c.Print("\n You would rather not touch the moldy cheese.^");
                            }
                            else if (obj == "flute" && opt2 == "flute")
                            {
                                TakeMethods.ITEM(8);
                            }
                            else if (obj == "rug" && (opt2 == "oriental" || opt2 == "rug"))
                            {
                                Use_Methods.rug();
                            }
                            else if (obj == "rug2" && (opt2 == "oriental" || opt2 == "rug"))
                            {
                                c.Print("\n You are on top of it.^");
                            }
                            else if (obj == "bread" && (opt2 == "bread" || opt2 == "loaf" || opt2 == "slice" || opt2 == "slices" || opt2 == "garlic"))
                            {
                                TakeMethods.bread();
                            }
                            else if (obj == "snake" && opt2 == "snake")
                            {
                                if (Program.pyAwake)
                                {
                                    Storyline.SnakeBite();
                                }
                                else
                                {
                                    c.Print("\n You grab the snake, causing it to awaken.^");
                                    Storyline.WakeUpSnake();
                                }

                                c.Print("^");
                            }
                            else if (obj == "coffee" && (opt2 == "coffee" || opt2 == "mug" || opt2 == "cup"))
                            {
                                c.Print("\n The coffee is poisoned.\n It would not be wise to take it or drink it.^");
                            }
                            else if (obj == "k_sink" && opt2 == "sink")
                            {
                                c.Print("\n Do you really need everything and the kitchen sink?^");
                                Program.pregunta = 1;
                            }
                            else if ((obj == "computer" && opt2 == "computer") || (obj == "computer" && opt2 == "cpu") || (obj == "computer" && opt2 == "pc"))
                            {
                                c.Print("\n The computer has many cables and parts.\n It would be too difficult to take.^");
                            }
                            else if ((obj == "purple" && opt2 == "strange") || (obj == "purple" && opt2 == "blue"))
                            {
                                c.Print("\n That would be stealing!^");
                            }
                            else if (obj == "spellbook" && (opt2 == "spellbook" || opt2 == "spell"))
                            {
                                c.Print("\n That would be stealing!^");
                            }
                            else if (obj == "atlas" && opt2 == "atlas")
                            {
                                c.Print("\n As you move towards the atlas, a brilliant light shines from it pages.^");
                            }
                            else if (obj == "poetry" && (opt2 == "poetry" || opt2 == "poem"))
                            {
                                c.Print("\n As you move towards the poetry book, a brilliant light shines from it pages.^");
                            }
                            else if (obj == "cookbook" && (opt2 == "cookbook" || opt2 == "cook"))
                            {
                                c.Print("\n That would be stealing!^");
                            }
                            else if (obj == "chandelier" && opt2 == "chandelier")
                            {
                                c.Print("\n It is too high for you to reach.^");
                            }
                            else if (obj == "chandelier2" && opt2 == "chandelier")
                            {
                                TakeMethods.chandelier();
                            }
                            else if ((obj == "table" || obj == "table2") && opt2 == "table")
                            {
                                c.Print("\n It is too heavy to lift.^");
                            }
                            else if (obj == "calendar" && opt2 == "calendar")
                            {
                                c.Print("\n It is tacked to the wall.^");
                            }
                            else if (obj == "calendar" && (opt2 == "tack" || opt2 == "tacks"))
                            {
                                c.Print("\n The tack is too far into the wall.^");
                            }
                            else if (obj == "map" && opt2 == "map")
                            {
                                c.Print("\n It is tacked to the wall.^");
                            }
                            else if (obj == "map" && (opt2 == "tack" || opt2 == "tacks"))
                            {
                                c.Print("\n The tacks are too far into the wall.^");
                            }
                            else if (obj == "wheel" && (opt2 == "wheel" || opt2 == "steering"))
                            {
                                Use_Methods.wheel();
                            }
                            else if (obj == "box" && opt2 == "box")
                            {
                                TakeMethods.ITEM(9);
                                c.Print("\n You hastily walk north after taking the box to avoid the guards.");
                                c.Pause();
                                Storyline.PartXXIII();
                            }
                            else if (obj == "crate" && opt2 == "crate")
                            {
                                TakeMethods.ITEM(10);
                                c.Print("\n You hastily walk north after taking the crate to avoid the guards.");
                                c.Pause();
                                Storyline.PartXXIII();
                            }
                            else if (obj == "tomatoes" && (opt2 == "tomatoes" || opt2 == "tomato"))
                            {
                                c.Print("\n They are too heavy to lift for a weakling such as yourself.^");
                            }
                            else if (obj == "apple" && opt2 == "apple")
                            {
                                TakeMethods.ITEM(3);
                            }
                            else if (obj == "cards" && (opt2 == "cards" || opt2 == "card" || opt2 == "deck"))
                            {
                                c.Print("\n That would be stealing!^");
                            }
                            else if (obj == "floppy" && (opt2 == "floppy" || opt2 == "disk" || opt2 == "disc" || opt2 == "diskette"))
                            {
                                TakeMethods.floppy();
                            }
                            else if (obj == "bird" && opt2 == "bird")
                            {
                                c.Print("\n The bird jumps away from you as you reach out to grab it.\n\n You notice a particularly long feather portruding from its back.^");
                            }
                            else if (obj == "feather" && opt2 == "feather")
                            {
                                TakeMethods.feather();
                            }
                            else if (obj == "crate2" && opt2 == "crate")
                            {
                                c.Print("\n You are inside of it.^");
                            }
                            else if (obj == "blackberry" && (opt2 == "blackberry" || opt2 == "black" || opt2 == "berry"))
                            {
                                TakeMethods.ITEM(12);
                            }
                        }

                        break;
                }
            }

            if (opt1 == "remove")
            {
                if (opt2 == "shirt" || opt2 == "pants" || opt2 == "clothes" || opt2 == "clothing" || opt2 == "pant" || opt2 == "shoe" || opt2 == "shoes" || opt2 == "underwear" || opt2 == "sock" || opt2 == "socks")
                {
                    c.Print("\n No.^");
                }

                if (opt2 == string.Empty)
                {
                    c.Print("\n You do not know what to " + opt1 + ".^");
                    return;
                }

                foreach (string obj in objects)
                {
                    if (obj == "calendar" && opt2 == "calendar")
                    {
                        c.Print("\n It is tacked to the wall.^");
                    }
                    else if (obj == "calendar" && (opt2 == "tack" || opt2 == "tacks"))
                    {
                        c.Print("\n The tack is too far into the wall.^");
                    }
                    else if (obj == "map" && opt2 == "map")
                    {
                        c.Print("\n It is tacked to the wall.^");
                    }
                    else if (obj == "map" && (opt2 == "tack" || opt2 == "tacks"))
                    {
                        c.Print("\n The tacks are too far into the wall.^");
                    }
                    else if (obj == "floppy" && (opt2 == "floppy" || opt2 == "disk" || opt2 == "diskette"))
                    {
                        if (Program.Inventory[11] == 0)
                        {
                            c.Print("\n It is jammed in the disk drive and cannot be removed.^");
                        }
                        else
                        {
                            c.Print("\n You already have that.^");
                        }
                    }
                    else if (obj == "feather" && opt2 == "feather")
                    {
                        TakeMethods.feather();
                    }
                    else if (obj == "blackberry" && (opt2 == "blackberry" || opt2 == "black" || opt2 == "berry"))
                    {
                        TakeMethods.ITEM(12);
                    }
                }
            }

            if (opt1 == "pluck" || opt1 == "pick")
            {
                if (opt2 == string.Empty)
                {
                    c.Print("\n You do not know what to " + opt1 + ".^");
                    return;
                }

                foreach (string obj in objects)
                {
                    if (obj == "feather" && opt2 == "feather")
                    {
                        TakeMethods.feather();
                    }
                    else if (obj == "blackberry" && (opt2 == "blackberry" || opt2 == "black" || opt2 == "berry"))
                    {
                        TakeMethods.ITEM(12);
                    }
                }
            }
        }
    }
}
