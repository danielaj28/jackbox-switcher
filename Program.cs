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

		internal static void ChangePack(int packNumber)
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

			string packPath;

			if (packNumber == 1)
			{
				packPath = @"The Jackbox Party Pack\The Jackbox Party Pack.exe";
			}
			else
			{
				packPath = String.Format(@"The Jackbox Party Pack {0}\The Jackbox Party Pack {0}.exe", packNumber);
			}

			Process jbProcess = new Process();

			foreach (var steamLocation in steamLocations)
			{
				try
				{
					jbProcess.StartInfo.FileName = steamLocation + packPath;
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
					FolderBrowserDialog folderDialog = new FolderBrowserDialog
					{
						ShowNewFolderButton = false,
						RootFolder = Environment.SpecialFolder.MyComputer,
						Description = "Navigate and select the \"Steam\" folder location to add to available directories."
					};

					if (folderDialog.ShowDialog() == DialogResult.OK)
					{
						if (!folderDialog.SelectedPath.EndsWith("Steam"))
						{
							MessageBox.Show("Unfortunately the folder selected was not the folder called \"Steam\", please try again.", "Invalid Folder Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}

						String newPath = String.Format("{0}\\steamapps\\common\\", folderDialog.SelectedPath);
						steamLocations.Add(newPath);

						var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
						config.AppSettings.Settings["steamLocations"].Value = String.Join(",", steamLocations);
						config.Save(ConfigurationSaveMode.Modified);

						ConfigurationManager.RefreshSection("appSettings");

						MessageBox.Show(String.Format("New path has been added as: \n{0}\nAttempting to launch again", newPath), "Path Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
						ChangePack(packNumber);
					}
				}
			}
		}
	}
}