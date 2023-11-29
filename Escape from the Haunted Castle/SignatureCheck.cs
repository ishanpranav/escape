﻿using System;

namespace haunted_castle
{
    class SignatureCheck
    {
        public static void Run()
        {
            try
            {
                if (IshanSignature.Ishan.Version != 131)
                {
                    GUI.Display c = new GUI.Display();

                    c.Clear();
                    c.StyleHeader("Error", true, false);
                    c.Print("\n Required files have been modified!\n\n Please contact the publisher for assistance.", ConsoleColor.Red);
                    c.Pause();
                    c.CloseEnvironment();
                }
            }
            catch
            {
                GUI.Display c = new GUI.Display();

                c.Clear();
                c.StyleHeader("Error", true, false);
                c.Print("\n The program cannot run due to a software issue!\n\n Please contact the publisher for assistance.", ConsoleColor.Red);
                c.Pause();
                c.CloseEnvironment();
            }
        }
    }
}