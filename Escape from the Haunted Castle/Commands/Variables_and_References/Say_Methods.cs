namespace haunted_castle.Commands.Variables_and_References
{
    public class Say_Methods
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void FinalSpell()
        {
            c.Print("\n The ground begins to tremble.");
            c.Pause();
            c.Print("\n The werewolf, recognizing a familiar scent, howls with fear.\n\n It jumps up from the bed, opens the door, and runs out of the house.");
            c.Pause();
            c.Print("\n There is a deafening roar and a burst of flame.\n Your house is destroyed.");
            c.Pause();
            Score.Addition(Score.W2_UseSpell);
            Storyline.U2();
        }

        public static void SpellOfInvisibility(string Message)
        {
            if (!Program.IsInvisible)
            {
                Program.IsInvisible = true;

                c.Print("\n You invoke the spell of invisibility!^");
            }
            else
                c.Print("\n Nothing happens.^");
        }

        public static void SpellOfSpiderRepelling()
        {
            c.Print("\n You invoke the spell of spider repelling!^");

            Program.SpiderRepelling = true;
        }

        public static void SpellOfReviving()
        {
            if (Program.State[2])
            {
                c.Print("\n All of your injuries are healed.");

                Program.State[2] = false;
            }

            if (Program.State[3])
            {
                c.Print("\n You are cured of poisoning.");

                Program.State[3] = false;
            }

            c.Print("\n The spell has a lasting effect.^");

            Methods.SetPermanentHealth(100);

            Program.Revive = true;
        }

        public static void Gesundheit()
        {
            if (!Program.gsn)
            {
                Program.gsn = true;
                Score.Addition(Score.Z_Gesundheit);
            }

            c.Print("\n Concerned about its sneezing, you wish the dragon good health.\n Any other polite person would do the same.^");
        }

        public static void Ishan()
        {
            c.Print("\n You invoke the spell of awesomeness!^");
            SpellOfReviving();
        }

        public static void OpenGlassCase(string Message)
        {
            if (Program.ROOM == "B4")
            {
                if (Program.caseOpen)
                    c.Print("\n The display case is already open.^");
                else if (Program.vampireAwake && Program.vampireGone)
                {
                    Program.caseOpen = true;

                    Score.Addition(Score.M3_OpenCase);

                    c.Print("\n The display case opens with a click.^");
                }
                else
                    c.Print("\n Nothing happens.^");
            }
            else
                c.Print("\n Nothing happens.^");
        }
    }
}
