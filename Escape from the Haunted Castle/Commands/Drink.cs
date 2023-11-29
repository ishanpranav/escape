// Drink.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace HauntedCastle.Commands
{
    public class Drink
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string[] liqs)
        {
            List<string> liquids = new List<string>();

            liquids.AddRange(liqs);
            liquids.Add("y=mx+b");

            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            for (int i = 0; i < liquids.Count; i++)
            {
                liquids[i] = liquids[i].ToLower();
            }

            switch (opt1)
            {
                case "drink":
                case "chug":
                case "sip":
                    switch (opt2)
                    {
                        case "":
                        case "drink":
                            c.Print("\n You do not know what to " + opt1 + ".^");
                            break;

                        case "spit":
                        case "saliva":
                        case "drool":
                            Drink_Methods.spit();
                            break;

                        case "me":
                        case "myself":
                        case "self":
                            c.Print("\n You do not have a blender or juicer.^");
                            break;

                        case "water":
                            Drink_Methods.water();
                            break;

                        case "tea":
                            Drink_Methods.tea();
                            break;

                        default:
                            foreach (string obj in liquids)
                            {
                                if (obj == "coffee" && opt2 == "coffee")
                                {
                                    Drink_Methods.coffee();
                                }
                                else if (obj == "stove" && opt2 == "soup")
                                {
                                    Eat_Methods.soup();
                                }
                            }

                            break;
                    }

                    break;
            }
        }
    }
}
