using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;

namespace Jackbox_Switcher
{
	static class Program
	{
		public static String PreviousProcess { get; private set; }
		public static List<String> steamLocations = new List<String>();

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
			if (steamLocations.Count == 0)
			{
				steamLocations.AddRange(ConfigurationManager.AppSettings["steamLocations"].Split(','));
			}

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

			String PackPath = "";

			switch (pack)
			{
				case 1:
					PackPath = @"The Jackbox Party Pack\The Jackbox Party Pack.exe";
					break;
				case 2:
					PackPath = @"The Jackbox Party Pack 2\The Jackbox Party Pack 2.exe";
					break;
				case 3:
					PackPath = @"The Jackbox Party Pack 3\The Jackbox Party Pack 3.exe";
					break;
				case 4:
					PackPath = @"The Jackbox Party Pack 4\The Jackbox Party Pack 4.exe";
					break;
				case 5:
					PackPath = @"The Jackbox Party Pack 5\The Jackbox Party Pack 5.exe";
					break;
				case 6:
					PackPath = @"The Jackbox Party Pack 6\The Jackbox Party Pack 6.exe";
					break;
				case 7:
					PackPath = @"The Jackbox Party Pack 7\The Jackbox Party Pack 7.exe";
					break;
			}

			Process jbProcess = new Process();

			foreach (var steamLocation in steamLocations)
			{
				try
				{
					jbProcess.StartInfo.FileName = steamLocation + PackPath;
					jbProcess.Start();
					break;
				}
				catch (Exception)
				{
				}
			}

			try
			{
				Program.PreviousProcess = jbProcess.ProcessName;
			}
			catch (Exception)
			{
				if (MessageBox.Show("Could not find Jackbox Pack, would you like to add a new steam library location?", "Pack Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					//TODO: Use Folder browser dialog to find location and add it to library list
				}
			}
		}
	}
}
