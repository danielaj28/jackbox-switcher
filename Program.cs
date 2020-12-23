using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Jackbox_Switcher
{
	static class Program
	{
		public static String PreviousProcess { get; private set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}

		internal static void ChangePack(int pack)
		{
			if (Program.PreviousProcess != null)
			{
				try
				{
					Process.GetProcessesByName(Program.PreviousProcess)[0].Kill();
				}
				catch (Exception)
				{
				}
			}

			Process jbProcess = new Process();
			switch (pack)
			{
				case 1:
					jbProcess.StartInfo.FileName = @"D:\Steam\steamapps\common\The Jackbox Party Pack\The Jackbox Party Pack.exe";
					break;
				case 2:
					jbProcess.StartInfo.FileName = @"D:\Steam\steamapps\common\The Jackbox Party Pack 2\The Jackbox Party Pack 2.exe";
					break;
				case 3:
					jbProcess.StartInfo.FileName = @"D:\Steam\steamapps\common\The Jackbox Party Pack 3\The Jackbox Party Pack 3.exe";
					break;
				case 4:
					jbProcess.StartInfo.FileName = @"D:\Steam\steamapps\common\The Jackbox Party Pack 4\The Jackbox Party Pack 4.exe";
					break;
				case 5:
					jbProcess.StartInfo.FileName = @"D:\Steam\steamapps\common\The Jackbox Party Pack 5\The Jackbox Party Pack 5.exe";
					break;
				case 6:
					jbProcess.StartInfo.FileName = @"D:\Steam\steamapps\common\The Jackbox Party Pack 6\The Jackbox Party Pack 6.exe";
					break;
				case 7:
					jbProcess.StartInfo.FileName = @"D:\Steam\steamapps\common\The Jackbox Party Pack 7\The Jackbox Party Pack 7.exe";
					break;
			}
			jbProcess.Start();
			Program.PreviousProcess = jbProcess.ProcessName;
		}
	}
}
