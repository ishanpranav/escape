// Eat.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace HauntedCastle.Commands
{
    public class Eat
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2, string[] fds)
        {
            List<string> food = new List<string>();

            food.AddRange(fds);
            food.Add("y=mx+b");

            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            for (int i = 0; i < food.Count; i++)
            {
                food[i] = food[i].ToLower();
            }

            if ((opt1 == "eat" || opt1 == "munch" || opt1 == "m" || opt1 == "bite" || opt1 == "peck" || opt1 == "taste") && (opt2 == "seeds" || opt2 == "seed" || opt2 == "appleseed" || opt2 == "appleseeds"))
            {
                Eat_Methods.seeds();
            }

            if (opt1 == "eat" || opt1 == "munch" || opt1 == "m" || opt1 == "bite" || opt1 == "taste")
            {
                switch (opt2)
                {
                    case "":
                    case "food":
                    case "meal":
                        c.Print("\n You do not know what to eat.^");
                        break;

                    case "apple":
                        Eat_Methods.apple();
                        break;

                    case "match":
                        Eat_Methods.match();
                        break;

                    case "newspaper":
                    case "news":
                    case "paper":
                        Eat_Methods.newspaper();
                        break;

                    case "blackberry":
                    case "black":
                    case "berry":
                        Eat_Methods.blackberry();
                        break;

                    case "garlic":
                    case "bread":
                    case "loaf":
                    case "slice":
                    case "slices":
                        Eat_Methods.bread();
                        break;

                    case "crumbs":
                    case "breadcrumbs":
                    case "crumb":
                    case "breadcrumb":
                    case "handful":
                        if (Program.ateBread)
                        {
                            c.Print("\n They are flavorless, but you eat a few nonetheless.^");
                        }

                        break;

                    case "me":
                    case "myself":
                    case "self":
                        c.Print("\n Are you really that hungry?^");
                        c.Print("\n Well... if you insist...^");
                        c.Print("\n You die of autocannibalism.");
                        c.Pause();
                        Methods.GameOver(false);
                        break;

                    case "brain":
                    case "brains":
                        c.Print("\n Are you a zombie?^");
                        Program.pregunta = 4;
                        break;

                    default:
                        foreach (string obj in food)
                        {
                            if ((obj == "tomatoes" && opt2 == "tomatoes") || (obj == "tomatoes" && opt2 == "tomato"))
                            {
                                Eat_Methods.tomatoes();
                            }
                            else if ((obj == "sphinx" && opt2 == "sphinx") || (obj == "leprechaun" && (opt2 == "leprechaun" || opt2 == "leper")))
                            {
                                c.Print("\n It screeches with fury.^");
                            }
                            else if (obj == "cake" && (opt2 == "purple" || opt2 == "cake"))
                            {
                                Eat_Methods.cake();
                            }
                            else if (obj == "stove" && opt2 == "soup")
                            {
                                Eat_Methods.soup();
                            }
                            else if (obj == "snake" && opt2 == "snake")
                            {
                                if (Program.pyAwake)
                                {
                                    Storyline.SnakeBite();
                                }
                                else
                                {
                                    c.Print("\n You bite into the flesh of the snake, causing it to awaken.^");
                                    Storyline.WakeUpSnake();
                                }

                                c.Print("^");
                            }
                            else if (obj == "troll" && opt2 == "troll")
                            {
                                c.Print("\n You bite the troll.\n\n It strikes quickly, too fast for you to react.");
                                c.Pause();
                                Methods.GameOver(false);
                            }
                            else if (obj == "cyclops" && opt2 == "cyclops")
                            {
                                c.Print("\n You bite the cyclops.\n\n It strikes quickly, too fast for you to react.");
                                c.Pause();
                                Methods.GameOver(false);
                            }
                            else if (obj == "werewolf" && (opt2 == "werewolf" || opt2 == "were" || opt2 == "wolf"))
                            {
                                c.Print("\n You bite the werewolf.\n\n It strikes quickly, too fast for you to react.");
                                c.Pause();
                                Methods.GameOver(false);
                            }
                            else if (obj == "dragon" && opt2 == "dragon")
                            {
                                c.Print("\n You bite the dragon.");
                                c.Pause();
                                Storyline.DestroyDragon();
                            }
                            else if (obj == "cheese" && (opt2 == "moldy" || opt2 == "cheese"))
                            {
                                Eat_Methods.cheese();
                            }
                            else if (obj == "vampire" && (opt2 == "vampire" || opt2 == "bat") && Program.vampireAwake && !Program.vampireGone)
                            {
                                Score.Addition(Score.M2_DropBread);

                                Program.vampireGone = true;

                                c.Print("\n You bite the vampire before it can bite you.\n\n It realizes your clever trick, transforms into a human, and runs away.^");
                            }
                        }

                        break;
                }
            }
        }
    }
}
