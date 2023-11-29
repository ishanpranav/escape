// Light.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using HauntedCastle.Commands.Variables_and_References;

namespace HauntedCastle.Commands
{
    public class Light
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string opt3, string opt4, string[] objs)
        {
            List<string> objects = new List<string>();

            objects.AddRange(objs);
            objects.Add("y=mx+b");

            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');
            opt3 = opt3.ToLower().Replace('^', ' ');
            opt4 = opt4.ToLower().Replace('^', ' ');

            for (int i = 0; i < objects.Count; i++)
            {
                objects[i] = objects[i].ToLower();
            }

            if ((opt1 == "light" || opt1 == "burn") && (opt2 == "" || opt2 == "fire"))
            {
                c.Print("\n You do not know what to " + opt1 + ".^");
            }

            if ((opt1 == "light" || opt1 == "burn") && (opt2 == "me" || opt2 == "myself" || opt2 == "self"))
            {
                switch (opt3)
                {
                    case "":
                    case "with":
                    case "using":
                    case "fire":
                        switch (opt4)
                        {
                            case "match":
                                if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed && Program.Inventory[1] > 0)
                                {
                                    c.Print("\n It has already been used.^");
                                }
                                else if (Program.Inventory[1] > 0)
                                {
                                    c.Print("\n You would rather not waste it.^");
                                }
                                else
                                {
                                    c.Print("\n You do not have that.^");
                                }

                                break;

                            case "":
                            case "fire":
                            case "candle":
                                if (Program.Inventory[2] == 1 && Program.InventoryCaptions[2] == InventoryItems.CandleLit)
                                {
                                    c.Print("\n You light yourself on fire with the candle, instantly killing yourself.");
                                    c.Pause();
                                    Methods.GameOver(false);
                                }
                                else if (Program.InventoryCaptions[2] != InventoryItems.CandleLit)
                                {
                                    c.Print("\n You do not have a lit candle.^");
                                }

                                break;
                        }

                        break;
                }
            }

            switch (opt1)
            {
                case "light":
                case "burn":
                    switch (opt2)
                    {
                        case "match":
                            Light_Methods.match();
                            break;

                        case "newspaper":
                        case "paper":
                        case "news":
                            Light_Methods.newspaperWithCandle();
                            break;

                        case "fire":
                        case "castle":
                        case "wall":
                        case "walls":
                            c.Print("\n The walls of the castle are solid and cannot be burned.^");
                            break;

                        case "candle":
                            Light_Methods.candleWithMatch();
                            break;

                        case "rat":
                        case "rats":
                            if ((Program.ROOM != "D1" && (Program.ROOM == "D8" || (Program.ROOM.StartsWith("D") && !Program.ogAsleep && Program.ratsGone))) || (Program.ROOM == "DX" && Program.ogAsleep))
                            {
                                c.Print("\n The three rats jump away from the flame.^");
                            }

                            break;

                        case "snake":
                            switch (opt3)
                            {
                                case "":
                                case "with":
                                case "using":
                                case "fire":
                                    switch (opt4)
                                    {
                                        case "match":
                                            if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed && Program.Inventory[1] > 0)
                                            {
                                                c.Print("\n It has already been used.^");
                                            }
                                            else if (Program.Inventory[1] > 0)
                                            {
                                                c.Print("\n You would rather not waste it.^");
                                            }
                                            else
                                            {
                                                c.Print("\n You do not have that.^");
                                            }

                                            break;

                                        case "":
                                        case "candle":
                                        case "fire":
                                            if (Program.pyAwake)
                                            {
                                                Storyline.SnakeBite();
                                            }
                                            else
                                            {
                                                c.Print("\n You burn the viper using the candle, causing it to awaken.^");
                                                Storyline.WakeUpSnake();
                                            }

                                            c.Print("^");
                                            break;
                                    }

                                    break;
                            }

                            break;

                        case "hair":
                        case "hairs":
                            switch (opt3)
                            {
                                case "":
                                case "with":
                                case "using":
                                case "fire":
                                    switch (opt4)
                                    {
                                        case "match":
                                            if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed && Program.Inventory[1] > 0)
                                            {
                                                c.Print("\n It has already been used.^");
                                            }
                                            else if (Program.Inventory[1] > 0)
                                            {
                                                c.Print("\n You would rather not waste it.^");
                                            }
                                            else
                                            {
                                                c.Print("\n You do not have that.^");
                                            }

                                            break;

                                        case "":
                                        case "candle":
                                        case "fire":
                                            Light_Methods.eyebrowsWithCandle();
                                            break;
                                    }

                                    break;
                            }

                            break;

                        case "key":
                            switch (opt3)
                            {
                                case "":
                                case "with":
                                case "using":
                                case "fire":
                                    switch (opt4)
                                    {
                                        case "match":
                                            if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed && Program.Inventory[1] > 0)
                                            {
                                                c.Print("\n It has already been used.^");
                                            }
                                            else if (Program.Inventory[1] > 0)
                                            {
                                                c.Print("\n You would rather not waste it.^");
                                            }
                                            else
                                            {
                                                c.Print("\n You do not have that.^");
                                            }

                                            break;

                                        case "":
                                        case "candle":
                                        case "fire":
                                            Light_Methods.keyWithCandle();
                                            break;
                                    }

                                    break;
                            }

                            break;

                        default:
                            foreach (string obj in objects)
                            {
                                if (obj == "bars" && (opt2 == "bars" || opt2 == "bar"))
                                {
                                    if (Program.firstprisoncell)
                                    {
                                        switch (opt3)
                                        {
                                            case "":
                                            case "with":
                                            case "using":
                                            case "fire":
                                                switch (opt4)
                                                {
                                                    case "match":
                                                        if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed && Program.Inventory[1] > 0)
                                                        {
                                                            c.Print("\n It has already been used.^");
                                                        }
                                                        else if (Program.Inventory[1] > 0)
                                                        {
                                                            c.Print("\n You would rather not waste it.^");
                                                        }
                                                        else
                                                        {
                                                            c.Print("\n You do not have that.^");
                                                        }

                                                        break;

                                                    case "":
                                                    case "candle":
                                                    case "fire":
                                                        Light_Methods.barsWithCandle();
                                                        break;
                                                }

                                                break;
                                        }
                                    }
                                    else
                                    {
                                        c.Print("\n They are already burnt.^");
                                    }
                                }
                                else if (obj == "crate2" && opt2 == "crate")
                                {
                                    c.Print("\n You see no reason to do that.^");
                                }
                                else if (obj == "crate3" && opt2 == "crate")
                                {
                                    switch (opt3)
                                    {
                                        case "":
                                        case "with":
                                        case "using":
                                        case "fire":
                                            switch (opt4)
                                            {
                                                case "match":
                                                    if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed && Program.Inventory[1] > 0)
                                                    {
                                                        c.Print("\n It has already been used.^");
                                                    }
                                                    else if (Program.Inventory[1] > 0)
                                                    {
                                                        c.Print("\n You would rather not waste it.^");
                                                    }
                                                    else
                                                    {
                                                        c.Print("\n You do not have that.^");
                                                    }

                                                    break;

                                                case "":
                                                case "candle":
                                                case "fire":
                                                    Light_Methods.crateWithCandle();
                                                    break;
                                            }

                                            break;
                                    }
                                }
                                else if (obj == "vampire" && (opt2 == "vampire" || opt2 == "bat") && Program.vampireAwake && !Program.vampireGone)
                                {
                                    c.Print("\n As you move towards the vampire, it jumps away from the light.^");
                                }
                                else if ((obj == "chandelier" || obj == "chandelier2") && opt2 == "chandelier")
                                {
                                    c.Print("\n The chandelier has no bulbs or candles.^");
                                }
                                else if (obj == "lamp" && (opt2 == "lamp" || opt2 == "oil"))
                                {
                                    Use_Methods.lamp();
                                }
                                else if (obj == "bushes" && (opt2 == "bush" || opt2 == "bushes"))
                                {
                                    c.Print("\n The bushes are too large to burn completely.^");
                                }
                                else if (obj == "oak" && (opt2 == "oaks" || opt2 == "oak" || opt2 == "tree" || opt2 == "trees"))
                                {
                                    c.Print("\n The oak trees are too large to burn completely.^");
                                }
                                else if (obj == "troll" && opt2 == "troll")
                                {
                                    c.Print("\n You burn the troll using the candle.\n\n It strikes quickly, too fast for you to react.");
                                    c.Pause();
                                    Methods.GameOver(false);
                                }
                                else if (obj == "dragon" && opt2 == "dragon")
                                {
                                    c.Print("\n You burn the dragon using the candle.");
                                    c.Pause();
                                    Storyline.DestroyDragon();
                                }
                                else if ((obj == "sphinx" && opt2 == "sphinx") || (obj == "leprechaun" && (opt2 == "leprechaun" || opt2 == "leper")))
                                {
                                    c.Print("\n It screeches with fury.^");
                                }
                                else if (obj == "werewolf" && (opt2 == "werewolf" || opt2 == "were" || opt2 == "wolf"))
                                {
                                    c.Print("\n You burn the werewolf using the candle.\n\n It strikes quickly, too fast for you to react.");
                                    c.Pause();
                                    Methods.GameOver(false);
                                }
                                else if (obj == "cyclops" && opt2 == "cyclops")
                                {
                                    c.Print("\n You burn the cyclops using the candle.\n\n It strikes quickly, too fast for you to react.");
                                    c.Pause();
                                    Methods.GameOver(false);
                                }
                                else if ((obj == "computer" && opt2 == "computer") || (obj == "computer" && opt2 == "cpu") || (obj == "computer" && opt2 == "pc"))
                                {
                                    switch (opt3)
                                    {
                                        case "":
                                        case "with":
                                        case "using":
                                        case "fire":
                                            switch (opt4)
                                            {
                                                case "match":
                                                    if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed)
                                                    {
                                                        c.Print("\n It has already been used.^");
                                                    }
                                                    else if (Program.Inventory[1] > 0)
                                                    {
                                                        c.Print("\n You would rather not waste it.^");
                                                    }
                                                    else
                                                    {
                                                        c.Print("\n You do not have that.^");
                                                    }

                                                    break;

                                                case "":
                                                case "candle":
                                                case "fire":
                                                    Light_Methods.computerWithCandle();
                                                    break;
                                            }

                                            break;
                                    }
                                }
                            }

                            break;
                    }

                    break;
            }
        }
    }
}
