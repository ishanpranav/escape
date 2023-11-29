// Television.cs
// Copyright (c) 2016-2023 Ishan Pranav. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;

namespace HauntedCastle.Minigames
{
    internal class Television
    {
        private static readonly GUI.Display gui = new GUI.Display();
        private static readonly ChannelInfo[] Channels = new ChannelInfo[]
        {
            new ChannelInfo(1, "News", "Breaking News", "Breaking News: Kingdom's Precious Magic Staff Stolen"),
            new ChannelInfo(2, "Public Broadcasting", "Nature Documentary", "The annual vampire migration is such a majestic sight"),
            new ChannelInfo(3, "Kids", "Educational Television", "Let's count to four! One... Two.. Three"),
            new ChannelInfo(5, "Game Shows", "Wheel of Torture", "Welcome back to WHEEL of TORTURE"),
            new ChannelInfo(8, "News", "Financial News", "Breaking News: Gold Prices Plumment After Mining Boom"),
            new ChannelInfo(13, "Drama", "Soap Opera", "What necklace? I don't have the necklace"),
            new ChannelInfo(21, "Razorteeth", "Razorteeth Studios", "And now, an interview with Razorteeth Studios visionary"),
            new ChannelInfo(34, "Science Fiction", "Attack of the Humans", "The dark creature lurks in the shadows, waiting to"),
            new ChannelInfo(55, "Nonfiction", "Documentary", "The cave formation is just so intricate"),
            new ChannelInfo(89, "Pseudoscience", "Conspiracy Theories Exposed", "Last year, 52 unconfirmed human sightings were reported"),
            new ChannelInfo(144, "Reality", "The Wizards", "Brad annoys me so much, he's like super"),
            new ChannelInfo(233, "Cooking", "Tomato Soup Tutorial", "I'm going to let this cook for a few more minutes"),
            new ChannelInfo(377, "Comedy", "The Cyclops Comedian", "And then I asked the optometrist for 50% off"),
            new ChannelInfo(610, "News", "Weather", "The weather will continue to be sunny all week"),
           new ChannelInfo(987, "Paid Programming", "Paid Programming", "Now you can get TWO of these amazing blenders for just"),
        };
        private static readonly string[] Products = new string[] { "a toaster oven", "dish-washing powder", "laundry detergent", "headache tablets", "a soft drink", "a Razorteeth Studios Smartphone", "a Razorteeth Studios Personal Computer", "Escape from the Haunted Castle", "a Razorteeth Studios Television", "a word-processor program", "a cleaning product", "soap", "a sugary breakfast cereal", "a fast food chain", "pet food", "flowers", "medicine", "vitamins", "a Razorteeth Studios entertainment system", "a Razorteeth Studios Camera", "a washing machine", "a dishwasher", "sports equipment", "a clothing brand", "kitchen utensils", "a kitchen gadget", "a new restaurant", "an upscale restaurant", "a hotel", "an airline company", "a luggage brand", "a gym membership", "a hairdresser", "a beauty salon", "an automobile repair service", "an automobile", "a mechanic", "a perfume brand", "running shoes", "jewelry", "a bicycle", "a floppy disk", "an internet provider", "a home mortgage bank", "a bank", "a credit card provider", "a home repair service", "health insurance", "a luxury automobile", "a new form of medicine", "a microwave", "a refrigerator", "a bed" };

        public static bool Start()
        {
            gui.DrawScreen();

            gui.PrintScreen("RAZORTEETH TV", 1, ConsoleColor.White);
            gui.PrintScreen("  ###   #####     #####  #   #", 4, ConsoleColor.Gray);
            gui.PrintScreen("  #  #  # # #     # # #  #   #", 5, ConsoleColor.Gray);
            gui.PrintScreen("  ###     #         #    #   #", 6, ConsoleColor.Gray);
            gui.PrintScreen("  #  #    #         #     # #", 7, ConsoleColor.Gray);
            gui.PrintScreen("  #  #    #         #      #", 8, ConsoleColor.Gray);
            gui.PrintScreen("Razorteeth Studios Television", 10, ConsoleColor.Gray);
            gui.PrintScreen("PRESS [X] TO TURN ON", 19, ConsoleColor.White);

            char c = char.ToLower(Console.ReadKey(true).KeyChar);

            return c == 'x' && SelectChannel();
        }

        private static ChannelInfo GetChannelInfo(int Number)
        {
            if (Channels.Any(x => x.Number == Number))
            {
                ChannelInfo info = Channels.FirstOrDefault(x => x.Number == Number);

                return info ?? new ChannelInfo(Number, "", "", "");
            }
            else
            {
                return new ChannelInfo(Number, "", "", "");
            }
        }

        private static bool SelectChannel()
        {
            int idx = 1;
            while (true)
            {
                ChannelInfo info = GetChannelInfo(idx);

                gui.DrawScreen();

                if (info.Channel == "")
                {
                    gui.PrintScreen("CHANNEL " + gui.FormatScore(info.Number) + ": Commercials", 1, ConsoleColor.White);
                    gui.PrintScreen("It's an advertisement for " + Products[Program.rnd.Next(Products.Length)] + ".", 3, ConsoleColor.Gray);
                }
                else
                {
                    gui.PrintScreen("CHANNEL " + gui.FormatScore(info.Number) + " " + info.Channel.ToUpper() + ": " + info.Show, 1, ConsoleColor.Yellow);
                    gui.PrintScreen("\"" + info.Description + "...\"", 3, ConsoleColor.Cyan);
                }

                if (idx == 987)
                {
                    gui.PrintScreen("PRESS [X] TO TURN OFF", 19, ConsoleColor.White);

                    while (true)
                    {
                        char c = char.ToLower(Console.ReadKey(true).KeyChar);

                        if (c == 'x')
                        {
                            return true;
                        }
                    }
                }

                gui.PrintScreen("Enter a channel (001-999) or 000 to exit: ", 19, ConsoleColor.White);

                int pIdx = idx;
                try
                {
                    idx = int.Parse(gui.ReadLine(3));
                }
                catch
                {
                    idx = pIdx;
                }

                if (idx == 0)
                {
                    return false;
                }
                else if (idx > 999 && idx < 1)
                {
                    idx = pIdx;
                }
            }
        }
    }

    internal class ChannelInfo
    {
        public int Number { get; }
        public string Channel { get; }
        public string Show { get; }
        public string Description { get; }

        public ChannelInfo(int ChannelNumber, string ChannelName, string ChannelShow, string ChannelDescription)
        {
            Number = ChannelNumber;
            Channel = ChannelName;
            Show = ChannelShow;
            Description = ChannelDescription;
        }
    }
}
