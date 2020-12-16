using System;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Database
{
	public class RememberedGuids
	{
		public static async Task Add(Guid guid, int id)
		{
			var entity = new Entity("remembered_guids")
			{
				["guid"] = guid,
				["user_id"] = id
			};
			await entity.Insert();
		}

		public static async Task Remove(Guid guid)
		{
			await using var connection = new NpgsqlConnection(General.connectionString);
			await connection.OpenAsync();
			await using var command = new NpgsqlCommand($"DELETE FROM remembered_guids WHERE guid='{guid.ToString()}'", connection);
			await command.ExecuteNonQueryAsync();
		}

		public static async Task<int> GetIdOr0(Guid guid)
		{
			var e = await General.SelectByValue("remembered_guids", "guid", guid).FirstOrDefaultAsync();
			return (int?) e?["user_id"] ?? 0;
		}
	}
}