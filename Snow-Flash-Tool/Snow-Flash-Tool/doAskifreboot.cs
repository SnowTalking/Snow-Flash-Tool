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
	class doAskifreboot
	{
		public static async Task AskIfReboot()
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
				await cmd.StandardInput.WriteLineAsync("fastboot reboot");
				await Task.Delay(340);
				Console.ResetColor();
				cmd.StandardInput.Flush();
				cmd.StandardInput.Close();
				cmd.StandardOutput.ReadToEnd();
				Console.WriteLine(cmd.StandardOutput.ReadToEnd());
				Console.ResetColor();
				Console.WriteLine("Finished, if you would like to return to the main menu, press any key.");
				Console.ReadKey();
				await Program.FlashMenu();
			}
			else if (result.Equals("n", StringComparison.OrdinalIgnoreCase) || result.Equals("no", StringComparison.OrdinalIgnoreCase))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Skipped Reboot!");
				await Task.Delay(340);
				Console.ResetColor();
				Console.WriteLine("   ");
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
				Console.WriteLine("---------------------------------");
				Console.WriteLine("| Would you like to reboot? Y/N |");
				Console.WriteLine("---------------------------------");
				Console.ResetColor();
				await AskIfReboot();
			}
		}
	}
}
