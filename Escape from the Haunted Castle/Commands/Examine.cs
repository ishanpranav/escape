using haunted_castle.Commands.Variables_and_References;
using System;
using System.Resources;

namespace haunted_castle.Commands
{
    public class Examine
    {
        // Declarations
        static readonly GUI.Display c = new GUI.Display();
        static readonly ResourceManager res = new ResourceManager("haunted_castle.Strings.Examine", typeof(Examine).Assembly);

        public static void Run(string opt1, string opt2, string N, string S, string E, string W, string U, string D, string[] objects)
        {
            if (opt1 == "ln" && opt2 == "")
            {
                opt1 = "l";
                opt2 = "n";
            }
            else if (opt1 == "ls" && opt2 == "")
            {
                opt1 = "l";
                opt2 = "s";
            }
            else if (opt1 == "le" && opt2 == "")
            {
                opt1 = "l";
                opt2 = "e";
            }
            else if (opt1 == "lw" && opt2 == "")
            {
                opt1 = "l";
                opt2 = "w";
            }
            else if (opt1 == "lu" && opt2 == "")
            {
                opt1 = "l";
                opt2 = "u";
            }
            else if (opt1 == "ld" && opt2 == "")
            {
                opt1 = "l";
                opt2 = "d";
            }

            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            for (int i = 0; i < objects.Length; i++) objects[i] = objects[i].ToLower();

            if (N == string.Empty)
                N = "The north wall is made of solid stone.";
            if (S == string.Empty)
                S = "The south wall is made of solid stone.";
            if (E == string.Empty)
                E = "The east wall is made of solid stone.";
            if (W == string.Empty)
                W = "The west wall is made of solid stone.";
            if (U == string.Empty)
                U = "You look up at the arched ceiling.";
            if (D == string.Empty)
                D = "You look down at the white marble floor.";

            if (opt1 == "look" || opt1 == "l" || opt1 == "examine" || opt1 == "x" || opt1 == "inspect" || opt1 == "watch")
                switch (opt2)
                {
                    case "writing":
                        c.Print("\n You do not know which writing to read.^");
                        break;

                    case "me":
                    case "myself":
                    case "self":
                        Diagnose.Run("stats", string.Empty);
                        break;

                    case "wall":
                    case "walls":
                    case "all":
                    case "everywhere":
                        c.Print("\n North: " + N);
                        c.Print("\n\n South: " + S);
                        c.Print("\n\n East: " + E);
                        c.Print("\n\n West: " + W + "^");
                        break;

                    case "inventory":
                    case "items":
                        Inventory.Run("i", string.Empty);
                        break;

                    case "newspaper":
                    case "paper":
                    case "news":
                        Read_Methods.newspaper();
                        break;

                    case "up":
                    case "u":
                    case "roof":
                    case "ceiling":
                    case "sky":
                        c.Print(string.Format("\n {0}^", U));
                        break;

                    case "manual":
                        c.Print("\n Good idea.^");
                        break;

                    case "down":
                    case "d":
                    case "floor":
                    case "ground":
                        c.Print(string.Format("\n {0}^", D));
                        break;

                    case "north":
                    case "n":
                    case "f":
                    case "forward":
                    case "forwards":
                        c.Print(string.Format("\n {0}^", N));
                        break;

                    case "south":
                    case "s":
                    case "aft":
                    case "back":
                        c.Print(string.Format("\n {0}^", S));
                        break;

                    case "east":
                    case "e":
                    case "right":
                    case "starboard":
                    case "b":
                    case "sb":
                        c.Print(string.Format("\n {0}^", E));
                        break;

                    case "west":
                    case "w":
                    case "left":
                    case "port":
                    case "p":
                        c.Print(string.Format("\n {0}^", W));
                        break;

                    case "":
                    case "surrounding":
                    case "area":
                    case "surroundings":
                    case "room":
                    case "around":
                        if ((opt1 == "l" || opt1 == "look") && opt2 == "")
                            Clear.Run("cls", "");
                        else if (opt2 != "")
                            Clear.Run("cls", "");
                        else if (opt1 != "x")
                            c.Print("\n You do not know what to " + opt1 + ".^");
                        else
                            c.Print("\n You do not know what to examine.^");
                        break;

                    case "castle":
                        Methods.WriteCaption(res.GetString("castle"));
                        break;

                    case "palm":
                    case "hand":
                    case "hands":
                    case "palms":
                        Read_Methods.palm();
                        break;

                    case "flute":
                        if (Program.Inventory[8] == 1 || Program.ROOM == "R7A")
                            Methods.WriteCaption(res.GetString("flute"));
                        break;

                    case "magic":
                    case "staff":
                        if (Program.ROOM == "FIN")
                            Read_Methods.magic_staff();
                        else
                            Methods.WriteCaption(res.GetString("magic_staff"));
                        break;

                    case "compass":
                    case "needle":
                        Methods.WriteCaption(res.GetString("compass"));
                        break;

                    case "match":
                        if (Program.Inventory[1] == 1 || Program.ROOM == "PartI")
                            Methods.WriteCaption(res.GetString("match"));
                        break;

                    case "candle":
                        if (Program.Inventory[2] == 1 || Program.ROOM == "PartI")
                            Methods.WriteCaption(res.GetString("candle"));
                        break;

                    case "leather":
                    case "bag":
                        Methods.WriteCaption(res.GetString("leather_bag"));
                        break;

                    case "shield":
                        if (Program.Inventory[6] == 1)
                            Methods.WriteCaption(res.GetString("shield"));
                        break;

                    case "key":
                        if ((Program.Inventory[5] == 1 && Program.InventoryCaptions[5] == InventoryItems.Key) || Program.ROOM == "PartXV")
                            Methods.WriteCaption(res.GetString("key"));
                        if (Program.Inventory[5] > 0 && Program.InventoryCaptions[5] == InventoryItems.Silver)
                            Methods.WriteCaption(res.GetString("silver"));
                        break;

                    case "silver":
                        if (Program.Inventory[5] > 0 && Program.InventoryCaptions[5] == InventoryItems.Silver)
                            Methods.WriteCaption(res.GetString("silver"));
                        break;

                    case "spit":
                    case "sailva":
                    case "drool":
                        Methods.WriteCaption(res.GetString("spit"));
                        break;

                    case "crate":
                        if (Program.Inventory[10] == 1 || Program.ROOM == "PartXXII")
                            Methods.WriteCaption(res.GetString("crate"));
                        break;

                    case "box":
                        if (Program.Inventory[9] == 1 || Program.ROOM == "PartXXII")
                            Methods.WriteCaption(res.GetString("box"));
                        break;

                    case "apple":
                    case "seeds":
                    case "seed":
                    case "appleseeds":
                    case "appleseed":
                        if (Program.InventoryCaptions[3] == InventoryItems.Apple && (Program.Inventory[3] == 1 || Program.ROOM == "PartXXXI"))
                            Methods.WriteCaption(res.GetString("apple"));
                        else if (Program.InventoryCaptions[3] == InventoryItems.Seeds && Program.Inventory[3] == 1)
                            Methods.WriteCaption(res.GetString("seeds"));
                        break;

                    case "floppy":
                    case "disk":
                    case "disc":
                    case "diskette":
                        if (Program.Inventory[11] == 1)
                            Methods.WriteCaption(res.GetString("floppy_disk"));
                        else if (Program.ROOM == "PartVIII" || Program.ROOM == "PC")
                            Methods.WriteCaption("It is inside of the computer's floppy disk drive.");
                        break;

                    case "monocle":
                    case "lens":
                        if (Program.Inventory[15] == 1 || Program.ROOM == "D8")
                            Methods.WriteCaption(res.GetString("monocle"));
                        break;

                    case "blackberry":
                    case "berry":
                    case "black":
                        if (Program.Inventory[12] == 1 || Program.ROOM == "PartXXXIV")
                            Methods.WriteCaption(res.GetString("blackberry"));
                        break;

                    case "water":
                        if (Program.InventoryCaptions[4] == InventoryItems.BagWater || Program.ROOM == "PartXV" || Program.ROOM == "PartXXXI")
                            Methods.WriteCaption(res.GetString("water"));
                        break;

                    case "feather":
                        if (Program.Inventory[13] == 1 || Program.ROOM == "PartXXXV")
                            Methods.WriteCaption(res.GetString("feather"));
                        break;

                    case "recipe":
                        if (Program.Inventory[7] == 1)
                            Methods.WriteCaption(res.GetString("recipe"));
                        break;

                    case "rat":
                    case "rats":
                        if (Program.ROOM != "D1" && (Program.ROOM == "D8" || (Program.ROOM.StartsWith("D") && !Program.ogAsleep && Program.ratsGone)) || (Program.ROOM == "DX" && Program.ogAsleep))
                            Methods.WriteCaption(res.GetString("rats"));
                        break;

                    case "garlic":
                    case "bread":
                    case "slice":
                    case "slices":
                    case "loaf":
                        if (Program.Inventory[14] == 1)
                            Methods.WriteCaption("A slice of white bread covered with garlic.");
                        else if (Program.Inventory[14] > 0 || Program.ROOM == "R6")
                            Methods.WriteCaption(res.GetString("bread"));
                        break;

                    case "gold":
                    case "golden":
                    case "coin":
                    case "dust":
                    case "egg":
                    case "eggs":
                    case "coins":
                    case "ring":
                    case "pair":
                    case "rings":
                    case "bracelet":
                    case "goblet":
                    case "tiara":
                    case "scarab":
                    case "spoon":
                    case "ingot":
                        if (Program.Inventory[0] > 0)
                            Methods.WriteCaption(res.GetString("gold"));
                        break;

                    case "crumbs":
                    case "breadcrumbs":
                    case "crumb":
                    case "breadcrumb":
                    case "handful":
                        if (Program.ateBread)
                            Methods.WriteCaption(res.GetString("crumbs"));
                        else
                            c.Print("\n You do not have that.^");
                        break;

                    case "rainbow":
                    case "bow":
                        if (Storyline.sky != Storyline.sky4)
                            c.Print("\n A glistening rainbow high above the clouds\n with a wide arc ending somewhere in the rainforest.^");
                        break;
                    default:
                        foreach (string obj in objects)
                        {
                            if (obj == "window" && opt2 == "window")
                                Methods.WriteCaption(res.GetString("window"));
                            else if (obj == "door" && opt2 == "door")
                                Methods.WriteCaption(res.GetString("door"));
                            else if (obj == "door2" && opt2 == "door")
                                Methods.WriteCaption(res.GetString("door"));
                            else if (obj == "ship" && opt2 == "ship")
                                Read_Methods.ship();
                            else if (obj == "coffee" && (opt2 == "coffee" || opt2 == "cup" || opt2 == "mug"))
                                Methods.WriteCaption(res.GetString("coffee"));
                            else if (obj == "stove" && opt2 == "stove")
                                Methods.WriteCaption(res.GetString("stove"));
                            else if (obj == "rainforest" && (opt2 == "rainforest" || opt2 == "forest" || opt2 == "tree" || opt2 == "trees"))
                                Methods.WriteCaption(res.GetString("rainforest"));
                            else if (obj == "snake" && (opt2 == "snake" || opt2 == "fangs" || opt2 == "fang" || opt2 == "jaw" || opt2 == "jaws" || opt2 == "pattern" || opt2 == "patterns"))
                                Methods.WriteCaption(res.GetString("snake"));
                            else if (obj == "sink" && opt2 == "sink")
                                Methods.WriteCaption(res.GetString("sink"));
                            else if (obj == "television" && (opt2 == "television" || opt2 == "tv" || opt2 == "tele"))
                                Use_Methods.television();
                            else if (obj == "calendar" && (opt2 == "calendar" || opt2 == "tack" || opt2 == "tacks"))
                                Read_Methods.calendar();
                            else if (obj == "table" && opt2 == "table")
                                Methods.WriteCaption(res.GetString("table"));
                            else if (obj == "cake" && (opt2 == "cake" || opt2 == "purple"))
                                Read_Methods.cake();
                            else if (obj == "lamp" && (opt2 == "lamp" || opt2 == "oil"))
                                Methods.WriteCaption(res.GetString("oil_lamp"));
                            else if (obj == "case" && (opt2 == "case" || opt2 == "display"))
                                Methods.WriteCaption(res.GetString("display_case"));
                            else if (obj == "vampire" && (opt2 == "vampire" || opt2 == "bat") && Program.vampireAwake && !Program.vampireGone)
                                Methods.WriteCaption(res.GetString("vampire"));
                            else if (obj == "werewolf" && (opt2 == "werewolf" || opt2 == "were" || opt2 == "wolf"))
                                Methods.WriteCaption(res.GetString("werewolf"));
                            else if (obj == "tomatoes" && (opt2 == "tomatoes" || opt2 == "tomato"))
                                Methods.WriteCaption(res.GetString("tomatoes"));
                            else if (obj == "shelf" && opt2 == "shelf")
                                Methods.WriteCaption(res.GetString("shelf"));
                            else if (obj == "dragon" && opt2 == "dragon")
                                Methods.WriteCaption(res.GetString("dragon"));
                            else if (obj == "hook" && opt2 == "hook")
                                Methods.WriteCaption(res.GetString("hook"));
                            else if (obj == "armchairs" && (opt2 == "armchairs" || opt2 == "armchair"))
                                Methods.WriteCaption(res.GetString("armchairs"));
                            else if (obj == "kettle" && (opt2 == "tea" || opt2 == "kettle"))
                                Methods.WriteCaption(res.GetString("kettle"));
                            else if (obj == "desk" && (opt2 == "desk" || opt2 == "table"))
                                Methods.WriteCaption(res.GetString("desk"));
                            else if (obj == "table2" && opt2 == "table")
                                Methods.WriteCaption(res.GetString("table2"));
                            else if (obj == "cyclops" && opt2 == "cyclops")
                                Methods.WriteCaption(res.GetString("cyclops"));
                            else if (obj == "troll" && opt2 == "troll")
                                Methods.WriteCaption(res.GetString("troll"));
                            else if (obj == "elf" && opt2 == "elf")
                                Methods.WriteCaption(res.GetString("elf"));
                            else if (obj == "chandelier" && opt2 == "chandelier")
                                Methods.WriteCaption(res.GetString("chandelier"));
                            else if (obj == "cheese" && (opt2 == "moldy" || opt2 == "cheese"))
                                Methods.WriteCaption(res.GetString("cheese"));
                            else if (obj == "coffin" && (opt2 == "black" || opt2 == "coffin"))
                                Read_Methods.coffin();
                            else if (obj == "chandelier2" && opt2 == "chandelier")
                                Methods.WriteCaption(res.GetString("chandelier"));
                            else if (obj == "gate" && (opt2 == "limestone" || opt2 == "gate"))
                                Methods.WriteCaption(res.GetString("limestone_gate"));
                            else if (obj == "fountain" && (opt2 == "fountain" || opt2 == "basin"))
                                Read_Methods.fountain();
                            else if (obj == "figurehead" && (opt2 == "figurehead" || opt2 == "bowsprit" || opt2 == "bow"))
                                Methods.WriteCaption(res.GetString("figurehead"));
                            else if (obj == "cookbook" && (opt2 == "cookbook" || opt2 == "cook"))
                                Methods.WriteCaption(res.GetString("cookbook"));
                            else if (obj == "beanstalk" && (opt2 == "beanstalk" || opt2 == "bean" || opt2 == "stalk" || opt2 == "tall"))
                                Methods.WriteCaption(res.GetString("beanstalk"));
                            else if (obj == "house" && (opt2 == "house" || opt2 == "gingerbread" || opt2 == "ginger"))
                                Methods.WriteCaption(res.GetString("house"));
                            else if (obj == "observatory" && (opt2 == "observatory" || opt2 == "tower" || opt2 == "observation"))
                                Methods.WriteCaption(res.GetString("observatory"));
                            else if (obj == "x" && (opt2 == "x" || opt2 == "door" || opt2 == "wooden" || opt2 == "doorway"))
                                Methods.WriteCaption(res.GetString("x"));
                            else if (obj == "y" && (opt2 == "y" || opt2 == "door" || opt2 == "wooden" || opt2 == "doorway"))
                                Methods.WriteCaption(res.GetString("y"));
                            else if (obj == "spellbook" && (opt2 == "spellbook" || opt2 == "spell"))
                                Methods.WriteCaption(res.GetString("spellbook"));
                            else if (obj == "trough" && opt2 == "trough")
                                Methods.WriteCaption(res.GetString("trough"));
                            else if (obj == "purple" && (opt2 == "strange" || opt2 == "blue"))
                                Methods.WriteCaption(res.GetString("strange_purple"));
                            else if (obj == "chest" && opt2 == "chest")
                                Methods.WriteCaption(res.GetString("chest"));
                            else if (obj == "stage" && opt2 == "stage")
                                Methods.WriteCaption(res.GetString("stage"));
                            else if (obj == "ladder" && opt2 == "ladder")
                                Methods.WriteCaption(res.GetString("ladder"));
                            else if (obj == "sign" && opt2 == "sign")
                                Read_Methods.sign();
                            else if (obj == "bed" && opt2 == "bed")
                                Methods.WriteCaption(res.GetString("bed"));
                            else if (obj == "bars" && (opt2 == "bars" || opt2 == "bar"))
                                Methods.WriteCaption(res.GetString("bars"));
                            else if (obj == "tunnel" && (opt2 == "tunnel" || opt2 == "hole" || opt2 == "tunnels"))
                                Methods.WriteCaption(res.GetString("tunnel"));
                            else if (obj == "doorway" && (opt2 == "doorway" || opt2 == "door"))
                                Methods.WriteCaption(res.GetString("doorway"));
                            else if (obj == "counter" && opt2 == "counter")
                                Methods.WriteCaption(res.GetString("counter"));
                            else if (obj == "mirror" && (opt2 == "mirror" || opt2 == "talking") && !Program.IsInvisible)
                                Methods.WriteCaption(res.GetString("mirror"));
                            else if (obj == "mirror" && (opt2 == "mirror" || opt2 == "talking") && Program.IsInvisible)
                                Methods.WriteCaption(res.GetString("mirrorInvisible"));
                            else if (obj == "steps" && (opt2 == "stairs" || opt2 == "steps" || opt2 == "staircase"))
                                Methods.WriteCaption(res.GetString("steps"));
                            else if (obj == "throne" && opt2 == "throne")
                                Methods.WriteCaption(res.GetString("throne"));
                            else if (obj == "computer" && (opt2 == "computer" || opt2 == "cpu" || opt2 == "pc"))
                                Methods.WriteCaption(res.GetString("computer"));
                            else if (obj == "computer" && opt2 == "drive")
                                Methods.WriteCaption(res.GetString("drive"));
                            else if (obj == "rug" && (opt2 == "oriental" || opt2 == "rug"))
                                Methods.WriteCaption(res.GetString("oriental_rug"));
                            else if (obj == "rug2" && (opt2 == "oriental" || opt2 == "rug"))
                                Methods.WriteCaption(res.GetString("oriental_rug"));
                            else if (obj == "atlas" && opt2 == "atlas")
                                Methods.WriteCaption(res.GetString("atlas"));
                            else if (obj == "poetry" && (opt2 == "poetry" || opt2 == "poem"))
                                Methods.WriteCaption(res.GetString("poetry"));
                            else if (obj == "statue" && (opt2 == "statue" || opt2 == "marble"))
                                Methods.WriteCaption("A white marble statue depicting a majestic horse@ galloping through a river of foaming water.");
                            else if (obj == "secret" && (opt2 == "secret" || opt2 == "door"))
                            {
                                if (Program.elf)
                                    Methods.WriteCaption(res.GetString("secret_door"));
                                else
                                    c.Print("\n You cannot find the secret door.^");
                            }
                            else if (obj == "leprechaun" && (opt2 == "leprechaun" || opt2 == "leper"))
                                Methods.WriteCaption(res.GetString("leprechaun"));
                            else if (obj == "columns" && (opt2 == "columns" || opt2 == "column" || opt2 == "pillar" || opt2 == "pillars" || opt2 == "roman"))
                                Methods.WriteCaption(res.GetString("columns"));
                            else if (obj == "k" && (opt2 == "k" || opt2 == "kitchen" || opt2 == "doorway"))
                                Methods.WriteCaption(res.GetString("k"));
                            else if (obj == "l" && (opt2 == "l" || opt2 == "library" || opt2 == "doorway"))
                                Methods.WriteCaption(res.GetString("l"));
                            else if (obj == "l" && (opt2 == "door" || opt2 == "doors" || opt2 == "doorway"))
                                Methods.WriteCaption("Two wooden doors marked K and L.");
                            else if (obj == "n" && (opt2 == "door" || opt2 == "doors" || opt2 == "doorway"))
                                Methods.WriteCaption("Four wooden doors marked N, S, E, and W.");
                            else if (obj == "doors" && (opt2 == "doors" || opt2 == "door"))
                                Methods.WriteCaption(res.GetString("doors"));
                            else if (obj == "chairs" && (opt2 == "chairs" || opt2 == "chair"))
                                Methods.WriteCaption(res.GetString("chairs"));
                            else if (obj == "cards" && (opt2 == "cards" || opt2 == "card" || opt2 == "deck"))
                                Methods.WriteCaption(res.GetString("cards"));
                            else if (obj == "oak" && (opt2 == "oak" || opt2 == "oaks" || opt2 == "tree" || opt2 == "trees"))
                                Methods.WriteCaption(res.GetString("oak_trees"));
                            else if (obj == "bird" && opt2 == "bird")
                                Methods.WriteCaption(res.GetString("bird"));
                            else if (obj == "bushes" && (opt2 == "bushes" || opt2 == "bush"))
                                Methods.WriteCaption(res.GetString("bushes"));
                            else if (obj == "drawbridge" && (opt2 == "drawbridge" || opt2 == "bridge"))
                                Methods.WriteCaption(res.GetString("drawbridge"));
                            else if (obj == "crate2" && opt2 == "crate")
                                Methods.WriteCaption(res.GetString("crate"));
                            else if (obj == "rope" && opt2 == "rope")
                                Methods.WriteCaption(res.GetString("rope"));
                            else if (obj == "rope2" && opt2 == "rope")
                                Methods.WriteCaption(res.GetString("rope"));
                            else if (obj == "ship2" && opt2 == "ship2")
                                Methods.WriteCaption(res.GetString("ship2"));
                            else if (obj == "mast" && opt2 == "mast")
                                Methods.WriteCaption(res.GetString("mast"));
                            else if (obj == "telescope" && opt2 == "telescope")
                                Use_Methods.telescope();
                            else if (obj == "wheel" && (opt2 == "wheel" || opt2 == "steering"))
                                Methods.WriteCaption(res.GetString("wheel"));
                            else if (obj == "map" && (opt2 == "map" || opt2 == "tack" || opt2 == "tacks"))
                                Read_Methods.map();
                        }
                        break;
                }
        }
    }
}
