using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClubManager.Model;

namespace ClubManager
{
	public partial class frmMemberShipPlan : Form
	{
		private MemberShipPlan MemberShipPlanBeforeEdit = null;
		public frmMemberShipPlan()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{

		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			if (MemberShipPlanBeforeEdit != null)
			{
				txtMemberShip.Text = MemberShipPlanBeforeEdit.MemberShip.ToString();
				txtDescription.Text = MemberShipPlanBeforeEdit.Description.ToString();
				txtMonthlyFee.Text = MemberShipPlanBeforeEdit.MonthlyFee.ToString();
				txtQuarterlyFee.Text = MemberShipPlanBeforeEdit.QuarterlyFee.ToString();
				txtHalfYearlyFee.Text = MemberShipPlanBeforeEdit.HalfYearlyFee.ToString();
				txtAnnualFee.Text = MemberShipPlanBeforeEdit.AnnualFee.ToString();
				chkIsActive.Checked = MemberShipPlanBeforeEdit.IsActive;
			}
			else
			{
				txtMemberShip.Text =
					txtDescription.Text =
					txtMonthlyFee.Text =
					txtQuarterlyFee.Text =
					txtHalfYearlyFee.Text =
					txtAnnualFee.Text = "";
				chkIsActive.Checked = true;
			}
		}

		public void NewPlan()
		{
			MemberShipPlanBeforeEdit = null;
			btnReset_Click(null, null);
			this.Show();
			this.Focus();
		}

		public void EditPlan(MemberShipPlan MemberShipPlan )
		{
			MemberShipPlanBeforeEdit = null;
			btnReset_Click(null, null);
			this.Show();
			this.Focus();
		}
	}
}