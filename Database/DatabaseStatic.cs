using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace Database
{
	public static class DatabaseStatic
	{
		private static string connectionString;//TODO set value

		//Select with optional condition, offset and rows number
		public static IEnumerable<Entity> Select(string tableName, string condition = null, int offset = 0, int number = -1)
		{
			//TODO check if condition valid
			var info = EntityInfo.EntityProperties[tableName];
			//var query =  + tableName;
			var builder = new StringBuilder("SELECT * FROM ");
			builder.Append(tableName);
			if (condition != null)
			{
				builder.Append(" WHERE ");
				builder.Append(condition);
				//query += "WHERE " + condition;
			}
			if (offset != 0)
			{
				builder.Append(" OFFSET ");
				builder.Append(offset);
				builder.Append(" ROWS");
			}
			if (number != -1)
			{
				builder.Append(" FETCH FIRST ");
				builder.Append(number);
				builder.Append(" ROWS ONLY");
			}
			using var connection = new NpgsqlConnection(connectionString);
			using var command = new NpgsqlCommand(builder.ToString());
			using var reader = command.ExecuteReader();
			if (reader.HasRows)
				while (reader.Read())
				{
					var instance = new Entity(tableName);
					foreach (var key in info.Keys)
						instance.Values[key] = reader[key];
					yield return instance;
				}
		}

		//Select without condition, but with offset and rows number
		public static IEnumerable<Entity> Select(string tableName, int offset, int number)
		{
			return Select(tableName, null, offset, number);
		}

		//Inserts entity to table
		public static void Insert(Entity entity)
		{
			var builder = new StringBuilder("INSERT INTO ");
			builder.Append(entity.TableName);
			builder.Append(" (");
			var valuesBuilder = new StringBuilder(" VALUES (");
			foreach (var pair in entity.Values)
			{
				builder.Append(pair.Key);
				builder.Append(", ");
				valuesBuilder.Append(pair.Value);
				valuesBuilder.Append(", ");
			}
			builder.Remove(builder.Length - 2, 2);
			valuesBuilder.Remove(valuesBuilder.Length - 2, 2);
			builder.Append(')');
			valuesBuilder.Append(')');
			builder.Append(valuesBuilder);
			var query = builder.ToString();
			using var connection = new NpgsqlConnection(connectionString);
			using var command = new NpgsqlCommand(query);
			command.ExecuteNonQuery();
		}
	}
}