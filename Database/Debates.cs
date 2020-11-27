using System.Collections.Generic;
using static Database.General;

namespace Database
{
	public class Debates
	{
		public static IAsyncEnumerable<Entity> GetUserDebates(Entity user)
			=> user.GetManyToManyEntities("debates_users");
		
		public static IAsyncEnumerable<Entity> Get(int offset = 0, int number = -1) =>
			Select("debates", offset, number);
	}
}