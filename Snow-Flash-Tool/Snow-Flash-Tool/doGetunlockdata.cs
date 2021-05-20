using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.IO;
using System.Collections;

namespace ConsoleApp1
{
    public class doGetunlockdata
    {
        public static async Task AskIfContinueUnlockData()
        {
            string result9 = Console.ReadLine();
            if (result9.Equals("y", StringComparison.OrdinalIgnoreCase) || result9.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                System.Diagnostics.Process.Start("https://support.motorola.com/us/en/dataScrubTool");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.WriteLine("| Finished. You can now submit this data after scrubbing to the motorola website! |");
                Console.WriteLine("-----------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.ReadKey();
                await Mainmenu.Main();
            }
            else if (result9.Equals("n", StringComparison.OrdinalIgnoreCase) || result9.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("| Finished. You can now submit this data to the motorola website! (after of course scrubbing the data) |");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                Console.ReadKey();
                await Mainmenu.Main();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please choose a valid option!");
                await Task.Delay(1350);
                Program.ClearLastLine();
                Program.ClearLastLine();
                Program.ClearLastLine();
                Program.ClearLastLine();
                Program.ClearLastLine();
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.WriteLine("| Would you like to scrub the data? (gets unlock code data) (opens moto scrub tool) |");
                Console.WriteLine("-------------------------------------------------------------------------------------");
                Console.ResetColor();
                await AskIfContinueUnlockData();
            }
        }
        public static async Task doGetUnlockdata()
        {
            Process cmd8 = new Process();

            cmd8.StartInfo.FileName = "cmd.exe";
            cmd8.StartInfo.RedirectStandardInput = true;
            cmd8.StartInfo.RedirectStandardOutput = true;
            cmd8.StartInfo.CreateNoWindow = false;
            cmd8.StartInfo.UseShellExecute = false;
            Console.Clear();
            Console.Title = "Selected - Get Unlock Data";
            Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
            Console.ResetColor();
            string result8 = Console.ReadLine();
            if (result8.Equals("y", StringComparison.OrdinalIgnoreCase) || result8.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Title = "Getting unlock data";
                Console.Clear();
                cmd8.Start();


                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Getting unlock data");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Make sure the device stays connected!");
                Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                await cmd8.StandardInput.WriteLineAsync("fastboot oem get_unlock_data");
                await Task.Delay(450);
                Console.Title = "Finished";
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.WriteLine("| Finished. Would you like to scrub the data? (gets unlock code data, and opens moto scrub tool) |");
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.ResetColor();
                await AskIfContinueUnlockData();
            }
            else if (result8.Equals("n", StringComparison.OrdinalIgnoreCase) || result8.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Cancelled, Closing...");
                await Task.Delay(1300);
                Environment.Exit(0);
                Console.ReadKey();
            }
            else if (result8.Equals("r", StringComparison.OrdinalIgnoreCase) || result8.Equals("return", StringComparison.OrdinalIgnoreCase))
            {
                await Toolsmenu.ToolsMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please choose a valid option!");
                Console.ResetColor();
                await Task.Delay(1350);
                await doGetUnlockdata();
            }
        }
    }
}
