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

namespace Snow-Flash-Tool
{
	class doReboottorecovery
	{
		public static async Task doRebootToreocvery()
		{
			var shell = "/bin/bash";
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
				shell = "cmd.exe";
			}
			Process cmd4 = new Process();
			cmd4.StartInfo.FileName = shell;
			cmd4.StartInfo.RedirectStandardInput = true;
			cmd4.StartInfo.RedirectStandardOutput = true;
			cmd4.StartInfo.CreateNoWindow = false;
			cmd4.StartInfo.UseShellExecute = false;
			Console.Title = "Selected - Reboot to recovery";
			Console.Clear();
			Console.WriteLine("Are you sure you would like to continue? Y/N or R (return)");
			string result4 = Console.ReadLine();
			if (result4.Equals("y", StringComparison.OrdinalIgnoreCase) || result4.Equals("yes", StringComparison.OrdinalIgnoreCase))
			{
				Console.Title = "Reboot to recovery";
				Console.Clear();
				cmd4.Start();


				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("Rebooting");
				Console.ResetColor();
				Console.WriteLine("");
				Console.WriteLine("Make sure the device stays connected!");
				Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
				Console.WriteLine("");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Title = "Rebooting";
				await cmd4.StandardInput.WriteLineAsync("fastboot reboot recovery");
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
			else if (result4.Equals("n", StringComparison.OrdinalIgnoreCase) || result4.Equals("no", StringComparison.OrdinalIgnoreCase))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Cancelled, Closing...");
				await Task.Delay(1300);
				Environment.Exit(0);
				Console.ReadKey();
			}
			else if (result4.Equals("r", StringComparison.OrdinalIgnoreCase) || result4.Equals("return", StringComparison.OrdinalIgnoreCase))
			{
				await Toolsmenu.ToolsMenu();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Please choose a valid option!");
				Console.ResetColor();
				await Task.Delay(1350);
				await doRebootToreocvery();
			}
		}
	}
}
