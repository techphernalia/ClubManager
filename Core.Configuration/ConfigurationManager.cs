using System.Collections.Generic;
using System.Xml.Linq;

namespace Core.Configuration
{
	/// <summary>
	/// Configuration Manager to retrieve XML Configurations
	/// </summary>
	public class ConfigurationManager
	{
		#region Configuration Values
		/// <summary>
		/// XML Configuration nodes mapped against node key
		/// </summary>
		public static Dictionary<string, XElement> ConfigValue = new Dictionary<string, XElement>();
		#endregion Configuration Values

		#region XML Configuration Keys
		/// <summary>
		/// Key to be searched in App.Config/Web.Config
		/// </summary>
		private static string APP_CONFIG = "AppConfig";

		#endregion XML Configuration Keys

		#region Constructors
		/// <summary>
		/// Static Initializer which is invoked automatically as required
		/// </summary>
		static ConfigurationManager()
		{
			XDocument XDoc = XDocument.Load(System.Configuration.ConfigurationManager.AppSettings[APP_CONFIG]);

			foreach (XElement ele in XDoc.Root.Elements())
				ConfigValue.Add(ele.Name.LocalName, ele);
		}

		#endregion Constructors
	}
}