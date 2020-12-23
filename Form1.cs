using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jackbox_Switcher
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
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
	}
}
