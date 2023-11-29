namespace haunted_castle.Commands.Variables_and_References
{
    public class Take_Methods
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void ITEM(int InventoryIndex)
        {
            if (Program.Inventory[InventoryIndex] > 0)
                c.Print("\n You already have that.^");
            else
            {
                Program.Inventory[InventoryIndex] = 1;

                if (InventoryIndex == 5)
                    Score.Addition(Score.B1_ObtainKey);
                else if (InventoryIndex == 10)
                    Score.Addition(Score.G1_ObtainCrate);
                else if (InventoryIndex == 12)
                    Score.Addition(Score.H4_ObtainBlackberry);
                else if (InventoryIndex == 8)
                    Score.Addition(Score.L1_ObtainFlute);

                c.Print("\n Taken.^");
            }
        }

        public static void bread()
        {
            if (Program.Inventory[14] == 0)
            {
                c.Print("\n Taken.^");
                Program.Inventory[14] = 6;
            }
            else if (Program.Inventory[14] <= 2)
            {
                c.Print("\n Taken.^");
                Program.Inventory[14]++;
            }
            else
                c.Print("\n You already have that.^");
        }

        public static void water()
        {
            if (Program.InventoryCaptions[4] != InventoryItems.Bag)
                c.Print("\n The leather bag is full and you have no other container for the water.^");
            else
            {
                Program.InventoryCaptions[4] = InventoryItems.BagWater;

                c.Print("\n Your leather bag is now filled with water.^");
            }
        }

        public static void tea()
        {
            if (Program.InventoryCaptions[4] != InventoryItems.Bag)
                c.Print("\n The leather bag is full and you have no other container for the tea.^");
            else
            {
                Program.InventoryCaptions[4] = InventoryItems.BagTea;

                c.Print("\n Your leather bag is now filled with tea.^");
            }
        }

        public static void monocle()
        {
            if (Program.ogAsleep)
            {
                if (Program.Inventory[15] == 0 && Program.InventoryCaptions[15] != InventoryItems.MonocleLens)
                {
                    Program.Inventory[15] = 1;
                    Score.Addition(Score.P8_ObtainMonocle);
                    c.Print("\n Taken.^");
                }
            }
            else
            {
                c.Print("\n As you reach out to grab the cyclops's monocle, he pushes you back.\n\n \"What do ye think yer doing, matey?\"^");
            }
        }

        public static void floppy()
        {
            if (Program.Inventory[11] == 0)
                c.Print("\n The floppy disk is inside of the closed disk drive.^");
            else
                c.Print("\n You already have that.^");
        }

        public static void feather()
        {
            if (Program.Inventory[13] == 0 && Program.Inventory[3] == 0 && Program.InventoryCaptions[3] == InventoryItems.Seeds)
            {
                Program.Inventory[13] = 1;

                c.Print("\n Taken.^");
            }
            else if (Program.Inventory[13] == 0)
                c.Print("\n It is too high for you to reach.^");
            else if (Program.Inventory[13] == 1)
                c.Print("\n You already have that.^");
        }

        public static void chandelier()
        {
            c.Print("\n As you reach out towards the chandelier,\n you lose your balance and fall off of the shelf.");
            c.Pause();

            Methods.GameOver(false);
        }
    }
}
