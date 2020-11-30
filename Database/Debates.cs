using System.Collections.Generic;
using System.Threading.Tasks;
using static Database.General;

namespace Database
{
	public class Debates
	{
		public static IAsyncEnumerable<Entity> GetUserDebates(Entity user)
			=> user.GetManyToManyEntities("debates_users");
		
		public static IAsyncEnumerable<Entity> Get(int offset = 0, int number = -1) =>
			Select("debates", offset, number);
		
		public static async Task<Entity> GetById(int id)
			=> await SelectById("debates", id);
		
		public static IAsyncEnumerable<Entity> SearchByName(string name, int offset = 0, int number = -1) =>
			Select("debates_with_tags", $"name LIKE '%{name}%'", offset, number/*, "date"*/);

		public static IAsyncEnumerable<Entity> SearchByNameAndTag(string name, string tag, int offset = 0,
			int number = -1) => Select($"select_debates_by_name_and_tag('%{name}%', '{tag}')", offset, number);
	}
}