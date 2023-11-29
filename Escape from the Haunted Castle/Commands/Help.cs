using haunted_castle.Properties;

namespace haunted_castle.Commands
{
    public class Help
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if (opt1 == "help" || opt1 == "?" || opt1 == "hint" || opt1 == "hints")
            {
                if (opt2 == string.Empty || opt2 == "all" || opt2 == "me" || opt2 == "help")
                    Methods.ShowHelpFile(Resources.Commands);
            }
        }
    }
}
