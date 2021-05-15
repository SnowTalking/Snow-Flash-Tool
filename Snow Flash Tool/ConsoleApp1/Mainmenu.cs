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
using System.Drawing;
using Console = Colorful.Console;
using Colorful;

namespace ConsoleApp1
{
    class Mainmenu
    {
        public static async Task Main()
        {
            // A variable to keep track of the current Item, and a simple counter.
            short curItem = 0, c;

            // The object to read in a key
            ConsoleKeyInfo key;
            // Our array of Items for the menu (in order)
            string[] menuItems = { "The Snowflake", "Changelog", "Credits", "Support", "Warnings & Info", "Exit" };
            do
            {
                // Clear the screen.  One could easily change the cursor position,
                // but that won't work out well with tabbing out menu items.
                Console.Clear();
                // Replace this with whatever you want.
                Console.Title = "Snow Flash Tool";
                Console.WriteAscii("Snow Flash Tool", Color.OrangeRed);
                Console.ResetColor();

                // The loop that goes through all of the menu items.
                for (c = 0; c < menuItems.Length; c++)
                {
                    // If the current item number is our variable c, tab out this option.
                    // You could easily change it to simply change the color of the text.
                    if (curItem == c)
                    {
                        Console.WriteLine("\r> " + menuItems[c], Color.OrangeRed);
                        Console.ResetColor();
                    }
                    // Just write the current option out if the current item is not our variable c.
                    else
                    {
                        Console.WriteLine(menuItems[c]);
                    }
                }
                // Waits until the user presses a key, and puts it into our object key
                Console.WriteLine("   ");
                Console.WriteLine("Select your choice with the arrow keys.");
                Console.WriteLine("-");
                Console.WriteLine("Use Enter key to choose the current selected item.");
                Console.WriteLine(" ");
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

                    await Program.FlashMenu();

                    break;
                case 1:

                    Console.Clear();
                    Console.WriteLine("V1.2.2 (current)");
                    Console.WriteLine("Changes include:");
                    Console.WriteLine("Added get file name for gsi flash");
                    Console.WriteLine("Added get file name for recovery flash");
                    Console.WriteLine("Added TWRP flashable flash, finally");
                    Console.WriteLine("Tweaked main menu a bit, now has some cool ASCII art!");
                    Console.WriteLine("Added Warnings & Info. Please read it!");
                    Console.WriteLine("-");
                    Console.WriteLine("To return, press any key.");
                    Console.ReadKey();
                    await Main();

                    break;
                case 2:

                    Console.Clear();
                    Console.WriteLine("Developers", Color.OrangeRed);
                    Console.WriteLine("SnowTalker @XDA 2021");
                    Console.WriteLine(" ");
                    Console.WriteLine("Contributors", Color.OrangeRed);
                    Console.WriteLine("Huge thanks to @nicopizzafria for being a good friend and all in all supporting me");
                    Console.WriteLine("Thanks to discord.gg/code (TheCodingDen) for help with many nooby questions Haha");
                    Console.WriteLine("Thanks to Kevin on telegram for testing");
                    Console.WriteLine(" ");
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
                    Console.Title = "Snow Flash Tool - Warnings & Info";
                    Console.Clear();
                    Console.WriteLine("Warnings & Info Below!", Color.Red);
                    Console.ResetColor();
                    Console.WriteLine("This tool is licensed with GPL-3.0 License, For more information use these links: ");
                    Console.WriteLine("https://www.gnu.org/licenses/gpl-3.0.en.html", Color.CornflowerBlue);
                    Console.WriteLine("https://github.com/SnowTalking/Snow-Flash-Tool", Color.CornflowerBlue);
                    Console.ResetColor();
                    Console.WriteLine(" ");
                    Console.WriteLine("* I am not responsible for bricked devices, dead SD cards,");
                    Console.WriteLine("* thermonuclear war, or you getting fired because the alarm app failed. Please");
                    Console.WriteLine("* do some research if you have any concerns about features included in this TOOL");
                    Console.WriteLine("* before using it! YOU are choosing to make these modifications, and if");
                    Console.WriteLine("* you point the finger at me for messing up your device, I will laugh at you.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to return.");
                    Console.ReadKey();
                    await Mainmenu.Main();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
            }
            Console.Read();
        }
    }
}
