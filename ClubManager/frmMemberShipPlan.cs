using System;
using System.Windows.Forms;
using ClubManager.Data;
using ClubManager.Model;
using Core;
using Core.Data;

namespace ClubManager
{
	public partial class frmMemberShipPlan : Form
	{
		private MemberShipPlan MemberShipPlanBeforeEdit = null;

		public frmMemberShipPlan()
		{
			InitializeComponent();
			chkIsActive.Checked = true;
			BindGrid();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			MemberShipPlan temp = FormToObject();
			if (MemberShipPlanBeforeEdit == null)
			{
				temp._id = Context.DB.GetID(DBConstants.MemberShipPlanKey);
				Context.DB.AddNew(temp, DBConstants.MemberShipPlanTable);
			}
			else
			{
				temp._id = MemberShipPlanBeforeEdit._id;
				Context.DB.Save(temp, DBConstants.MemberShipPlanTable);
				MemberShipPlanBeforeEdit = null;
			}
			btnReset_Click(null, null);
			BindGrid();
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

		private MemberShipPlan FormToObject()
		{
			return new MemberShipPlan
			{
				MemberShip = txtMemberShip.Text,
				Description = txtDescription.Text,
				AnnualFee = txtAnnualFee.Text.ToDouble(),
				MonthlyFee = txtMonthlyFee.Text.ToDouble(),
				QuarterlyFee = txtQuarterlyFee.Text.ToDouble(),
				HalfYearlyFee = txtHalfYearlyFee.Text.ToDouble(),
				IsActive = chkIsActive.Checked
			};
		}

		private void BindGrid()
		{
			//Clear all the columns
			if (dgvMemberShipPlan.Columns.Count > 0)
				dgvMemberShipPlan.Columns.Clear();

			//Set Datasource
			dgvMemberShipPlan.DataSource = Context.DB.ListAll<MemberShipPlan>(DBConstants.MemberShipPlanTable);

			//Hide _id column
			dgvMemberShipPlan.Columns["_id"].Visible = false;

			//Add Edit button
			DataGridViewButtonColumn EditColumn = new DataGridViewButtonColumn();
			EditColumn.Text = "Edit";
			EditColumn.HeaderText = "Edit";
			EditColumn.UseColumnTextForButtonValue = true;
			dgvMemberShipPlan.Columns.Add(EditColumn);
		}

		public void NewPlan()
		{
			MemberShipPlanBeforeEdit = null;
			btnReset_Click(null, null);
			this.Show();
			this.Focus();
		}

		public void EditPlan(MemberShipPlan MemberShipPlan)
		{
			MemberShipPlanBeforeEdit = MemberShipPlan;
			btnReset_Click(null, null);
			this.Show();
			this.Focus();
		}

		private void dgvMemberShipPlan_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//Get the DataGridView object
			var senderGrid = sender as DataGridView;

			//Check if click is in valid cell
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
			{
				switch (senderGrid.Columns[e.ColumnIndex].HeaderText)
				{
					case "Edit":
						EditPlan((MemberShipPlan)senderGrid.Rows[e.RowIndex].DataBoundItem);
						break;
				}
			}
		}

		private void frmMemberShipPlan_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
	}
}