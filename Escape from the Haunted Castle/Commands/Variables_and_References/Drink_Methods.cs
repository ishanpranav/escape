using System;

namespace haunted_castle.Commands.Variables_and_References
{
    public class Drink_Methods
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void water()
        {
            if (Program.InventoryCaptions[4] == InventoryItems.BagWater || Program.ROOM == "PartXV" || Program.ROOM == "PartXXXI")
            {
                if (Program.ROOM != "PartXV" && Program.ROOM != "PartXXXI")
                    Program.InventoryCaptions[4] = InventoryItems.Bag;

                c.Print("\n You have a drink of water.^");

                if (!Program.drankWater)
                {
                    Program.drankWater = true;
                    Methods.SetPermanentHealth(Program.PermanentHealth + 30);
                }
                else
                    Methods.SetPermanentHealth(Program.PermanentHealth + 15);

                Methods.SetPermanentHealth(Program.PermanentHealth + 30);

                c.Print("\n Ahh.\n\n The water is very refreshing.\n It replenishes some of your health and gives you strength.");

                if (Program.State[2])
                    c.Print("\n It also cures your injury.");

                c.Print("^");

                Program.State[3] = false;
                Program.IsInvisible = false;
            }
            else
                c.Print("\n You do not have that.^");
        }

        public static void coffee()
        {
            Methods.SetPermanentHealth(Program.PermanentHealth - 15);

            c.Print("\n Bleh!\n\n The coffee is poisoned.\n\n You are slowly becoming weaker.^");

            Program.State[3] = true;
        }

        public static void tea()
        {
            if (Program.InventoryCaptions[4] == InventoryItems.BagTea || Program.ROOM == "R3")
            {
                c.Print("\n You have a spot of tea.^");

                if (Program.ROOM != "R3")
                    Program.InventoryCaptions[4] = InventoryItems.Bag;

                if (!Program.drankWater)
                {
                    Program.drankWater = true;
                    Methods.SetPermanentHealth(Program.PermanentHealth + 30);
                }
                else
                    Methods.SetPermanentHealth(Program.PermanentHealth + 15);

                Methods.SetPermanentHealth(Program.PermanentHealth + 30);

                c.Print("\n Ahh.\n\n The tea is very refreshing.\n It replenishes some of your health and gives you strength.^");

                if (Program.State[3])
                {
                    c.Print("\n You are cured of poisoning.^");
                    Program.State[3] = false;
                }
            }
            else
                c.Print("\n You do not have that.^");
        }

        public static void spit()
        {
            if (!Program.spit)
            {
                Program.spit = true;
                Score.Addition(Score.J);
            }

            if (!Program.drankWater)
            {
                c.Print("\n You swallow your saliva for a while to quench your thirst.^");

                Program.drankWater = true;

                Score.Addition(Score.E_DrinkWater);
            }
            else
                c.Print("\n You spit.\n\n How unhygienic.^");
        }
    }
}
