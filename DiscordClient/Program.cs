using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;


namespace DiscordClient
{
    static class Program
    {
        static void Main()
        {
            /* Starts a console window for debuging */
            AllocConsole();
            /* Starts the Discord API calls in a new thread */
            Thread DiscordThread = new Thread(DiscordMain.StartApiCommunication);
            DiscordThread.Start();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        /* Gets the AllocConsole() function from kernel32.dll which will let the program create a console window */
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
