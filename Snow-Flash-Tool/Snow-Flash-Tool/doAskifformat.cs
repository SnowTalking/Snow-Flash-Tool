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
	class doAskifformat
	{
		public static async Task doAskIfformat()
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
				await cmd.StandardInput.WriteLineAsync("fastboot -w");
				await Task.Delay(340);
				Console.ResetColor();
				cmd.StandardInput.Flush();
				cmd.StandardInput.Close();
				cmd.StandardOutput.ReadToEnd();
				Console.WriteLine(cmd.StandardOutput.ReadToEnd());
				Console.ResetColor();
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("-------------------------------------------");
				Console.WriteLine("| Finished. Would you like to reboot? Y/N |");
				Console.WriteLine("-------------------------------------------");
				Console.ResetColor();
				await doAskifreboot.AskIfReboot();
			}
			else if (result.Equals("n", StringComparison.OrdinalIgnoreCase) || result.Equals("no", StringComparison.OrdinalIgnoreCase))
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Skipped Format!");
				Console.ResetColor();
				await Task.Delay(340);
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("-------------------------------------------");
				Console.WriteLine("| Finished. Would you like to reboot? Y/N |");
				Console.WriteLine("-------------------------------------------");
				Console.ResetColor();
				await doAskifreboot.AskIfReboot();
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
				Console.WriteLine("| Would you like to format? Y/N |");
				Console.WriteLine("---------------------------------");
				Console.ResetColor();
				await doAskIfformat();
			}
		}
	}
}
