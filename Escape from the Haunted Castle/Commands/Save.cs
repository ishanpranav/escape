using System;
using System.IO;

namespace haunted_castle.Commands
{
    public class Save
    {
        // Declarations
        static GUI.Display c = new GUI.Display();

        public static void Run(string opt1, string opt2)
        {
            opt1 = opt1.ToLower().Replace('^', ' ');
            opt2 = opt2.ToLower().Replace('^', ' ');

            if (opt1 == "save" && (opt2 == "" || opt2 == "game" || opt2 == "state" || opt2 == "me" || opt2 == "myself" || opt2 == "save"))
            {
                c.Print("\n Saving... Please wait.\n", ConsoleColor.Gray);

                FileSystem.SaveData();

                c.Print(string.Format("\n Progress saved ({0:n2} kb).^", (double)(new FileInfo(FileSystem.savefile).Length) / 1024), ConsoleColor.Gray);
            }
            else if (opt1 == "restore" || opt1 == "load" && (opt2 == "" || opt2 == "game" || opt2 == "state" || opt2 == "me" || opt2 == "myself" || opt2 == "save"))
                c.Print("\n Automatic progress restoration is now on.^", ConsoleColor.Gray);
        }
}
}
