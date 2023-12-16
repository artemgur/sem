using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
	public static class Comments
	{
		public static async Task<Dictionary<bool, List<Entity>>> Get(Entity debate)
		{
			return (await debate.GetOneToManyChildren("debate_id", "comments").ToListAsync()).GroupBy(x => (bool) x["opinion"])
				.Select(x => x.OrderBy(x => (DateTime)x["date"]).ToList()).ToDictionary(x => (bool)x[0]["opinion"], x => x);
		}


		public static async Task Save(int id, string debateId, string text, string opinion)
		{
			var entity = new Entity("comments")
			{
				["debate_id"] = debateId,
				["text"] = text,
				["user_id"] = id,
				["opinion"] = opinion,
				["date"] = DateTime.UtcNow
			};
			await entity.Insert();
		}
	}
}