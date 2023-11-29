namespace haunted_castle.Commands.Variables_and_References
{
    public class Open_Methods
    {
        // Declarations
        static readonly GUI.Display c = new GUI.Display();

        public static void bag(bool ComputerRoom)
        {
            if (Program.InventoryCaptions[4] == InventoryItems.BagGold)
            {
                c.Print("\n Inside are 20 gold coins.\n\n You keep them.^");

                Program.Inventory[0] += 40;
                Program.InventoryCaptions[4] = InventoryItems.Bag;

                Score.Addition(Score.J);
            }
            else if (Program.InventoryCaptions[4] == InventoryItems.BagWater)
            {
                if (ComputerRoom)
                    Drop_Methods.water("COMPUTER_ROOM");
                else
                    Drop_Methods.water("0");
            }
            else if (Program.InventoryCaptions[4] == InventoryItems.BagTea)
            {
                if (Program.ROOM == "R8")
                    Drop_Methods.tea("PY");
                else
                    Drop_Methods.tea("");
            }
            else if (Program.InventoryCaptions[4] == InventoryItems.Bag)
                c.Print("\n Empty.^");
        }

        public static void door()
        {
            if (!Program.State[1] && Program.Ghosts[0])
            {
                c.Print("\n The door opens with a simple push.");
                c.Pause();

                Storyline.PartIV();
            }
            else
            {

                c.Print("\n The door does not budge.^");

                if (Program.Inventory[5] == 1 && Program.InventoryCaptions[5] == InventoryItems.Key)
                    c.Print("\n You try to use the key but it does not fit.^");
                else if (Program.Inventory[5] == 1 && Program.InventoryCaptions[5] == InventoryItems.Silver)
                    c.Print("\n You try to use the key but it has been melted out of shape.^");
            }
        }

        public static void door2()
        {
            c.Print("\n You open the door with a simple push.\n\n You find yourself in a tiny utility closet.");
            c.Pause();
            Storyline.PartXXII();
        }

        public static void SouthNorthWest(string door)
        {
            Storyline.Skywalk(door);

            // Spider's Lair
            if (Program.SpiderRepelling)
            {
                Methods.Checkpoint("Gnome Room", string.Format("Haunted Castle: {0} Tower", Methods.GrammarCaps(door)));
                c.Print(string.Format("\n You are in a small room on the second floor of the castle's {0} tower.", Methods.GrammarCaps(door)));

                c.Print("\n A terrifying gnome falls from the ceiling and crashes down in front of you.");
                c.Print("\n\n It bites with its menacing jaws and kills you instantly, too fast for you to react.");
            }
            else
            {
                Methods.Checkpoint("Spider's Lair", string.Format("Haunted Castle: {0} Tower", Methods.GrammarCaps(door)));
                c.Print(string.Format("\n You are in a small room on the second floor of the castle's {0} tower.", door));

                c.Print("\n You see a shadow cast from above, directly in front of you.\n Suddenly, a giant spider descends from a web on the ceiling.\n It drops down and advances quickly, ready to strike.");
                c.Print("\n\n The venom in its bite kills you instantly, too fast for you to react.");
            }

            c.Pause();
            Methods.GameOver(false);
        }

        public static void e()
        {
            Storyline.Skywalk("east");

            Score.Addition(Score.D_OpenE);

            Storyline.PartV(true);
        }

        public static void l()
        {
            if (!Program.libraryUNLOCKED)
            {
                c.Print("\n The library door is locked.^");

                if (Program.Inventory[5] > 0 && Program.InventoryCaptions[5] != InventoryItems.Key)
                    c.Print("\n The key has been melted out of shape.^");

                if (Program.Inventory[5] > 0 && Program.InventoryCaptions[5] == InventoryItems.Key)
                {
                    Program.libraryUNLOCKED = true;

                    Score.Addition(Score.B3_OpenL);

                    c.Print("\n You put the key into the lock and discover that it fits.\n You turn the key, open the door, and walk through the doorway.");
                    c.Pause();
                    Storyline.PartIII();
                }
                else if (!Program.Ghosts[0])
                {
                    c.Print("\n You turn back towards the corridor.\n\n An angry ghost is blocking your path!^");
                    c.Print("\n \"You dare to enter this castle without permission?\n  For this you shall have a taste of my extraordinary magic!\"");
                    c.Pause();
                    BattleSimulator.StartBattle(0, Program.GhostAttacks, "Haunted Castle: Corridor");

                    FileSystem.SaveData();
                    FileSystem.TRAVELTO();
                }
            }
            else
                Storyline.PartIII();
        }

        public static void coffin()
        {
            if (Program.vampireGone && Program.vampireAwake)
                Read_Methods.coffin();
            else if (Program.vampireAwake)
                c.Print("\n Inside is a huge vampire.\n\n He stares at you furiously.\n Take caution: a single bite can kill you.^");
            else
            {
                Score.Addition(Score.M1_OpenCoffin);

                Program.vampireAwake = true;

                c.Print("\n Inside is a huge bat.\n\n You jump backwards as the bat transforms into a vampire.\n\n He stares at you furiously.\n Take caution: a single bite can kill you.^");
            }
        }

        public static void chest()
        {
            if (Program.Ghosts[1])
                c.Print("\n Empty.^");
            else
            {
                if (Program.Inventory[6] == 0)
                {
                    c.Print("\n Inside is a new shield!\n\n As you reach out to grab it, a suit of armor rises from\n the depths of the chest.\n\n He draws his sword and attacks.");
                    Program.Inventory[6] = 1;
                }
                else
                    c.Print("\n A suit of armor rises from\n the depths of the chest.\n\n He draws his sword and attacks.");

                c.Pause();
                BattleSimulator.StartBattle(1, Program.SwordAttacks, "Haunted Castle: Armory");
                FileSystem.SaveData();
                FileSystem.TRAVELTO();
            }
        }

        public static void secret_door()
        {
            if (Program.elf)
            {
                c.Print("\n You open the secret door and crawl through it.");
                c.Pause();
                Storyline.PartXII(true);
            }
            else
                c.Print("\n You cannot find the secret door that leads south.^");
        }

        public static void doors()
        {
            c.Print("\n You open the large double doors and enter a grand dining hall.");
            c.Pause();
            Storyline.PartXXI();
        }

        public static void box()
        {
            if (Program.Inventory[9] == 1 || Program.ROOM == "PartXXII")
                c.Print("\n It is already open.^");
            else
                c.Print("\n You do not have that.^");
        }

        public static void crate()
        {
            if (Program.Inventory[10] == 1 || Program.ROOM == "PartXXII")
                c.Print("\n It is already open.^");
            else
                c.Print("\n You do not have that.^");
        }

        public static void drawbridge()
        {
            if (Program.InventoryCaptions[7] == InventoryItems.RecipePaperApproved)
                c.Print("\n The drawbridge is already open.^");
            else
                c.Print("\n It does not budge.^");
        }

        public static void y()
        {
            if (Program.ROOM == "J2")
                Storyline.E6();
            else if (Program.ROOM == "E6")
                Storyline.J2();
        }

        public static void x()
        {
            if (Program.ROOM == "E5")
                Storyline.J1();
            else if (Program.ROOM == "J1")
                Storyline.E5();
            else if (Program.ROOM == "U1")
                c.Print("\n It would be unwise to explore further while there is still a werewolf in your house.^");
        }
    }
}
