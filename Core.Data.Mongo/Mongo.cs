using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Core.Data.Mongo
{
	public class Mongo : Context
	{
		#region Private Objects
		private static MongoDatabase _DB = null;
		#endregion Private Objects

		#region Constructors

		static Mongo()
		{
			_DB = new MongoServer
			(
				new MongoServerSettings
				{
					Server = new MongoServerAddress(Host, Port)
				}
			).GetDatabase(DBName);
		}

		#endregion Constructors

		#region Context Implementation

		public override List<T> ListAll<T>(string table)
		{
			return _DB.GetCollection<T>(GetTableName(table)).FindAllAs<T>().ToList();
		}

		public override void AddNew<T>(T record, string table)
		{
			_DB.GetCollection(GetTableName(table)).Insert<T>(record);
		}

		public override void Save<T>(T record, string table)
		{
			_DB.GetCollection(GetTableName(table)).Save<T>(record);
		}

		public override List<T> Where<T>(string query, string table)
		{
			return _DB.GetCollection(GetTableName(table)).FindAs<T>(Query.Where(query)).ToList();
		}

		public override string GetID(string key)
		{
			return _DB.GetCollection(GetTableName(ConfigTable))
				.FindAndModify(Query.EQ("_id", key), null,
				Update.Inc("Value", 1), true, true).ModifiedDocument.GetElement("Value").Value.ToString();
		}

		#endregion Context Implementation
	}
}