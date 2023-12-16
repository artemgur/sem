using System.Collections.Generic;

namespace Database
{
	public class Entity// : DynamicObject
	{
		public readonly string TableName;
		internal readonly Dictionary<string, object> Values = new Dictionary<string, object>();

		internal Entity(string tableName)
		{
			//Utilities.CheckIfTableNameValid(tableName);
			TableName = tableName;
		}

		// public Entity(Entity entity)
		// {
		// 	TableName = entity.TableName;
		// }

		//Not sure if we need dynamic, will leave it here for now
		// public override bool TryGetMember(GetMemberBinder binder, out object result)
		// {
		// 	return Values.TryGetValue(binder.Name.ToLower(), out result);
		// }
		//
		// public override bool TrySetMember(SetMemberBinder binder, object value)
		// {
		// 	Values[binder.Name.ToLower()] = value;
		// 	return true;
		// }

		//public string[] GetInfo() => EntityInfo.EntityKeys[TableName];

		// static Entity()
		// {
		// 	Initializer.InitEntityInfo();
		// }

		public object this[string index]
		{
			get => Values[index];
			internal set => Values[index] = value;
		}
	}
}