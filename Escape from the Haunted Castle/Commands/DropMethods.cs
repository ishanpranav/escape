// DropMethods.cs
// Copyright (c) 2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

namespace HauntedCastle.Commands
{
    public class DropMethods
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void ITEM(int InventoryIndex)
        {
            if (Program.Inventory[InventoryIndex] == 0)
            {
                c.Print("\n You do not have that.^");
            }
            else
            {
                c.Print("\n It would be wise to keep that.^");
            }
        }

        public static void match()
        {
            if (Program.Inventory[1] == 0)
            {
                c.Print("\n You do not have that.^");
            }
            else if (Program.ROOM == "T1" && !Program.ateCake)
            {
                Program.Inventory[1] = 0;
                Score.Addition(Score.J);

                c.Print("\n You insert the match into the cake.\n\n Happy birthday!^");
            }
            else
            {
                c.Print("\n It would be wise to keep that.^");
            }
        }

        public static void gold()
        {
            if (Program.Inventory[0] == 0)
            {
                c.Print("\n You do not have that.^");
            }
            else
            {
                Score.Addition(Score.N_DropGold);
                Program.Inventory[0] -= 2;

                if (Program.Inventory[0] < 0)
                {
                    Program.Inventory[0] = 0;
                }

                c.Print("\n You throw a gold coin into the fountain,\n hoping that by some miracle the gate will open.\n\n Your wish comes true: the huge limestone doors begin to slowly\n turn inwards, and a brilliant light shines through the gap.");
                c.Pause();
                c.Print("\n You enter the throne room and the limestone gate closes behind you.");
                c.Pause();
                Storyline.PartXX();
            }
        }

        public static void computer()
        {
            if (Program.computerDropped)
            {
                c.Print("\n It has already been dropped.^");
            }
            else
            {
                Program.computerDropped = true;

                Score.Addition(Score.J); // J.DropComputer

                c.Print("\n Oops.\n\n You drop the computer and it breaks.\n The screen flashes, then turns dark.^");
            }
        }

        public static void bread(string room)
        {
            if (Program.Inventory[14] > 0 && Program.ROOM == "PartXXXV")
            {
                if (Program.Inventory[3] == 0 && Program.InventoryCaptions[3] == InventoryItems.Seeds)
                {
                    c.Print("\n It would be wise to keep that.^");
                }
                else
                {
                    Program.Inventory[14]--;

                    c.Print("\n You place the garlic bread on the ground, attracting the bird.^");
                    c.Print("\n It swoops down from its oak tree, grabs the slice in its beak,\n and flutters back up to the top of the tree again.^");
                }
            }
            else if (Program.pyMoved && Program.Inventory[14] > 0 && room == "PY")
            {
                Program.Inventory[14]--;

                c.Print("\n You place the garlic bread in front of the snake.\n\n \"More garlic bread!\"\n\n The snake devours the slice.\n\n Now if only it would go back to sleep...^");
            }
            else if (room == "PY" && Program.Inventory[14] > 0 && Program.pyAwake)
            {
                Score.Addition(Score.L2_DropBread);

                Program.pyMoved = true;
                Program.Inventory[14]--;

                c.Print("\n You place the garlic bread in front of the snake.\n\n It stares at it intently, carefully examining it.\n\n \"Hmm... I have never ssseen that before...\n\n  What is it?\n\n  Could it be... no... but it is...\n  How did the human get it?\n\n  Garlic bread!\"\n\n The snake slowly devours the slice.\n\n Now if only it would go back to sleep...^");
            }
            else if (Program.Inventory[14] > 0 && room == "V" && Program.vampireGone)
            {
                c.Print("\n The vampire is already gone.^");
            }
            else if (Program.Inventory[14] > 0 && room == "V" && Program.vampireAwake)
            {
                Program.vampireGone = true;

                c.Print("\n You place the garlic bread in front of the vampire.\n\n It takes one sniff and lets out a high-pitched screech.\n Unable to handle the pungent odor, the vampire transforms\n into a bat and flutters away.^");
                c.Print("\n You keep the slice of bread.^");
            }
            else if (Program.Inventory[14] > 0 && Program.ROOM == "D8")
            {
                c.Print("\n You place the garlic bread in front of the three rats.\n\n They run towards you.");

                Program.Inventory[14]--;
                Program.ratsGone = true;

                if (Program.ogAsleep)
                {
                    c.Print("\n The rats quickly snatch up the bread.^");
                }
                else
                {
                    c.Print("\n The rats quickly snatch up the bread,\n then continue to disturb the cyclops.^");
                }
            }
            else if (Program.Inventory[14] > 0)
            {
                c.Print("\n It would be wise to keep that.^");
            }
            else
            {
                c.Print("\n You do not have that.^");
            }
        }

        public static void water(string room)
        {
            if (Program.InventoryCaptions[4] == InventoryItems.BagWater)
            {
                Program.InventoryCaptions[4] = InventoryItems.Bag;

                c.Print("\n Oops.\n\n You spill the water.^");

                if (Program.Inventory[3] == 0 && Program.InventoryCaptions[3] == InventoryItems.Seeds && Program.ROOM == "PartXXXV")
                {
                    if (Program.beans)
                    {
                        c.Print("\n The beanstalk does not need any more water.^");
                    }
                    else
                    {
                        Program.beans = true;
                        Storyline.sky3 = Storyline.sky + "\n A tall beanstalk leads up.";
                        Score.Addition(Score.J * 2);

                        c.Print("\n It splashes onto the seeds, and they begin to sprout.\n\n The plant gradually grows from a tiny seedling into a huge beanstalk.^");
                    }
                }
                else if (Program.ROOM == "U2")
                {
                    c.Print("\n It hits the dragon and extinguishes its flaming breath.");
                    c.Pause();
                    Score.Addition(Score.X_Dragon);
                    Storyline.DestroyDragon();
                }
                else if (room == "COMPUTER_ROOM" && !Program.computerBroken)
                {
                    Program.computerBroken = true;

                    Score.Addition(Score.J * 2); // J.BreakComputer

                    c.Print("\n It hits the computer, which short-circuts.\n The screen flashes, then turns dark.^");
                }
                else if (Program.PannedForGoldTimes < 2)
                {
                    Program.Inventory[0] += 2;
                    Program.PannedForGoldTimes++;

                    Score.Addition(Score.J); // J.DropWater

                    c.Print("\n It splashes everywhere.\n You see a flash of gold as you bend down to grab your bag.^");
                    c.Print("\n Gold dust!\n You form a cup with your hands and scoop up as much as possible.^");
                }

                c.Print("\n The water evaporates.^");
            }
            else
            {
                c.Print("\n You do not have that.^");
            }
        }

        public static void tea(string room)
        {
            if (room == "T" && Program.InventoryCaptions[4] != InventoryItems.BagTea)
            {
                Drop.Run("drop", "kettle", "", new string[] { "kettle" });
            }
            else if (Program.ROOM == "U2" && Program.InventoryCaptions[4] == InventoryItems.BagTea)
            {
                Program.InventoryCaptions[4] = InventoryItems.Bag;

                c.Print("\n It hits the dragon and extinguishes its flaming breath.");
                c.Pause();
                Storyline.DestroyDragon();
            }
            else if (room == "PY" && Program.InventoryCaptions[4] == InventoryItems.BagTea && Program.pyAwake)
            {
                Program.InventoryCaptions[4] = InventoryItems.Bag;

                c.Print("\n Splash.\n\n You spill the tea in front of the snake,\n who hungrily slithers towards it, drinking it from the ground.\n\n \"Tea! My favorite!\n\n  It was tasssty, but I'm not thirsty. I am quite hungry.\n\n  Human looksss nice... but do I even like humans?\n  Perhapsss I will have to tassste it to know for sure.\"^");
            }
            else if (Program.InventoryCaptions[4] == InventoryItems.BagTea)
            {
                Program.InventoryCaptions[4] = InventoryItems.Bag;

                c.Print("\n Oops.\n\n You spill the tea.\n It splashes everywhere, then evaporates.^");
            }
            else
            {
                c.Print("\n You do not have that.^");
            }
        }

        public static void coffee()
        {
            c.Print("\n Oops.\n\n You spill some of the coffee.^");
        }

        public static void cards()
        {
            c.Print("\n Oops.\n\n You drop the deck of cards and have to pick them up one-by-one.^");
        }

        public static void seeds()
        {
            if (Program.Inventory[3] == 1 && Program.InventoryCaptions[3] == InventoryItems.Seeds && Program.ROOM == "PartXXXV")
            {
                Program.Inventory[3] = 0;

                Score.Addition(Score.H2_DropSeeds);

                c.Print("\n You drop the seeds on the ground, attracting the bird.^");
                c.Print("\n It swoops down from its oak tree and pecks at them.^");
            }
            else if (Program.Inventory[3] == 1 && Program.InventoryCaptions[3] == InventoryItems.Seeds)
            {
                c.Print("\n The soil here is not optimal for planting seeds.^");
            }
            else if (Program.Inventory[3] == 1)
            {
                c.Print("\n They are still inside of the uneaten apple.^");
            }
            else
            {
                c.Print("\n You do not have that.^");
            }
        }

        public static void monocle()
        {
            Program.Inventory[15] = 0;

            c.Print("\n You place the monocle onto the sunny area of the floor.^");

            Score.Addition(Score.V1_DropMonocle);

            if (Storyline.CheckLight(false))
            {
                Score.Addition(Score.V_Rainbow);
            }
        }

        public static void silver_key()
        {
            Program.Inventory[5] = 0;

            if (Program.InventoryCaptions[5] == InventoryItems.Silver)
            {
                c.Print("\n You place the lump of silver onto the sunny area of the floor.^");
            }
            else if (Program.InventoryCaptions[5] == InventoryItems.Key)
            {
                c.Print("\n You place the silver key onto the sunny area of the floor.^");
            }

            Score.Addition(Score.V2_DropSilver);

            if (Storyline.CheckLight(false))
            {
                Score.Addition(Score.V_Rainbow);
            }
        }
    }
}
