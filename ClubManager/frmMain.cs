using System;
using System.Windows.Forms;

namespace ClubManager
{
	public partial class frmMain : Form
	{
		public frmMain()
		{
			InitializeComponent();
		}

		private void newPlanToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void planManagerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormManager.MemberShipPlan.Show();
			FormManager.MemberShipPlan.Focus();
		}
	}
}