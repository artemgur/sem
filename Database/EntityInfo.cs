using System;
using System.Collections.Generic;
using System.Reflection;

namespace Database
{
	public class EntityInfo
	{
		public static Dictionary<string, EntityInfo> EntityProperties;
		
		//public string TableName;
		public string[] Keys;
		public Type[] Types;

		private EntityInfo(string tableName, string[] keys, Type[] types)
		{
			//TableName = tableName;
			Keys = keys;
			Types = types;
		}
	}
}