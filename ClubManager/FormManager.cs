namespace ClubManager
{
	public class FormManager
	{
		public static frmMemberShipPlan MemberShipPlan = new frmMemberShipPlan();
		public static frmMain Main = new frmMain();

		static FormManager()
		{
			MemberShipPlan.MdiParent = Main;
		}
	}
}