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
    class doReboottofastbootd
    {
        public static async Task doRebootTofastbootd()
        {
            Process cmd2 = new Process();

            cmd2.StartInfo.FileName = "cmd.exe";
            cmd2.StartInfo.RedirectStandardInput = true;
            cmd2.StartInfo.RedirectStandardOutput = true;
            cmd2.StartInfo.CreateNoWindow = false;
            cmd2.StartInfo.UseShellExecute = false;
            Console.Title = "Selected - Reboot to fastbootd";
            Console.Clear();
            Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
            string result3 = Console.ReadLine();
            if (result3.Equals("y", StringComparison.OrdinalIgnoreCase) || result3.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Title = "Reboot to fastbootd";
                Console.Clear();
                cmd2.Start();


                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Rebooting");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Make sure the device stays connected!");
                Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Title = "Rebooting";
                await cmd2.StandardInput.WriteLineAsync("fastboot reboot fastboot");
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
            else if (result3.Equals("n", StringComparison.OrdinalIgnoreCase) || result3.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cancelled, Closing...");
                await Task.Delay(1300);
                Environment.Exit(0);
                Console.ReadKey();
            }
            else if (result3.Equals("r", StringComparison.OrdinalIgnoreCase) || result3.Equals("return", StringComparison.OrdinalIgnoreCase))
            {
                await Toolsmenu.ToolsMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please choose a valid option!");
                Console.ResetColor();
                await Task.Delay(1350);
                await doRebootTofastbootd();
            }
        }
    }
}
