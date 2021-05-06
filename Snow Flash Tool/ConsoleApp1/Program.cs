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
    class Program
    {
        public void getAllFiles(string directoryPath)
        {
            var arlist = new ArrayList();
            DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo f in files)
            {
                arlist.Add(f.Name);
                Console.WriteLine(f.Name);
            }

            Console.ReadLine();
        }
        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - (Console.WindowWidth >= Console.BufferWidth ? 1 : 0));
        }
        static async Task AskIfReboot()
        {
            string result = Console.ReadLine();
            if (result.Equals("y", StringComparison.OrdinalIgnoreCase) || result.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Process cmd = new Process();

                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = false;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                Console.ForegroundColor = ConsoleColor.Blue;
                await cmd.StandardInput.WriteLineAsync("fastboot reboot");
                await Task.Delay(340);
                Console.ResetColor();
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.StandardOutput.ReadToEnd();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                Console.ResetColor();
                Console.WriteLine("Finished, if you would like to return to the main menu, press any key.");
                Console.ReadKey();
                await Main();
            }
            else if (result.Equals("n", StringComparison.OrdinalIgnoreCase) || result.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Skipped Reboot!");
                await Task.Delay(340);
                Console.ResetColor();
                Console.WriteLine("   ");
                Console.WriteLine("Finished, if you would like to return to the main menu, press any key.");
                Console.ReadKey();
                await Main();
            }
            else
            {
                ClearLastLine();
                ClearLastLine();
                ClearLastLine();
                ClearLastLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter a valid option!");
                await Task.Delay(1350);
                ClearLastLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("---------------------------------");
                Console.WriteLine("| Would you like to reboot? Y/N |");
                Console.WriteLine("---------------------------------");
                Console.ResetColor();
                await AskIfReboot();
            }
        }
        static async Task Fastboot()
        {
            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;


            // A variable to keep track of the current Item, and a simple counter.
            short curItem = 0, c;

            // The object to read in a key
            ConsoleKeyInfo key;
            // Our array of Items for the menu (in order)
            string[] menuItems = { "ROM (vbmeta, boot, system, product)", "Super Image", "TWRP Flashable", "Return" };
            do
            {
                // Clear the screen.  One could easily change the cursor position,
                // but that won't work out well with tabbing out menu items.
                Console.Clear();
                // Replace this with whatever you want.
                Console.Title = "Select an option";
                Console.ForegroundColor = ConsoleColor.White;

                // The loop that goes through all of the menu items.
                for (c = 0; c < menuItems.Length; c++)
                {
                    // If the current item number is our variable c, tab out this option.
                    // You could easily change it to simply change the color of the text.
                    if (curItem == c)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\r> " + menuItems[c]);
                        Console.ResetColor();
                    }
                    // Just write the current option out if the current item is not our variable c.
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }
                // Waits until the user presses a key, and puts it into our object key.
                Console.WriteLine("   ");
                Console.WriteLine("Select your choice with the arrow keys.");
                Console.WriteLine("-");
                Console.WriteLine("Use Enter key to choose the current selected item.");
                key = Console.ReadKey(true);
                // Simply put, if the key the user pressed is a "DownArrow", the current item will deacrease.
                // Likewise for "UpArrow", except in the opposite direction.
                // If curItem goes below 0 or above the maximum menu item, it just loops around to the other end.
                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);

                }

                // Loop around until the user presses the enter go.

            } while (key.KeyChar != 13);

            switch (curItem)
            {
                case 0:
                    Console.Title = "Selected - ROM (vbmeta, boot, system, product)";
                    Console.Clear();
                    Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
                    string result1 = Console.ReadLine();
                    if (result1.Equals("y", StringComparison.OrdinalIgnoreCase) || result1.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Title = "ROM (vbmeta, boot, system, product)";
                        Console.Clear();
                        cmd.Start();


                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Flashing...");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Make sure the device stays connected!");
                        Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Title = "Flashing";
                        await cmd.StandardInput.WriteLineAsync("fastboot reboot fastboot");
                        await cmd.StandardInput.WriteLineAsync("fastboot flash vbmeta vbmeta.img");
                        await cmd.StandardInput.WriteLineAsync("fastboot flash boot boot.img");
                        await cmd.StandardInput.WriteLineAsync("fastboot flash system system.img");
                        await cmd.StandardInput.WriteLineAsync("fastboot flash product product.img");
                        await Task.Delay(450);
                        Console.Title = "Finished";
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("| Finished. Would you like to format? Y/N |");
                        Console.WriteLine("-------------------------------------------");
                        Console.ResetColor();
                        await AskIfFormat();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("| Finished. Would you like to reboot? Y/N |");
                        Console.WriteLine("-------------------------------------------");
                        Console.ResetColor();
                        await AskIfReboot();
                        
                    }
                    else if (result1.Equals("n", StringComparison.OrdinalIgnoreCase) || result1.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Cancelled, Closing...");
                        await Task.Delay(1300);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    else if (result1.Equals("r", StringComparison.OrdinalIgnoreCase) || result1.Equals("return", StringComparison.OrdinalIgnoreCase))
                    {
                        await Fastboot();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Please choose a valid option!");
                        Console.ResetColor();
                        await Task.Delay(1350);
                        goto case 0;
                    }
                    break;
                case 1:
                    Console.Title = "Selected - Super Image";
                    Console.Clear();
                    Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
                    string result2 = Console.ReadLine();
                    if (result2.Equals("y", StringComparison.OrdinalIgnoreCase) || result2.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Title = "Super Image";
                        Console.Clear();
                        cmd.Start();


                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Flashing...");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Make sure the device stays connected!");
                        Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Title = "Flashing";
                        await cmd.StandardInput.WriteLineAsync("fastboot flash super super.img");
                        await Task.Delay(450);
                        Console.Title = "Finished";
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("| Finished. Would you like to format? Y/N |");
                        Console.WriteLine("-------------------------------------------");
                        Console.ResetColor();
                        await AskIfFormat();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("| Finished. Would you like to reboot? Y/N |");
                        Console.WriteLine("-------------------------------------------");
                        Console.ResetColor();
                        await AskIfReboot();

                    }
                    else if (result2.Equals("n", StringComparison.OrdinalIgnoreCase) || result2.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Cancelled, Closing...");
                        await Task.Delay(1300);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    else if (result2.Equals("r", StringComparison.OrdinalIgnoreCase) || result2.Equals("return", StringComparison.OrdinalIgnoreCase))
                    {
                        await Fastboot();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Please choose a valid option!");
                        Console.ResetColor();
                        await Task.Delay(1350);
                        goto case 1;
                    }
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Soon.");
                    Console.WriteLine("Press any key to return.");
                    Console.ReadKey();
                    await Fastboot();
                    break;
                case 3:
                    await Return();
                    break;
            }
        }
        static async Task Return()
        {
            Console.Clear();
            await Main();
        }

        static async Task Main()
        {
            


            // A variable to keep track of the current Item, and a simple counter.
            short curItem = 0, c;

            // The object to read in a key
            ConsoleKeyInfo key;
            // Our array of Items for the menu (in order)
            string[] menuItems = { "The Flasher", "Changelog", "Credits", "Support", "Exit" };
            do
            {
                // Clear the screen.  One could easily change the cursor position,
                // but that won't work out well with tabbing out menu items.
                Console.Clear();
                // Replace this with whatever you want.
                Console.Title = "Snow Flash Tool";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Welcome To Snow Flash Tool");
                Console.WriteLine("Made by SnowTalker @ XDA 2021");
                Console.WriteLine(" ");
                Console.ResetColor();
                
                // The loop that goes through all of the menu items.
                for (c = 0; c < menuItems.Length; c++)
                {
                    // If the current item number is our variable c, tab out this option.
                    // You could easily change it to simply change the color of the text.
                    if (curItem == c)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\r> " + menuItems[c]);
                        Console.ResetColor();
                    }
                    // Just write the current option out if the current item is not our variable c.
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }
                // Waits until the user presses a key, and puts it into our object key.
                Console.WriteLine("   ");
                Console.WriteLine("Select your choice with the arrow keys.");
                Console.WriteLine("-");
                Console.WriteLine("Use Enter key to choose the current selected item.");
                key = Console.ReadKey(true);
                // Simply put, if the key the user pressed is a "DownArrow", the current item will deacrease.
                // Likewise for "UpArrow", except in the opposite direction.
                // If curItem goes below 0 or above the maximum menu item, it just loops around to the other end.
                if (key.Key.ToString() == "DownArrow")
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                    
                }

                // Loop around until the user presses the enter go.

            } while (key.KeyChar != 13);

            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.RedirectStandardError = true;

            switch (curItem)
            {
                case 0:

                    await Fastboot();

                    break;
                case 1:

                    Console.Clear();
                    Console.WriteLine("V1.1.1 (current)");
                    Console.WriteLine("Changes include:");
                    Console.WriteLine("Now we are Snow Flash Tool!! Lol.");
                    Console.WriteLine("Added The Flasher for falshing various ways!");
                    Console.WriteLine("Added more notes.");
                    Console.WriteLine("-");
                    Console.WriteLine("To return, press any key.");
                    Console.ReadKey();
                    await Main();

                    break;
                case 2:

                    Console.Clear();
                    Console.WriteLine("Huge thanks to @nicopizzafria for being a good friend and all in all supporting me");
                    Console.WriteLine("Thanks to discord.gg/code (TheCodingDen) for help with many nooby questions Haha");
                    Console.WriteLine("Thanks to Kevin on telegram for testing");
                    Console.WriteLine("-");
                    Console.WriteLine("To return, press any key.");
                    Console.ReadKey();
                    await Main();

                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Link launched. To return to the main menu, press any key.");
                    System.Diagnostics.Process.Start("https://t.me/snowflashtooldiscussion");
                    Console.ReadKey();
                    await Main();

                    break;
                case 4:
                    Environment.Exit(0);
                    cmd.Close();
                    cmd.Kill();
                    break;
            }
            Console.Read();
        }
        static async Task AskIfFormat()
        {
            string result = Console.ReadLine();
            if (result.Equals("y", StringComparison.OrdinalIgnoreCase) || result.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Process cmd = new Process();

                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = false;
                cmd.StartInfo.UseShellExecute = false;
                cmd.Start();
                Console.ForegroundColor = ConsoleColor.Blue;
                await cmd.StandardInput.WriteLineAsync("fastboot -w");
                await Task.Delay(340);
                Console.ResetColor();
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.StandardOutput.ReadToEnd();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("| Finished. Would you like to reboot? Y/N |");
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                await AskIfReboot();
            }
            else if (result.Equals("n", StringComparison.OrdinalIgnoreCase) || result.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Skipped Format!");
                Console.ResetColor();
                await Task.Delay(340);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("| Finished. Would you like to reboot? Y/N |");
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
                await AskIfReboot();
            }
            else
            {
                ClearLastLine();
                ClearLastLine();
                ClearLastLine();
                ClearLastLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter a valid option!");
                await Task.Delay(1350);
                ClearLastLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("---------------------------------");
                Console.WriteLine("| Would you like to format? Y/N |");
                Console.WriteLine("---------------------------------");
                Console.ResetColor();
                await AskIfFormat();
            }
        }
    }
}

