namespace ClubManager
{
	partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.memberShipPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memberShipPlanToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(632, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "MenuStrip";
			// 
			// memberShipPlanToolStripMenuItem
			// 
			this.memberShipPlanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlanToolStripMenuItem});
			this.memberShipPlanToolStripMenuItem.Name = "memberShipPlanToolStripMenuItem";
			this.memberShipPlanToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
			this.memberShipPlanToolStripMenuItem.Text = "Membership Plan";
			// 
			// newPlanToolStripMenuItem
			// 
			this.newPlanToolStripMenuItem.Name = "newPlanToolStripMenuItem";
			this.newPlanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newPlanToolStripMenuItem.Text = "New Plan";
			this.newPlanToolStripMenuItem.Click += new System.EventHandler(this.newPlanToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 431);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(632, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "StatusStrip";
			// 
			// toolStripStatusLabel
			// 
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
			this.toolStripStatusLabel.Text = "Status";
			// 
			// toolStrip
			// 
			this.toolStrip.Location = new System.Drawing.Point(0, 24);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(632, 25);
			this.toolStrip.TabIndex = 1;
			this.toolStrip.Text = "ToolStrip";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 453);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.toolStrip);
			this.Controls.Add(this.menuStrip);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip;
			this.Name = "frmMain";
			this.Text = "frmMain";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.ToolStripMenuItem memberShipPlanToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newPlanToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip;
	}
}



