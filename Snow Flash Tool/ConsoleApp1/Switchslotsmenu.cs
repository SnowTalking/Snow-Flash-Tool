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
    class Switchslotsmenu
    {
        public static async Task SwitchSlotsMenu()
        {
            // A variable to keep track of the current Item, and a simple counter.
            short curItem = 0, c;

            // The object to read in a key
            ConsoleKeyInfo key;
            // Our array of Items for the menu (in order)
            string[] menuItems = { "Slot: A", "Slot: B", "Return" };
            do
            {
                // Clear the screen.  One could easily change the cursor position,
                // but that won't work out well with tabbing out menu items.
                Console.Clear();
                // Replace this with whatever you want.
                Console.Title = "Switch to slot";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Switch to?");
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
                if (key.Key == ConsoleKey.DownArrow)
                {
                    curItem++;
                    if (curItem > menuItems.Length - 1) curItem = 0;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    curItem--;
                    if (curItem < 0) curItem = Convert.ToInt16(menuItems.Length - 1);
                }

                // Loop around until the user presses the enter go.

            } while (key.KeyChar != 13);

            switch (curItem)
            {
                case 0:
                    Process cmd6 = new Process();

                    cmd6.StartInfo.FileName = "cmd.exe";
                    cmd6.StartInfo.RedirectStandardInput = true;
                    cmd6.StartInfo.RedirectStandardOutput = true;
                    cmd6.StartInfo.CreateNoWindow = false;
                    cmd6.StartInfo.UseShellExecute = false;
                    Console.Title = "Selected - Switch to Slot: A";
                    Console.Clear();
                    Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
                    string result6 = Console.ReadLine();
                    if (result6.Equals("y", StringComparison.OrdinalIgnoreCase) || result6.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Title = "Switch to: Slot: A ?";
                        Console.Clear();
                        cmd6.Start();


                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Rebooting");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Make sure the device stays connected!");
                        Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Title = "Rebooting";
                        await cmd6.StandardInput.WriteLineAsync("fastboot set_active a");
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
                    else if (result6.Equals("n", StringComparison.OrdinalIgnoreCase) || result6.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Cancelled, Closing...");
                        await Task.Delay(1300);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    else if (result6.Equals("r", StringComparison.OrdinalIgnoreCase) || result6.Equals("return", StringComparison.OrdinalIgnoreCase))
                    {
                        await SwitchSlotsMenu();
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
                    Process cmd7 = new Process();

                    cmd7.StartInfo.FileName = "cmd.exe";
                    cmd7.StartInfo.RedirectStandardInput = true;
                    cmd7.StartInfo.RedirectStandardOutput = true;
                    cmd7.StartInfo.CreateNoWindow = false;
                    cmd7.StartInfo.UseShellExecute = false;
                    Console.Title = "Selected - Switch to Slot: B";
                    Console.Clear();
                    Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
                    string result7 = Console.ReadLine();
                    if (result7.Equals("y", StringComparison.OrdinalIgnoreCase) || result7.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Title = "Switch to: Slot: B ?";
                        Console.Clear();
                        cmd7.Start();


                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Rebooting");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Make sure the device stays connected!");
                        Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Title = "Rebooting";
                        await cmd7.StandardInput.WriteLineAsync("fastboot set_active b");
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
                    else if (result7.Equals("n", StringComparison.OrdinalIgnoreCase) || result7.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Cancelled, Closing...");
                        await Task.Delay(1300);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    else if (result7.Equals("r", StringComparison.OrdinalIgnoreCase) || result7.Equals("return", StringComparison.OrdinalIgnoreCase))
                    {
                        await SwitchSlotsMenu();
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
                    await Toolsmenu.ToolsMenu();
                    break;
            }
        }
    }
}
