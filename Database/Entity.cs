using System.Collections.Generic;

namespace Database
{
	public class Entity
	{
		public readonly string TableName;
		public readonly Dictionary<string, object> Values = new Dictionary<string, object>();

		internal Entity(string tableName)
		{
			TableName = tableName;
		}

		public EntityInfo GetInfo() => EntityInfo.EntityProperties[TableName];

		static Entity()
		{
			//TODO Init EntityInfo
		}
	}
}