namespace ClubManager.Model
{
	/// <summary>
	/// Member Ship Plan
	/// </summary>
	public class MemberShipPlan
	{
		#region Properties

		/// <summary>
		/// Name of MemberShip e.g. Gold, Platinum
		/// </summary>
		public string MemberShip { get; set; }

		/// <summary>
		/// A brief description of the plan
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Fee of the plan if paid monthly.
		/// </summary>
		public double MonthlyFee { get; set; }

		/// <summary>
		/// Fee of the plan if paid quarterly.
		/// </summary>
		public double QuarterlyFee { get; set; }

		/// <summary>
		/// Fee of the plan if paid half yearly.
		/// </summary>
		public double HalfYearlyFee { get; set; }

		/// <summary>
		/// Fee of the plan if paid annually.
		/// </summary>
		public double AnnualFee { get; set; }

		/// <summary>
		/// MemberShip Plan ID
		/// </summary>
		public string _id { get; set; }

		/// <summary>
		/// If plan is active or not.
		/// </summary>
		public bool IsActive { get; set; }

		#endregion Properties

		#region Overridden Methods

		/// <summary>
		/// String representation of the Member Ship Plan
		/// </summary>
		/// <returns>Name of the Plan</returns>
		public override string ToString()
		{
			return this.MemberShip;
		}

		#endregion Overridden Methods
	}
}