using System;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Core.Data.Mongo
{
	public class Mongo : Context
	{
		#region Private Objects
		private static MongoDatabase _DB = null;
		#endregion

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
		#endregion Context Implementation
	}
}
