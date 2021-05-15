using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.IO;
using System.Collections;

namespace ConsoleApp1
{
    class doFormatdata
    {
        public static async Task doFormatData()
        {
            Process cmd5 = new Process();

            cmd5.StartInfo.FileName = "cmd.exe";
            cmd5.StartInfo.RedirectStandardInput = true;
            cmd5.StartInfo.RedirectStandardOutput = true;
            cmd5.StartInfo.CreateNoWindow = false;
            cmd5.StartInfo.UseShellExecute = false;
            Console.Title = "Selected - Format Data";
            Console.Clear();
            Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
            string result5 = Console.ReadLine();
            if (result5.Equals("y", StringComparison.OrdinalIgnoreCase) || result5.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Title = "Format Data";
                Console.Clear();
                cmd5.Start();


                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Wiping");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Make sure the device stays connected!");
                Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Title = "Wiping";
                await cmd5.StandardInput.WriteLineAsync("fastboot erase userdata");
                await Task.Delay(450);
                Console.Title = "Finished";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("| Finished. Press any key to return to main menu. |");
                Console.WriteLine("---------------------------------------------------");
                Console.ResetColor();
                Console.ReadKey();
                await Mainmenu.Main();
            }
            else if (result5.Equals("n", StringComparison.OrdinalIgnoreCase) || result5.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cancelled, Closing...");
                await Task.Delay(1300);
                Environment.Exit(0);
                Console.ReadKey();
            }
            else if (result5.Equals("r", StringComparison.OrdinalIgnoreCase) || result5.Equals("return", StringComparison.OrdinalIgnoreCase))
            {
                await Toolsmenu.ToolsMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please choose a valid option!");
                Console.ResetColor();
                await Task.Delay(1350);
                await doFormatData();
            }
        }
    }
}
