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
using System.Drawing;
using Console = Colorful.Console;
using Colorful;

namespace Snow_Flash_Tool
{
	class Flashfastbootmenu
	{
		public static async Task FlashFastbootMenu()
		{
			var shell = "/bin/bash";
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
				shell = "cmd.exe";
			}
			Process cmd = new Process();
			cmd.StartInfo.FileName = shell;
			cmd.StartInfo.RedirectStandardInput = true;
			cmd.StartInfo.RedirectStandardOutput = true;
			cmd.StartInfo.CreateNoWindow = false;
			cmd.StartInfo.UseShellExecute = false;

			// A variable to keep track of the current Item, and a simple counter.
			short curItem = 0, c;

			// The object to read in a key
			ConsoleKeyInfo key;
			// Our array of Items for the menu (in order)
			string[] menuItems = { "FastbootD ROM Images", "Super Image", "TWRP Flashable ZIP", "DIY Flash", "GSI", "Recovery", "Return" };
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
					Console.Title = "Selected - ROM (vbmeta, boot, system, product)";
					Console.Clear();
					Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
					string result1 = Console.ReadLine();
					if (result1.Equals("y", StringComparison.OrdinalIgnoreCase) || result1.Equals("yes", StringComparison.OrdinalIgnoreCase))
					{
						Console.Title = "ROM (vbmeta, boot, system, product)";
						Console.Clear();
						cmd.Start();

						Console.WriteLine("Flashing...");
						Console.ResetColor();
						Console.WriteLine("");
						Console.WriteLine("Make sure the device stays connected!");
						Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
						Console.WriteLine("");
						Console.Title = "Flashing";
						await cmd.StandardInput.WriteLineAsync("fastboot reboot fastboot");
						await cmd.StandardInput.WriteLineAsync("fastboot flash vbmeta vbmeta.img");
						await cmd.StandardInput.WriteLineAsync("fastboot flash boot boot.img");
						await cmd.StandardInput.WriteLineAsync("fastboot flash system system.img");
						await cmd.StandardInput.WriteLineAsync("fastboot flash product product.img");
						await Task.Delay(450);
						Console.Title = "Finished";
						Console.WriteLine("-------------------------------------------", Color.Orange);
						Console.WriteLine("| Finished. Would you like to format? Y/N |", Color.Orange);
						Console.WriteLine("-------------------------------------------", Color.Orange);
						Console.ResetColor();
						await doAskifformat.doAskIfformat();
						Console.WriteLine("-------------------------------------------", Color.Orange);
						Console.WriteLine("| Finished. Would you like to reboot? Y/N |", Color.Orange);
						Console.WriteLine("-------------------------------------------", Color.Orange);
						Console.ResetColor();
						await doAskifreboot.AskIfReboot();

					}
					else if (result1.Equals("n", StringComparison.OrdinalIgnoreCase) || result1.Equals("no", StringComparison.OrdinalIgnoreCase))
					{
						Console.WriteLine("Cancelled, Closing...", Color.Red);
						await Task.Delay(1300);
						Environment.Exit(0);
						Console.ReadKey();
					}
					else if (result1.Equals("r", StringComparison.OrdinalIgnoreCase) || result1.Equals("return", StringComparison.OrdinalIgnoreCase))
					{
						await Program.FlashMenu();
					}
					else
					{
						Console.WriteLine("Please choose a valid option!", Color.Red);
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


						Console.WriteLine("Flashing...", Color.Orange);
						Console.ResetColor();
						Console.WriteLine("");
						Console.WriteLine("Make sure the device stays connected!");
						Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
						Console.WriteLine("");
						Console.Title = "Flashing";
						await cmd.StandardInput.WriteLineAsync("fastboot flash super super.img");
						await Task.Delay(450);
						Console.Title = "Finished";
						Console.WriteLine("-------------------------------------------", Color.Orange);
						Console.WriteLine("| Finished. Would you like to format? Y/N |", Color.Orange);
						Console.WriteLine("-------------------------------------------", Color.Orange);
						Console.ResetColor();
						await doAskifformat.doAskIfformat();
						Console.WriteLine("-------------------------------------------", Color.Orange);
						Console.WriteLine("| Finished. Would you like to reboot? Y/N |", Color.Orange);
						Console.WriteLine("-------------------------------------------", Color.Orange);
						Console.ResetColor();
						await doAskifreboot.AskIfReboot();

					}
					else if (result2.Equals("n", StringComparison.OrdinalIgnoreCase) || result2.Equals("no", StringComparison.OrdinalIgnoreCase))
					{
						Console.WriteLine("Cancelled, Closing...", Color.Red);
						await Task.Delay(1300);
						Environment.Exit(0);
						Console.ReadKey();
					}
					else if (result2.Equals("r", StringComparison.OrdinalIgnoreCase) || result2.Equals("return", StringComparison.OrdinalIgnoreCase))
					{
						await Program.FlashMenu();
					}
					else
					{
						Console.WriteLine("Please choose a valid option!", Color.Red);
						Console.ResetColor();
						await Task.Delay(1350);
						goto case 1;
					}
					break;
				case 2:
					await doFlashtwrpflashable.doFlashTwrpflashable();
					break;
				case 3:
					Console.Title = "DIY Flash (Command Prompt)";
					var shell2 = "/bin/bash";
					if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
						shell2 = "cmd.exe";
					}
					Process diycmd = new Process();
					cmd.StartInfo.FileName = shell2;
					cmd.StartInfo.CreateNoWindow = false;
					cmd.Start();
					Console.Clear();
					if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
						Console.WriteLine("Started Command Prompt. To return back to flash menu, press any key.");
						Console.WriteLine("Add adb and fastboot to your PATH, so you can use it from any directory.");
					} 
					else {
						if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
							Console.WriteLine("This doesnt work on OSX because we dont know the executable for the Terminal app.");
							Console.WriteLine("Submit an Issue on our GitHub (https://github.com/SnowTalking/Snow-Flash-Tool) if you know where it is");
							Console.WriteLine("Open your own Terminal Window for now.");
							Console.WriteLine("Press any button to continue.");
						}
						else {
							if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
								Console.WriteLine("This will not work on Linux. This will never work on Linux.");
								Console.WriteLine("This is because there are too many Terminal apps for Linux.");
								Console.WriteLine("A few examples are gnome-terminal and kconsole.");
								Console.WriteLine("There are too many to guess.");
								Console.WriteLine("Just open your default Terminal if you want to DIY Flash.");
								Console.WriteLine("Press any button to continue.");

							}
						}
					}
					Console.ReadKey();
					await FlashFastbootMenu();
					break;
				case 4:
					Console.Title = "Selected - Generic System Image (GSI)";
					Console.Clear();
					Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
					string result10 = Console.ReadLine();
					if (result10.Equals("y", StringComparison.OrdinalIgnoreCase) || result10.Equals("yes", StringComparison.OrdinalIgnoreCase))
					{
						Console.Title = "Generic System Image (GSI)";
						Console.Clear();
						cmd.Start();
						Console.Write("Please give the file name of what you wish to flash: ");
						string inputfilenamegsi = Console.ReadLine();
						if (inputfilenamegsi.EndsWith(".img"))
						{
							Console.WriteLine(" ");
							Console.WriteLine("Please dont include .img , only the file name!", Color.Red);
							Console.ResetColor();
							await Task.Delay(2300);
							goto case 4;
						}
						else if (inputfilenamegsi.Contains(" "))
						{
							Console.WriteLine(" ");
							Console.WriteLine("File name cannot contain a space! (adb and fastboot restrictions)", Color.Red);
							Console.ResetColor();
							await Task.Delay(2300);
							goto case 4;
						}
						else
						{
							Console.WriteLine("Flashing...", Color.Orange);
							Console.ResetColor();
							Console.WriteLine("");
							Console.WriteLine("Make sure the device stays connected!");
							Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
							Console.WriteLine("");
							Console.Title = "Flashing";
							await cmd.StandardInput.WriteLineAsync("fastboot flash system " + inputfilenamegsi + ".img" );
							await Task.Delay(450);
							Console.Title = "Finished";
							Console.WriteLine("-------------------------------------------", Color.Orange);
							Console.WriteLine("| Finished. Would you like to format? Y/N |", Color.Orange);
							Console.WriteLine("-------------------------------------------", Color.Orange);
							Console.ResetColor();
							await doAskifformat.doAskIfformat();
							Console.WriteLine("-------------------------------------------", Color.Orange);
							Console.WriteLine("| Finished. Would you like to reboot? Y/N |", Color.Orange);
							Console.WriteLine("-------------------------------------------", Color.Orange);
							Console.ResetColor();
							await doAskifreboot.AskIfReboot();
						}
					}
					else if (result10.Equals("n", StringComparison.OrdinalIgnoreCase) || result10.Equals("no", StringComparison.OrdinalIgnoreCase))
					{
						Console.WriteLine("Cancelled, Closing...", Color.Red);
						await Task.Delay(1300);
						Environment.Exit(0);
						Console.ReadKey();
					}
					else if (result10.Equals("r", StringComparison.OrdinalIgnoreCase) || result10.Equals("return", StringComparison.OrdinalIgnoreCase))
					{
						await FlashFastbootMenu();
					}
					else
					{
						Console.WriteLine("Please choose a valid option!", Color.Red);
						Console.ResetColor();
						await Task.Delay(1350);
						goto case 4;
					}
					break;
				case 5:
					Console.Title = "Selected - Recovery";
					Console.Clear();
					Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
					string result11 = Console.ReadLine();
					if (result11.Equals("y", StringComparison.OrdinalIgnoreCase) || result11.Equals("yes", StringComparison.OrdinalIgnoreCase))
					{
						Console.Title = "Recovery";
						Console.Clear();
						cmd.Start();
						Console.Write("Please give the file name of what you wish to flash: ");
						string filenameinput2 = Console.ReadLine();
						if (filenameinput2.EndsWith(".img"))
						{
							Console.WriteLine(" ");
							Console.WriteLine("Please dont include .img , only the file name!", Color.Red);
							Console.ResetColor();
							await Task.Delay(2300);
							goto case 5;
						}
						else if (filenameinput2.Contains(" "))
						{
							Console.WriteLine(" ");
							Console.WriteLine("File name cannot contain a space! (adb and fastboot restrictions)", Color.Red);
							Console.ResetColor();
							await Task.Delay(2300);
							goto case 5;
						}
						else
						{
							Console.WriteLine("Would you like to flash to both slots? Y or N (flash to current slot)");
							await doFlashrecovery.AskIfFlashToBothSlots();
						}
					}
					else if (result11.Equals("n", StringComparison.OrdinalIgnoreCase) || result11.Equals("no", StringComparison.OrdinalIgnoreCase))
					{
						Console.WriteLine("Cancelled, Closing...", Color.Red);
						await Task.Delay(1300);
						Environment.Exit(0);
						Console.ReadKey();
					}
					else if (result11.Equals("r", StringComparison.OrdinalIgnoreCase) || result11.Equals("return", StringComparison.OrdinalIgnoreCase))
					{
						await FlashFastbootMenu();
					}
					else
					{
						Console.WriteLine("Please choose a valid option!", Color.Red);
						Console.ResetColor();
						await Task.Delay(1350);
						goto case 5;
					}
					break;
				case 6:
					await Program.FlashMenu();
					break;
			}
		}
	}
}
