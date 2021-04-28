using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static async Task FlashFW()
            {

            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("| Are you sure you would like to continue? Y/N or R (return to main menu)|");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            string resultt = Console.ReadLine();
            if (resultt.Equals("y", StringComparison.OrdinalIgnoreCase) || resultt.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                cmd.Start();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Flashing... Please be patient.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("Make sure the device stays connected!");
                Console.WriteLine("If you have any issues report back on xda or telegram!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                await cmd.StandardInput.WriteLineAsync("fastboot reboot fastboot");
                await cmd.StandardInput.WriteLineAsync("fastboot flash vbmeta vbmeta.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash boot boot.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash system system.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash product product.img");
                await cmd.StandardInput.WriteLineAsync("fastboot -w");
                await cmd.StandardInput.WriteLineAsync("fastboot reboot");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.StandardOutput.ReadToEnd();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                Console.ResetColor();
                Console.WriteLine("Finished.");
                Console.ReadKey();
            }
            if (resultt.Equals("n", StringComparison.OrdinalIgnoreCase) || resultt.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cancelled, Closing...");
                Thread.Sleep(1300);
                Environment.Exit(0);
                Console.ReadKey();
            }
            if (resultt.Equals("r", StringComparison.OrdinalIgnoreCase) || resultt.Equals("return", StringComparison.OrdinalIgnoreCase))
            {
                await Return();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter a valid option!");
                await Task.Delay(2300);
                await Main();
            }
        }
        static async Task FlashFWR()
        {
            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("| Are you sure you would like to continue? Y/N or R (return to main menu)|");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            string result = Console.ReadLine();
            if (result.Equals("y", StringComparison.OrdinalIgnoreCase) || result.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                cmd.Start();


                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Flashing... Please be patient.");
                Console.ResetColor();
                Console.WriteLine("");
                Console.WriteLine("Make sure the device stays connected!");
                Console.WriteLine("If you have any issues report back on xda or telegram!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;

                await cmd.StandardInput.WriteLineAsync("fastboot reboot fastboot");
                await cmd.StandardInput.WriteLineAsync("fastboot flash vbmeta vbmeta.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash boot boot.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash system system.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash product product.img");
                await cmd.StandardInput.WriteLineAsync("fastboot -w");
                await cmd.StandardInput.WriteLineAsync("fastboot reboot");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.StandardOutput.ReadToEnd();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                Console.ResetColor();
                Console.WriteLine("Finished.");
                Console.ReadKey();
            }
            if (result.Equals("n", StringComparison.OrdinalIgnoreCase) || result.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cancelled, Closing...");
                Thread.Sleep(1300);
                Environment.Exit(0);
                Console.ReadKey();
            }
            if (result.Equals("r", StringComparison.OrdinalIgnoreCase) || result.Equals("return", StringComparison.OrdinalIgnoreCase))
            {
                await Return();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter a valid option!");
                await Task.Delay(2300);
                await Main();
            }
        }

        static async Task Flash()
        {

            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("| Are you sure you would like to continue? Y/N or R (return to main menu)|");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            string resulttt = Console.ReadLine();
            if (resulttt.Equals("y", StringComparison.OrdinalIgnoreCase) || resulttt.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                cmd.Start();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Flashing... Please be patient.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("Make sure the device stays connected!");
                Console.WriteLine("If you have any issues report back on xda or telegram!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                await cmd.StandardInput.WriteLineAsync("fastboot reboot fastboot");
                await cmd.StandardInput.WriteLineAsync("fastboot flash vbmeta vbmeta.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash boot boot.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash system system.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash product product.img");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.StandardOutput.ReadToEnd();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                Console.ResetColor();
                Console.WriteLine("Finished.");
                Console.ReadKey();
            }
            if (resulttt.Equals("n", StringComparison.OrdinalIgnoreCase) || resulttt.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cancelled, Closing...");
                Thread.Sleep(1300);
                Environment.Exit(0);
                Console.ReadKey();
            }
            if (resulttt.Equals("r", StringComparison.OrdinalIgnoreCase) || resulttt.Equals("return", StringComparison.OrdinalIgnoreCase))
            {
                await Return();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter a valid option!");
                await Task.Delay(2300);
                await Main();
            }
        }

        static async Task FlashR()
        {
            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = false;
            cmd.StartInfo.UseShellExecute = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("| Are you sure you would like to continue? Y/N or R (return to main menu)|");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            string resulttt = Console.ReadLine();
            if (resulttt.Equals("y", StringComparison.OrdinalIgnoreCase) || resulttt.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.Clear();
                cmd.Start();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Flashing... Please be patient.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("");
                Console.WriteLine("Make sure the device stays connected!");
                Console.WriteLine("If you have any issues report back on xda or telegram!");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Blue;
                await cmd.StandardInput.WriteLineAsync("fastboot reboot fastboot");
                await cmd.StandardInput.WriteLineAsync("fastboot flash vbmeta vbmeta.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash boot boot.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash system system.img");
                await cmd.StandardInput.WriteLineAsync("fastboot flash product product.img");
                await cmd.StandardInput.WriteLineAsync("fastboot reboot");
                cmd.StandardInput.Flush();
                cmd.StandardInput.Close();
                cmd.StandardOutput.ReadToEnd();
                Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                Console.ResetColor();
                Console.WriteLine("Finished.");
                Console.ReadKey();
            }
            if (resulttt.Equals("n", StringComparison.OrdinalIgnoreCase) || resulttt.Equals("no", StringComparison.OrdinalIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cancelled, Closing...");
                Thread.Sleep(1300);
                Environment.Exit(0);
                Console.ReadKey();
            }
            if (resulttt.Equals("r", StringComparison.OrdinalIgnoreCase) || resulttt.Equals("return", StringComparison.OrdinalIgnoreCase))
            {
                await Return();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter a valid option!");
                await Task.Delay(2300);
                await Main();
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
            string[] menuItems = { "Flash all, Format and Reboot (recommended)", "Flash all, Format", "Flash all", "Flash all and Reboot", "Exit" };
            do
            {
                // Clear the screen.  One could easily change the cursor position,
                // but that won't work out well with tabbing out menu items.
                Console.Clear();
                // Replace this with whatever you want.
                Console.Title = "FastbootD Image Flasher";
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Welcome To FastbootD Image Flasher!");
                Console.WriteLine("Made by SnowTalker @ XDA 2021");
                Console.ResetColor();
                Console.WriteLine("-");
                Console.WriteLine("Choose an option . . . (prompt will appear before continuing)");
                Console.WriteLine("           ");
                // The loop that goes through all of the menu items.
                for (c = 0; c < menuItems.Length; c++)
                {
                    // If the current item number is our variable c, tab out this option.
                    // You could easily change it to simply change the color of the text.
                    if (curItem == c)
                    {
                        Console.Write(">> ");
                        Console.ResetColor();
                        Console.WriteLine(menuItems[c]);
                    }
                    // Just write the current option out if the current item is not our variable c.
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }
                // Waits until the user presses a key, and puts it into our object key.
                Console.WriteLine("         ");
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

            switch (curItem)
            {
                case 0:

                    await FlashFWR();

                    break;
                case 1:

                    await FlashFW();
                    
                    break;
                case 2:

                    await Flash();

                    break;
                case 3:

                    await FlashR();

                    break;
                case 4:
                    Console.ReadKey();
                    Environment.Exit(0);
                    cmd.Close();
                    cmd.Kill();
                    break;
            }
            Console.Read();
            }
       }
    }
