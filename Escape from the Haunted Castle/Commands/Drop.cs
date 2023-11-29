// Drop.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using HauntedCastle.Commands.Variables_and_References;

namespace HauntedCastle.Commands
{
    public class Drop
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string room, string[] objs)
        {
            List<string> objects = new List<string>();

            objects.AddRange(objs);

            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            for (int i = 0; i < objects.Count; i++)
            {
                objects[i] = objects[i].ToLower();
            }

            if ((opt1 == "drop" && opt2 == "roll") || (opt1 == "stop" && opt2 == "drop") || opt1 == "roll")
            {
                c.Print("\n It is always good to be prepared in case of a fire.^");
            }

            if (opt1 == "drop" || opt1 == "spill" || opt1 == "pour" || opt1 == "throw" || opt1 == "toss" || opt1 == "j")
            {
                if (opt2 == "")
                {
                    string text = opt1;

                    if (opt1 == "j")
                    {
                        text = "drop";
                    }

                    c.Print("\n You do not know what to " + text + ".^");
                }

                if (opt2 == "water")
                {
                    DropMethods.water(room);
                }

                if (opt2 == "tea")
                {
                    DropMethods.tea(room);
                }

                foreach (string obj in objects)
                {
                    if (obj == "coffee" && opt2 == "coffee")
                    {
                        DropMethods.coffee();
                    }
                }
            }

            if (opt1 == "drop" || opt1 == "throw" || opt1 == "toss" || opt1 == "j")
            {
                switch (opt2)
                {
                    case "magic":
                    case "staff":
                    case "compass":
                    case "leather":
                    case "bag":
                        c.Print("\n It would be wise to keep that.^");
                        break;

                    case "crumbs":
                    case "breadcrumbs":
                    case "crumb":
                    case "breadcrumb":
                    case "handful":
                        if (Program.ateBread)
                        {
                            if (Program.ROOM == "Z")
                            {
                                if (Program.breadcrumbs[Program.mazeIdx])
                                {
                                    c.Print("\n You have already dropped breadcrumbs here.^");
                                }
                                else
                                {
                                    c.Print("\n You drop some breadcrumbs on the ground to form a trail.^");

                                    Program.breadcrumbs[Program.mazeIdx] = true;
                                    Score.Addition(Score.U_Jungle);
                                }
                            }
                            else
                            {
                                c.Print("\n That would be littering!^");
                            }
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
                        if (Program.ROOM == "C5")
                        {
                            DropMethods.gold();
                        }
                        else
                        {
                            DropMethods.ITEM(0);
                        }

                        break;

                    case "silver":
                    case "key":
                        if (Program.ROOM == "J3" && Program.Inventory[5] == 1)
                        {
                            DropMethods.silver_key();
                        }
                        else
                        {
                            DropMethods.ITEM(5);
                        }

                        break;

                    case "monocle":
                    case "lens":
                        if (Program.ROOM == "J3" && Program.Inventory[15] == 1)
                        {
                            DropMethods.monocle();
                        }
                        else
                        {
                            DropMethods.ITEM(15);
                        }

                        break;

                    case "candle":
                        DropMethods.ITEM(2);
                        break;

                    case "apple":
                        DropMethods.ITEM(3);
                        break;

                    case "shirt":
                    case "pants":
                    case "pant":
                    case "clothes":
                    case "clothing":
                    case "shoes":
                    case "shoe":
                    case "underwear":
                    case "sock":
                    case "socks":
                        c.Print("\n No.^");
                        break;

                    case "seed":
                    case "seeds":
                    case "appleseed":
                    case "appleseeds":
                        DropMethods.seeds();
                        break;

                    case "shield":
                        DropMethods.ITEM(6);
                        break;

                    case "recipe":
                        DropMethods.ITEM(7);
                        break;

                    case "box":
                        DropMethods.ITEM(9);
                        break;

                    case "crate":
                        DropMethods.ITEM(10);
                        break;

                    case "flute":
                        DropMethods.ITEM(8);
                        break;

                    case "match":
                        DropMethods.match();
                        break;

                    case "newspaper":
                    case "news":
                    case "paper":
                        DropMethods.ITEM(16);
                        break;

                    case "garlic":
                    case "bread":
                    case "loaf":
                    case "slice":
                    case "slices":
                        DropMethods.bread(room);
                        break;

                    case "floppy":
                    case "disk":
                    case "disc":
                    case "diskette":
                        DropMethods.ITEM(11);
                        break;

                    case "feather":
                        DropMethods.ITEM(13);
                        break;

                    case "blackberry":
                    case "black":
                    case "berry":
                        if (Program.Inventory[12] == 1 && Program.ROOM == "D8")
                        {
                            c.Print("\n You place the blackberry in front of the three rats.");

                            Program.Inventory[12]--;

                            if (!Program.ratsGone)
                            {
                                Score.Addition(Score.P4_RatsEatCheese);
                                Score.Addition(Score.P5_PlayFlute);
                                Score.Addition(Score.J);

                                Program.ratsGone = true;
                                Program.ogAsleep = true;

                                c.Print("\n The rats nibble on the blackberry and are immediately poisoned.\n\n They faint.\n\n With the rat problem handled, the cyclops is able to rest.^");
                            }
                        }

                        break;

                    default:
                        foreach (string obj in objects)
                        {
                            if (obj == "cards" && (opt2 == "cards" || opt2 == "card" || opt2 == "deck"))
                            {
                                DropMethods.cards();
                            }
                            else if (obj == "computer" && (opt2 == "computer" || opt2 == "pc" || opt2 == "cpu"))
                            {
                                DropMethods.computer();
                            }
                            else if (obj == "drawbridge" && (opt2 == "drawbridge" || opt2 == "bridge"))
                            {
                                OpenMethods.drawbridge();
                            }
                            else if (obj == "cheese" && (opt2 == "moldy" || opt2 == "cheese"))
                            {
                                c.Print("\n You would rather not touch the moldy cheese.^");
                            }
                            else if (obj == "kettle" && opt2 == "kettle")
                            {
                                c.Print("\n The kettle slips from your hands,\n but you catch it just before the fine porcelain shatters.^");
                            }
                            else if (obj == "coffee" && (opt2 == "cup" || opt2 == "mug"))
                            {
                                c.Print("\n The cup slips from your hands, but you catch it before it shatters.^");
                            }
                            else if (obj == "lamp" && (opt2 == "lamp" || opt2 == "oil"))
                            {
                                Use_Methods.lamp();
                            }
                        }

                        break;
                }
            }
        }
    }
}
