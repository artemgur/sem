using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;

namespace Database
{
	public static class General
	{
		private static string connectionString;// = @"Server=127.0.0.1;Port=5432;Database=filmography;User Id=postgres;Password=postgres;";//Filmography for test

		//Select with optional condition, offset and rows number
		public static IEnumerable<Entity> Select(string tableName, string condition = null, int offset = 0, int number = -1)
		{
			//TODO check if condition valid
			var info = EntityInfo.EntityKeys[tableName];
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
					foreach (var key in info)
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
				valuesBuilder.Append(pair.Value.ToStringPg());
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

		public static Entity GetForeignEntity(Entity entity, string foreignKey, string foreignTable) =>
			Select(foreignTable, "id=" + entity.Values[foreignKey].ToStringPg()).Single();

		public static IEnumerable<Entity> GetManyToManyEntities(Entity entity, string manyToManyTable)
		{
			var relationship = ManyToManyRelationship.Relationships[manyToManyTable];
			var otherTable = relationship.ForeignKeys.Keys.Single(x => x != entity.TableName);
			var otherIds = Select(manyToManyTable,
				relationship.ForeignKeys[entity.TableName] + "=" + entity.Values["id"]).Select(x => x.Values[relationship.ForeignKeys[otherTable]]);
			return Select(otherTable, "id IN " + otherIds.ToStringListPg());
		}
	}
}