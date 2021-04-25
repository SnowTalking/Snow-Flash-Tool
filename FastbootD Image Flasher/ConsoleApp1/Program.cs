using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 

            Console.WriteLine("Welcome To FastbootD Image Flasher!");
            Console.WriteLine("Made by SnowTalker @ XDA 2021");
            Console.WriteLine("              ");
            Console.WriteLine("Press any key to start.");

            Console.ReadKey();

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
                Console.WriteLine("Choose an option . . .");
                // The loop that goes through all of the menu items.
                for (c = 0; c < menuItems.Length; c++)
                {
                    // If the current item number is our variable c, tab out this option.
                    // You could easily change it to simply change the color of the text.
                    if (curItem == c)
                    {
                        Console.Write("> ");
                        Console.WriteLine(menuItems[c]);
                    }
                    // Just write the current option out if the current item is not our variable c.
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }
                // Waits until the user presses a key, and puts it into our object key.
                Console.Write("Select your choice with the arrow keys.");
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
                    Process cmd = new Process();

                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = false;
                    cmd.StartInfo.UseShellExecute = false;

                    cmd.Start();

                    /* execute "dir" */
                    Console.Clear();
                    Console.WriteLine("Are you sure you would like to continue? Y/N ");
                    string result = Console.ReadLine();
                    if (result.Equals("y", StringComparison.OrdinalIgnoreCase) || result.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        cmd.Start();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cancelled, Closing...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Flashing... Please be patient.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    cmd.StandardInput.WriteLine("fastboot flash vbmeta vbmeta.img");
                    cmd.StandardInput.WriteLine("fastboot flash boot boot.img");
                    cmd.StandardInput.WriteLine("fastboot flash system system.img");
                    cmd.StandardInput.WriteLine("fastboot flash product product.img");
                    cmd.StandardInput.WriteLine("fastboot -w");
                    cmd.StandardInput.WriteLine("fastboot reboot");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();
                    Console.WriteLine(cmd.StandardOutput.ReadToEnd());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Finished! You may close this window.");
                    Console.WriteLine("------------------------------------");
                    break;
                case 1:
                    Process p = new Process();

                    p.StartInfo.FileName = "cmd.exe";
                    p.StartInfo.RedirectStandardInput = true;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.CreateNoWindow = false;
                    p.StartInfo.UseShellExecute = false;

                    p.Start();

                    /* execute "dir" */
                    Console.Clear();
                    Console.WriteLine("Would you like to continue? Y/N ");
                    string resultt = Console.ReadLine();
                    if (resultt.Equals("y", StringComparison.OrdinalIgnoreCase) || resultt.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        p.Start();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cancelled, Closing...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Flashing... Please be patient.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    p.StandardInput.WriteLine("fastboot flash vbmeta vbmeta.img");
                    p.StandardInput.WriteLine("fastboot flash boot boot.img");
                    p.StandardInput.WriteLine("fastboot flash system system.img");
                    p.StandardInput.WriteLine("fastboot flash product product.img");
                    p.StandardInput.WriteLine("fastboot -w");
                    p.StandardInput.Flush();
                    p.StandardInput.Close();
                    Console.WriteLine(p.StandardOutput.ReadToEnd());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Finished! You may close this window.");
                    Console.WriteLine("------------------------------------");
                    break;
                case 2:
                    Process a = new Process();

                    a.StartInfo.FileName = "cmd.exe";
                    a.StartInfo.RedirectStandardInput = true;
                    a.StartInfo.RedirectStandardOutput = true;
                    a.StartInfo.CreateNoWindow = false;
                    a.StartInfo.UseShellExecute = false;

                    a.Start();

                    Console.Clear();
                    Console.WriteLine("Would you like to continue? Y/N ");
                    string resulttt = Console.ReadLine();
                    if (resulttt.Equals("y", StringComparison.OrdinalIgnoreCase) || resulttt.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        a.Start();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cancelled, Closing...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Flashing... Please be patient.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    a.StandardInput.WriteLine("fastboot flash vbmeta vbmeta.img");
                    a.StandardInput.WriteLine("fastboot flash boot boot.img");
                    a.StandardInput.WriteLine("fastboot flash system system.img");
                    a.StandardInput.WriteLine("fastboot flash product product.img");
                    a.StandardInput.Flush();
                    a.StandardInput.Close();
                    Console.WriteLine(a.StandardOutput.ReadToEnd());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Finished! You may close this window.");
                    Console.WriteLine("------------------------------------");
                    break;
                case 3:
                    Process b = new Process();

                    b.StartInfo.FileName = "cmd.exe";
                    b.StartInfo.RedirectStandardInput = true;
                    b.StartInfo.RedirectStandardOutput = true;
                    b.StartInfo.CreateNoWindow = false;
                    b.StartInfo.UseShellExecute = false;

                    b.Start();

                    Console.Clear();
                    Console.WriteLine("Would you like to continue? Y/N ");
                    string resultttt = Console.ReadLine();
                    if (resultttt.Equals("y", StringComparison.OrdinalIgnoreCase) || resultttt.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.Clear();
                        b.Start();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Cancelled, Closing...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        Console.ReadKey();
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Flashing... Please be patient.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    b.StandardInput.WriteLine("fastboot flash vbmeta vbmeta.img");
                    b.StandardInput.WriteLine("fastboot flash boot boot.img");
                    b.StandardInput.WriteLine("fastboot flash system system.img");
                    b.StandardInput.WriteLine("fastboot flash product product.img");
                    b.StandardInput.WriteLine("fastboot reboot");
                    b.StandardInput.Flush();
                    b.StandardInput.Close();
                    Console.WriteLine(b.StandardOutput.ReadToEnd());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Finished! You may close this window.");
                    Console.WriteLine("------------------------------------");
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
            Console.Read();
        }
    }
}
