using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace haunted_castle
{
    class Native
    {
        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public static void SetWindowState()
        {
            try
            {
                IntPtr handle = GetConsoleWindow();
                IntPtr sysMenu = GetSystemMenu(handle, false);

                if (handle != IntPtr.Zero)
                {
                    DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                    DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
                }
            }
            catch { }
        }
    }
}
