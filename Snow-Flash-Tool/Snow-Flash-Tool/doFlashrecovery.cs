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
	class doFlashrecovery
	{
		public static async Task AskIfRebootRecovery()
		{
			string result = Console.ReadLine();
			if (result.Equals("y", StringComparison.OrdinalIgnoreCase) || result.Equals("yes", StringComparison.OrdinalIgnoreCase))
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
				cmd.Start();
				Console.ForegroundColor = ConsoleColor.Blue;
				await cmd.StandardInput.WriteLineAsync("fastboot reboot recovery");
				await Task.Delay(340);
				Console.ResetColor();
				Console.WriteLine(" ");
				Console.WriteLine("Finished, if you would like to return to the main menu, press any key.");
				Console.ReadKey();
				await Mainmenu.Main();
			}
			else if (result.Equals("n", StringComparison.OrdinalIgnoreCase) || result.Equals("no", StringComparison.OrdinalIgnoreCase))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Skipped Reboot!");
				await Task.Delay(340);
				Console.ResetColor();
				Console.WriteLine(" ");
				Console.WriteLine("Finished, if you would like to return to the main menu, press any key.");
				Console.ReadKey();
				await Mainmenu.Main();
			}
			else
			{
				Program.ClearLastLine();
				Program.ClearLastLine();
				Program.ClearLastLine();
				Program.ClearLastLine();
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Please enter a valid option!");
				await Task.Delay(1350);
				Program.ClearLastLine();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("---------------------------------------------");
				Console.WriteLine("| Would you like to reboot to recovery? Y/N |");
				Console.WriteLine("---------------------------------------------");
				Console.ResetColor();
				await AskIfRebootRecovery();
			}
		}
		public static async Task AskIfFlashToBothSlots()
		{
			var shell = "/bin/bash";
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
				shell = "cmd.exe";
			}
			Process cmd12 = new Process();
			cmd12.StartInfo.FileName = shell;
			cmd12.StartInfo.RedirectStandardInput = true;
			cmd12.StartInfo.RedirectStandardOutput = true;
			cmd12.StartInfo.CreateNoWindow = false;
			cmd12.StartInfo.UseShellExecute = false;
			string result12 = Console.ReadLine();
			if (result12.Equals("y", StringComparison.OrdinalIgnoreCase) || result12.Equals("yes", StringComparison.OrdinalIgnoreCase))
			{
				cmd12.Start();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("Flashing...");
				Console.ResetColor();
				Console.WriteLine("");
				Console.WriteLine("Make sure the device stays connected!");
				Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
				Console.WriteLine("");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Title = "Flashing";
				await cmd12.StandardInput.WriteLineAsync("fastboot flash recovery_a recovery.img");
				await cmd12.StandardInput.WriteLineAsync("fastboot flash recovery_b recovery.img");
				await Task.Delay(450);
				Console.Title = "Finished";
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine("| Finished. Would you like to reboot to recovery? Y/N |");
				Console.WriteLine("-------------------------------------------------------");
				Console.ResetColor();
				await doAskifreboot.AskIfReboot();
			}
			else if (result12.Equals("n", StringComparison.OrdinalIgnoreCase) || result12.Equals("no", StringComparison.OrdinalIgnoreCase))
			{
				cmd12.Start();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("Flashing...");
				Console.ResetColor();
				Console.WriteLine("");
				Console.WriteLine("Make sure the device stays connected!");
				Console.WriteLine("If any issues or unexpected problems occur, message me on Telegram @SnowTalking or xda!");
				Console.WriteLine("");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.Title = "Flashing";
				await cmd12.StandardInput.WriteLineAsync("fastboot flash recovery recovery.img");
				await Task.Delay(450);
				Console.Title = "Finished";
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("-------------------------------------------------------");
				Console.WriteLine("| Finished. Would you like to reboot to recovery? Y/N |");
				Console.WriteLine("-------------------------------------------------------");
				Console.ResetColor();
				await AskIfRebootRecovery();
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Please enter a valid option!");
				await Task.Delay(1350);
				Program.ClearLastLine();
				Program.ClearLastLine();
				await AskIfFlashToBothSlots();
			}
		}
	}
}
