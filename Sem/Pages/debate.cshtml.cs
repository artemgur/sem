using System.Collections.Generic;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sem.Pages
{
	public class debate : PageModel
	{
		public Entity Debate;

		public Dictionary<bool, List<Entity>> Comments;
		
		public async Task<IActionResult> OnGet(string debateId)
		{
			Debate = await Debates.GetById(int.Parse(debateId));
			Comments = await Database.Comments.Get(Debate);
			return null;
		}
	}
}