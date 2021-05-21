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
	public class Program
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
		
		public static async Task FlashMenu()
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
			string[] menuItems = { "Flash", "Misc", "Main Menu" };
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
					await Flashfastbootmenu.FlashFastbootMenu();
					break;
				case 1:
					await Toolsmenu.ToolsMenu();
					break;
				case 2:
					await Mainmenu.Main();
					break;
			}
		}		
	}
}

