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

namespace Snow_Flash_Tool
{
	public class doUnlockbootloader
	{
		public static async Task doUnlockBootloader()
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
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Title = "Selected - Unlock Bootloader";
			Console.WriteLine("WARNING! This is a dangerous command, use at your own risk! Are you sure you would like to continue? Y/N or R (return)");
			Console.ResetColor();
			string result1 = Console.ReadLine();
			if (result1.Equals("y", StringComparison.OrdinalIgnoreCase) || result1.Equals("yes", StringComparison.OrdinalIgnoreCase))
			{
				Console.Clear();
				Console.WriteLine("Note: Leave this blank if your device is a pixel for example and doesnt require a code.");
				Console.Write("Please give the bootloader unlock code: ");
				string unlockCode = Console.ReadLine();
				if (unlockCode.Contains("#"))
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.Write("Please format your code! Press any key to return to main menu.");
					Console.Write("\nUnlock code given: ");
					Console.ForegroundColor = ConsoleColor.White;
					Console.Write(unlockCode);
					Console.ReadKey();
					await Mainmenu.Main();
				}
				else if (unlockCode.Contains(" "))
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("Unlock codes can not contain spaces! Press any key to return to main menu.");
					Console.ForegroundColor = ConsoleColor.White;
					Console.ReadKey();
					await Mainmenu.Main();
				}
				else
				{
					Console.Clear();
					Console.Title = "Unlocking bootloader";
					cmd.Start();


					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("Unlocking bootloader");
					Console.ResetColor();
					Console.WriteLine("");
					Console.WriteLine("Make sure the device stays connected!");
					Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
					Console.WriteLine("");
					Console.ForegroundColor = ConsoleColor.Blue;
					await cmd.StandardInput.WriteLineAsync("fastboot oem unlock " + unlockCode);
					await Task.Delay(450);
					Console.Title = "Finished";
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("---------------------------------------------------");
					Console.WriteLine("| Finished. Press any key to return to main menu. |");
					Console.WriteLine("---------------------------------------------------");
					Console.ResetColor();
					Console.WriteLine(" ");
					if (unlockCode.Length >= 1)
					{
						Console.Write("Unlock code given: " + unlockCode);
					}
					else
					{
						Console.ForegroundColor = ConsoleColor.DarkYellow;
						Console.WriteLine("No code given");
						Console.WriteLine("Please ignore this if your phone does not require a code.");
					}

					Console.ResetColor();
					Console.ReadKey();
					await Mainmenu.Main();

				}
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
				await Mainmenu.Main();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Please choose a valid option!");
				Console.ResetColor();
				await Task.Delay(1350);
				await doUnlockBootloader();
			}
		}
	}
}
