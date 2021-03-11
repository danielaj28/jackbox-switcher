using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace Party_Pack_Switcher
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			if (ApplicationDeployment.IsNetworkDeployed)
			{
				this.Text = string.Format("Party Pack Switcher - v{0}",
					ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString(4));
			}
		}

		private void btn1_Click(object sender, EventArgs e)
		{
			Program.ChangePack(1);
		}

		private void btn2_Click(object sender, EventArgs e)
		{
			Program.ChangePack(2);
		}

		private void btn3_Click(object sender, EventArgs e)
		{
			Program.ChangePack(3);
		}

		private void btn4_Click(object sender, EventArgs e)
		{
			Program.ChangePack(4);
		}

		private void btn5_Click(object sender, EventArgs e)
		{
			Program.ChangePack(5);
		}

		private void btn6_Click(object sender, EventArgs e)
		{
			Program.ChangePack(6);
		}

		private void btn7_Click(object sender, EventArgs e)
		{
			Program.ChangePack(7);
		}

		private void sendFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/danielaj28/Jackbox-Switcher/issues");
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/danielaj28/Jackbox-Switcher");
		}
	}
}
