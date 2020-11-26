using System.Collections.Generic;

namespace Database
{
	public class Debates
	{
		public static IAsyncEnumerable<Entity> GetUserDebates(Entity user)
			=> user.GetManyToManyEntities("debates_users");

	}
}