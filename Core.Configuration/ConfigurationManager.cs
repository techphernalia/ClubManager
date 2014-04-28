using System.Collections.Generic;
using System.Xml.Linq;

namespace Core.Configuration
{
	public class ConfigurationManager
	{
		#region Configuration Values
		public static Dictionary<string, XElement> ConfigValue = new Dictionary<string, XElement>();
		#endregion Configuration Values

		#region XML Configuration Keys

		private static string APP_CONFIG = "AppConfig";

		#endregion XML Configuration Keys

		#region Constructors

		static ConfigurationManager()
		{
			XDocument XDoc = XDocument.Load(System.Configuration.ConfigurationManager.AppSettings[APP_CONFIG]);

			foreach (XElement ele in XDoc.Root.Elements())
				ConfigValue.Add(ele.Name.LocalName, ele);
		}

		#endregion Constructors
	}
}