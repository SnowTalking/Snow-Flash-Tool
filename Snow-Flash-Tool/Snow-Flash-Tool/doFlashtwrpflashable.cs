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
	class doFlashtwrpflashable
	{
		public static async Task doFlashTwrpflashable()
		{
			Console.Title = "Selected - TWRP Flashable";
			Console.Clear();
			Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
			string result13 = Console.ReadLine();
			if (result13.Equals("y", StringComparison.OrdinalIgnoreCase) || result13.Equals("yes", StringComparison.OrdinalIgnoreCase))
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
				Console.Title = "TWRP Flashable";
				Console.Clear();
				cmd.Start();
				Console.Write("Please give the file name of what you wish to flash: ");
				string filenameinput = Console.ReadLine();
				if (filenameinput.EndsWith(".zip"))
				{
					Console.WriteLine(" ");
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("Please dont include .zip , only the file name!");
					Console.ResetColor();
					await Task.Delay(2300);
					await doFlashTwrpflashable();
				}
				else if (filenameinput.Contains(" "))
				{
					Console.WriteLine(" ");
					Console.ForegroundColor = ConsoleColor.DarkRed;
					Console.WriteLine("File name cannot contain a space! (adb and fastboot restrictions)");
					Console.ResetColor();
					await Task.Delay(2300);
					await doFlashTwrpflashable(); 
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("Flashing...");
					Console.ResetColor();
					Console.WriteLine("");
					Console.WriteLine("Make sure the device stays connected!");
					Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
					Console.WriteLine("");
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.Title = "Flashing";
					await cmd.StandardInput.WriteLineAsync("adb reboot sideload");
					await cmd.StandardInput.WriteLineAsync("adb sideload " + filenameinput + ".zip");
					await Task.Delay(450);
					Console.Title = "Finished";
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("-------------------------------------------------------------");
					Console.WriteLine("| Finished. Would you like to format? (mainly for roms) Y/N |");
					Console.WriteLine("-------------------------------------------------------------");
					Console.ResetColor();
					await doAskifformat.doAskIfformat();
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("-------------------------------------------");
					Console.WriteLine("| Finished. Would you like to reboot? Y/N |");
					Console.WriteLine("-------------------------------------------");
					Console.ResetColor();
					await doAskifreboot.AskIfReboot();
				}
			}
			else if (result13.Equals("n", StringComparison.OrdinalIgnoreCase) || result13.Equals("no", StringComparison.OrdinalIgnoreCase))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Cancelled, Closing...");
				await Task.Delay(1300);
				Environment.Exit(0);
				Console.ReadKey();
			}
			else if (result13.Equals("r", StringComparison.OrdinalIgnoreCase) || result13.Equals("return", StringComparison.OrdinalIgnoreCase))
			{
				await Program.FlashMenu();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Please choose a valid option!");
				Console.ResetColor();
				await Task.Delay(1350);
				await doFlashTwrpflashable();
			}
		}
	}
}
