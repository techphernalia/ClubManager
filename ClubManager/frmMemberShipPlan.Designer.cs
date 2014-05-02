namespace ClubManager
{
	partial class frmMemberShipPlan
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.grpPlanDetails = new System.Windows.Forms.GroupBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.lblAnnualFee = new System.Windows.Forms.Label();
			this.lblHalfYearlyFee = new System.Windows.Forms.Label();
			this.lblQuarterlyFee = new System.Windows.Forms.Label();
			this.lblMonthlyFee = new System.Windows.Forms.Label();
			this.txtAnnualFee = new System.Windows.Forms.TextBox();
			this.txtHalfYearlyFee = new System.Windows.Forms.TextBox();
			this.txtQuarterlyFee = new System.Windows.Forms.TextBox();
			this.txtMonthlyFee = new System.Windows.Forms.TextBox();
			this.chkIsActive = new System.Windows.Forms.CheckBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtMemberShip = new System.Windows.Forms.TextBox();
			this.lblMemberShip = new System.Windows.Forms.Label();
			this.dgvMemberShipPlan = new System.Windows.Forms.DataGridView();
			this.grpPlanDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMemberShipPlan)).BeginInit();
			this.SuspendLayout();
			// 
			// grpPlanDetails
			// 
			this.grpPlanDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.grpPlanDetails.Controls.Add(this.btnReset);
			this.grpPlanDetails.Controls.Add(this.btnSave);
			this.grpPlanDetails.Controls.Add(this.lblAnnualFee);
			this.grpPlanDetails.Controls.Add(this.lblHalfYearlyFee);
			this.grpPlanDetails.Controls.Add(this.lblQuarterlyFee);
			this.grpPlanDetails.Controls.Add(this.lblMonthlyFee);
			this.grpPlanDetails.Controls.Add(this.txtAnnualFee);
			this.grpPlanDetails.Controls.Add(this.txtHalfYearlyFee);
			this.grpPlanDetails.Controls.Add(this.txtQuarterlyFee);
			this.grpPlanDetails.Controls.Add(this.txtMonthlyFee);
			this.grpPlanDetails.Controls.Add(this.chkIsActive);
			this.grpPlanDetails.Controls.Add(this.lblDescription);
			this.grpPlanDetails.Controls.Add(this.txtDescription);
			this.grpPlanDetails.Controls.Add(this.txtMemberShip);
			this.grpPlanDetails.Controls.Add(this.lblMemberShip);
			this.grpPlanDetails.Location = new System.Drawing.Point(12, 12);
			this.grpPlanDetails.Name = "grpPlanDetails";
			this.grpPlanDetails.Size = new System.Drawing.Size(759, 120);
			this.grpPlanDetails.TabIndex = 0;
			this.grpPlanDetails.TabStop = false;
			this.grpPlanDetails.Text = "MemberShipPlan Details";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(270, 88);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 14;
			this.btnReset.Text = "&Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(183, 88);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 13;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lblAnnualFee
			// 
			this.lblAnnualFee.AutoSize = true;
			this.lblAnnualFee.Location = new System.Drawing.Point(267, 43);
			this.lblAnnualFee.Name = "lblAnnualFee";
			this.lblAnnualFee.Size = new System.Drawing.Size(47, 13);
			this.lblAnnualFee.TabIndex = 7;
			this.lblAnnualFee.Text = "Annually";
			// 
			// lblHalfYearlyFee
			// 
			this.lblHalfYearlyFee.AutoSize = true;
			this.lblHalfYearlyFee.Location = new System.Drawing.Point(180, 43);
			this.lblHalfYearlyFee.Name = "lblHalfYearlyFee";
			this.lblHalfYearlyFee.Size = new System.Drawing.Size(72, 13);
			this.lblHalfYearlyFee.TabIndex = 6;
			this.lblHalfYearlyFee.Text = "Semi annually";
			// 
			// lblQuarterlyFee
			// 
			this.lblQuarterlyFee.AutoSize = true;
			this.lblQuarterlyFee.Location = new System.Drawing.Point(93, 43);
			this.lblQuarterlyFee.Name = "lblQuarterlyFee";
			this.lblQuarterlyFee.Size = new System.Drawing.Size(49, 13);
			this.lblQuarterlyFee.TabIndex = 5;
			this.lblQuarterlyFee.Text = "Quarterly";
			// 
			// lblMonthlyFee
			// 
			this.lblMonthlyFee.AutoSize = true;
			this.lblMonthlyFee.Location = new System.Drawing.Point(9, 43);
			this.lblMonthlyFee.Name = "lblMonthlyFee";
			this.lblMonthlyFee.Size = new System.Drawing.Size(44, 13);
			this.lblMonthlyFee.TabIndex = 4;
			this.lblMonthlyFee.Text = "Monthly";
			// 
			// txtAnnualFee
			// 
			this.txtAnnualFee.Location = new System.Drawing.Point(270, 62);
			this.txtAnnualFee.Name = "txtAnnualFee";
			this.txtAnnualFee.Size = new System.Drawing.Size(81, 20);
			this.txtAnnualFee.TabIndex = 11;
			// 
			// txtHalfYearlyFee
			// 
			this.txtHalfYearlyFee.Location = new System.Drawing.Point(183, 62);
			this.txtHalfYearlyFee.Name = "txtHalfYearlyFee";
			this.txtHalfYearlyFee.Size = new System.Drawing.Size(81, 20);
			this.txtHalfYearlyFee.TabIndex = 10;
			// 
			// txtQuarterlyFee
			// 
			this.txtQuarterlyFee.Location = new System.Drawing.Point(96, 62);
			this.txtQuarterlyFee.Name = "txtQuarterlyFee";
			this.txtQuarterlyFee.Size = new System.Drawing.Size(81, 20);
			this.txtQuarterlyFee.TabIndex = 9;
			// 
			// txtMonthlyFee
			// 
			this.txtMonthlyFee.Location = new System.Drawing.Point(9, 62);
			this.txtMonthlyFee.Name = "txtMonthlyFee";
			this.txtMonthlyFee.Size = new System.Drawing.Size(81, 20);
			this.txtMonthlyFee.TabIndex = 8;
			// 
			// chkIsActive
			// 
			this.chkIsActive.AutoSize = true;
			this.chkIsActive.Location = new System.Drawing.Point(12, 92);
			this.chkIsActive.Name = "chkIsActive";
			this.chkIsActive.Size = new System.Drawing.Size(64, 17);
			this.chkIsActive.TabIndex = 12;
			this.chkIsActive.Text = "IsActive";
			this.chkIsActive.UseVisualStyleBackColor = true;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(354, 22);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(60, 13);
			this.lblDescription.TabIndex = 2;
			this.lblDescription.Text = "Description";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Location = new System.Drawing.Point(420, 18);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescription.Size = new System.Drawing.Size(333, 91);
			this.txtDescription.TabIndex = 3;
			this.txtDescription.WordWrap = false;
			// 
			// txtMemberShip
			// 
			this.txtMemberShip.Location = new System.Drawing.Point(88, 18);
			this.txtMemberShip.Name = "txtMemberShip";
			this.txtMemberShip.Size = new System.Drawing.Size(263, 20);
			this.txtMemberShip.TabIndex = 1;
			// 
			// lblMemberShip
			// 
			this.lblMemberShip.AutoSize = true;
			this.lblMemberShip.Location = new System.Drawing.Point(6, 22);
			this.lblMemberShip.Name = "lblMemberShip";
			this.lblMemberShip.Size = new System.Drawing.Size(66, 13);
			this.lblMemberShip.TabIndex = 0;
			this.lblMemberShip.Text = "MemberShip";
			// 
			// dgvMemberShipPlan
			// 
			this.dgvMemberShipPlan.AllowUserToAddRows = false;
			this.dgvMemberShipPlan.AllowUserToDeleteRows = false;
			this.dgvMemberShipPlan.AllowUserToOrderColumns = true;
			this.dgvMemberShipPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvMemberShipPlan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.dgvMemberShipPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMemberShipPlan.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvMemberShipPlan.Location = new System.Drawing.Point(12, 139);
			this.dgvMemberShipPlan.Name = "dgvMemberShipPlan";
			this.dgvMemberShipPlan.Size = new System.Drawing.Size(759, 207);
			this.dgvMemberShipPlan.TabIndex = 1;
			this.dgvMemberShipPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMemberShipPlan_CellClick);
			// 
			// frmMemberShipPlan
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 362);
			this.Controls.Add(this.dgvMemberShipPlan);
			this.Controls.Add(this.grpPlanDetails);
			this.Name = "frmMemberShipPlan";
			this.Text = "MemberShipPlan";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMemberShipPlan_FormClosing);
			this.grpPlanDetails.ResumeLayout(false);
			this.grpPlanDetails.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvMemberShipPlan)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpPlanDetails;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.TextBox txtMemberShip;
		private System.Windows.Forms.Label lblMemberShip;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TextBox txtAnnualFee;
		private System.Windows.Forms.TextBox txtHalfYearlyFee;
		private System.Windows.Forms.TextBox txtQuarterlyFee;
		private System.Windows.Forms.TextBox txtMonthlyFee;
		private System.Windows.Forms.CheckBox chkIsActive;
		private System.Windows.Forms.Label lblAnnualFee;
		private System.Windows.Forms.Label lblHalfYearlyFee;
		private System.Windows.Forms.Label lblQuarterlyFee;
		private System.Windows.Forms.Label lblMonthlyFee;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.DataGridView dgvMemberShipPlan;
	}
}