using System;
using System.Xml.Linq;
using Core.Configuration;

namespace ClubManager.Model
{
	public class Member
	{
		#region XML Keys
		public static string MEMBER_PROPERTY_KEY = "MemberProperty";
		public static string MEMBER_PROPERTY = "Property{0}";
		#endregion XML Keys

		#region Property Names
		public static string[] PropertyNames = new string[] { null, null, null, null, null, null, null, null };
		#endregion Property Names

		#region Constructors

		static Member()
		{
			XElement ele = ConfigurationManager.ConfigValue[MEMBER_PROPERTY_KEY];
			for (int i = 1; i <= 8; i++)
			{
				if (ele.Element(string.Format(MEMBER_PROPERTY, i.ToString())) != null)
				{
					PropertyNames[i - 1] = ele.Element(string.Format(MEMBER_PROPERTY, i.ToString())).Value;
				}
			}
		}

		#endregion Constructors

		#region Basic Details of Member

		/// <summary>
		/// Name of the member
		/// </summary>
		public string MemberName { get; set; }

		/// <summary>
		/// Contact number of the member
		/// </summary>
		public string ContactNo { get; set; }

		/// <summary>
		/// EmailID of the member
		/// </summary>
		public string EmailID { get; set; }

		/// <summary>
		/// Address of the member
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// ZIP/PIN code of the member
		/// </summary>
		public string ZIPCode { get; set; }

		/// <summary>
		/// Date of birth of member
		/// </summary>
		public DateTime DateOfBirth { get; set; }

		#endregion Basic Details of Member

		#region MemberShipDetail

		/// <summary>
		/// MemberShipPlan opted by member
		/// </summary>
		public string MemberShipPlan { get; set; }

		/// <summary>
		/// Joining date of member
		/// </summary>
		public DateTime DateOfJoining { get; set; }

		/// <summary>
		/// Next payment is due on
		/// </summary>
		public DateTime PaymentDueDate { get; set; }

		/// <summary>
		/// Fee was last paid on
		/// </summary>
		public DateTime LastFeePaidOn { get; set; }

		/// <summary>
		/// Balance amount if any
		/// </summary>
		public double BalanceAmount { get; set; }
		#endregion MemberShipDetail

		#region Other Information

		/// <summary>
		/// Member ID
		/// </summary>
		public string _id { get; set; }

		/// <summary>
		/// If Member is active or not.
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// Some information specific to this user
		/// </summary>
		public string Comment { get; set; }

		/// <summary>
		/// Location of User's Profile Picture
		/// </summary>
		public string ProfilePictureLocation { get; set; }
		#endregion Other Information

		#region Club Properties

		/// <summary>
		/// Property1 response of the Member
		/// </summary>
		public string Property1 { get; set; }

		/// <summary>
		/// Property2 response of the Member
		/// </summary>
		public string Property2 { get; set; }

		/// <summary>
		/// Property3 response of the Member
		/// </summary>
		public string Property3 { get; set; }

		/// <summary>
		/// Property4 response of the Member
		/// </summary>
		public string Property4 { get; set; }

		/// <summary>
		/// Property5 response of the Member
		/// </summary>
		public string Property5 { get; set; }

		/// <summary>
		/// Property6 response of the Member
		/// </summary>
		public string Property6 { get; set; }

		/// <summary>
		/// Property7 response of the Member
		/// </summary>
		public string Property7 { get; set; }

		/// <summary>
		/// Property8 response of the Member
		/// </summary>
		public string Property8 { get; set; }
		#endregion Club Properties

		#region Overridden Methods

		/// <summary>
		/// String representation of the Member
		/// </summary>
		/// <returns>Name of the Member</returns>
		public override string ToString()
		{
			return this.MemberName;
		}

		#endregion Overridden Methods
	}
}