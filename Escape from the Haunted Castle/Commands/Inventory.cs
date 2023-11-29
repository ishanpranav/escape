using System;

namespace haunted_castle.Commands
{
    public class Inventory
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if ((opt1 == "i" || opt1 == "inv" || opt1 == "inventory" || opt1 == "items") && opt2 == string.Empty)
            {
                try
                {
                    c.Print("\n You are carrying: \n");

                    if (Program.Inventory[0] > 0)
                        c.Print(string.Format("\n     {0} g of gold", Program.Inventory[0] * 15.5));

                    if (Program.InventoryCaptions[5] == InventoryItems.Silver && Program.Inventory[5] > 0)
                        c.Print(string.Format("\n     {0} g of silver", Program.Inventory[5] * 15.5));
                    
                    c.Print("\n     a magic staff\n     a compass");

                    if (Program.Inventory[14] == 1)
                        c.Print("\n     a slice of garlic bread");
                    else if (Program.Inventory[14] == 2)
                        c.Print("\n     2 slices of garlic bread");
                    else if (Program.Inventory[14] == 3)
                        c.Print("\n     3 slices of garlic bread");
                    else if (Program.Inventory[14] > 0)
                        c.Print(string.Format("\n     a loaf of garlic bread ({0} slices)", Program.Inventory[14]));
                    
                    if (Program.ateBread && Program.mazeIdx != 16)
                        c.Print("\n     a handful of crumbs");

                    for (int i = 1; i < 17; i++)
                        if (i != 14)
                        {
                            if (Program.Inventory[i] == 1 && Program.InventoryCaptions[i] != InventoryItems.Silver)
                                c.Print("\n    " + Program.InventoryCaptions[i]);
                            else if (Program.Inventory[i] > 1 && Program.InventoryCaptions[i] != InventoryItems.Silver)
                                c.Print("\n    " + Program.InventoryCaptions[i] + " (x" + Program.Inventory[i] + ")");
                        }

                    c.Print("\n");
                }
                catch
                {
                    c.Clear();
                    c.StyleHeader("Error", true, false);
                    c.Print("\n The save file is incompatible with the current version.\n\n Please see the game manual for details on troubleshooting errors.", ConsoleColor.Red);
                    Console.ReadKey(false);
                    c.CloseEnvironment();
                }
            }
        }
    }
}
