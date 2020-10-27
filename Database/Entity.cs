using System.Collections.Generic;

namespace Database
{
	public class Entity
	{
		public readonly string TableName;
		public readonly Dictionary<string, object> Values = new Dictionary<string, object>();
		//public Dictionary<string, object> Extra;

		internal Entity(string tableName)
		{
			TableName = tableName;
		}

		public string[] GetInfo() => EntityInfo.EntityKeys[TableName];

		// static Entity()
		// {
		// 	Initializer.InitEntityInfo();
		// }
	}
}