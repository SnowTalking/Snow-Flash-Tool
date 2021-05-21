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
	class doLockbootloader
	{
		public static async Task doLockBootloader()
		{
			var shell = "/bin/bash";
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
				shell = "cmd.exe";
			}
			Process cmd1 = new Process();
			cmd1.StartInfo.FileName = shell;
			cmd1.StartInfo.RedirectStandardInput = true;
			cmd1.StartInfo.RedirectStandardOutput = true;
			cmd1.StartInfo.CreateNoWindow = false;
			cmd1.StartInfo.UseShellExecute = false;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Title = "Selected - Lock Bootloader";
			Console.WriteLine("WARNING! This is a dangerous command, use at your own risk! Are you sure you would like to continue? Y/N or R (return)");
			Console.ResetColor();
			string result2 = Console.ReadLine();
			if (result2.Equals("y", StringComparison.OrdinalIgnoreCase) || result2.Equals("yes", StringComparison.OrdinalIgnoreCase))
			{
				Console.Title = "Locking bootloader";
				Console.Clear();
				cmd1.Start();


				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("Locking bootloader");
				Console.ResetColor();
				Console.WriteLine("");
				Console.WriteLine("Make sure the device stays connected!");
				Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
				Console.WriteLine("");
				Console.ForegroundColor = ConsoleColor.Blue;
				await cmd1.StandardInput.WriteLineAsync("fastboot oem lock");
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
				await Mainmenu.Main();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Please choose a valid option!");
				Console.ResetColor();
				await Task.Delay(1350);
				await doLockBootloader();
			}
		}
	}
}
