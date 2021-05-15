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
    class Toolsmenu
    {
        public static async Task ToolsMenu()
        {
            // A variable to keep track of the current Item, and a simple counter.
            short curItem = 0, c;

            // The object to read in a key
            ConsoleKeyInfo key;
            // Our array of Items for the menu (in order)
            string[] menuItems = { "Unlock Bootloader", "Lock Bootloader", "Get unlock data", "Reboot to fastbootd", "Reboot to recovery", "Format Data", "Change slot", "Return" };
            do
            {
                // Clear the screen.  One could easily change the cursor position,
                // but that won't work out well with tabbing out menu items.
                Console.Clear();
                // Replace this with whatever you want.
                Console.Title = "Select an option";

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
                    await doUnlockbootloader.doUnlockBootloader();
                    break;
                case 1:
                    await doLockbootloader.doLockBootloader();
                    break;
                case 2:
                    await doGetunlockdata.doGetUnlockdata();
                    break;
                case 3:
                    await doReboottofastbootd.doRebootTofastbootd();
                    break;
                case 4:
                    await doReboottorecovery.doRebootToreocvery();
                    break;
                case 5:
                    await doFormatdata.doFormatData();
                    break;
                case 6:
                    await Switchslotsmenu.SwitchSlotsMenu();
                    break;
                case 7:
                    await Program.FlashMenu();
                    break;
            }
        }
    }
}
