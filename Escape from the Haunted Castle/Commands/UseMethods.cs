// UseMethods.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;

namespace HauntedCastle.Commands.Variables_and_References
{
    public class Use_Methods
    {
        // Declarations
        private static readonly GUI.Display c = new GUI.Display();

        public static void stoveToCook()
        {
            if (Program.Inventory[7] == 1)
            {
                if (Program.State[1])
                {
                    Program.State[1] = false;
                    Methods.SetPermanentHealth(100);
                    c.Print("\n You follow the recipe and cook a soup using a few of the tomatoes.^");
                    c.Print("\n Mmm... Delicious!");
                    c.Print("\n\n You yawn. You are no longer hungry, but still very tired.^");
                }
                else
                {
                    c.Print("\n You are not hungry.^");
                }
            }
            else
            {
                c.Print("\n There are ingredients here to cook anything,\n but you have no recipe to follow.^");
            }
        }

        public static void sinkToWash()
        {
            c.Print("\n After using the sink, you notice that there is a strange\n gold tint to the water.\n\n It does not seem harmful, so you think little of it.^");
        }

        public static void sinkToWashhands()
        {
            if (!Program.washedHands)
            {
                Score.Addition(Score.J); // J.WashHands
            }

            Program.washedHands = true;

            c.Print("\n You wash your hands and face.\n\n How overly hygienic of you.^");
            sinkToWash();
        }

        public static void sinkToWashtomatoes()
        {
            if (!Program.washedTomatoes)
            {
                Score.Addition(Score.J); // WashTomatoes
            }

            Program.washedTomatoes = true;

            c.Print("\n You wash the tomatoes before eating them.\n\n How overly hygienic of you.^");
            sinkToWash();
        }

        public static void nose()
        {
            if ((Program.pyAwake && !Program.ROOM.StartsWith("#")) || Program.ROOM == "R24")
            {
                c.Print("\n Sniff.\n\n You can smell the scent of an ancient snake.^");
            }
            else if (Program.ROOM == "PartXXXI")
            {
                c.Print("\n Sniff.\n\n You can smell the lingering scent of horses.^");
            }
            else if (Program.Inventory[14] > 0)
            {
                c.Print("\n Sniff.\n\n You can smell the pungent odor of garlic.^");
            }
            else if (Program.ateBread)
            {
                c.Print("\n Sniff.\n\n You can smell the pungent, garlic-scented odor of your breath.^");
            }
            else if ((Program.ratsGone && !Program.ogAsleep) || (Program.ogAsleep && Program.ROOM == "DX"))
            {
                c.Print("\n Sniff.\n\n You can smell the scent of rats.^");
            }
            else
            {
                c.Print("\n Sniff.\n\n You cannot smell anything out of the ordinary.^");
            }
        }

        public static void ears()
        {
            if ((Program.pyAwake && !Program.ROOM.StartsWith("#")) || Program.ROOM == "R24")
            {
                c.Print("\n Listening carefully, you hear the menacing hiss of a snake.^");
            }
            else if (Program.ROOM == "PartXXIV")
            {
                c.Print("\n Listening carefully, you hear footsteps.^");
            }
            else if (Program.ROOM == "PartXXXI" || Program.ROOM == "PartXXXIII" || Program.ROOM == "PartXXXV" || Program.ROOM.StartsWith("Y"))
            {
                c.Print("\n Listening carefully, you hear the chirping of a bird.^");
            }
            else if (Program.ROOM.StartsWith("D") && Program.ROOM != "D1")
            {
                c.Print("\n Listening carefully, you hear the scurrying of rats.^");
            }
            else
            {
                c.Print("\n Silence.^");
            }
        }

        public static void cards()
        {
            c.Print("\n You are so bored that you decide to play a card game against yourself.^");
        }

        public static void monocle()
        {
            if (Program.Inventory[15] == 1)
            {
                if (Program.InventoryCaptions[15] == InventoryItems.MonocleLens)
                {
                    c.Print("\n Done.^");
                }
                else if (Program.ROOM == "D6")
                {
                    c.Print("\n You place the monocle on the telescope, using it as a lens.^");
                    Program.InventoryCaptions[15] = InventoryItems.MonocleLens;
                    Score.Addition(Score.P6_UseMonocleAsLens);
                }
                else
                {
                    c.Print("\n You wear the monocle.\n\n The cyclops's perscription is far worse than yours.\n Your head begins to ache, so you take it off.^");
                }
            }
            else
            {
                c.Print("\n You do not have that.^");
            }
        }

        public static void telescope()
        {
            if (Program.InventoryCaptions[15] == InventoryItems.MonocleLens)
            {
                c.Print("\n You look in the telescope.^");

                if (Program.mapRead)
                {
                    if (Program.useTel)
                    {
                        c.Print("\n According to the stars, the ship is " + Program.degrees + " degrees of course.^");
                    }
                    else
                    {
                        Program.useTel = true;
                        Score.Addition(Score.P7_UseTelescope);

                        c.Print("\n You find the stars pictured on the map\n and realize that the ship is currently " + Program.degrees + " degrees off course.\n\n You will need to turn the ship quickly to make it home.^");
                    }
                }
                else
                {
                    c.Print("\n The sky is beautiful, but you do not know what you are looking for.^");
                }
            }
            else
            {
                c.Print("\n The telescope is missing a lens.^");
            }
        }

        public static void computer()
        {
            if (Program.computerBroken || Program.computerDropped)
            {
                c.Print("\n You try to turn on the computer but it does not start.^");
            }
            else
            {
                if (Minigames.Computer.Start())
                {
                    if (Program.Inventory[11] == 0)
                    {
                        Score.Addition(Score.J); // J.EjectFloppy
                    }

                    Program.Inventory[11] = 1;

                    c.Clear(true);
                    c.Print("\n As the computer shuts down, a small floppy disk shoots out of the disk drive\n very roughly, making the drive unusable.\n\n You remove the disk and keep it.");
                    c.Pause();
                }

                FileSystem.SaveData();
                FileSystem.TRAVELTO();
            }
        }

        public static void television()
        {
            if (Program.ROOM.StartsWith("#"))
            {
                if (Minigames.Television.Start())
                {
                    c.Clear(true);
                    c.Print("\n Hours of television-watching have caused your eyes to ache.\n\n You close your eyes for a while and imagine a blinding light.\n\n You are rapidly transported through space and time to continue your journey.");
                    c.Pause();
                    Program.ROOM = Program.ROOM.Replace("#", "");
                }
            }
            else
            {
                _ = Minigames.Television.Start();
            }

            FileSystem.SaveData();
            FileSystem.TRAVELTO();
        }

        public static void box()
        {
            Program.Inventory[9] = 0;

            c.Print("\n You realize that you can use the box as a raft to cross the moat.\n You enter the box and use your hands as paddles to push it across\n the water.^");
            c.Print("\n The idea seems to work, except for the fact\n that the carboard becomes wet and soggy.\n Your makeshift vessel tears and begins to sink,\n taking you to the bottom of the ocean with it.");
            c.Pause();
            Methods.GameOver(false);
        }

        public static void crate()
        {
            Program.Inventory[10] = 0;

            Score.Addition(Score.G2_UseCrate);

            c.Print("\n You realize that you can use the crate as a raft to cross the moat.\n You enter the crate and use your hands as paddles to push it across\n the water.");
            c.Pause();
            Storyline.PartXXVII();
        }

        private static void MakePermit()
        {
            if (Program.InventoryCaptions[13] == InventoryItems.FeatherPen &&
                    Program.InventoryCaptions[12] == InventoryItems.BlackberryInk &&
                    Program.InventoryCaptions[7] == InventoryItems.RecipePaper)
            {
                Program.InventoryCaptions[7] = InventoryItems.RecipePaperUsed;

                c.Print("\n You dip the feather into the blackberry juice\n and begin to forge a permit on the back of the recipe.^");
                c.Print("\n You hear loud footsteps.\n The guards will be here soon.^");
                c.Print("\n The permit is complete.^");
            }
        }

        public static void recipeAsPaper()
        {
            if (Program.InventoryCaptions[7] != InventoryItems.RecipePaperApproved && Program.InventoryCaptions[7] != InventoryItems.RecipePaperUsed && Program.InventoryCaptions[7] != InventoryItems.RecipePaper)
            {
                c.Print("\n You realize that you can use the recipe as a piece of paper.\n\n You turn it over to the blank side.^");

                Program.InventoryCaptions[7] = InventoryItems.RecipePaper;

                Score.Addition(Score.H5_UseRecipeAsPaper);

                MakePermit();
            }
            else
            {
                c.Print("\n Done.^");
            }
        }

        public static void blackberryAsInk()
        {
            if (Program.InventoryCaptions[7] != InventoryItems.RecipePaperApproved && Program.InventoryCaptions[7] != InventoryItems.RecipePaperUsed && Program.InventoryCaptions[12] != InventoryItems.BlackberryInk)
            {
                c.Print("\n You realize that you can use the blackberry juice as ink.\n\n You squeeze it partially.^");

                Program.InventoryCaptions[12] = InventoryItems.BlackberryInk;

                Score.Addition(Score.H6_UseBlackberryAsInk);

                MakePermit();
            }
            else
            {
                c.Print("\n Done.^");
            }
        }

        public static void featherAsPen()
        {
            if (Program.InventoryCaptions[7] != InventoryItems.RecipePaperApproved && Program.InventoryCaptions[7] != InventoryItems.RecipePaperUsed && Program.InventoryCaptions[13] != InventoryItems.FeatherPen)
            {
                c.Print("\n You realize that you can use the feather as a quill pen.\n\n You sharpen the tip.^");

                Program.InventoryCaptions[13] = InventoryItems.FeatherPen;

                Score.Addition(Score.H7_UseFeatherAsPen);

                MakePermit();
            }
            else
            {
                c.Print("\n Done.^");
            }
        }

        public static void featherToTickle()
        {
            c.Print("\n You use the feather to tickle the dragon's nose.\n\n \"Ah- Ah- Ah-\"\n\n Politely covering its mouth with a batlike wing,\n the dragon sneezes so violently that it almost knocks you down.\n\n A burst of flame erupts from its sinuses,\n and the dragon's wing is severely burned.");
            c.Pause();
            Score.Addition(Score.X_Dragon);
            Score.Addition(Score.X_Tickle);
            Storyline.DestroyDragon();
        }

        public static void flute()
        {
            if (Program.Inventory[8] == 1 || Program.ROOM == "R7A")
            {
                c.Print("\n You play a simple tune on the flute.^");

                if (Program.ROOM == "R8" && Program.pyAwake)
                {
                    c.Print("\n The enchanting music causes the snake's eyelids to droop.\n It yawns, reminding you of its vicious fangs and huge jaws.\n Soon, it begins to curl up and fall back asleep.^");

                    Program.pyAwake = false;
                }

                if (Program.ROOM == "PartXXXV" && Program.Inventory[3] == 0 && Program.InventoryCaptions[3] == InventoryItems.Seeds)
                {
                    c.Print("\n The bird is enchanted by the sweet-sounding music.^");
                }
                else if (Program.ROOM == "PartXXXV")
                {
                    c.Print("\n The bird is enchanted by the sweet-sounding music.\n It starts to fall asleep, then remembers how hungry it is.^");
                }
                else if (Program.ROOM == "D1")
                {
                    c.Print("\n The music is not loud enough for the captain to hear.^");
                }
                else if (Program.ROOM.StartsWith("D") && Program.ROOM != "D1")
                {
                    c.Print("\n Three rats run towards you, enchanted by the beautiful music.^");

                    Program.ratsGone = true;

                    if (Program.ROOM == "DX" && !Program.ogAsleep)
                    {
                        c.Print("\n They begin to nibble on the cheese,\n which will occupy them for a while.^");

                        Program.ogAsleep = true;
                        Score.Addition(Score.P4_RatsEatCheese);
                    }
                }
            }
        }

        public static void lamp()
        {
            if (Program.caseOpen)
            {
                c.Print("\n As your hand rubs against the lamp, a lazy, overweight genie appears.\n\n \"Hey!\n\n  I thought I told you to stop asking me for help!");

                if (!Program.lampUsed)
                {
                    Score.Addition(Score.M4_RubLamp);

                    c.Print("\n\n  Oh, a new master? What do you want?\n\n  Actually, never mind. I don't have time for this.\n  I'll tell you what - why don't you just\n  take this gold coin and leave me alone, okay?");
                }
                else if (Program.Inventory[0] == 0)
                {
                    c.Print("\n\n  Here, just take another coin and get lost.");
                }

                c.Print("\"^");

                if (!Program.lampUsed || Program.Inventory[0] == 0)
                {
                    Program.lampUsed = true;
                    Program.Inventory[0] += 2;

                    c.Print("\n You keep the gold coin and the genie disappears.^");
                }
                else
                {
                    c.Print("\n The genie disappears.^");
                }
            }
            else
            {
                c.Print("\n It is inside of the closed display case.^");
            }
        }

        public static void rug()
        {
            if (Program.lampUsed)
            {
                Score.Addition(Score.M_ObtainRug);

                c.Print("\n The rug begins to float upwards.");
                c.Pause();
                Storyline.C1();
            }
            else
            {
                c.Print("\n The rug floats upwards, then floats back down again.^");
            }
        }

        public static void wheel()
        {
            if (Program.useTel)
            {
                if (Program.minutes == 0)
                {
                    c.Print("\n You turn it a specific number of degrees.^");

                    c.StyleAlt("Enter a number of degrees:");

                    int degree;
                    try
                    {
                        degree = Convert.ToInt32(c.ReadLine().ToLower().Replace("degrees", "").Replace("degree", ""));
                    }
                    catch
                    {
                        c.Print("\n\n Hmm... That will not work!\n\n The steering wheel must be turned a specific number of degrees.^");
                        return;
                    }

                    c.Print("\n\n You turn the steering wheel " + degree.ToString() + " degrees.^");

                    if (degree == Program.degrees)
                    {
                        Program.minutes = 1;
                        Score.Addition(Score.P_TurnWheel);

                        c.Print("\n The ship is now on course.\n\n It begins to sail home.^");
                    }
                }
                else
                {
                    c.Print("\n It would be unwise to interfere with the\n ship's course now that you are on your way home.^");
                }
            }
            else
            {
                c.Print("\n It would be unwise to interfere with the\n ship's course without knowing how far to turn the ship.^");
            }
        }
    }
}
