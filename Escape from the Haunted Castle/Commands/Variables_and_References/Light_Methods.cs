namespace haunted_castle.Commands.Variables_and_References
{
    public class Light_Methods
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void match()
        {
            if (Program.InventoryCaptions[1] == InventoryItems.MatchUsed)
                c.Print("\n It has already been used.^");
            else if (Program.InventoryCaptions[1] != InventoryItems.MatchLit && (Program.Inventory[1] == 1 || Program.ROOM == "PartI"))
            {
                Score.Addition(Score.A1_LightMatch);

                Program.InventoryCaptions[1] = InventoryItems.MatchLit;

                if (Program.InventoryCaptions[2] == InventoryItems.Candle)
                    c.Print("\n The match is now lit, although its light is too feeble\n to disperse the suffocating darkness around you.\n It will go out soon.^");
                else
                    c.Print("\n The match is now lit.\n It will go out soon.^");
            }
            else if (Program.InventoryCaptions[1] == InventoryItems.MatchLit)
                c.Print("\n It is already lit.^");
            else if (Program.Inventory[1] == 0 && Program.ROOM != "PartI")
                c.Print("\n You do not have that.^");
        }

        public static void candleWithMatch()
        {
            if (Program.InventoryCaptions[2] != InventoryItems.CandleLit && Program.InventoryCaptions[1] == InventoryItems.MatchLit)
            {
                Program.InventoryCaptions[1] = InventoryItems.MatchUsed;
                Program.InventoryCaptions[2] = InventoryItems.CandleLit;

                Score.Addition(Score.A_LightCandle);

                c.Print("\n You light the candle using the match.\n The match goes out.");
                c.Pause();

                Storyline.PartI();
            }
            else if (Program.Inventory[2] == 0 && Program.ROOM != "PartI")
                c.Print("\n You do not have that.^");
            else if (Program.InventoryCaptions[2] == InventoryItems.CandleLit)
                c.Print("\n It is already lit.^");
            else if (Program.InventoryCaptions[1] != InventoryItems.MatchLit)
                c.Print("\n The match is not lit.^");
        }

        public static void newspaperWithCandle()
        {
            if (Program.Inventory[16] == 1)
            {
                Program.Inventory[16] = 0;

                Score.Addition(Score.J);

                c.Print("\n You light the newspaper on fire using the candle.\n\n It burns completely, disappearing into ash.^");
            }
            else
                c.Print("\n You do not have that.^");
        }

        public static void eyebrowsWithCandle()
        {
            if (Program.Inventory[2] == 1 && Program.InventoryCaptions[2] == InventoryItems.CandleLit && Program.hasEyebrows)
            {
                Program.State[2] = true;

                Score.Addition(Score.J); // J.LightEyebrows

                Program.hasEyebrows = false;

                Methods.SetPermanentHealth(Program.PermanentHealth - 25);
                c.Print("\n You light your hair on fire using the candle.^");
            }
            else if (!Program.hasEyebrows)
                c.Print("\n Your hair is already burnt.^");
            else if (Program.InventoryCaptions[2] != InventoryItems.CandleLit)
                c.Print("\n You do not have a lit candle.^");
        }

        public static void barsWithCandle()
        {
            if (Program.Inventory[2] == 1 && Program.InventoryCaptions[2] == InventoryItems.CandleLit)
            {
                Score.Addition(Score.F_LightBars);

                c.Print("\n You light the bars on fire using the candle.\n\n They burn up and leave a gaping hole for you to crawl through.\n You are now on the east side of the bars.");
                c.Pause();
                Storyline.PrisonCell2(false);
                Storyline.PartVI(false);
            }
            else if (Program.InventoryCaptions[2] != InventoryItems.CandleLit)
                c.Print("\n You do not have a lit candle.^");
        }

        public static void keyWithCandle()
        {
            if (Program.Inventory[2] == 1 && Program.InventoryCaptions[2] == InventoryItems.CandleLit && (Program.InventoryCaptions[5] == InventoryItems.Key) && (Program.Inventory[5] > 0 || Program.ROOM == "PartXV"))
            {
                Program.InventoryCaptions[5] = InventoryItems.Silver;
                Program.Inventory[5] = 1;

                Score.Addition(Score.J); // J.LightKey

                c.Print("\n You light the key on fire using the candle.\n\n It melts completely, making it unusable.^");

                if (Program.ROOM == "PartXV")
                    c.Print("\n You keep the remaining silver.^");
            }
            else if (Program.Inventory[5] == 0 && Program.ROOM != "PartXV")
                c.Print("\n You do not have that.^");
            else if (Program.InventoryCaptions[5] == InventoryItems.Silver)
                c.Print("\n The key has already been melted completeley.^");
            else if (Program.InventoryCaptions[1] != InventoryItems.CandleLit)
                c.Print("\n You do not have a lit candle.^");
        }

        public static void computerWithCandle()
        {
            if (Program.Inventory[2] == 1 && Program.InventoryCaptions[2] == InventoryItems.CandleLit)
            {
                c.Print("\n You light the computer on fire using the candle.\n\n An explosion occurs, instantly killing you.");
                c.Pause();
                Methods.GameOver(false);
            }
            else if (Program.InventoryCaptions[2] != InventoryItems.CandleLit)
                c.Print("\n You do not have a lit candle.^");
        }

        public static void crateWithCandle()
        {
            if (Program.Inventory[2] == 1 && Program.InventoryCaptions[2] == InventoryItems.CandleLit)
            {
                c.Print("\n You light the crate on fire using the candle,\n alerting the ship's captain of your presence.\n\n The ship gradually approaches and finally reaches you.^");
                c.Print("\n You quickly jump out of the crate as the fire engulfs it,\n and the it sinks down to the bottom of the ocean.");
                c.Pause();
                Score.Addition(Score.P1_LightCrate);
                Score.Addition(Score.J);
                Storyline.D1();
            }
            else if (Program.InventoryCaptions[2] != InventoryItems.CandleLit)
                c.Print("\n You do not have a lit candle.^");
        }
    }
}
