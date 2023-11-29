// EatMethods.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

namespace HauntedCastle.Commands
{
    public class Eat_Methods
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void cake()
        {
            if (Program.ateCake)
            {
                c.Print("\n The cake is already finished.^");
            }
            else
            {
                Program.ateCake = true;
                Score.Addition(Score.S_EatCake);

                c.Print("\n Mmm... Delicious!\n\n You eat all of the purple cake.\n\n You begin to shrink.^");
            }
        }

        public static void match()
        {
            if (Program.Inventory[1] == 0)
            {
                c.Print("\n You do not have that.^");
            }
            else
            {
                Program.Inventory[1] = 0;

                c.Print("\n Bleh!\n\n You eat the match.^");
            }
        }

        public static void soup()
        {
            if (!Program.State[1])
            {
                c.Print("\n The soup is already finished.^");
            }
        }

        public static void newspaper()
        {
            if (Program.Inventory[16] == 0)
            {
                c.Print("\n You do not have that.^");
            }
            else
            {
                Program.Inventory[16] = 0;

                c.Print("\n Bleh!\n\n You eat the newspaper.^");
            }
        }
        public static void tomatoes()
        {
            if (Program.State[1])
            {
                c.Print("\n Bleh!\n\n You would rather cook something with the tomatoes\n than eat them raw.^");
            }
            else if (Program.ROOM == "PartXV")
            {
                c.Print("\n You are not hungry.^");
            }
            else
            {
                c.Print("\n Bleh!^");
            }
        }

        public static void cheese()
        {
            c.Print("\n Bleh!\n\n You bite into the obviously rotten cheese.\n The poisonous mold is slowly making you weaker.^");

            Methods.SetPermanentHealth(Program.PermanentHealth - 15);
            Program.State[3] = true;
        }

        public static void apple()
        {
            if ((Program.Inventory[3] == 1 || Program.ROOM == "PartXXXI") && Program.InventoryCaptions[3] == InventoryItems.Apple)
            {
                Program.InventoryCaptions[3] = InventoryItems.Seeds;
                Program.Inventory[3] = 1;

                c.Print("\n Crunch.\n\n You eat the crisp, juicy, red apple and keep its seeds.^");
                Methods.SetPermanentHealth(Program.PermanentHealth + 15);

                Score.Addition(Score.H1_EatApple);

                c.Print("\n It replenishes some of your health and gives you strength.^");
            }
            else if (Program.Inventory[3] == 0 && Program.ROOM != "PartXXXI")
            {
                c.Print("\n You do not have that.^");
            }
        }

        public static void seeds()
        {
            if (Program.Inventory[3] == 1 && Program.InventoryCaptions[3] == InventoryItems.Seeds)
            {
                c.Print("\n Are you a bird?^");
                Program.pregunta = 2;
            }
            else if ((Program.Inventory[3] == 1 || Program.ROOM == "PartXXXI") && Program.InventoryCaptions[3] == InventoryItems.Apple)
            {
                c.Print("\n They are inside of the apple.^");
            }
        }

        public static void blackberry()
        {
            if (Program.Inventory[12] == 1 || Program.ROOM == "PartXXXIV")
            {
                if (Program.InventoryCaptions[12] == InventoryItems.BlackberryInk)
                {
                    c.Print("\n Bleh!\n\n You bite into the blackberry.\n\n It is poisonous and slowly makes you weaker.^");
                }
                else
                {
                    c.Print("\n Bleh!\n\n You eat the entire blackberry.\n\n It is poisonous and slowly makes you weaker.^");
                    Program.Inventory[12] = 0;
                }

                Methods.SetPermanentHealth(Program.PermanentHealth - 15);
                Program.State[3] = true;
            }
        }

        public static void bread()
        {
            if (Program.Inventory[14] > 0 || Program.ROOM == "R6")
            {
                if (Program.ROOM != "R6")
                {
                    Program.Inventory[14]--;
                }

                c.Print("\n Munch.\n\n You eat a slice of garlic bread.^");
                Methods.SetPermanentHealth(Program.PermanentHealth + 5);

                c.Print("\n It replenishes some of your health and gives you strength.^");

                if (!Program.ateBread)
                {
                    Program.ateBread = true;
                    Score.Addition(Score.U1_EatBread);

                    c.Print("\n There are many leftover crumbs, which you keep.^");
                }
            }
            else if (Program.Inventory[14] == 0 && Program.ROOM != "R6")
            {
                c.Print("\n You do not have that.^");
            }
        }
    }
}
