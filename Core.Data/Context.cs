using System.Collections.Generic;
using Core.Configuration;
using System.Xml.Linq;
using System.Reflection;
namespace Core.Data
{
	public abstract class Context
	{
		#region Data Properties
		/// <summary>
		/// Hostname of Database
		/// </summary>
		protected static string Host { get; set; }
		/// <summary>
		/// Port of Database
		/// </summary>
		protected static int Port { get; set; }
		/// <summary>
		/// Authentication true or false
		/// </summary>
		protected static bool Auth { get; set; }
		/// <summary>
		/// Username for database authentication
		/// </summary>
		protected static string Username { get; set; }
		/// <summary>
		/// Password to be used for authentication
		/// </summary>
		protected static string Password { get; set; }
		/// <summary>
		/// Name of the database
		/// </summary>
		protected static string DBName { get; set; }
		/// <summary>
		/// Prefix to be added to table names
		/// </summary>
		protected static string Prefix { get; set; }
		/// <summary>
		/// Suffix to be added to table names
		/// </summary>
		protected static string Suffix { get; set; }

		/// <summary>
		/// Type of database we are using
		/// </summary>
		protected static string Type { get; set; }
		/// <summary>
		/// Name of the config table without Prefix/Suffix
		/// </summary>
		protected static string ConfigTable { get; set; }
		#endregion Data Properties

		#region XML Configuration Keys
		/// <summary>
		/// Key for Database settings in XML Node
		/// </summary>
		private static string DB_KEY = "DB";

		/// <summary>
		/// Key to get Hostname from XML node
		/// </summary>
		private static string DB_HOST = "Host";
		/// <summary>
		/// Key to get Port from XML node
		/// </summary>
		private static string DB_PORT = "Port";
		/// <summary>
		/// Key to get Authentication settings from XML node
		/// </summary>
		private static string DB_AUTH = "Auth";
		/// <summary>
		/// Key to get Username from XML node
		/// </summary>
		private static string DB_USERNAME = "Username";
		/// <summary>
		/// Key to get Password from XML node
		/// </summary>
		private static string DB_PASSWORD = "Password";
		/// <summary>
		/// Key to get Database Name from XML node
		/// </summary>
		private static string DB_DBNAME = "DBName";
		/// <summary>
		/// Key to get Prefix from XML node
		/// </summary>
		private static string DB_PREFIX = "Prefix";
		/// <summary>
		/// Key to get Suffix from XML node
		/// </summary>
		private static string DB_SUFFIX = "Suffix";

		/// <summary>
		/// Key to get Database Type from XML node
		/// </summary>
		private static string DB_TYPE = "Type";
		/// <summary>
		/// Key to get Name of Configuration Table from XML node
		/// </summary>
		private static string DB_CONFIGTABLE = "ConfigTable";
		#endregion XML Configuration Keys

		#region Private Properties
		private static string AssemblyName
		{
			get
			{
				return string.Format("Core.Data.{0}.dll", Type);
			}
		}
		private static string ClassName
		{
			get
			{
				return string.Format("Core.Data.{0}.{0}", Type);
			}
		}
		#endregion Private Properties

		#region Abstract Methods
		public abstract List<T> ListAll<T>(string table);
		public abstract void AddNew<T>(T record, string table);
		public abstract void Save<T>(T record, string table);
		public abstract List<T> Where<T>(string query, string table);
		#endregion Abstract Methods

		#region Context Object
		public static Context DB = null;
		#endregion Context Object

		#region Constructors
		static Context()
		{
			XElement ele = ConfigurationManager.ConfigValue[DB_KEY];
			Host = ele.Element(DB_HOST).Value;
			Port = ele.Element(DB_PORT).Value.ToInt32();
			Auth = ele.Element(DB_AUTH).Value.ToBoolean();
			Username = ele.Element(DB_USERNAME).Value;
			Password = ele.Element(DB_PASSWORD).Value;
			DBName = ele.Element(DB_DBNAME).Value;
			Prefix = ele.Element(DB_PREFIX).Value;
			Suffix = ele.Element(DB_SUFFIX).Value;
			Type = ele.Element(DB_TYPE).Value;
			ConfigTable = ele.Element(DB_CONFIGTABLE).Value;

			DB = (Context)Assembly.LoadFrom(AssemblyName).CreateInstance(ClassName);
		}
		#endregion Constructors

		#region Protected Members
		protected static string GetTableName(string table)
		{
			return Prefix + table + Suffix;
		}
		#endregion Protected Members
	}
}